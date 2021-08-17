using System;
using System.IO.Ports;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using NationalInstruments.VisaNS;

                        
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string[] rsetting = {
            "000000000000000000001", "000000000000000000010",
            "000000000000000000011", "000000000000000000100",
            "000000000000000000111", "000000000000000001000",
            "000000000000000001111", "000000000000000010000",
            "000000000000000011111", "000000000000000100000",
            "000000000000000111111", "000000000000001000000",
            "000000000000001111111", "000000000000010000000",
            "000000000000011111111", "000000000000100000000",
            "000000000000111111111", "000000000001000000000",
            "000000000001111111111", "000000000010000000000",
            "000000000011111111111", "000000000100000000000",
            "000000000111111111111", "000000001000000000000",
            "000000001111111111111", "000000010000000000000",
            "000000011111111111111", "000000100000000000000",
            "000000111111111111111", "000001000000000000000",
            "000001111111111111111", "000010000000000000000",
            "000011111111111111111", "000100000000000000000",
            "000111111111111111111", "001000000000000000000",
            "001111111111111111111", "010000000000000000000",
            "011111111111111111111", "100000000000000000000"
//            "111111111111111111111", "000000000000000000000"
        } ;

        private MessageBasedSession mbSession;
        string tableLab = "抵抗No\t測定比（No0=1）\t校正値\n";

        public Form1()
        {
            InitializeComponent();

            richTextBoxOutput.Text = tableLab;

        }

        private void setResi(string seriNum)
        {
            try {
                serialPort1.Open();
                serialPort1.Write(seriNum);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            serialPort1.Close();
        }

        private double getTmpr()
        {
            double resp = 0;

            try {
                serialPort1.Open();
                serialPort1.Write("T");
                Thread.Sleep(100);
                resp = double.Parse(serialPort1.ReadLine());
                serialPort1.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            return resp;
        }

        private void serialReset()
        {
            string[] ptName = SerialPort.GetPortNames();

            serialPort1.PortName =  ptName[0];

            if (serialPort1.IsOpen)
                serialPort1.Close();
            try
            {
                serialPort1.Open();
                Thread.Sleep(3000);
                serialPort1.Close();
                richTextBox1.Text = ptName[0] + "\n" + richTextBox1.Text + "\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void dmmReset()
        {
            try　//通信部分
            {
                mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open("GPIB0::" + numericUpDownGpib.Value.ToString() + "::INSTR");
                mbSession.Write("CONF:RES");
                mbSession.Write("RES:NPLC 100");
                mbSession.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("接続エラー\n" + ex.Message);
            }
        }

        double dmmMeas()
        {
            double rtnData = 0;

            try　//通信部分
            {
                mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open("GPIB0::" + numericUpDownGpib.Value.ToString() + "::INSTR");
                rtnData = double.Parse(mbSession.Query("READ?").Replace("\n", ""));//末尾にNOHMがつくのでNで分割
                mbSession.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("接続エラー\n" + ex.Message);
            }

            richTextBox1.Text = rtnData.ToString() + "\n" + richTextBox1.Text;
            return rtnData;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            double[] dmmAve = new double[10];
            double tempdata0 = 0, tempdata1 = 0;
            double[] resiRatio = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            double[] resiValue = new double[21];
            double[] tmprValue = new double[21];
            double data1024 = 0;
            string saveStr = "";
            int numberOfLoop;

            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            richTextBoxOutput.Text = "";

            dmmReset();

            MessageBox.Show("DMMを校正します\nDMMに100kΩ標準抵抗器を接続してください\n\nOKを押すと校正開始します");

            DmmCal();
            if (buttonStop.Enabled == false) goto END_MEAS;

            MessageBox.Show("ディジタル可変抵抗を自己校正します\nDMMにディジタル可変抵抗を接続してください");

            serialReset();

            for (int j = 0; j < rsetting.Length; j++)
            {
                setResi("R" + rsetting[j]);

                if (j > 132) numberOfLoop = 5;
                else numberOfLoop = 2;
                for (int k = 0; k < numberOfLoop; k++)//同じ測定2周やって最後の１周だけ使う
                {
                    for (int i = 0; i < dmmAve.Length; i++)
                    {
                        if(sleepSec(1) == true) goto END_MEAS;
                        if (richTextBox1.Visible == true) labelGpib.Text = j.ToString() + " " + k.ToString() + " " + i.ToString();
                        else labelGpib.Text = "GPIB ADDR";
                        dmmAve[i] = dmmMeas();
                    }
                }

                if (j % 2 == 0)
                {
                    tempdata0 = dmmAve.Average();
                }
                else
                {
                    tmprValue[(j + 1) / 2] = getTmpr();
                    tempdata1 = dmmAve.Average();
                    if (j == 21) data1024 = dmmAve.Average();
                    resiRatio[(j + 1) / 2] = tempdata1 / tempdata0 * resiRatio.Sum();
                    richTextBoxOutput.Text += ((j + 1) / 2).ToString("       00") + "\t" + resiRatio[(j + 1) / 2].ToString("  000000.0000") + "  \t" + tmprValue[(j + 1) / 2].ToString("F2") + "\n";
                }
            }

            richTextBoxOutput.Text = tableLab;
            for (int i = 1; i < resiRatio.Length; i++)
            {
                resiValue[i] = (resiRatio[i] / resiRatio[11]) * (double)numericUpDownDmmCal.Value * data1024;
                richTextBoxOutput.Text += i.ToString("       00") + "\t" + resiRatio[i].ToString("  000000.0000") + "  \t" + tmprValue[i].ToString("F2") + "\t" + resiValue[i].ToString("00000000.00") + "\n";
                saveStr += resiValue[i].ToString() + "@" + tmprValue[i].ToString("F2") + ",\n";
            }

            DialogResult dr = MessageBox.Show("自己校正が完了しました\n\n結果を保存します", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                File.WriteAllText(@"C:\Users\denshi\Documents\caldata\" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt", saveStr);
            }

        END_MEAS:

            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void DmmCal()
        {
            double[] dmmStdData = new double[10];


            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < dmmStdData.Length; i++)
                {
                    if (richTextBox1.Visible == true) labelGpib.Text = j.ToString() + " " + i.ToString();
                    else labelGpib.Text = "GPIB ADDR";
                    sleepSec(1);
                    dmmStdData[i] = dmmMeas();
                }
            }
            numericUpDownStdMeas.Value = (decimal)dmmStdData.Average();

            numericUpDownDmmCal.Value = numericUpDownStdCal.Value / numericUpDownStdMeas.Value;
        }

        bool sleepSec(double slp)
        {
            int slpms = (int)(slp * 10);
            bool stopped = false;

            for (int i = 0; i < slpms ; i++)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                if (buttonStop.Enabled == false)
                {
                    stopped = true;
                    break;
                }
            }
            return stopped;
        }

        private void labelGpib_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible == false)
                richTextBox1.Visible = true;
            else
                richTextBox1.Visible = false;
        }
    }

}
