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

namespace Knijniymagazin
{
    public partial class Авторизация : Form
    {
        Query controller;
            public Авторизация()
            {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
            }

        private void button3_Click(object sender, EventArgs e)
        {
            // подключение файла базы данных
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Книжный магазин.mdb");
            // запрос на проверку данных
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("Select Count(*) From PAROLI where login = '" + textBox1.Text + "' and Parol = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                СкладКниги ss = new СкладКниги(); // форма после ввода верных значений логина и пароля
                Поступление sd = new Поступление();
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                   
                }
                else if(textBox1.Text == "larisa" && textBox2.Text == "555"){

                    ss.button1.Visible = false; //показать кнопку «Продажи»
                    ss.button3.Visible = false; //показать кнопку «Клиенты»
                    sd.button1.Visible = false; //показать кнопку «Продажи»
                    sd.button3.Visible = false; //показать кнопку «Клиенты»
                }
                ss.Show(); // открыть форму Form1

            }
            else
            {
                MessageBox.Show("Неправильно введен Логин и (или) Пароль");
            }

        }
    }
}
