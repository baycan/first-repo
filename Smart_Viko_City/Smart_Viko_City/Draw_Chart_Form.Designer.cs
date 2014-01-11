namespace Smart_Viko_City
{
    partial class Draw_Chart_Form
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.city_DataBaseDataSet = new Smart_Viko_City.City_DataBaseDataSet();
            this.productionConsumptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.production_ConsumptionTableAdapter = new Smart_Viko_City.City_DataBaseDataSetTableAdapters.Production_ConsumptionTableAdapter();
            this.productionConsumptionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.city_DataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionConsumptionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionConsumptionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.productionConsumptionBindingSource1;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Prodoction(t1, t2, t3)";
            series1.XValueMember = "Kimlik";
            series1.YValueMembers = "Interval2";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(307, 192);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.DataSource = this.productionConsumptionBindingSource;
            legend2.BorderWidth = 5;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(344, 12);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Consumption(t1, t2, t3)";
            series2.XValueMember = "Kimlik";
            series2.YValueMembers = "Interval1";
            series2.YValuesPerPoint = 2;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(301, 192);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(200, 229);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(248, 189);
            this.chart3.TabIndex = 2;
            this.chart3.Text = "chart3";
            // 
            // city_DataBaseDataSet
            // 
            this.city_DataBaseDataSet.DataSetName = "City_DataBaseDataSet";
            this.city_DataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productionConsumptionBindingSource
            // 
            this.productionConsumptionBindingSource.DataMember = "Production_Consumption";
            this.productionConsumptionBindingSource.DataSource = this.city_DataBaseDataSet;
            // 
            // production_ConsumptionTableAdapter
            // 
            this.production_ConsumptionTableAdapter.ClearBeforeFill = true;
            // 
            // productionConsumptionBindingSource1
            // 
            this.productionConsumptionBindingSource1.DataMember = "Production_Consumption";
            this.productionConsumptionBindingSource1.DataSource = this.city_DataBaseDataSet;
            // 
            // Draw_Chart_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 430);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "Draw_Chart_Form";
            this.Text = "Draw_Chart_Form";
            this.Load += new System.EventHandler(this.Draw_Chart_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.city_DataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionConsumptionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionConsumptionBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private City_DataBaseDataSet city_DataBaseDataSet;
        private System.Windows.Forms.BindingSource productionConsumptionBindingSource;
        private City_DataBaseDataSetTableAdapters.Production_ConsumptionTableAdapter production_ConsumptionTableAdapter;
        private System.Windows.Forms.BindingSource productionConsumptionBindingSource1;
        //private City_DataBaseDataSet1 city_DataBaseDataSet1;
        //private City_DataBaseDataSet1TableAdapters.Production_ConsumptionTableAdapter production_ConsumptionTableAdapter;
    }
}