using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;


namespace JSC_Aeroflot
{
    public partial class Form5 : Form
    {
        private static string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Аэрофлот.mdb";
        private OleDbConnection myConnection;
        public Form5()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аэрофлотDataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this.аэрофлотDataSet.Продажи);
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.продажиTableAdapter.Fill(this.аэрофлотDataSet.Продажи);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();

            ChartValues<int> directValues = new ChartValues<int>();

            List<string> dates = new List<string>();

            foreach (var directRow in аэрофлотDataSet.Продажи)
            {
                directValues.Add(directRow.Стоимость);

                dates.Add(directRow.Дата.ToShortDateString());
            }
            cartesianChart1.AxisX.Clear();

            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });

            LineSeries directLine = new LineSeries();

            directLine.Title = "Продажи";

            directLine.Values = directValues;

            series.Add(directLine);

            cartesianChart1.Series = series;
        }
    }
}
