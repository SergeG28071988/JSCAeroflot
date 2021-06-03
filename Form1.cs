using System;
using System.Windows.Forms;

namespace JSC_Aeroflot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор программы Аэрофлот: Сергей Галкин, \nДата релиза: 29.01.2021 г.", "Внимание!!");
        }
    }
}
