using Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TideDiagram
{
    public partial class Form1 : Form
    {
        Project1 projecta;

        public Form1()
        {
            InitializeComponent();
            projecta = new Project1();
            projecta.WebRequest();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            var objChart = chart1.ChartAreas[0];

            //TimeDate
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            objChart.AxisX.Minimum = projecta.resp.meta.start.ToOADate();
            objChart.AxisX.Maximum = projecta.resp.meta.end.ToOADate();

            //Tide
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = -2;
            objChart.AxisY.Maximum = 2;

            //Clear
            chart1.Series.Clear();

            Series newSeries = new Series("Tide");
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.BorderWidth = 1;
            newSeries.Color = Color.Blue;
            newSeries.XValueType = ChartValueType.DateTime;
            chart1.Series.Add(newSeries);

            for (int i = 0; i < projecta.resp.data.Count; i++)
            {
                chart1.Series[0].Points.AddXY(projecta.resp.data[i].time, projecta.resp.data[i].height);
                Refresh();
            }
        }
    }
}
