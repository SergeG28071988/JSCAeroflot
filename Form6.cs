using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace JSC_Aeroflot
{
    public partial class Form6 : Form
    {
        private static string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Аэрофлот.mdb";
        private OleDbConnection myConnection;
        public Form6()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string date = textBox2.Text;
            string customer = textBox3.Text;
            string direction = textBox4.Text;
            string profit = textBox5.Text;
            string query = "INSERT INTO Продажи ([Код ], Дата,Клиент,Направление, Стоимость ) VALUES (" + kod + ", '" + date + "', '" + customer + "', '" + direction + "', '" + profit + "' )";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о продажах добавлены");
        }
    }
}
