namespace SocietySim
{
    partial class Treasury
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
            this.button_spendDefence = new System.Windows.Forms.Button();
            this.button_spendEdu = new System.Windows.Forms.Button();
            this.button_spendHealth = new System.Windows.Forms.Button();
            this.button_spendRoads = new System.Windows.Forms.Button();
            this.button_spendWelfare = new System.Windows.Forms.Button();
            this.button_spendInnovation = new System.Windows.Forms.Button();
            this.AmountDefence = new System.Windows.Forms.NumericUpDown();
            this.AmountEducation = new System.Windows.Forms.NumericUpDown();
            this.AmountHealth = new System.Windows.Forms.NumericUpDown();
            this.AmountRoads = new System.Windows.Forms.NumericUpDown();
            this.AmountWelfare = new System.Windows.Forms.NumericUpDown();
            this.AmountInnovation = new System.Windows.Forms.NumericUpDown();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AmountDefence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountEducation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountRoads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountWelfare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountInnovation)).BeginInit();
            this.SuspendLayout();
            // 
            // button_spendDefence
            // 
            this.button_spendDefence.Location = new System.Drawing.Point(168, 12);
            this.button_spendDefence.Name = "button_spendDefence";
            this.button_spendDefence.Size = new System.Drawing.Size(91, 23);
            this.button_spendDefence.TabIndex = 0;
            this.button_spendDefence.Text = "Spend Defence";
            this.button_spendDefence.UseVisualStyleBackColor = true;
            this.button_spendDefence.Click += new System.EventHandler(this.SpendMoney);
            // 
            // button_spendEdu
            // 
            this.button_spendEdu.Location = new System.Drawing.Point(157, 52);
            this.button_spendEdu.Name = "button_spendEdu";
            this.button_spendEdu.Size = new System.Drawing.Size(102, 23);
            this.button_spendEdu.TabIndex = 0;
            this.button_spendEdu.Text = "Spend Education";
            this.button_spendEdu.UseVisualStyleBackColor = true;
            this.button_spendEdu.Click += new System.EventHandler(this.SpendMoney);
            // 
            // button_spendHealth
            // 
            this.button_spendHealth.Location = new System.Drawing.Point(168, 95);
            this.button_spendHealth.Name = "button_spendHealth";
            this.button_spendHealth.Size = new System.Drawing.Size(91, 23);
            this.button_spendHealth.TabIndex = 0;
            this.button_spendHealth.Text = "Spend Health";
            this.button_spendHealth.UseVisualStyleBackColor = true;
            this.button_spendHealth.Click += new System.EventHandler(this.SpendMoney);
            // 
            // button_spendRoads
            // 
            this.button_spendRoads.Location = new System.Drawing.Point(168, 139);
            this.button_spendRoads.Name = "button_spendRoads";
            this.button_spendRoads.Size = new System.Drawing.Size(91, 23);
            this.button_spendRoads.TabIndex = 0;
            this.button_spendRoads.Text = "Spend Roads";
            this.button_spendRoads.UseVisualStyleBackColor = true;
            this.button_spendRoads.Click += new System.EventHandler(this.SpendMoney);
            // 
            // button_spendWelfare
            // 
            this.button_spendWelfare.Location = new System.Drawing.Point(168, 184);
            this.button_spendWelfare.Name = "button_spendWelfare";
            this.button_spendWelfare.Size = new System.Drawing.Size(91, 23);
            this.button_spendWelfare.TabIndex = 0;
            this.button_spendWelfare.Text = "Spend Welfare";
            this.button_spendWelfare.UseVisualStyleBackColor = true;
            this.button_spendWelfare.Click += new System.EventHandler(this.SpendMoney);
            // 
            // button_spendInnovation
            // 
            this.button_spendInnovation.Location = new System.Drawing.Point(157, 229);
            this.button_spendInnovation.Name = "button_spendInnovation";
            this.button_spendInnovation.Size = new System.Drawing.Size(102, 23);
            this.button_spendInnovation.TabIndex = 0;
            this.button_spendInnovation.Text = "Spend Innovation";
            this.button_spendInnovation.UseVisualStyleBackColor = true;
            this.button_spendInnovation.Click += new System.EventHandler(this.SpendMoney);
            // 
            // AmountDefence
            // 
            this.AmountDefence.DecimalPlaces = 3;
            this.AmountDefence.Location = new System.Drawing.Point(12, 12);
            this.AmountDefence.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.AmountDefence.Name = "AmountDefence";
            this.AmountDefence.Size = new System.Drawing.Size(77, 20);
            this.AmountDefence.TabIndex = 1;
            // 
            // AmountEducation
            // 
            this.AmountEducation.DecimalPlaces = 3;
            this.AmountEducation.Location = new System.Drawing.Point(12, 52);
            this.AmountEducation.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.AmountEducation.Name = "AmountEducation";
            this.AmountEducation.Size = new System.Drawing.Size(77, 20);
            this.AmountEducation.TabIndex = 1;
            // 
            // AmountHealth
            // 
            this.AmountHealth.DecimalPlaces = 3;
            this.AmountHealth.Location = new System.Drawing.Point(12, 95);
            this.AmountHealth.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.AmountHealth.Name = "AmountHealth";
            this.AmountHealth.Size = new System.Drawing.Size(77, 20);
            this.AmountHealth.TabIndex = 1;
            // 
            // AmountRoads
            // 
            this.AmountRoads.DecimalPlaces = 3;
            this.AmountRoads.Location = new System.Drawing.Point(12, 139);
            this.AmountRoads.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.AmountRoads.Name = "AmountRoads";
            this.AmountRoads.Size = new System.Drawing.Size(77, 20);
            this.AmountRoads.TabIndex = 1;
            // 
            // AmountWelfare
            // 
            this.AmountWelfare.DecimalPlaces = 3;
            this.AmountWelfare.Location = new System.Drawing.Point(12, 184);
            this.AmountWelfare.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.AmountWelfare.Name = "AmountWelfare";
            this.AmountWelfare.Size = new System.Drawing.Size(77, 20);
            this.AmountWelfare.TabIndex = 1;
            // 
            // AmountInnovation
            // 
            this.AmountInnovation.DecimalPlaces = 3;
            this.AmountInnovation.Location = new System.Drawing.Point(12, 229);
            this.AmountInnovation.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.AmountInnovation.Name = "AmountInnovation";
            this.AmountInnovation.Size = new System.Drawing.Size(77, 20);
            this.AmountInnovation.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(184, 321);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "Spend All";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "B";
            // 
            // Treasury
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 503);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.AmountInnovation);
            this.Controls.Add(this.AmountWelfare);
            this.Controls.Add(this.AmountRoads);
            this.Controls.Add(this.AmountHealth);
            this.Controls.Add(this.AmountEducation);
            this.Controls.Add(this.AmountDefence);
            this.Controls.Add(this.button_spendInnovation);
            this.Controls.Add(this.button_spendWelfare);
            this.Controls.Add(this.button_spendRoads);
            this.Controls.Add(this.button_spendHealth);
            this.Controls.Add(this.button_spendEdu);
            this.Controls.Add(this.button_spendDefence);
            this.Name = "Treasury";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Treasury Spending";
            ((System.ComponentModel.ISupportInitialize)(this.AmountDefence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountEducation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountRoads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountWelfare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountInnovation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_spendDefence;
        private System.Windows.Forms.Button button_spendEdu;
        private System.Windows.Forms.Button button_spendHealth;
        private System.Windows.Forms.Button button_spendRoads;
        private System.Windows.Forms.Button button_spendWelfare;
        private System.Windows.Forms.Button button_spendInnovation;
        private System.Windows.Forms.NumericUpDown AmountDefence;
        private System.Windows.Forms.NumericUpDown AmountEducation;
        private System.Windows.Forms.NumericUpDown AmountHealth;
        private System.Windows.Forms.NumericUpDown AmountRoads;
        private System.Windows.Forms.NumericUpDown AmountWelfare;
        private System.Windows.Forms.NumericUpDown AmountInnovation;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
    }
}