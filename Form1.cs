using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;

namespace Lab3_2
{
    public partial class Form1 : Form
    {
        
        string exp = "";
        public Form1()
        {
            InitializeComponent();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += timer_Tick;
            timer.Enabled = true;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString() + "." + DateTime.Now.Second.ToString();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            exp = textBox1.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Minimum = -10;
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisX.Minimum = -10;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;

            List<double> xi = new List<double>();
            List<double> yi = new List<double>();
            for (double x = -9.9; x <= 10; x +=0.05)
            {
                Argument arg = new Argument("x", x);
                Expression eh = new Expression(exp, arg);
                double y = eh.calculate();
                xi.Add(x);
                yi.Add(y);
            }
            chart1.Series[0].LegendText = "График " + exp;
            for (int i = 0; i < xi.Count; i++)
            {
                chart1.Series[0].Points.AddXY(xi[i], yi[i]);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
        }
    }
}
