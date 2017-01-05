namespace SocietySim
{
    partial class StatChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1yr = new System.Windows.Forms.CheckBox();
            this.checkBox10yr = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackSecondaryColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            series1.ShadowColor = System.Drawing.Color.Silver;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(478, 245);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 2000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Population",
            "Balance (Treasury)",
            "Baseline",
            "Inflation",
            "GDPPP",
            "Money in Circulation",
            "Worker Happiness"});
            this.comboBox1.Location = new System.Drawing.Point(12, 272);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox1yr
            // 
            this.checkBox1yr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1yr.AutoSize = true;
            this.checkBox1yr.Location = new System.Drawing.Point(445, 276);
            this.checkBox1yr.Name = "checkBox1yr";
            this.checkBox1yr.Size = new System.Drawing.Size(45, 17);
            this.checkBox1yr.TabIndex = 2;
            this.checkBox1yr.Text = "1 Yr";
            this.checkBox1yr.UseVisualStyleBackColor = true;
            // 
            // checkBox10yr
            // 
            this.checkBox10yr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox10yr.AutoSize = true;
            this.checkBox10yr.Location = new System.Drawing.Point(361, 276);
            this.checkBox10yr.Name = "checkBox10yr";
            this.checkBox10yr.Size = new System.Drawing.Size(51, 17);
            this.checkBox10yr.TabIndex = 2;
            this.checkBox10yr.Text = "10 Yr";
            this.checkBox10yr.UseVisualStyleBackColor = true;
            // 
            // StatChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(502, 305);
            this.Controls.Add(this.checkBox10yr);
            this.Controls.Add(this.checkBox1yr);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chart1);
            this.Name = "StatChart";
            this.Text = "StatChart";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1yr;
        private System.Windows.Forms.CheckBox checkBox10yr;
    }
}