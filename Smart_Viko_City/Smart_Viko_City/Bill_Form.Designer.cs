namespace Smart_Viko_City
{
    partial class Bill_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill_Form));
            this.textBox_billMoney = new System.Windows.Forms.TextBox();
            this.textBox_billKWh = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_billMoney
            // 
            this.textBox_billMoney.Location = new System.Drawing.Point(212, 30);
            this.textBox_billMoney.Name = "textBox_billMoney";
            this.textBox_billMoney.Size = new System.Drawing.Size(72, 20);
            this.textBox_billMoney.TabIndex = 0;
            // 
            // textBox_billKWh
            // 
            this.textBox_billKWh.Location = new System.Drawing.Point(212, 56);
            this.textBox_billKWh.Name = "textBox_billKWh";
            this.textBox_billKWh.Size = new System.Drawing.Size(72, 20);
            this.textBox_billKWh.TabIndex = 1;
            // 
            // Bill_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(296, 488);
            this.Controls.Add(this.textBox_billKWh);
            this.Controls.Add(this.textBox_billMoney);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Bill_Form";
            this.Text = "Bill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_billMoney;
        private System.Windows.Forms.TextBox textBox_billKWh;
    }
}