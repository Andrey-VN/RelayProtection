using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Modbus.Device;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        //SerialPort port;
        ModbusSerialMaster master;
        byte slaveID = 1;
        public Form1()
        {
            InitializeComponent();
            Graph();
            //MaximizeBox = false;
            tabPage1.Enabled = false;
            try
            {
                string[] ports = SerialPort.GetPortNames();
                comboBox1.Items.AddRange(ports);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            if (comboBox1.Items.Count <= 0)
            {
                comboBox1.Text = "";
                comboBox1.Enabled = false;
            }
            else { comboBox1.Enabled = true; }

            comboBox1.Update();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.Open();
                button1.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                serialPort1.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
                
            try
            {
                master = ModbusSerialMaster.CreateRtu(serialPort1);
                master.Transport.ReadTimeout = 3000;

                Potok_znach_in_vikluch();
                tabPage1.Enabled = true;
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                button1.Text = "Подключиться";
                serialPort1.Close();
            }

                //timer7.Enabled = false;

                //button2.Click += Button2_Click;
                //Registr_output_int(7, 0);
                //foreach (Panel pn in tabPage1.Controls.OfType<Panel>())
                //{
                //    pn.BackColor = Color.Red;
                //}
                //q = 0;
                //ushort registerAddress = 6;
                //byte value1 = q;
                //master.WriteSingleRegister(1, registerAddress, value1);
                //Potok_znach_in_vikluch();
                //serialPort1.Close();
                //this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        void Init()
        {
           
            
            button6.Enabled = true;
            button7.Enabled = false;
            button22.Enabled = true;
            button21.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = true;
            button12.Enabled = false;
            button13.Enabled = true;
            button15.Enabled = false;
            button18.Enabled = true;
            button19.Enabled = false;
            button20.Enabled = true;
            button36.Enabled = false;
            button37.Enabled = true;
            button34.Enabled = false;
            button35.Enabled = true;
            button10.Enabled = false;
            button11.Enabled = true;
            Check_group(groupBox5);
            Check_group(groupBox6);
            Check_group(groupBox7);
            Check_group(groupBox9);
            Check_group(groupBox10);
            Check_group(groupBox16);
            Check_group(groupBox15);
            Check_group(groupBox14);
            Check_tabPage(tabPage5);
            Check_tabPage(tabPage6);
            //Check_Vikluch_Red();
            
            //tabPage1.Enabled = false;

        }

        void Ruchnoy_rezhim_tabPage(TabPage tabPage)
        {
            foreach (CheckBox cb in tabPage.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;
            }
        }
        void Ruchnoy_rezhim_group(GroupBox groupBox)
        {
            foreach (CheckBox cb in groupBox.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;
            }
        }

        void Check_group(GroupBox group)
        {
            foreach (CheckBox cb in group.Controls.OfType<CheckBox>())
            {
                if (cb.Enabled) cb.Enabled = false;
                else cb.Enabled = true;
            }
        }


        void Check_tabPage(TabPage tabPage)
        {
            foreach (CheckBox cb in tabPage.Controls.OfType<CheckBox>())
            {
                if (cb.Enabled) cb.Enabled = false;
                else cb.Enabled = true;
            }
        }

        void Color_C(TextBox textbox, Label lable, CheckBox checkbox)
        {
            if (checkbox.Checked == true)
            {
                textbox.ForeColor = Color.Black;
                lable.ForeColor = Color.Black;
            }

            else
            {
                textbox.ForeColor = Color.Gray;
                lable.ForeColor = Color.Gray;
            }

        }

        void Check_b(CheckBox check, KeyPressEventArgs e)
        {

            if (check.Checked == true)
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;

            }
        }
        void Stroka_float(TextBox sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;


            if (e.KeyChar == '.')
                e.KeyChar = ',';

            if (e.KeyChar == ',')
            {
                if (sender.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            e.Handled = true;
        }
        void Stroka_int(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;

            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            e.Handled = true;
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox1, e);
            Stroka_float(textBox1, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox1, e);
            Stroka_int(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox3, e);
            Stroka_int(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox5, e);
            Stroka_float(textBox4, e);
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox5, e);
            Stroka_int(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox1, label2, checkBox1);
            Color_C(textBox2, label3, checkBox1);
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox3, label5, checkBox3);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox4, label4, checkBox5);
            Color_C(textBox6, label7, checkBox5);
        }



        private void button7_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            button7.Enabled = false;
            RazBlock_tabPage_pri_puske(groupBox1);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox7, e);
            Stroka_float(textBox11, e);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox11, label40, checkBox7);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox2, e);
            Stroka_float(textBox12, e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox2, e);
            Stroka_float(textBox10, e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            Color_C(textBox12, label39, checkBox2);
            Color_C(textBox10, label41, checkBox2);
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox10, e);
            Stroka_float(textBox18, e);
        }

        private void checkBox10_CheckedChanged_1(object sender, EventArgs e)
        {
            Color_C(textBox18, label47, checkBox10);
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox9, e);
            Stroka_float(textBox24, e);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox24, label53, checkBox9);
            if (checkBox9.Checked == true)
            {
                checkBox6.Enabled = true;
                checkBox8.Enabled = true;
            }

            else
            {
                checkBox6.Enabled = false;
                checkBox8.Enabled = false;
            }

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox23, label51, checkBox8);
        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox8, e);
            Stroka_int(e);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox20, label50, checkBox6);
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox6, e);
            Stroka_int(e);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox27, label56, checkBox16);
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox16, e);
            Stroka_int(e);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox30, label59, checkBox19);
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox19, e);
            Stroka_int(e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Check_tabPage(tabPage5);
            Check_tabPage(tabPage6);
            //Check_Vikluch_Red();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox5);
            //Check_Vikluch_Red();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox6);
            //Check_Vikluch_Red();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox7);
            checkBox6.Enabled = false;
            checkBox8.Enabled = false;
            //Check_Vikluch_Red();
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox9);
            //Check_Vikluch_Red();
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox10);
            //Check_Vikluch_Red();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Ruchnoy_rezhim_tabPage(tabPage5);
            Ruchnoy_rezhim_tabPage(tabPage6);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Ruchnoy_rezhim_group(groupBox5);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            Ruchnoy_rezhim_group(groupBox6);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            Ruchnoy_rezhim_group(groupBox7);
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            Ruchnoy_rezhim_group(groupBox9);
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            Ruchnoy_rezhim_group(groupBox10);
        }


        private void button21_Click(object sender, EventArgs e)
        {
            button21.Enabled = false;
            button22.Enabled = true;
            RazBlock_tabPage_pri_puske(groupBox12);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button9.Enabled = true;
            RazBlock_tabPage_pri_puske(groupBox2);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Enabled = false;
            button13.Enabled = true;
            RazBlock_tabPage_pri_puske(groupBox4);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }



        private void button15_Click(object sender, EventArgs e)
        {
            button15.Enabled = false;
            button18.Enabled = true;
            RazBlock_tabPage_pri_puske(groupBox8);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button19.Enabled = false;
            button20.Enabled = true;
            RazBlock_tabPage_pri_puske(groupBox11);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }

        void Block_tabPage_pri_puske(TabPage tb, GroupBox gb)
        {
            foreach (TabPage cb in tabControl2.Controls.OfType<TabPage>())
            {
                tb.Enabled = true;
                if (tb != cb)
                    cb.Enabled = false;

            }
            foreach (RadioButton rb in gb.Controls.OfType<RadioButton>())
            {
                rb.Enabled = false;
            }
        }
        void RazBlock_tabPage_pri_puske(GroupBox gb)
        {

            foreach (TabPage cb in tabControl2.Controls.OfType<TabPage>())
            {
                cb.Enabled = true;
            }
            foreach (RadioButton rb in gb.Controls.OfType<RadioButton>())
            {
                rb.Enabled = true;
            }
        }
        
        void OffOnRele(Panel pn) 
        {
                if (pn.BackColor == Color.Red)
                {
                    pn.BackColor = Color.Green;                   
                }

                else
                {
                    pn.BackColor = Color.Red;
                }       
        }


        void Poverenie_vikluchateley(RadioButton radio, Button button, Panel panel)
        {
            if (radio.Checked == false & !button.Enabled == true)
                OffOnRele(panel);
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton2, button6, panel3);
            if (radioButton1.Checked & button7.Enabled)
                RR1(panel3, panel1, panel2);

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton2, button6, panel1);
            if (radioButton1.Checked & button7.Enabled)
                RR1(panel3, panel1, panel2);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton2, button6, panel2);
            if (radioButton1.Checked & button7.Enabled)
                RR1(panel3, panel1, panel2);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton4, button9, panel4);
            if (radioButton3.Checked & button8.Enabled)
                RR1(panel4, panel5, panel6);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton4, button9, panel5);
            if (radioButton3.Checked & button8.Enabled)
                RR1(panel4, panel5, panel6);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton4, button9, panel6);

            if (radioButton3.Checked & button8.Enabled)
                RR1(panel4, panel5, panel6);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton8, button13, panel7);
            if (radioButton7.Checked & button12.Enabled)
                RR1(panel7, panel8, panel9);
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton8, button13, panel8);
            if (radioButton7.Checked & button12.Enabled)
                RR1(panel7, panel8, panel9);
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton8, button13, panel9);
            if (radioButton7.Checked & button12.Enabled)
                RR1(panel7, panel8, panel9);
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton10, button18, panel10);

            if (radioButton9.Checked & button15.Enabled)
                RR1(panel10, panel11, panel13);
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton10, button18, panel11);
            if (radioButton9.Checked & button15.Enabled)
                RR1(panel10, panel11, panel13);
        }

        private void panel17_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton12, button20, panel17);
            if (radioButton11.Checked & button19.Enabled)
                RR1(panel17, panel12, panel13);
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton12, button20, panel12);
            if (radioButton11.Checked & button19.Enabled)
                RR1(panel17, panel12, panel13);
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton12, button20, panel13);
            if (radioButton11.Checked & button19.Enabled)
                RR1(panel17, panel12, panel13);
        }

        private void panel18_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton14, button22, panel18);
            if (radioButton13.Checked & button21.Enabled)
                RR1(panel18, panel14, panel15, panel16);
        }

        private void panel14_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton14, button22, panel14);
            if (radioButton13.Checked & button21.Enabled)
                RR1(panel18, panel14, panel15, panel16);
        }

        private void panel16_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton14, button22, panel16);
            if (radioButton13.Checked & button21.Enabled)
                RR1(panel18, panel14, panel15, panel16);
        }

        private void panel15_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton14, button22, panel15);
            if (radioButton13.Checked & button21.Enabled)
                RR1(panel18, panel14, panel15, panel16);
        }

        void Graph()
        {
            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[1].Points.AddXY(0, 0);
            chart1.Series[2].Points.AddXY(0, 0);
            chart2.Series[0].Points.AddXY(0, 0);

            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 10);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;


            //chart1.ChartAreas[0].AxisY.ScaleView.Zoom(0, 1);
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            //chart2.ChartAreas[0].AxisX.ScaleView.Zoom(0, 100);
            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;


            //chart2.ChartAreas[0].AxisY.ScaleView.Zoom(0, 220);
            chart2.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
        }

        int Timerr2;
        int Timerr3;

        private void timer2_Tick(object sender, EventArgs e)
        {
            button27.Click += (s, a) =>
            {
                Timerr2 = 0;
            };
            Timerr2 += timer2.Interval / 1000;
            if(timer4.Enabled)
                chart1.Series[0].Points.AddXY(Timerr2, textBox5.Text);
            if (timer1.Enabled)
                chart1.Series[1].Points.AddXY(Timerr2, textBox7.Text);
            if (timer6.Enabled)
                chart1.Series[2].Points.AddXY(Timerr2, textBox21.Text);
            
        }
        private void button39_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string x1, y1, z1;
                string x2, y2, z2;
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                if (timer4.Enabled)
                {
                    x1 = "\tTA1,A";
                }
                else
                {
                    x1 = "";
                }
                if (timer1.Enabled)
                {
                    y1 = "\tTA2,A";
                }
                else
                {
                    y1 = "";
                }
                if (timer6.Enabled)
                {
                    z1 = "\tTA3,A";
                }
                else
                {
                    z1 = "";
                }
                streamWriter.WriteLine($"t,s{x1}{y1}{z1}");
                for (int i = 0; i < chart1.Series[0].Points.Count;i++)
                {
                    if (timer4.Enabled)
                    {
                        x2 = $"\t{chart1.Series[0].Points[i].YValues[0]}";
                    }
                    else
                    {
                        x2 = "";
                    }
                    if (timer1.Enabled)
                    {
                        y2 = $"\t{chart1.Series[1].Points[i].YValues[0]}";
                    }
                    else
                    {
                        y2 = "";
                    }
                    if (timer6.Enabled)
                    {
                        z2 = $"\t{chart1.Series[2].Points[i].YValues[0]}";
                    }
                    else
                    {
                        z2 = "";
                    }
                    streamWriter.WriteLine($"{i}{x2}{y2}{z2}");
                }
                streamWriter.Close();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Enabled = false;
                button28.Text = "Включить график\"Ток\"";


            }
            else
            {
                timer2.Enabled = true;
                button28.Text = "Отключить график\"Ток\"";
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            button29.Click += (s, a) =>
            {
                Timerr3 = 0;
            };
            Timerr3 += timer3.Interval / 1000;
            if(timer5.Enabled)
                chart2.Series[0].Points.AddXY(Timerr3, textBox8.Text);

        }
        private void button30_Click(object sender, EventArgs e)
        {
            if (timer3.Enabled)
            {
                timer3.Enabled = false;
                button30.Text = "Включить график\"Напряжение\"";
            }
            else
            {
                timer3.Enabled = true;
                button30.Text = "Отключить график\"Напряжение\"";
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[1].Points.AddXY(0, 0);
            chart1.Series[2].Points.AddXY(0, 0);
        }
        private void button29_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[0].Points.AddXY(0, 0);
        }


        void Analog_signal(int i, TextBox textbox)
        {
            ushort startAddress = 0;
            ushort numOfPoints = 4;
            ushort[] holding_register = master.ReadHoldingRegisters(slaveID, startAddress, numOfPoints);

            float[] floatData = new float[2];
            Buffer.BlockCopy(holding_register, 0, floatData, 0, 8);
            textbox.Text = floatData[i].ToString("0.000");
        }
        private void button24_Click(object sender, EventArgs e)
        {
            if (timer4.Enabled)
            {
                button24.Text = "Включить TA1";
                timer4.Enabled = false;
                textBox5.Text = default;
                ushort registerAddress = 59;
                byte value1 = 0;
                master.WriteSingleRegister(1, registerAddress, value1);
            }
            else
            {
                button24.Text = "Отключить TA1";
                timer4.Enabled = true;
                ushort registerAddress = 59;
                byte value1 = 1;
                master.WriteSingleRegister(1, registerAddress, value1);
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            Analog_signal(0, textBox5);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (timer6.Enabled)
            {
                button38.Text = "Включить TA3";
                timer6.Enabled = false;
                textBox21.Text = default;
                ushort registerAddress = 61;
                byte value1 = 0;
                master.WriteSingleRegister(1, registerAddress, value1);
            }
            else
            {
                button38.Text = "Отключить TA3";
                timer6.Enabled = true;
                ushort registerAddress = 61;
                byte value1 = 1;
                master.WriteSingleRegister(1, registerAddress, value1);
            }
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            ushort startAddress = 43;
            ushort numOfPoints = 2;
            ushort[] holding_register = master.ReadHoldingRegisters(slaveID, startAddress, numOfPoints);

            float[] floatData = new float[2];
            Buffer.BlockCopy(holding_register, 0, floatData, 0, 4);
            textBox21.Text = floatData[0].ToString("0.000");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button25.Text = "Включить TA2";
                timer1.Enabled = false;
                textBox7.Text = default;
                ushort registerAddress = 60;
                byte value1 = 0;
                master.WriteSingleRegister(1, registerAddress, value1);
            }
            else
            {
                button25.Text = "Отключить TA2";
                timer1.Enabled = true;
                ushort registerAddress = 60;
                byte value1 = 1;
                master.WriteSingleRegister(1, registerAddress, value1);

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Analog_signal(1, textBox7);
        }
        private void button26_Click(object sender, EventArgs e)
        {
            if (timer5.Enabled)
            {
                button26.Text = "Включить TV1";
                timer5.Enabled = false;
                textBox8.Text = default;
                ushort registerAddress = 62;
                byte value1 = 0;
                master.WriteSingleRegister(1, registerAddress, value1);
            }
            else
            {
                button26.Text = "Отключить TV1";
                timer5.Enabled = true;
                ushort registerAddress = 62;
                byte value1 = 1;
                master.WriteSingleRegister(1, registerAddress, value1);
            }
        }



        private void timer5_Tick(object sender, EventArgs e)
        {
            //Analog_signal(2, textBox8);
            ushort startAddress = 4;
            ushort numOfPoints = 1;
            ushort[] holding_register = master.ReadHoldingRegisters(slaveID, startAddress, numOfPoints);
            textBox8.Text = holding_register[0].ToString();


        }
        byte q1;
        byte q2;
        byte q3;
        byte q4;
        byte q;


        void Check_Vikluch_Red()
        {
            Panel[] massiv = new Panel[] { panel3, panel1, panel2, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
            panel11, panel17, panel12, panel13, panel18, panel14, panel15, panel16};
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i].BackColor = Color.Red;
            }

        }
        private void button41_Click(object sender, EventArgs e)
        {



        }

        void RR1(Panel panel_q1, Panel panel_q2, Panel panel_q3)
        {

            Panel[] massiv = new Panel[] { panel3, panel1, panel2, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
            panel11, panel17, panel12, panel13, panel18, panel14, panel15, panel19, panel21, panel20, panel22, panel25, panel24 , panel27, panel28};
            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i] == panel_q1 | massiv[i] == panel_q2 | massiv[i] == panel_q3)
                    continue;
                massiv[i].BackColor = Color.Red;
            }

            if (panel_q1.BackColor == Color.Green)
            {
                q1 = 1;
                q = (byte)(q1 | q2 | q3 | q4);
            }
            if (panel_q1.BackColor == Color.Red)
            {
                q1 = 0;
                q = (byte)(q1 | q2 | q3 | q4);
            }
            if (panel_q2.BackColor == Color.Green)
            {
                q2 = 2;
                q = (byte)(q1 | q2 | q3 | q4);
            }
            if (panel_q2.BackColor == Color.Red)
            {
                q2 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel_q3.BackColor == Color.Green)
            {
                q3 = 4;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel_q3.BackColor == Color.Red)
            {
                q3 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel16.BackColor == Color.Green)
            {
                q4 = 8;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel16.BackColor == Color.Red)
            {
                q4 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel26.BackColor == Color.Green)
            {
                q4 = 8;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel26.BackColor == Color.Red)
            {
                q4 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel23.BackColor == Color.Green)
            {
                q4 = 8;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel23.BackColor == Color.Red)
            {
                q4 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            ushort registerAddress = 6;
            byte value1 = q;
            master.WriteSingleRegister(1, registerAddress, value1);
            Potok_znach_in_vikluch();

        }


        void RR1(Panel panel_q1, Panel panel_q2, Panel panel_q3, Panel panel_q4)
        {

            Panel[] massiv = new Panel[] { panel3, panel1, panel2, panel4, panel5, panel6, panel7, panel8, panel9, panel10,
            panel11, panel17, panel12, panel13, panel18, panel14, panel15, panel16, panel19, panel21, panel20, panel26, panel22, panel25, panel24 ,panel23, panel27, panel28};
            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i] == panel_q1 | massiv[i] == panel_q2 | massiv[i] == panel_q3 | massiv[i] == panel_q4)
                    continue;
                massiv[i].BackColor = Color.Red;
            }

            //if (groupBox12.Enabled == false)
            //{
            //    q4 = 0;
            //    q = (byte)(q1 | q2 | q3 | q4);
            //}

            if (panel_q1.BackColor == Color.Green)
            {
                q1 = 1;
                q = (byte)(q1 | q2 | q3 | q4);
            }
            if (panel_q1.BackColor == Color.Red)
            {
                q1 = 0;
                q = (byte)(q1 | q2 | q3 | q4);
            }
            if (panel_q2.BackColor == Color.Green)
            {
                q2 = 2;
                q = (byte)(q1 | q2 | q3 | q4);
            }
            if (panel_q2.BackColor == Color.Red)
            {
                q2 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel_q3.BackColor == Color.Green)
            {
                q3 = 4;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel_q3.BackColor == Color.Red)
            {
                q3 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel_q4.BackColor == Color.Green)
            {
                q4 = 8;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            if (panel_q4.BackColor == Color.Red)
            {
                q4 = 0;
                q = (byte)(q1 | q2 | q3 | q4);

            }
            ushort registerAddress = 6;
            byte value1 = q;
            master.WriteSingleRegister(1, registerAddress, value1);
            Potok_znach_in_vikluch();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button22_Click(object sender, EventArgs e)
        {
            button22.Enabled = false;
            button21.Enabled = true;
            Block_tabPage_pri_puske(tabPage10, groupBox12);

            if (radioButton14.Checked)  //режим защиты АВР секционного выключателя    
            {
                timer7.Enabled = true;
                if (checkBox19.Checked)
                {

                    Registr_output_int(41, 1);//напряжение уставки АВР секционного выключателя            
                    Registr_output_int(42, (ushort)Out_text_int(textBox30)); //АВР  секционного выключателя    

                }
                Registr_output_int(7, 6); //АВР питающего соединения  int 6

            }
            if (radioButton13.Checked)
            {
                //RR1(panel3, panel1, panel2);
                RR1(panel18, panel14, panel15, panel16);

                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  
                timer7.Enabled = false;

            }
        }
        private void button20_Click(object sender, EventArgs e)       //АВР питающего соединения
        {
            button20.Enabled = false;
            button19.Enabled = true;
            Block_tabPage_pri_puske(tabPage9, groupBox11);

            if (radioButton12.Checked)  //режим защиты АВР питающего соединения
            {
                timer7.Enabled = true;
                if (checkBox16.Checked)
                {

                    Registr_output_int(39, 1);//напряжение уставки АВР питающего соединения                  
                    Registr_output_int(40, (ushort)Out_text_int(textBox27)); //АВР питающего соединения

                }
                Registr_output_int(7, 5); //АВР питающего соединения  int 5

            }
            if (radioButton11.Checked)
            {
                RR1(panel17, panel12, panel13);
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  
                timer7.Enabled = false;
               
                

            }
        }


        private void button13_Click(object sender, EventArgs e)     //Включить режим дифференциальной защиты Трансформатора 
        {
            button13.Enabled = false;
            button12.Enabled = true;
            Block_tabPage_pri_puske(tabPage7, groupBox4);

            if (radioButton8.Checked)  //режим защиты дифференциальной защиты трансформатора
            {
                timer7.Enabled = true;
                if (checkBox2.Checked)
                {

                    Registr_output_float(35, Out_text_float(textBox12)); //дифференциальный ток уставки ДЗ трансформатора                 
                    Registr_output_int(33, 1); //ДЗ трансформатора
                }
                if (checkBox10.Checked)
                {

                    Registr_output_float(38, Out_text_float(textBox18)); //уставка коэффициента трансформации                
                    Registr_output_int(36, 1); //задать коэф -т трансформации
                }
                Registr_output_int(7, 4); //ДЗ ЛЭП  int 4

            }
            if (radioButton7.Checked)
            {
                RR1(panel7, panel8, panel9);
                
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  
                timer7.Enabled = false;

            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox12.Text = default;
            textBox10.Text = default;
            textBox18.Text = default;

            checkBox10.Checked = default;
            checkBox2.Checked = default;

            Registr_output_float(34, Out_text_float(textBox12)); //дифференциальный ток уставки ДЗ трансформатора                 
            Registr_output_int(35, 0); //ДЗ трансформатора
            Registr_output_float(38, Out_text_float(textBox18)); //уставка коэффициента трансформации                
            Registr_output_int(36, 0); //задать коэф -т трансформации

        }

        private void button9_Click(object sender, EventArgs e)   //Включить режим дифференциальной защиты ЛЭП
        {
            button9.Enabled = false;
            button8.Enabled = true;
            Block_tabPage_pri_puske(tabPage4, groupBox2);

            if (radioButton4.Checked)  //режим защиты дифференциальной защиты ЛЭП
            {
                timer7.Enabled = true;
                if (checkBox7.Checked)
                {
                    
                    Registr_output_float(31, Out_text_float(textBox11)); //дифференциальный ток уставки ДЗ ЛЭП                   
                    Registr_output_int(32, 1); //ДЗ ЛЭП

                }
                Registr_output_int(7, 3); //ДЗ ЛЭП  int 3

            }
            if (radioButton3.Checked)
            {
                RR1(panel4, panel5, panel6);
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  
                timer7.Enabled = false;
            }
        }
        private void button6_Click(object sender, EventArgs e)     //Включить режим работы МТЗ
        {
            button6.Enabled = false;
            button7.Enabled = true;
            Block_tabPage_pri_puske(tabPage3, groupBox1);
            if (radioButton2.Checked)  //режим защиты мтз и то
            {
                timer7.Enabled = true;
                if (checkBox1.Checked)
                {
                    Registr_output_float(20, Out_text_float(textBox1)); //ток уставки МТЗ1
                    Registr_output_int(21, (ushort)Out_text_int(textBox2)); //Время МТЗ1
                    Registr_output_int(18, 1); //разрешить МТЗ1
                    
                }
                if (checkBox3.Checked)
                {
                    Registr_output_int(22, 1); // разрешить МТЗ1 по напряжению
                    Registr_output_int(23, (ushort)Out_text_int(textBox3)); // уставка МТЗ1 по напряжению
                }


                if (checkBox5.Checked)
                {
                    Registr_output_float(27, Out_text_float(textBox4)); //ток уставки МТЗ2
                    Registr_output_int(28, (ushort)Out_text_int(textBox6)); //Время МТЗ2
                    Registr_output_int(25, 1); //разрешить МТЗ2
                    
                }

                if (checkBox4.Checked)
                {
                    Registr_output_int(24, 1); // разрешить МТЗ1 зависимость от тока

                }
                Registr_output_int(7, 2); //МТЗ  int 2

            }
            if (radioButton1.Checked)
            {
                RR1(panel3, panel1, panel2);
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  

                timer7.Enabled = false;

            }
        }
        private void button18_Click(object sender, EventArgs e) //Включить режи работы АПВ
        {
            Registr_output_int(8, 0); //разрешить АПВ


            button18.Enabled = false;
            button15.Enabled = true;
            Block_tabPage_pri_puske(tabPage8, groupBox8);


            if (radioButton10.Checked)
            {
                timer7.Enabled = true;
                Registr_output_int(7, 1); //регистр для включения АПВ(1)
                if (checkBox9.Checked)
                {
                    Registr_output_int(8, 1); //разрешить АПВ
                    Registr_output_float(10, Out_text_float(textBox24)); //регистр с пределом тока уставки 
             
                    if (checkBox8.Checked)
                    {
                        Registr_output_int(12, (ushort)Out_text_int(textBox23)); //время АПВ1
                        Registr_output_int(11, 1); //разрешить АПВ1
                       

                    }
                    if (checkBox6.Checked) 
                    {
                        Registr_output_int(14, (ushort)Out_text_int(textBox20)); //время АПВ  
                        Registr_output_int(13, 1); //разрешить АПВ2
                                           

                    }                   
                }
            }
            if (radioButton9.Checked)
            {
                RR1(panel10, panel11, panel13);
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)
                timer7.Enabled = false;
                  
               
               
            }

        }
        private void button17_Click(object sender, EventArgs e) //сброс АВР секционного выключателя
        {
            textBox30.Text = default;
            checkBox19.Checked = default;

            Registr_output_int(41, 0);//напряжение уставки АВР питающего соединения отключить             
            Registr_output_int(42, 0); //АВР питающего соединения отключить
        }

        private void button16_Click(object sender, EventArgs e)  //сброс АВР питающего соединения
        {
            textBox27.Text = default;
            checkBox16.Checked = default;

            Registr_output_int(39, 0);//напряжение уставки АВР питающего соединения отключить             
            Registr_output_int(40, 0); //АВР питающего соединения отключить

        }


        private void button3_Click(object sender, EventArgs e)  //спрос ДЗ ЛЭП
        {
            textBox11.Text = default;        
            checkBox7.Checked = default;
            Registr_output_float(33, Out_text_float(textBox11)); //дифференциальный ток уставки ДЗ ЛЭП
            Registr_output_int(34, 0); //ДЗ ЛЭП
        }
        private void button14_Click(object sender, EventArgs e)   // сброс АПВ
        {
            Registr_output_int(8, 0); // разрешить АПВ откл
            textBox24.Text = default;
            textBox23.Text = default;
            textBox20.Text = default;

            checkBox6.Checked = default;
            checkBox8.Checked = default;
            checkBox9.Checked = default;
            checkBox8.Enabled = false;
            checkBox6.Enabled = false;

            Registr_output_int(14, (ushort)Out_text_int(textBox20)); //время АПВ2 откл
            Registr_output_int(13, 0); //разрешить АПВ2 откл

            Registr_output_int(12, (ushort)Out_text_int(textBox23)); //время АПВ1 откл
            Registr_output_int(11, 0); //разрешить АПВ1 откл

            Registr_output_float(10, Out_text_float(textBox24)); //регистр с пределом тока уставки откл 
        }
        private void button2_Click(object sender, EventArgs e)    // сброс МТЗ
        {
            textBox1.Text = default;
            textBox2.Text = default;
            textBox3.Text = default;
            textBox4.Text = default;
            textBox6.Text = default;

            checkBox1.Checked = default;
            checkBox3.Checked = default;
            checkBox4.Checked = default;
            checkBox5.Checked = default;
            checkBox6.Checked = default;



            Registr_output_int(18, 0); //разрешить МТЗ1
            Registr_output_float(20, Out_text_float(textBox1)); //ток уставки МТЗ1
            Registr_output_int(21, (ushort)Out_text_int(textBox2)); //Время МТЗ1
     


            Registr_output_int(22, 0); // разрешить МТЗ1 по напряжению
            Registr_output_int(23, (ushort)Out_text_int(textBox3)); // уставка МТЗ1 по напряжению




            Registr_output_int(25, 0); //разрешить МТЗ2
            Registr_output_float(27, Out_text_float(textBox4)); //ток уставки МТЗ2
            Registr_output_int(28, (ushort)Out_text_int(textBox6)); //Время МТЗ2


            Registr_output_int(24, 0); // разрешить МТЗ1 зависимость от тока


        }



        void Registr_output_float(ushort adress, float value)    //отправка регистра с сылкой на указатель????? число с плавающей точкой
        {
            ushort[] unitData = new ushort[2];
            float[] floatData = new float[1] { value };
            Buffer.BlockCopy(floatData, 0, unitData, 0, 4);

            master.WriteSingleRegister(slaveID, adress, unitData[1]);
        }
        void Registr_output_int(ushort adress, ushort value)     // отправка регистра с целым числом
        {
            master.WriteSingleRegister(slaveID, adress, value);
        }
      

        int Out_text_int(TextBox text)      //преобразовать текст в целое число 
        {
            if (text.Text == "")
                return 0;
            else
                return Convert.ToInt32(text.Text);              
        }

        float Out_text_float(TextBox text)  //преобразовать текст в число с плавающей точкой
        {
            if (text.Text == "")
                return 0;
            else
                return Convert.ToSingle(text.Text);
        }


        ushort Registr_in_int(ushort startAddress)    //отправить регистр целого числа
        {
            ushort numOfPoints = 1;
            ushort[] holding_register = master.ReadHoldingRegisters(slaveID, startAddress, numOfPoints);
            return holding_register[0];
        }

        void Potok_znach_in_vikluch()   //поток значений положений выключателей
        {

            //чтение сигналов 1 выключателя
            if (Registr_in_int(29) == 0)
            {
                panel3.BackColor = Color.Red;
                panel4.BackColor = Color.Red;
                panel7.BackColor = Color.Red;
                panel10.BackColor = Color.Red;
                panel17.BackColor = Color.Red;
                panel18.BackColor = Color.Red;
                panel19.BackColor = Color.Red;
                panel22.BackColor = Color.Red;
                panel27.BackColor = Color.Red;
            }
            else if (Registr_in_int(29) == 1)
            {
                panel3.BackColor = Color.Green;
                panel4.BackColor = Color.Green;
                panel7.BackColor = Color.Green;
                panel10.BackColor = Color.Green;
                panel17.BackColor = Color.Green;
                panel18.BackColor = Color.Green;
                panel19.BackColor = Color.Green;
                panel22.BackColor = Color.Green;
                panel27.BackColor = Color.Green;
            }

            //чтение сигналов 2 выключателя
            if (Registr_in_int(15) == 0)
            {
                panel1.BackColor = Color.Red;
                panel5.BackColor = Color.Red;
                panel8.BackColor = Color.Red;
                panel11.BackColor = Color.Red;
                panel12.BackColor = Color.Red;
                panel14.BackColor = Color.Red;
                panel21.BackColor = Color.Red;
                panel25.BackColor = Color.Red;
                panel28.BackColor = Color.Red;
            }
            else if (Registr_in_int(15) == 1)
            {
                panel1.BackColor = Color.Green;
                panel5.BackColor = Color.Green;
                panel8.BackColor = Color.Green;
                panel11.BackColor = Color.Green;
                panel12.BackColor = Color.Green;
                panel14.BackColor = Color.Green;
                panel21.BackColor = Color.Green;
                panel25.BackColor = Color.Green;
                panel28.BackColor = Color.Green;
            }

            //чтение сигналов 3 выключателя
            if (Registr_in_int(16) == 0)
            {
                panel2.BackColor = Color.Red;
                panel6.BackColor = Color.Red;
                panel9.BackColor = Color.Red;
                panel13.BackColor = Color.Red;
                panel15.BackColor = Color.Red;
                panel20.BackColor = Color.Red;
                panel24.BackColor = Color.Red;
            }
            else if (Registr_in_int(16) == 1)
            {
                panel2.BackColor = Color.Green;
                panel6.BackColor = Color.Green;
                panel9.BackColor = Color.Green;
                panel13.BackColor = Color.Green;
                panel15.BackColor = Color.Green;
                panel20.BackColor = Color.Green;
                panel24.BackColor = Color.Green;
            }
            //чтение сигналов 4 выключателя
            if (Registr_in_int(17) == 0)
            {
                panel26.BackColor = Color.Red;
                panel23.BackColor = Color.Red;
                panel16.BackColor = Color.Red;
            }
            else if (Registr_in_int(17) == 1)
            {
                panel26.BackColor = Color.Green;
                panel16.BackColor = Color.Green;
                panel23.BackColor = Color.Green;
            }
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            Potok_znach_in_vikluch();
        }

        private void label106_Click(object sender, EventArgs e)
        {

        }


        //===================================================
        //===================================================
        private void panel19_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton6, button11, panel19);
            if (radioButton5.Checked & button10.Enabled)
                RR1(panel19, panel21, panel20, panel26);
        }

        private void panel21_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton6, button11, panel21);
            if (radioButton5.Checked & button10.Enabled)
                RR1(panel19, panel21, panel20, panel26);
        }

        private void panel20_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton6, button11, panel20);
            if (radioButton5.Checked & button10.Enabled)
                RR1(panel19, panel21, panel20, panel26);
        }

        private void panel26_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton6, button11, panel26);
            if (radioButton5.Checked & button10.Enabled)
                RR1(panel19, panel21, panel20, panel26);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            button11.Enabled = true;
            button10.Enabled = false;
            RazBlock_tabPage_pri_puske(groupBox3);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }
        //===================================================
        //===================================================



        private void panel22_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton16, button35, panel22);
            if (radioButton15.Checked & button34.Enabled)
                RR1(panel22, panel25, panel24, panel23);
        }

        private void panel25_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton16, button35, panel25);
            if (radioButton15.Checked & button34.Enabled)
                RR1(panel22, panel25, panel24, panel23);
        }

        private void panel24_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton16, button35, panel24);
            if (radioButton15.Checked & button34.Enabled)
                RR1(panel22, panel25, panel24, panel23);
        }

        private void panel23_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton16, button35, panel23);
            if (radioButton15.Checked & button34.Enabled)
                RR1(panel22, panel25, panel24, panel23);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            button35.Enabled = true;
            button34.Enabled = false;
            RazBlock_tabPage_pri_puske(groupBox17);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }
        //===================================================
        //===================================================

        private void button36_Click(object sender, EventArgs e)
        {
            button37.Enabled = true;
            button36.Enabled = false;
            RazBlock_tabPage_pri_puske(groupBox18);
            //Check_Vikluch_Red();
            timer7.Enabled = false;
        }

        private void panel27_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton18, button37, panel27);
            if (radioButton17.Checked & button36.Enabled)
                RR1(panel27, panel28, panel24);
        }

        private void panel28_Click(object sender, EventArgs e)
        {
            Poverenie_vikluchateley(radioButton18, button37, panel28);
            if (radioButton17.Checked & button36.Enabled)
                RR1(panel27, panel28, panel24);
        }
        //===================================================
        //===================================================
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox15, e);
            Stroka_float(textBox19, e);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox15, e);
            Stroka_int(e);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox19, label120, checkBox15);
            Color_C(textBox17, label119, checkBox15);
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox16);
        }
        //===================================================
        //===================================================
        private void textBox10_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox14, e);
            Stroka_float(textBox10, e);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox10, label41, checkBox14);
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox15);
        }
        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox13, e);
            Stroka_float(textBox14, e);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox14, label43, checkBox13);
            if (checkBox13.Checked == true)
            {
                checkBox11.Enabled = true;
                checkBox12.Enabled = true;
            }

            else
            {
                checkBox11.Enabled = false;
                checkBox12.Enabled = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox13, label42, checkBox12);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox12, e);
            Stroka_int(e);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            Color_C(textBox9, label38, checkBox11);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_b(checkBox11, e);
            Stroka_int(e);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Check_group(groupBox14);
            checkBox12.Enabled = false;
            checkBox11.Enabled = false;
            //Check_Vikluch_Red();
        }
        private void button37_Click(object sender, EventArgs e)
        {
            button37.Enabled = false;
            button36.Enabled = true;
            Block_tabPage_pri_puske(tabPage13, groupBox18);

            if (radioButton18.Checked)  //режим защиты от КЗ на Землю
            {
                timer7.Enabled = true;
                if (checkBox15.Checked)
                {
                    Registr_output_float(48, Out_text_float(textBox19)); //ток уставки защиты от КЗ на Землю
                    Registr_output_int(46, (ushort)Out_text_int(textBox17)); //Время защиты от КЗ на Землю
                    Registr_output_int(45, 1); //разрешить МТЗ1

                }
                Registr_output_int(7, 7); //защиты от КЗ на Землю  int 7

            }
            if (radioButton17.Checked)
            {
                RR1(panel27, panel28, panel16);
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  
                timer7.Enabled = false;
                 
                //RR1(panel3, panel1, panel2);

            }
        }


        private void button33_Click(object sender, EventArgs e)
        {
            textBox19.Text = default;
            textBox17.Text = default;

            checkBox15.Checked = default;



            Registr_output_int(45, 0); //разрешить GND
            Registr_output_float(48, Out_text_float(textBox1)); //ток уставки GND
            Registr_output_int(46, (ushort)Out_text_int(textBox2)); //Время GND

        }

        private void button35_Click(object sender, EventArgs e)
        {
            button35.Enabled = false;
            button34.Enabled = true;
            Block_tabPage_pri_puske(tabPage12, groupBox17);

            if (radioButton16.Checked)  //режим защиты дифференциальной защиты шины
            {
                timer7.Enabled = true;
                if (checkBox14.Checked)
                {
                    Registr_output_float(51, Out_text_float(textBox10)); //дифференциальный ток уставки ДЗ шииныП                   
                    Registr_output_int(49, 1); //ДЗ шины

                }
                Registr_output_int(7, 8); //ДЗ ЛЭП  int 8

            }
            if (radioButton15.Checked)
            {
                RR1(panel22, panel23, panel24, panel25);
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  
                timer7.Enabled = false;
                
                //RR1(panel3, panel1, panel2);

            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox10.Text = default;

            checkBox14.Checked = default;

            Registr_output_int(49, 0); //разрешить ДЗ ШИН
            Registr_output_float(51, Out_text_float(textBox1)); //ток уставки ДЗ ШИН
        }
        private void button11_Click(object sender, EventArgs e)
        {
            button11.Enabled = false;
            button10.Enabled = true;
            Block_tabPage_pri_puske(tabPage11, groupBox3);
            Registr_output_int(52, 0); //разрешить АПВ шин


            if (radioButton6.Checked)
            {
                
                timer7.Enabled = true;
                Registr_output_int(7, 9); //регистр для включения АПВ(1) шин
                if (checkBox13.Checked)
                {
                    Registr_output_int(52, 1); //разрешить АПВ шин
                    Registr_output_float(54, Out_text_float(textBox14)); //регистр с пределом тока уставки 

                    if (checkBox12.Checked)
                    {
                        Registr_output_int(55, (ushort)Out_text_int(textBox13)); //время АПВ1 шин
                        Registr_output_int(56, 1); //разрешить АПВ1 шин


                    }
                    if (checkBox11.Checked)
                    {
                        Registr_output_int(57, (ushort)Out_text_int(textBox9)); //время АПВ2  шин
                        Registr_output_int(58, 1); //разрешить АПВ2 шин

                    }
                }
            }
            if (radioButton5.Checked)
            {
                RR1(panel19, panel21, panel20, panel26);
                Registr_output_int(7, 0);//регистр для включения ручного режима(0)  
                timer7.Enabled = false;
               
            }

        }

        private void button31_Click(object sender, EventArgs e)
        {
            Registr_output_int(52, 0); // разрешить АПВ откл
            textBox14.Text = default;
            textBox13.Text = default;
            textBox9.Text = default;

            checkBox13.Checked = default;
            checkBox12.Checked = default;
            checkBox11.Checked = default;
            checkBox12.Enabled = false;
            checkBox11.Enabled = false;

            Registr_output_int(57, (ushort)Out_text_int(textBox20)); //время АПВ2 откл
            Registr_output_int(58, 0); //разрешить АПВ2 откл

            Registr_output_int(55, (ushort)Out_text_int(textBox23)); //время АПВ1 откл
            Registr_output_int(56, 0); //разрешить АПВ1 откл

            Registr_output_float(53, Out_text_float(textBox24)); //регистр с пределом тока уставки откл
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                streamWriter.WriteLine($"t,s\tTV1,V");
                for (int i = 0; i < chart2.Series[0].Points.Count; i++)
                {
                    streamWriter.WriteLine($"{i}\t{chart2.Series[0].Points[i].YValues[0]}");
                }
                streamWriter.Close();
            }
        }

        private void button41_MouseClick(object sender, MouseEventArgs e)
        {
            //Init();
            Registr_output_int(7, 0);
            foreach (Panel pn in tabPage1.Controls.OfType<Panel>())
            {
                pn.BackColor = Color.Red;
            }
            q = 0;
            ushort registerAddress = 6;
            byte value1 = q;
            master.WriteSingleRegister(1, registerAddress, value1);
            Potok_znach_in_vikluch();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                timer7.Enabled = false;
                Registr_output_int(7, 0);
                foreach (Panel pn in tabPage1.Controls.OfType<Panel>())
                {
                    pn.BackColor = Color.Red;
                }
                q = 0;
                ushort registerAddress = 6;
                byte value1 = q;
                master.WriteSingleRegister(1, registerAddress, value1);
                Potok_znach_in_vikluch();
                serialPort1.Close();
            }
            catch
            {
            
            }
            
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Enabled = false;
                button42.Text = "Включить график\"Ток\"и\"Напряжение\"";


            }
            else
            {
                timer2.Enabled = true;
                button42.Text = "Отключить график\"Ток\"и\"Напряжение\"";
            }
            if (timer3.Enabled)
            {
                timer3.Enabled = false;
                button42.Text = "Включить график\"Ток\"и\"Напряжение\"";
            }
            else
            {
                timer3.Enabled = true;
                button42.Text = "Отключить график\"Ток\"и\"Напряжение\"";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Ruchnoy_rezhim_group(groupBox14);
        }
    }


}
