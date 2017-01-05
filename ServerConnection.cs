using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace SocietySim
{

    public enum Command
    {
        Attack,
        Info,
        NewConnection,
        ChangeName,
    }

    public partial class ServerConnection : Form
    {

        private const int port                      = 21989;
        public  ManualResetEvent connectDone        = new ManualResetEvent(false);
        public  ManualResetEvent sendDone           = new ManualResetEvent(false);
        public  ManualResetEvent receiveDone        = new ManualResetEvent(false);
        public Socket conn;

        public delegate void DataReceivedDelegate(String data);
        public DataReceivedDelegate drd;
        private bool connectionFailed = false;

        public byte[] EOF = Encoding.UTF8.GetBytes("<EOF>");

        private static string response = String.Empty;
        public ServerConnection()
        {
            InitializeComponent();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connectionFailed = false;
                String ip           = textBox1.Text;              

                conn                = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipe      = new IPEndPoint(IPAddress.Parse(ip),port);

                conn.BeginConnect(ipe, new AsyncCallback(connectCallback), conn);
                connectDone.WaitOne();

                if (connectionFailed)
                {
                    throw new Exception("Connection Failed");
                }
                this.DialogResult = DialogResult.OK;

                byte[]frame         = new byte[] {(byte)(char)Command.NewConnection}.Concat(EOF).ToArray();
                Send(frame);

                string playname = this.countryName.Text.Replace("<EOF>","").Replace(",","");

                byte[] nameFrame    = new byte[] {(byte)(char)Command.ChangeName}; ;
                nameFrame           = nameFrame.Concat(Encoding.UTF8.GetBytes(playname)).ToArray();
                nameFrame           = nameFrame.Concat(EOF).ToArray();

                Send(nameFrame);

                //Receive(conn);
                this.Close();

            }
            catch(Exception ex)
            {

                MessageBox.Show("Unable to connect to server: " +ex.ToString());
            }
          
        }


        public void Send(byte[] bytes)
        {
            conn.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(sendCallback), conn);
            sendDone.WaitOne();

        }
        public void Send( String data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            conn.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(sendCallback), conn);
            sendDone.WaitOne();

        }

        public void Receive(Socket client)
        {

            try
            {
                StateObject state   = new StateObject();
                state.workSocket    = client;

                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(receiveCallback), state);
                receiveDone.WaitOne();

            }
            catch (Exception e)
            {


            }


        }


        private void sendCallback(IAsyncResult ar)
        {

            try
            {
                Socket client = (Socket) ar.AsyncState;

                int bytesSent = client.EndSend(ar);

                sendDone.Set();


            }
            catch(Exception e)
            {
               

            }


            
        }

        private void receiveCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject) ar.AsyncState;
                Socket client = state.workSocket;

                int bytesRead = client.EndReceive(ar);

                if(bytesRead > 0 )
                {
                    
                    // state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                    response = Encoding.UTF8.GetString(state.buffer, 0, bytesRead);
                    //client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(receiveCallback), state);
                    Console.WriteLine(response);
                    receiveDone.Set();

                    drd.Invoke(response.Replace("<EOF>", ""));
                    

                }
                else
                {
                    if(state.sb.Length >= 1)
                    {
                        response = state.sb.ToString();
                        Console.WriteLine(response);
                    }
                    receiveDone.Set();
                }

            }
            catch(Exception e)
            {

            }

        }


        private void connectCallback(IAsyncResult ar)
        {

            try
            {
                Socket client = (Socket) ar.AsyncState;
                client.EndConnect(ar);
            }
            catch(Exception e)
            {
                connectionFailed = true;
            }
                connectDone.Set();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    public class StateObject
    {

        public Socket workSocket        = null;
        public const int BufferSize     = 256;
        public byte[] buffer            = new byte[BufferSize];
        public StringBuilder sb         = new StringBuilder();

    }

}
