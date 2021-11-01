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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runQuery();
        }

        private void runQuery()
        {
            string query = textBox1.Text;

            if(query == "")
            {
                MessageBox.Show("Please insert a query");
                return;
            }

            string mySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bigd";

            MySqlConnection databaseConnection = new MySqlConnection(mySQLConnectionString);

            MySqlCommand command = new MySqlCommand(query, databaseConnection);
            command.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Query returned values");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine("Value: " + reader.GetString(i));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Query excecuted");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);
            }

        }
    }
}
