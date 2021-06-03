using System;
using System.Data.OleDb;
using System.Windows.Forms;


namespace JSC_Aeroflot 
{    
    public partial class Form3 : Form
    {
        private static string connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Аэрофлот.mdb";
        private OleDbConnection myConnection;
        public Form3()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string Surname = textBox2.Text;
            string Name = textBox3.Text;
            string Phone = textBox4.Text;
            string query = "INSERT INTO Клиенты ([Код клиента], Фамилия, Имя, Телефон) VALUES (" + kod + ", '" + Surname + "', '" + Name + "', '" + Phone + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Клиент добавлен");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
