using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
         
    {
        string MyConnectionString = "Server=localhost;database=project_fifa;Uid=root;Pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tbl_players";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }    
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Clone();
                }
            }
            
            }
        }
        
    }

