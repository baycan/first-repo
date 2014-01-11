using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Viko_City
{
    public partial class Splash_Form : Form
    {
        public Splash_Form()
        {
            InitializeComponent();
        }

        private void splash_timer_Tick(object sender, EventArgs e)
        {
            splash_timer.Stop();           
            Hide();
            new Main_Form().Visible = true;
        }
    }
}
