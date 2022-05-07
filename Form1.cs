using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LP9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "-1,5";
            textBox2.Text = "3,5";
            textBox3.Text = "0,5";
            textBox4.Text = "-1,5";
            textBox5.Text = "0,75";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double xmin = double.Parse(textBox1.Text);
            double xmax = double.Parse(textBox2.Text);
            double h = double.Parse(textBox3.Text);
            double b = double.Parse(textBox4.Text);
            double c = double.Parse(textBox5.Text);


            int count = (int)Math.Ceiling(Math.Abs(xmax - xmin) / Math.Abs(h)) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];

            for (int i = 0; i < count; i++)
            {
                x[i] = xmax + h * i;
                double a = -1.25;
                y1[i] = (Math.Pow(10, -2) * b * c / x[i]) + Math.Cos(Math.Sqrt(Math.Pow(a, 3)) * x[i]);
                y2[i] = Math.Cos(x[i]);
            }
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Math.Abs(h);
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}