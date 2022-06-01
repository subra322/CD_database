using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PI
{
    public partial class CD : Form
    {
        static string connectionString = "datasource='localhost';port=3306;username=root;password=;database=cd;charset=utf8;";
        public CD()
        {
            InitializeComponent();
            Zaloguj();
            Zaznacz();
        }
        private void Pokaz()
        {
           string query = "SELECT * FROM cd";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connectionString))
            {
                DataSet dset = new DataSet();
                adpt.Fill(dset);
                dataGridView1.DataSource = dset.Tables[0];
            }
            databaseConnection.Close();
            dataGridView1.Visible = true;
        }

        private void Zaloguj()
        {
            string query = "SELECT * FROM cd";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                    }
                }
                else
                {
                    Console.WriteLine("Nie znaleziono!");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Dodaj()
        {
            string query = "INSERT INTO cd(`ID`, `Autor`, `Album`, `Opis`) VALUES (NULL, '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Album został dodany!");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Album nie mógł zostać dodany!");
            }
        }
        private void Usun()
        {
            string query = "DELETE FROM `cd` WHERE `cd`.`ID` = '" + textBox5.Text + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Album został usunięty!");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Album nie mógł zostać usunięty!");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pokaz();
            textBox2.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            textBox5.Visible = false;
            button3.Visible = false;


            label6.Visible = true;
            button4.Visible = true;

            textBox6.Visible = false;
            label7.Visible = false;
            textBox7.Visible = false;
            label8.Visible = false;
            textBox8.Visible = false;
            label9.Visible = false;
            textBox9.Visible = false;
            label10.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            label2.Visible = true;
            textBox3.Visible = true;
            label3.Visible = true;
            textBox4.Visible = true;
            label4.Visible = true;
            button2.Visible = true;
            label5.Visible = false;
            textBox5.Visible = false;
            textBox5.Text = "";
            button3.Visible = false;

            textBox6.Visible = false;
            label7.Visible = false;
            textBox7.Visible = false;
            label8.Visible = false;
            textBox8.Visible = false;
            label9.Visible = false;
            textBox9.Visible = false;
            label10.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0)
            {
                Dodaj();
                textBox2.Visible = false;
                label2.Visible = false;
                textBox3.Visible = false;
                label3.Visible = false;
                textBox4.Visible = false;
                label4.Visible = false;
                dataGridView1.Visible = true;
                button2.Visible = false;
                label5.Visible = false;
                textBox5.Visible = false;
                button3.Visible = false;

                textBox6.Visible = false;
                label7.Visible = false;
                textBox7.Visible = false;
                label8.Visible = false;
                textBox8.Visible = false;
                label9.Visible = false;
                textBox9.Visible = false;
                label10.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Pokaz();
            }
            else
            {
                MessageBox.Show("Któreś z pól jest puste, nie można dodać albumu");
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            dataGridView1.Visible = true;
            button2.Visible = false;
            label5.Visible = true;
            textBox5.Visible = true;
            button3.Visible = true;

            textBox6.Visible = false;
            label7.Visible = false;
            textBox7.Visible = false;
            label8.Visible = false;
            textBox8.Visible = false;
            label9.Visible = false;
            textBox9.Visible = false;
            label10.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length != 0)
            {
                Usun();
                label5.Visible = false;
                textBox5.Visible = false;
                textBox5.Text = "";
                button3.Visible = false;
                Pokaz();
            }
            else
            {
                MessageBox.Show("Puste pole!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                string co = "";
                string gdzie = listBox1.SelectedItem.ToString();
                string query = "";


                if (gdzie != "ID")
                {
                    co = "%" + textBox1.Text + "%";
                    query = "SELECT * FROM `cd` WHERE " + gdzie + " LIKE '" + co + "'";
                }
                else
                {
                    co = Encoding.UTF8.GetString(Encoding.Default.GetBytes(textBox1.Text));
                    query = "SELECT * FROM `cd` WHERE " + gdzie + "=" + co + "";
                }

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet dset = new DataSet();
                    adpt.Fill(dset);
                    dataGridView1.DataSource = dset.Tables[0];
                }
                databaseConnection.Close();
                dataGridView1.Visible = true;
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Pole nie może być puste!");
            }
        }
        private void Zaznacz()
        {
            listBox1.SelectedItem = "Autor";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Pole nie może być puste!");
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Pole nie może być puste!");
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Pole nie może być puste!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Wprowadź cyfry!");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //zmiana planów
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\baza.CSV";
                MessageBox.Show("Eksport do: "+file);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie można zrobić kopii" + ex.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            textBox6.Visible = true;
            label7.Visible = true;
            textBox7.Visible = true;
            label8.Visible = true;
            textBox8.Visible = true;
            label9.Visible = true;
            textBox9.Visible = true;
            label10.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            
            textBox2.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            textBox5.Visible = false;
            button3.Visible = false;

            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void Edytuj()
        {
            string query = "UPDATE `cd` SET `Autor` = '" + textBox7.Text + "', `Album` = '" + textBox8.Text + "', `Opis` = '" + textBox9.Text + "' WHERE `cd`.`ID` = '" + textBox6.Text + "';";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                MessageBox.Show("Album został edytowany!");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Album nie mógł zostać edytowany!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length != 0 && textBox7.Text.Length != 0 && textBox8.Text.Length != 0 && textBox9.Text.Length != 0)
            {
                Edytuj();
                textBox6.Visible = false;
                label7.Visible = false;
                textBox7.Visible = false;
                label8.Visible = false;
                textBox8.Visible = false;
                label9.Visible = false;
                textBox9.Visible = false;
                label10.Visible = false;
                button5.Visible = false;
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                button6.Visible = false;
                Pokaz();
            }
            else
            {
                MessageBox.Show("Któreś z pól jest puste, nie można dodać albumu");
            }
        }
        private void Dodaj_ZID()
        {
            string query = "SELECT * FROM cd WHERE `ID` = '" + textBox6.Text + "'";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        textBox7.Text = reader.GetString(1);
                        textBox8.Text = reader.GetString(2);
                        textBox9.Text = reader.GetString(3);
                        }
                    }
                    else
                    {
                    MessageBox.Show("Nie znaleziono!");
                    textBox6.Text =  "";
                    textBox7.Text = "";
                }
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dodaj_ZID();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

        }
    }
}
