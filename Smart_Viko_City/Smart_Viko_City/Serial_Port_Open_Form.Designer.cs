namespace Smart_Viko_City
{
    partial class Serial_Port_Open_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Serial_Port_Open_Form));
            this.btn_port_open = new System.Windows.Forms.Button();
            this.btn_port_close = new System.Windows.Forms.Button();
            this.label_com = new System.Windows.Forms.Label();
            this.label_baud_rate = new System.Windows.Forms.Label();
            this.label_parity = new System.Windows.Forms.Label();
            this.label_data_bits = new System.Windows.Forms.Label();
            this.label_stop_bit = new System.Windows.Forms.Label();
            this.combo_COM = new System.Windows.Forms.ComboBox();
            this.combo_baud_rate = new System.Windows.Forms.ComboBox();
            this.combo_parity = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_stop_bit = new System.Windows.Forms.ComboBox();
            this.combo_data_bits = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_com_port = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_connection = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_port_open
            // 
            this.btn_port_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_port_open.Location = new System.Drawing.Point(62, 259);
            this.btn_port_open.Name = "btn_port_open";
            this.btn_port_open.Size = new System.Drawing.Size(75, 27);
            this.btn_port_open.TabIndex = 0;
            this.btn_port_open.Text = "Open";
            this.btn_port_open.UseVisualStyleBackColor = true;
            this.btn_port_open.Click += new System.EventHandler(this.btn_port_open_Click);
            // 
            // btn_port_close
            // 
            this.btn_port_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_port_close.Location = new System.Drawing.Point(160, 259);
            this.btn_port_close.Name = "btn_port_close";
            this.btn_port_close.Size = new System.Drawing.Size(79, 27);
            this.btn_port_close.TabIndex = 1;
            this.btn_port_close.Text = "Close";
            this.btn_port_close.UseVisualStyleBackColor = true;
            this.btn_port_close.Click += new System.EventHandler(this.btn_port_close_Click);
            // 
            // label_com
            // 
            this.label_com.AutoSize = true;
            this.label_com.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_com.Location = new System.Drawing.Point(19, 37);
            this.label_com.Name = "label_com";
            this.label_com.Size = new System.Drawing.Size(62, 15);
            this.label_com.TabIndex = 2;
            this.label_com.Text = "COM         ";
            // 
            // label_baud_rate
            // 
            this.label_baud_rate.AutoSize = true;
            this.label_baud_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_baud_rate.Location = new System.Drawing.Point(19, 82);
            this.label_baud_rate.Name = "label_baud_rate";
            this.label_baud_rate.Size = new System.Drawing.Size(65, 15);
            this.label_baud_rate.TabIndex = 3;
            this.label_baud_rate.Text = "Baud Rate";
            // 
            // label_parity
            // 
            this.label_parity.AutoSize = true;
            this.label_parity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_parity.Location = new System.Drawing.Point(19, 125);
            this.label_parity.Name = "label_parity";
            this.label_parity.Size = new System.Drawing.Size(61, 15);
            this.label_parity.TabIndex = 4;
            this.label_parity.Text = "Parity        ";
            // 
            // label_data_bits
            // 
            this.label_data_bits.AutoSize = true;
            this.label_data_bits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_data_bits.Location = new System.Drawing.Point(19, 174);
            this.label_data_bits.Name = "label_data_bits";
            this.label_data_bits.Size = new System.Drawing.Size(56, 15);
            this.label_data_bits.TabIndex = 5;
            this.label_data_bits.Text = "Data Bits";
            // 
            // label_stop_bit
            // 
            this.label_stop_bit.AutoSize = true;
            this.label_stop_bit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_stop_bit.Location = new System.Drawing.Point(19, 227);
            this.label_stop_bit.Name = "label_stop_bit";
            this.label_stop_bit.Size = new System.Drawing.Size(49, 15);
            this.label_stop_bit.TabIndex = 6;
            this.label_stop_bit.Text = "Stop Bit";
            // 
            // combo_COM
            // 
            this.combo_COM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combo_COM.FormattingEnabled = true;
            this.combo_COM.Items.AddRange(new object[] {
            "COM1"});
            this.combo_COM.Location = new System.Drawing.Point(125, 34);
            this.combo_COM.Name = "combo_COM";
            this.combo_COM.Size = new System.Drawing.Size(102, 24);
            this.combo_COM.TabIndex = 7;
            // 
            // combo_baud_rate
            // 
            this.combo_baud_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combo_baud_rate.FormattingEnabled = true;
            this.combo_baud_rate.Items.AddRange(new object[] {
            "19200",
            "9600",
            "4800",
            "2400",
            "1200",
            "600",
            "300"});
            this.combo_baud_rate.Location = new System.Drawing.Point(125, 79);
            this.combo_baud_rate.Name = "combo_baud_rate";
            this.combo_baud_rate.Size = new System.Drawing.Size(102, 24);
            this.combo_baud_rate.TabIndex = 8;
            this.combo_baud_rate.Text = "9600";
            // 
            // combo_parity
            // 
            this.combo_parity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combo_parity.FormattingEnabled = true;
            this.combo_parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.combo_parity.Location = new System.Drawing.Point(126, 122);
            this.combo_parity.Name = "combo_parity";
            this.combo_parity.Size = new System.Drawing.Size(101, 24);
            this.combo_parity.TabIndex = 9;
            this.combo_parity.Text = "None";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_stop_bit);
            this.groupBox1.Controls.Add(this.btn_port_close);
            this.groupBox1.Controls.Add(this.combo_data_bits);
            this.groupBox1.Controls.Add(this.btn_port_open);
            this.groupBox1.Controls.Add(this.label_com);
            this.groupBox1.Controls.Add(this.label_stop_bit);
            this.groupBox1.Controls.Add(this.combo_parity);
            this.groupBox1.Controls.Add(this.label_data_bits);
            this.groupBox1.Controls.Add(this.combo_COM);
            this.groupBox1.Controls.Add(this.combo_baud_rate);
            this.groupBox1.Controls.Add(this.label_baud_rate);
            this.groupBox1.Controls.Add(this.label_parity);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 304);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // combo_stop_bit
            // 
            this.combo_stop_bit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combo_stop_bit.FormattingEnabled = true;
            this.combo_stop_bit.Items.AddRange(new object[] {
            "One",
            "None"});
            this.combo_stop_bit.Location = new System.Drawing.Point(126, 218);
            this.combo_stop_bit.Name = "combo_stop_bit";
            this.combo_stop_bit.Size = new System.Drawing.Size(102, 24);
            this.combo_stop_bit.TabIndex = 11;
            this.combo_stop_bit.Text = "One";
            // 
            // combo_data_bits
            // 
            this.combo_data_bits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.combo_data_bits.FormattingEnabled = true;
            this.combo_data_bits.Items.AddRange(new object[] {
            "8",
            "9"});
            this.combo_data_bits.Location = new System.Drawing.Point(125, 171);
            this.combo_data_bits.Name = "combo_data_bits";
            this.combo_data_bits.Size = new System.Drawing.Size(102, 24);
            this.combo_data_bits.TabIndex = 10;
            this.combo_data_bits.Text = "8";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(336, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 271);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // timer_com_port
            // 
            this.timer_com_port.Enabled = true;
            this.timer_com_port.Interval = 500;
            this.timer_com_port.Tick += new System.EventHandler(this.timer_com_port_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Port Status:";
            // 
            // label_connection
            // 
            this.label_connection.AutoSize = true;
            this.label_connection.Location = new System.Drawing.Point(454, 303);
            this.label_connection.Name = "label_connection";
            this.label_connection.Size = new System.Drawing.Size(78, 13);
            this.label_connection.TabIndex = 13;
            this.label_connection.Text = "No Connection";
            // 
            // Serial_Port_Open_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 324);
            this.Controls.Add(this.label_connection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "Serial_Port_Open_Form";
            this.Text = "Serial Port Configurations";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_port_open;
        private System.Windows.Forms.Button btn_port_close;
        private System.Windows.Forms.Label label_com;
        private System.Windows.Forms.Label label_baud_rate;
        private System.Windows.Forms.Label label_parity;
        private System.Windows.Forms.Label label_data_bits;
        private System.Windows.Forms.Label label_stop_bit;
        private System.Windows.Forms.ComboBox combo_COM;
        private System.Windows.Forms.ComboBox combo_baud_rate;
        private System.Windows.Forms.ComboBox combo_parity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combo_stop_bit;
        private System.Windows.Forms.ComboBox combo_data_bits;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer_com_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_connection;
        //private System.IO.Ports.SerialPort comport;
    }
}