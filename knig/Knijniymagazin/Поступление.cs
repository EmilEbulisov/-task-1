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
    public partial class Поступление : Form
    {
        Query controller;
        public Поступление()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdatePostuplenie();
        }

        private void Поступление_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            СкладКниги ss = new СкладКниги();
            ss.Show(); // открыть форму Form1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.DeletePostuplenie(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["NomerDocumenta"].Value.ToString()));
            dataGridView1.DataSource = controller.UpdatePostuplenie();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePostuplenie();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                try
                {
                controller.AddPostuplenie(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dataGridView1.DataSource = controller.UpdatePostuplenie();
            }
                catch
                {
                    MessageBox.Show("у вас ошибка!");
                }
        }
    }
}
