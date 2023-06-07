using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormDemo : Form
    {
        string connectionString = ConnectDatabaseString.SharedString;
        public FormDemo()
        {
            InitializeComponent();
            ListBooks();
        }
        private void ListBooks()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT Count(KnigaID) FROM Knigi";
                SqlCommand sqlCommand = new SqlCommand(command, con);
                int numberOfPotrebiteli = Convert.ToInt32(sqlCommand.ExecuteScalar());
                for (int i = 1; i <= numberOfPotrebiteli; i++)
                {
                    command = "SELECT Ime FROM Knigi WHERE KnigaID =" + i;
                    sqlCommand = new SqlCommand(command, con);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        string ime = reader["Ime"].ToString();
                        listBoxSelect.Items.Add(ime);
                    }
                    reader.Close();
                }
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            back.Show();
            this.Close();
        }
        private void listBoxSelect_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBoxInfoFillKniga(listBoxSelect.Items.IndexOf(listBoxSelect.SelectedItem));
        }
        private void listBoxInfoFillKniga(int index)
        {
            listBoxInfo.Items.Clear();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string KnigaID = Convert.ToString(index + 1);
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT * FROM Knigi WHERE KnigaID =" + KnigaID;
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    long ID = Convert.ToInt64(reader["KnigaID"]);
                    string ime = reader["Ime"].ToString();
                    string avtor = reader["avtor"].ToString();
                    string janr = reader["Janr"].ToString();
                    string cena = reader["Cena"].ToString();
                    listBoxInfo.Items.Add("ID: " + ID.ToString());
                    listBoxInfo.Items.Add("Ime: " + ime);
                    listBoxInfo.Items.Add("Avtor: " + avtor);
                    listBoxInfo.Items.Add("Janr: " + janr);
                    listBoxInfo.Items.Add("Cena: " + cena);
                }
                reader.Close();
            }
            con.Close();
        }
    }
}
