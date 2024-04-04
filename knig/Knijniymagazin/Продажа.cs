using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Knijniymagazin.Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Knijniymagazin
{
    public partial class Продажа : Form
        
    {
        Query controller;
        public Продажа()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdateProdaji();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            СкладКниги ss = new СкладКниги();
            ss.Show(); // открыть форму Form1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateProdaji();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
                controller.AddProdaji(int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text), textBox4.Text, textBox5.Text);
                dataGridView1.DataSource = controller.UpdateProdaji();
                

            //}
            //catch
            //{
            //    MessageBox.Show("у вас ошибка!");
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.DeleteProdaji(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["NomerZakaza"].Value.ToString()));
            dataGridView1.DataSource = controller.UpdateProdaji();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
