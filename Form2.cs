using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace JSC_Aeroflot
{
    public partial class Form2 : Form
    {
        private static string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Аэрофлот.mdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аэрофлотDataSet.Рейсы". При необходимости она может быть перемещена или удалена.
            this.рейсыTableAdapter.Fill(this.аэрофлотDataSet.Рейсы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "аэрофлотDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.аэрофлотDataSet.Клиенты);

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Клиенты WHERE [Код клиента]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Клиент удалён");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.клиентыTableAdapter.Fill(this.аэрофлотDataSet.Клиенты);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Клиенты SET Фамилия ='" + textBox3.Text + "'WHERE [Код клиента]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Фамилия изменена");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
;        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox4.Text);
            string query = "DELETE FROM Рейсы WHERE [Код направления]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Рейс удалён");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox6.Text);
            string query = "UPDATE Рейсы SET Наименование ='" + textBox5.Text + "'WHERE [Код направления]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Рейс изменен");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.рейсыTableAdapter.Fill(this.аэрофлотDataSet.Рейсы);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
