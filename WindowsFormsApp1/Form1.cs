using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string connectionString;
        string filePath = "D:\\Game dev\\библиотека село\\WindowsFormsApp1\\Connection.txt";
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            GetConnection();
        }
        private void GetConnection()
        {
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                fileContent.TrimEnd();
                ConnectDatabaseString.SharedString =fileContent;
                connectionString = ConnectDatabaseString.SharedString;
                textBoxConnection.Text= connectionString;
            }

        }
        private void Scena_2()
        {
            listBox1.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBoxConnection.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = false;
            button6.Visible = true;
            button7.Visible = true;
            buttonInit.Visible = true;
        }
        private void Scena_1()
        {
            listBox1.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBoxConnection.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            button6.Visible= false;
            button7.Visible = false;
            buttonInit.Visible = false;
        }
        private void Suzdavane_na_Operator()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            bool taken = false;
            string check = "SELECT COUNT(OperatorID) FROM Operatori WHERE Username = @Username";
            SqlCommand cmd = new SqlCommand(check, con);
            cmd.Parameters.AddWithValue("@Username", textBox3.Text);
            int userCount = (int)cmd.ExecuteScalar();
            if (userCount == 1)
            {
                taken = true;
            }
            con.Close();

            if (taken == false)
            {
                con.Open();
                string INS = "INSERT INTO Operatori(Username, Pass) VALUES(@Username, @Password)";
                SqlCommand command = new SqlCommand(INS, con);
                command.Parameters.AddWithValue("@Username", textBox3.Text);
                command.Parameters.AddWithValue("@Password", textBox4.Text);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected >= 0)
                {
                    MessageBox.Show("Успешно Добавяне");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Вече Съсществува такъв потребител");
            }
        }
        private void OperatorLogin()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string command = "SELECT Username, Pass FROM Operatori WHERE Username ='"+textBox1.Text+"' AND  Pass ='"+textBox2.Text+"'";
            SqlCommand sqlCommand = new SqlCommand(command, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Несъществуващ оператор!!");
            }
            reader.Close();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "12345") { Scena_2(); }
            else
            {
                OperatorLogin();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Scena_1();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" && textBox3.Text == "admin")
            {
                MessageBox.Show($"Грешно потребителско име ");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show($"Няма въведена парола");
                return;
            }
            if (textBox4.Text != textBox5.Text)
            { 
                MessageBox.Show($"Паролите не съвпадат");
                return;
            }
            else
                Suzdavane_na_Operator();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string command = "SELECT Count(OperatorID) FROM Operatori";
            SqlCommand sqlCommand = new SqlCommand(command, con);
            int numberOfOperatori = Convert.ToInt32(sqlCommand.ExecuteScalar());
            for(int i=1; i<=numberOfOperatori; i++)
            {
                command = "SELECT * FROM Operatori WHERE OperatorID = " + i;
                sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    string ID = reader["OperatorID"].ToString();
                    string ime = reader["Username"].ToString();
                    string pass = reader["Pass"].ToString();
                    ime = ime.TrimEnd();
                    pass= pass.TrimEnd();
                    string fullName = ID + ": " + ime + "   Pass:" + pass;
                    listBox1.Items.Add(fullName);
                }
                reader.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormDemo demo = new FormDemo();
            demo.Show();
            this.Hide();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Environment.Exit(0);
        }
        private void buttonInit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Създаване на база данни?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string createKnigiTableQuery = @"
                    CREATE TABLE Knigi(
                        KnigaID int PRIMARY KEY IDENTITY (1,1),
                        Ime char(50) NOT NULL,
                        Avtor char(50) NOT NULL,
                        Janr char(20),
                        Cena decimal(6,2)
                    )";
                        ExecuteNonQuery(connection, createKnigiTableQuery);

                        string createOperatoriTableQuery = @"
                    CREATE TABLE Operatori(
                        OperatorID int PRIMARY KEY IDENTITY (1,1),
                        Username char(20) NOT NULL,
                        Pass char(20) NOT NULL
                    )";
                        ExecuteNonQuery(connection, createOperatoriTableQuery);

                        string createPotrebitelTableQuery = @"
                    CREATE TABLE Potrebitel(
                        PotrebitelID int PRIMARY KEY IDENTITY(1,1),
                        Ime char(20) NOT NULL,
                        Familia char(20) NOT NULL,
                        EGN char(10),
                        Email char(45),
                        DataNaAbonament date NOT NULL,
                        VidAbonament int NOT NULL,
                        PhoneNumber int NOT NULL
                    )";
                        ExecuteNonQuery(connection, createPotrebitelTableQuery);

                        string createZaemaniqTableQuery = @"
                    CREATE TABLE Zaemaniq(
                        PoruchkaID int PRIMARY KEY IDENTITY(1,1),
                        NachalnaData date NOT NULL,
                        KrainaData date,
                        KnigaID int NOT NULL,
                        KlientID int NOT NULL,
                        Shteti char(50),
                        Zaeta bit,
                        FOREIGN KEY(KnigaID) REFERENCES Knigi(KnigaID),
                        FOREIGN KEY(KlientID) REFERENCES Potrebitel(PotrebitelID)
                    )";
                        ExecuteNonQuery(connection, createZaemaniqTableQuery);

                        MessageBox.Show("Таблицте са създадени успешно.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка: " + ex.Message);
                }
            }
        }
        static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            File.WriteAllText(filePath, textBoxConnection.Text.TrimEnd());
            ConnectDatabaseString.SharedString = textBoxConnection.Text.TrimEnd();
            connectionString = ConnectDatabaseString.SharedString;
            textBoxConnection.Text = connectionString;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string item= listBox1.SelectedItem.ToString();
                int indexTochki=item.IndexOf(":");
                item=item.Substring(0, indexTochki);


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string deleteQuery = "DELETE FROM Operatori WHERE OperatorID ="+item;
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Успешно изтрит оператор");
                    
                }
                else
                {
                    MessageBox.Show("Възникна Грешка");
                }
            }
        }
    }
}
