using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Task_Management
{
    
    public partial class Form1 : Form
    {
        public static string email = "";
        public static string name = "";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        
        Task task = new Task();
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            con = new MySqlConnection("Server=localhost;Database=stark;user=root;Pwd=tonystark;SslMode=none");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM user where email='" + txtUser.Text + "' AND password='" + txtPass.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                email = dr.GetString("email");
                name = dr.GetString("username");
                //MessageBox.Show("Login sucess Welcome to Homepage https://csharp-console-examples.com");
                task.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            email = "";
            name = "";
        }
    }
}
