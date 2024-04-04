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
    public partial class СкладКниги : Form
    {
        Query controller;
        public СкладКниги()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
            dataGridView1.DataSource = controller.UpdateKnigi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateKnigi();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                controller.AddKnigi(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, int.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                dataGridView1.DataSource = controller.UpdateKnigi();
            }
            catch
            {
                MessageBox.Show("у вас ошибка!");
            }
            
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Поступление ss = new Поступление();
            ss.Show(); // открыть форму Form1
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Продажа sr = new Продажа();
            sr.Show(); // открыть форму Form1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.DeleteKnigi(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["NomerKnigi"].Value.ToString()));
            dataGridView1.DataSource = controller.UpdateKnigi();

        }
    }
}
