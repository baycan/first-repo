using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Smart_Viko_City
{
    public partial class Draw_Chart_Form : Form
    {
        public Draw_Chart_Form()
        {
            InitializeComponent();
        }

        private void Draw_Chart_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'city_DataBaseDataSet.Production_Consumption' table. You can move, or remove it, as needed.
            this.production_ConsumptionTableAdapter.Fill(this.city_DataBaseDataSet.Production_Consumption);
                        
            
        }
    }
}
