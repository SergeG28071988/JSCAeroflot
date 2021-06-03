using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace JSC_Aeroflot
{
    public partial class Form4 : Form
    {
        private static string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Аэрофлот.mdb";
        private OleDbConnection myConnection;
        public Form4()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            int kod_2 = Convert.ToInt32(textBox2.Text);
            string name = textBox3.Text;
            string date = textBox4.Text;
            string price = textBox5.Text;
            string quantity = textBox6.Text;
            string profit = textBox7.Text;
            string query = "INSERT INTO Рейсы ([Код направления],[Код клиента], Наименование, Дата, Цена, Количество, Стоимость ) VALUES (" + kod + ", " + kod_2 + ", '" + name + "', '" + date + "', '" + price + "', '" + quantity + "', '" + profit + "' )";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Рейс добавлен");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price;
            double quantity;

            price = Convert.ToDouble(textBox5.Text);
            quantity = Convert.ToDouble(textBox6.Text);

            switch (comboBox1.Text)
            {
                case "*":

                    textBox7.Text = Convert.ToString(price * quantity);
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
