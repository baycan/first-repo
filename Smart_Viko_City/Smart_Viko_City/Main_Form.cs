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
    public partial class Main_Form : Form
    {
        
        

        #region  global variables

                int pause = 0; //sistemi play pause etmek için kulanılan kontrol.pause=0 sistem play demek

                int[] total_production_array = new int[24];  //her saatteki enerji üretim ve harcamasını saklamak için kullanılacak diziler
                int[] total_consumption_array = new int[24];
                
                int global_consumption = 0;
                int[] wind_turbine = new int[20]; // scroll wind turbine r13,14,15,16,17 rölesini aç kapa kontrolü için kullanıldı
                int milles_count = 0;  //kac adet rüzgar paneli aktif değişkeni
                int production_wind = 0;     //veri tabanından alınan rüzgar paneli enerji üretim değeri.(1 tanesi için)              
                int sunlight = 0;//gündüz mü gece mi bayrağı?
                int[] leds_scrollbars= new int[10];
    
                int second=0;    //USED FOR TİMER LABELS
                int minute = 0;
                int hour = 0;

                int midnight = 0;  //USED FOR TİMER COUNT
                int morning = 0;
                int night = 0;
                int other_time = 0;

                int pwm_comport_count = 0;
                public static OleDbConnection connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "/City_DataBase.accdb");                

                string[] relay_reset = new string[] { "R,0,0 ", "R,1,0 ", "R,2,0 ", 
                                                      "R,3,0 ", "R,4,0 ", "R,5,0 ",
                                                      "R,6,0 ", "R,7,0 ", "R,8,0 ",
                                                      "R,9,0 ", "R,10,0 ", "R,11,0 ",
                                                      "R,12,0 ", "R,13,0 ", "R,14,0 ",
                                                      "R,15,0 ", "R,16,0 ", "R,17,0 "};

                string[] relay_set = new string[] {   "R,0,1 ", "R,1,1 ", "R,2,1 ", 
                                                      "R,3,1 ", "R,4,1 ", "R,5,1 ",
                                                      "R,6,1 ", "R,7,1 ", "R,8,1 ",
                                                      "R,9,1 ", "R,10,1 ", "R,11,1 ",
                                                      "R,12,1 ", "R,13,1 ", "R,14,1 ",
                                                      "R,15,1 ", "R,16,1 ", "R,17,1 "};

                string[] pwm_reset = new string[] { "P,0,A,0 ", "P,0,B,0 ", "P,1,A,0 ",
                                                    "P,1,B,0 ","P,2,A,0 ","P,2,B,0 ",
                                                    "P,3,A,0 ","P,3,B,0 ","P,4,A,0 ",
                                                    "P,4,B,0 ","P,5,A,0 ","P,5,B,0 ",
                                                    "P,6,A,0 ","P,6,B,0 ","P,7,A,0 ","P,7,B,0 ","P,8,A,0 ",
                                                    "P,8,B,0 ","P,9,A,0 ","P,9,B,0 "};  



                string[] pwm_data = new string[] {   "P,0,A,", "P,0,B,", "P,1,A,",
                                                    "P,1,B,","P,2,A,","P,2,B,",
                                                    "P,3,A,","P,3,B,","P,4,A,",
                                                    "P,4,B,","P,5,A,","P,5,B,",
                                                    "P,6,A,","P,6,B,","P,7,A,","P,7,B,","P,8,A,",
                                                    "P,8,B,","P,9,A,","P,9,B,"};

                string[] leds_on = new string[] { "P,3,B,255 ", //cami
                                                  "P,4,A,255 ", //SCHOOL
                                                  "P,4,B,255 ",  //BELEDİYE
                                                  "P,5,A,255 ",  //MARKET
                                                  "P,5,B,255 ",  //PLAZA
                                                  "P,6,A,255 ",  //PLAZA2
                                                  "P,8,B,255 ",     //FABRİKA1
                                                  "P,7,A,255"};       //FABRİKA2

                string[] leds_off = new string[] {"P,3,B,0 ", //cami
                                                  "P,4,A,0 ", //SCHOOL
                                                  "P,4,B,0 ",  //BELEDİYE
                                                  "P,5,A,0 ",  //MARKET
                                                  "P,5,B,0 ",  //PLAZA
                                                  "P,6,A,0 ",  //PLAZA2
                                                  "P,8,B,0 ",     //FABRİKA1
                                                  "P,7,A,0 "};       //FABRİKA2
 
                    

        #endregion

        public Main_Form()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Serial_Port_Open_Form().Visible = true;
            
        }

        #region start time
        private void btn_start_time_Click(object sender, EventArgs e)
        {
            btn_start_time.Enabled = false;  //start butonuna basıldıktan sonra buton disable edilir
            
            run_time_condition();    //hangi zaman aralığındaysa onun gerekli koşullarının uygulandığı fonk.
            for (int i = 0; i <= 19; i++)       //starta basıldığında önce pwmler resetlenir
            {
                Serial_Port_Open_Form.comport.Write(pwm_reset[i]);
                wind_turbine[i] = 0;
            }

            Serial_Port_Open_Form.comport.Write("R,13,0 ");  //reset rüzgar panel
            Serial_Port_Open_Form.comport.Write("R,14,0 ");
            Serial_Port_Open_Form.comport.Write("R,15,0 ");
            Serial_Port_Open_Form.comport.Write("R,16,0 ");
            Serial_Port_Open_Form.comport.Write("R,17,0 ");
        }

        private void run_time_condition() 
        {
            if (Convert.ToInt32(label_hour.Text) == 0 && Convert.ToInt32(label_minute.Text) == 0 && Convert.ToInt32(label_seconds.Text) == 0 && (label_ampm.Text == "am"))
            {
                consumption_status(1); //ilgili zaman aralığında ki harcamayı databaseden alıp progressbara(total_consumptionprogressbar) gösteren fonk. 
                sunlight = 0;
                night_coming(); //gece olduğunda sun progress barı temizler.
                radioButton_sunny.Enabled = false;
                time_timer.Interval = 1000;
                midnight = 1;
                time_timer.Start();
            }

            else if (Convert.ToInt32(label_hour.Text) == 6 && Convert.ToInt32(label_minute.Text) == 0 && Convert.ToInt32(label_seconds.Text) == 0 && label_ampm.Text == "am") 
            {
                //güneş paneli gündüz_gece değişkenini set et ve progress barı arttır
                consumption_status(2); //ilgili zaman aralığında ki harcamayı databaseden alıp progressbara(total_consumptionprogressbar) gösteren fonk. 
                sunlight = 1;
                sun_control(); //gündüz oldu paneller aktif
                radioButton_sunny.Enabled = true;
                time_timer.Interval = 1000;
                morning = 1;
                time_timer.Start();            
            }

            else if (Convert.ToInt32(label_hour.Text) == 6 && Convert.ToInt32(label_minute.Text) == 0 && Convert.ToInt32(label_seconds.Text) == 0 && label_ampm.Text == "pm")
            {
                consumption_status(4); //ilgili zaman aralığında ki harcamayı databaseden alıp progressbara(total_consumptionprogressbar) gösteren fonk. 
                sunlight = 0;
                night_coming();//gece olduğunda sun progress barı temizler.
                radioButton_sunny.Enabled = false;
                time_timer.Interval = 1000;
                night = 1;
                time_timer.Start();
            }

            else 
            {
                time_timer.Interval = 30;
                other_time = 1;
                time_timer.Start();
            }


        }

        private void time_timer_Tick(object sender, EventArgs e)
        {
            if (midnight == 1) //change led status for midnight time
                led_status1();
            else if (morning == 1)  //change led status for morning time
                led_status2();
            else if (night == 1)    //change led status for night time
                led_status3();
            else { no_led_status(); }       //dont change led status, let go speed time 
            
        }

        private void led_status1() 
        {
            second++;
            label_seconds.Text = Convert.ToString(second);
            Serial_Port_Open_Form.comport.Write("P,2,B,255 "); //sokak lambası yanar diğerleri söner           
            Serial_Port_Open_Form.comport.Write(leds_off[pwm_comport_count]);
            
            if (second == 10)
            {
                midnight = 0;
                pwm_comport_count = 0;
                run_time_condition();                
            }
            
            else if(pwm_comport_count < 7)
                pwm_comport_count++ ;
        }
        private void led_status2()
        {
            second++;
            label_seconds.Text = Convert.ToString(second);
            if (second == 10)
            {               
                morning = 0;
                run_time_condition();
            }
            Serial_Port_Open_Form.comport.Write("P,2,B,0 ");  //sokak lambası söner
        }
        private void led_status3()
        {
            second++;
            label_seconds.Text = Convert.ToString(second);
            Serial_Port_Open_Form.comport.Write("P,2,B,255 "); //sokak lambası
            Serial_Port_Open_Form.comport.Write(leds_on[pwm_comport_count]);

            if (second == 10)
            {
                pwm_comport_count = 0;
                night = 0;
                run_time_condition();
            }          

            else if (pwm_comport_count < 7)
                pwm_comport_count++;
        }
        private void no_led_status()   //time is getting speed when this function going on
        {            
            minute++;
            label_seconds.Text="";
            if (minute == 60)
            {
                minute = 0;
                record_data(hour);   //her saat başında veri tabanına o anki üretim tüketim kaydı için bu fonk çağrılır
                hour++;
                if (hour == 12 && label_ampm.Text =="am")
                {
                    hour = 0;
                    label_ampm.Text = "pm";
                }

                if (hour == 12 && label_ampm.Text == "pm")
                {
                    hour = 0;
                    label_ampm.Text = "am";
                }
            }         
            label_minute.Text = Convert.ToString(minute);
            label_hour.Text = Convert.ToString(hour);

            if (hour == 6 && minute == 0 || hour == 0 && minute == 0)
            {
                second = 0;
                label_seconds.Text = Convert.ToString(second);
                run_time_condition();
            }            
        }

        private void consumption_status(int value) 
        {
            
            string sql = "Select * from consumption_time where Kimlik=1"; //veri tabanı tablo adı ve read işlemi için reader
            OleDbCommand cmd = new OleDbCommand(sql, connect);
            OleDbDataReader reader2 = cmd.ExecuteReader();            
            reader2.Read(); 

            if (value == 1) 
            {
                 global_consumption= Convert.ToInt32(reader2.GetValue(1));
            }

            else if (value == 2)
            {
                global_consumption = Convert.ToInt32(reader2.GetValue(2));
            }

            else if (value == 3)
            {
                global_consumption = Convert.ToInt32(reader2.GetValue(3));
            }
            else if (value == 4)
            {
                global_consumption = Convert.ToInt32(reader2.GetValue(4));
            }

            totalConsumption_progressbar();
        }




        #endregion       

        private void btn_database_connect_Click(object sender, EventArgs e)
        {                      
            database_status.Text = "Connected";
            connect.Open();
            groupBox4.Enabled = true;
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox2.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Close();
            database_status.Text = "No Connection";
        }

        private void button_bill_Click(object sender, EventArgs e)  //Pop up bill form
        {
            new Bill_Form().Visible = true;
        }

        private void btn_draw_chart_Click(object sender, EventArgs e) //Pop up chart form
        {
            new Draw_Chart_Form().Visible = true;
            time_timer.Stop();

            if (pause == 0)  //kullanıcı pause etmek istiyor 
            {
                pause = 1;
                //time_timer.Stop();
            }

            else if (pause == 1)
            {
                pause = 0;
                //time_timer.Start();
            }
        }

        #region Wind Control Unit
        private void ScrollBar_Wind_Scroll(object sender, ScrollEventArgs e)
        {
            
            textBox_scrollBar.Text=Convert.ToString(ScrollBar_Wind.Value);//scrollbar verisini text de gösterir.           


            string sql = "Select * from Solar_Wind where Kimlik=2"; //veri tabanı tablo adı ve read işlemi için reader
            OleDbCommand cmd = new OleDbCommand(sql, connect);
            OleDbDataReader reader = cmd.ExecuteReader();            
            reader.Read();       
            
            if ((ScrollBar_Wind.Value >= 0) && (ScrollBar_Wind.Value < 5))  //databaseden veri aldı, comporta gönderdi progress barda gösterdi 
            {
                production_wind = Convert.ToInt32(reader.GetValue(1));            
            }

            else if ((ScrollBar_Wind.Value >= 5) && (ScrollBar_Wind.Value < 15))
            {
                production_wind = Convert.ToInt32(reader.GetValue(2));  
            }

            else if ((ScrollBar_Wind.Value >= 15) && (ScrollBar_Wind.Value < 25))
            {
                production_wind = Convert.ToInt32(reader.GetValue(3));
            }

            else 
            {
                production_wind = Convert.ToInt32(reader.GetValue(4));           
            }

            //progressBar_productionWind.Value = production_wind;
            calculate_progressBar(production_wind,milles_count);
             /*
              
             
              */   //

            //send comport value
            send_comport_set(); // o an check box da set olan rüzgar güllerini yeni hızda çalıştırmaya gider
        }

        private void send_comport_set()         //comporttan rüzgar panellerini set edileceğinde çağırılır
        {
            for (int i = 0; i < 20; i++)            //oluşturulan dizide R13,R14,R15,R16,R17 rölesi oluşturulan arrayin ilgili
            {                                       //röle ile aynı olan indisleri 1 e eşit ise o röleyi aktif eder
                if (wind_turbine[i] == 1) 
                {
                    if (ScrollBar_Wind.Value < 25)
                        Serial_Port_Open_Form.comport.Write("R," + i + ",1 P,0,A," + ScrollBar_Wind.Value * 8 + " ");
                    else 
                    {
                        Serial_Port_Open_Form.comport.Write("R," + i + ",0 ");   //rüzgar hızı 25 m/s aşarsa röle türbin durdurulur
                    }
                }
            }
        }

        private void send_comport_reset(int value) 
        {
                    Serial_Port_Open_Form.comport.Write("R," + value + ",0 ");
                    wind_turbine[value] = 0;

        }

        private void calculate_progressBar(int value, int count) 
        {            
            progressBar_productionWind.Value = value*count;
            //textBox_productionWind.Text = Convert.ToString(value * count);
            //databasse bağlan ve rüzgar paneli üretim verileri burda yaz 
            label_windProduction.Text = Convert.ToString(value * count);
            totalProduction_progressbar();
        
        }

        private void checkBox_Mill1_CheckedChanged(object sender, EventArgs e)
        {
            wind_turbine[13] = 1; //mil bir konum değiştirdi

            if (checkBox_Mill1.CheckState == CheckState.Checked)
            {
                milles_count++;
                send_comport_set();
            }

            else 
            { 
                milles_count--;
                send_comport_reset(13);
            }

            calculate_progressBar(production_wind,milles_count);
        }

        private void checkBox_Mill2_CheckedChanged(object sender, EventArgs e)
        {
            wind_turbine[16] = 1;
            if (checkBox_Mill2.CheckState == CheckState.Checked)
            {
                milles_count++;
                send_comport_set();
            }

            else
            {
                milles_count--;
                send_comport_reset(16);
            }

            calculate_progressBar(production_wind, milles_count);
        }

        private void checkBox_Mill3_CheckedChanged(object sender, EventArgs e)
        {
            wind_turbine[14] = 1;
            if (checkBox_Mill3.CheckState == CheckState.Checked)
            {
                milles_count++;
                send_comport_set();
            }

            else
            {
                milles_count--;
                send_comport_reset(14);
            }
            calculate_progressBar(production_wind, milles_count);
        }

        private void checkBox_Mill4_CheckedChanged(object sender, EventArgs e)
        {
            wind_turbine[17] = 1;
            if (checkBox_Mill4.CheckState == CheckState.Checked)
            {
                milles_count++;
                send_comport_set();
            }

            else
            {
                milles_count--;
                send_comport_reset(17);
            }
            calculate_progressBar(production_wind, milles_count);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            wind_turbine[15] = 1;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                milles_count++;
                //Serial_Port_Open_Form.comport.Write("R,15,1 P,0,A," + ScrollBar_Wind.Value * 8);
                send_comport_set();
            }

            else
            {
                milles_count--;
                //Serial_Port_Open_Form.comport.Write("R,15,0 ");
                send_comport_reset(15);
            }

            calculate_progressBar(production_wind, milles_count);
        }




        #endregion

        #region Solar Panel Control Unit

        private void sun_control() 
        {
            int zero = 0;
            sun_production(zero);
        }

        private void sun_production(int value)
        {
            int default_value = 10;
            progressBar_sunProduction.Value = value+default_value;
            label_sunProduction.Text = Convert.ToString(progressBar_sunProduction.Value);
            //textBox_sunProduction.Text = Convert.ToString(progressBar_sunProduction.Value);
            totalProduction_progressbar();
        }

        private void night_coming() 
        {
            progressBar_sunProduction.Value = 0;
            label_sunProduction.Text = Convert.ToString(0);
            //textBox_sunProduction.Text = Convert.ToString(0);
        }

        private void radioButton_cloudy_CheckedChanged(object sender, EventArgs e)
        {
            int level1 = 1;
            if(sunlight==1)
                get_solar_production(level1);
        }

        private void radioButton_rainy_CheckedChanged(object sender, EventArgs e)
        {
            int level2 = 2;
            if (sunlight == 1)
                get_solar_production(level2);
        }

        private void radioButton_snowy_CheckedChanged(object sender, EventArgs e)
        {
            int level3 = 4;
            if (sunlight == 1)
                get_solar_production(level3);
        }

        private void radioButton_sunny_CheckedChanged(object sender, EventArgs e)
        {
            int level4 = 3;
            if (sunlight == 1)
                get_solar_production(level4);
        }

        private  void get_solar_production(int index) 
        {
            int database_value = 0;
            string sql = "Select * from Solar_Wind where Kimlik=1"; //veri tabanı tablo adı ve read işlemi için reader
            OleDbCommand cmd = new OleDbCommand(sql, connect);
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();

            database_value = Convert.ToInt32(reader.GetValue(index));
            sun_production(database_value);

        }

        #endregion
       
        #region Led Control Unit

        private void ScrollBar_street_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,2,B," + (ScrollBar_street.Value)*2 + " ");
            leds_scrollbars[0] = ScrollBar_street.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_market_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,5,A," + (ScrollBar_market.Value)*2 + " ");
            leds_scrollbars[1] = ScrollBar_market.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_municipality_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,4,B," + (ScrollBar_municipality.Value)*2+ " ");
            leds_scrollbars[2] = ScrollBar_municipality.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_Mosque_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,3,B," + (ScrollBar_Mosque.Value)*2 + " ");
            leds_scrollbars[3] = ScrollBar_Mosque.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_schooll_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,4,A," + (ScrollBar_schooll.Value)*2 + " ");
            leds_scrollbars[4] = ScrollBar_schooll.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_facility_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,3,A," + (ScrollBar_schooll.Value)*2 + " ");
            leds_scrollbars[5] = ScrollBar_facility.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_plaza1_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,5,B," + (ScrollBar_plaza1.Value)*2 + " ");
            leds_scrollbars[6] = ScrollBar_plaza1.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_factory1_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,8,B," + (ScrollBar_factory1.Value)*2 + " ");
            leds_scrollbars[7] = ScrollBar_factory1.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_plaza2_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,6,A," + (ScrollBar_plaza2.Value)*2 + " ");
            leds_scrollbars[8] = ScrollBar_plaza2.Value;
            led_consumptionProgressBar();
        }

        private void ScrollBar_factory2_Scroll(object sender, ScrollEventArgs e)
        {
            //burda comporta scrollbar verisini gönder ilgili ledin pwmni ayarla
            Serial_Port_Open_Form.comport.Write("P,6,B," + (ScrollBar_factory2.Value)*2 + " ");
            leds_scrollbars[9] = ScrollBar_factory2.Value;
            led_consumptionProgressBar();
        }

        private void led_consumptionProgressBar() 
        {
            int toplam = 0;
            for (int i = 0; i < 10; i++) 
            {
                toplam = toplam + leds_scrollbars[i]; 
            }

            progressBar_ledConsumption.Value = toplam;
            //textBox_ledConsumption.Text = Convert.ToString(toplam);
            label_ledConsumption.Text = Convert.ToString(toplam);
            totalConsumption_progressbar();
        
        }

        #endregion

        #region total  progressbars

        private void totalProduction_progressbar() //totalde üretimi gösteren progressbar ve text view gösterimi
        {
            int total_value = 0;
            total_value = progressBar_sunProduction.Value + progressBar_productionWind.Value;
            progressBar_totalProduction.Value = total_value;
            //textBox_totalProduction.Text = Convert.ToString(total_value);
            label_totalProduction.Text = Convert.ToString(total_value);
            request_progressbar();
        }

        private void totalConsumption_progressbar()  //totalde harcamayı gösteren progressbar ve text view gösterimi
        {

             progressBar_totalConsumption.Value = Convert.ToInt32(global_consumption + (progressBar_ledConsumption.Value)/10);
            //textBox_energyConsumption.Text = Convert.ToString(global_consumption + led);
             //textBox_energyConsumption.Text = Convert.ToString(global_consumption + "." + progressBar_ledConsumption.Value);
             label_totalConsumption.Text = Convert.ToString(global_consumption + "." + progressBar_ledConsumption.Value);
             request_progressbar();
        }

        private void request_progressbar() 
        {
            int value1 = 0, value2 = 0;
            int net_value = 0;
            value1 = progressBar_totalProduction.Value;
            value2 = global_consumption;
            if (value1 < value2)
            {
                net_value = value2 - value1;
                progressBar_requestEnergy.Value = net_value;
                //textBox_requestGrid.Text = Convert.ToString(net_value);
                label_requestGrid.Text = Convert.ToString(net_value);
            }
            else 
            {
                progressBar_requestEnergy.Value = 0;
                //textBox_requestGrid.Text = Convert.ToString(0);
                label_requestGrid.Text = Convert.ToString(0);
            }
        }

        #endregion

        #region record pro_con database

        private void  record_data(int hour_index)
        {
            if (label_ampm.Text == "am")   //gece 12 den öğlen 12 ye kadar olan kayıtlar burda tutulur.
            {
                total_consumption_array[hour_index] = progressBar_totalConsumption.Value;
                total_production_array[hour_index] = progressBar_totalProduction.Value;
                if (hour_index == 11)
                {
                    total_consumption_array[hour_index + 1] = progressBar_totalConsumption.Value;
                    total_production_array[hour_index] = progressBar_totalProduction.Value;
                }
            }

            else    //öğlen 12 den gece 12 ye kadar olan üretim tüketim kayıtları burda kaydedilir
            {
                total_consumption_array[hour_index + 12] = progressBar_totalConsumption.Value;
                total_production_array[hour_index+ 12] = progressBar_totalProduction.Value;
                if (hour_index == 11)
                    find_mean();  //24 saatlik dilim tamamlşanınca bu fonksiyon çağrılır.
            }

        }

        private void find_mean() 
        {
            float t1_con = 0, t2_con = 0, t3_con=0;   //ortalama tüketim değişkenleri
            float t1_pro = 0, t2_pro = 0, t3_pro = 0;  //ortalama üretim değişkenleri
            int sum_con = 0, sum_pro=0;

            for (int i = 0; i < 6; i++)    //saklanan verilerilk altı saatlik kısmı toplanır.
            {
                sum_con = sum_con + total_consumption_array[i];
                sum_pro = sum_pro + total_production_array[i];
            }

            t1_con = sum_con/6;   //ilk 6 saatlik kısmın verilerinin ortalaması alınarak gerekli zaman değişkenlerine aktarılır.
            t1_pro = sum_pro/6;
            sum_pro = 0;
            sum_con = 0;
            //----------------------------------------------------
            for (int i = 6; i < 18; i++)    //saklanan verilerilk altı saatlik kısmı toplanır.
            {
                sum_con = sum_con + total_consumption_array[i];
                sum_pro = sum_pro + total_production_array[i];
            }

            t2_con = sum_con / 12;
            t2_pro = sum_pro / 12;
            sum_pro = 0;
            sum_con = 0;
            //-----------------------------------------------------------------
            for (int i = 18; i < 24; i++)    //saklanan verilerilk altı saatlik kısmı toplanır.
            {
                sum_con = sum_con + total_consumption_array[i];
                sum_pro = sum_pro + total_production_array[i];
            }

            t3_con = sum_con / 6;
            t3_pro = sum_pro / 6;
            sum_pro = 0;
            sum_con = 0;

            //burda veri kaydı yapılacak t1 t2 t3 
            OleDbCommand cmd = new OleDbCommand("update Production_Consumption set  Interval1 = '" + t1_con +   "' where Kimlik = 1", connect);  
            OleDbCommand cmd2 = new OleDbCommand("update Production_Consumption set  Interval1 = '" + t2_con + "' where Kimlik = 2", connect);
            OleDbCommand cmd3 = new OleDbCommand("update Production_Consumption set  Interval1 = '" + t3_con + "' where Kimlik = 3", connect);

            OleDbCommand cmd4 = new OleDbCommand("update Production_Consumption set  Interval2 = '" + t1_pro + "' where Kimlik = 1", connect);
            OleDbCommand cmd5 = new OleDbCommand("update Production_Consumption set  Interval2 = '" + t2_pro + "' where Kimlik = 2", connect);
            OleDbCommand cmd6 = new OleDbCommand("update Production_Consumption set  Interval2 = '" + t3_pro + "' where Kimlik = 3", connect);

            cmd.ExecuteNonQuery();            
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd4.ExecuteNonQuery();
            cmd5.ExecuteNonQuery();
            cmd6.ExecuteNonQuery();

                  
        }
        #endregion

        private void btn_reset_time_Click(object sender, EventArgs e)
        {
            btn_start_time.Enabled = true;  //start butonuna basıldıktan sonra buton disable edilir
            time_timer.Stop();  //timer stop
            second = 0;
            minute = 0;
            hour = 0;

            //Bu bir github denemesidir!!!!
            int git_deneme = 0;
            
            //
            #region reset system controls
            label_hour.Text = "0";  //saat dakika temizlenir gece yarısına ayarlanır.
            label_minute.Text = "0";
            label_seconds.Text = "0";
            label_ampm.Text = "am";

            progressBar_ledConsumption.Value = 0;  //progress barlar temizlenir.
            //progressBar_productionWind.Value = 0;
            progressBar_requestEnergy.Value = 0;
            progressBar_sunProduction.Value = 0;
            progressBar_totalConsumption.Value = 0;
            progressBar_totalProduction.Value = 0;

            ScrollBar_facility.Value = 0;
            ScrollBar_factory1.Value = 0;
            ScrollBar_factory2.Value = 0;
            ScrollBar_market.Value = 0;
            ScrollBar_Mosque.Value = 0;
            ScrollBar_municipality.Value = 0;
            ScrollBar_plaza1.Value = 0;
            ScrollBar_plaza2.Value = 0;
            ScrollBar_schooll.Value = 0;
            ScrollBar_street.Value = 0;
            #endregion


        }

        private void btn_pause_time_Click(object sender, EventArgs e)
        {
            if (pause == 0)  //kullanıcı pause etmek istiyor 
            {
                pause = 1;
                time_timer.Stop();
            }

            else if (pause == 1) 
            {
                pause = 0;
                time_timer.Start();
            }

        }

        private void button_emergency_stop_Click(object sender, EventArgs e)
        {
            btn_start_time.Enabled = true;  //start butonuna basıldıktan sonra buton disable edilir
            time_timer.Stop();
            
            label_hour.Text = "0";  //saat dakika temizlenir gece yarısına ayarlanır.
            label_minute.Text = "0";
            label_seconds.Text = "0";
            label_ampm.Text = "am";

            second = 0;
            minute = 0;
            hour = 0;

            progressBar_ledConsumption.Value = 0;  //progress barlar temizlenir.
            progressBar_productionWind.Value = 0;
           
            progressBar_sunProduction.Value = 0;
            progressBar_totalConsumption.Value = 0;
            progressBar_totalProduction.Value = 0;

            ScrollBar_facility.Value = 0;
            ScrollBar_factory1.Value = 0;
            ScrollBar_factory2.Value = 0;
            ScrollBar_market.Value = 0;
            ScrollBar_Mosque.Value = 0;
            ScrollBar_municipality.Value = 0;
            ScrollBar_plaza1.Value = 0;
            ScrollBar_plaza2.Value = 0;
            ScrollBar_schooll.Value = 0;
            ScrollBar_street.Value = 0;
            ScrollBar_Wind.Value = 0;
            textBox_scrollBar.Text = "0";
            //Serial_Port_Open_Form.comport.Close();
            //connect.Close();
            //database_status.Text = "No Connection";

            for (int i = 0; i <= 19; i++)       //starta basıldığında önce pwmler resetlenir
            {
                Serial_Port_Open_Form.comport.Write(pwm_reset[i]);
                wind_turbine[i] = 0;
            }

            checkBox_Mill1.CheckState = CheckState.Unchecked;  //rüzgar panelleri check boxları resetlenir.
            checkBox_Mill2.CheckState = CheckState.Unchecked;
            checkBox_Mill3.CheckState = CheckState.Unchecked;
            checkBox_Mill4.CheckState = CheckState.Unchecked;
            checkBox_Mill1.CheckState = CheckState.Unchecked;
            checkBox1.CheckState = CheckState.Unchecked;
            progressBar_requestEnergy.Value = 0;
        }


        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {



            if (MessageBox.Show("Do you want to exit?", "Exit Application",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Cancel the Closing event from closing the form.
                //e.Cancel = true;
                // Call method to save file...
                Serial_Port_Open_Form.comport.Close();
                connect.Close();              
            }

            else 
            {
                e.Cancel = true;

            }

        }

    }
}
