using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;
using System.Reflection;
using System.Net.Configuration;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        string connectionString = ConnectDatabaseString.SharedString;
        public Form2()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
        }
        private int indexStripMenu = -1;
        private void PotrebiteliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            potrebitelToolStripFill();
        }
        private void KnigiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            knigiToolStripFill();
        }
        private void AvtoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avtoriToolStripFill();
        }
        private void ZaemaniqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zaemaniqToolStripFill();
        }
        private void potrebitelToolStripFill()
        {
            buttonDeleteRecord.Visible = true;
            listBoxSelect.Items.Clear();
            listBoxInfo.Items.Clear();
            indexStripMenu = 0;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT PotrebitelID, Ime, Familia FROM Potrebitel";
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string ID = reader["PotrebitelID"].ToString();
                    string ime = reader["Ime"].ToString();
                    string familia = reader["Familia"].ToString();
                    string fullName = ID + ": " + ime.TrimEnd() + " " + familia.TrimEnd();
                    listBoxSelect.Items.Add(fullName);
                }
                reader.Close();
            }
            con.Close();
        }
        private void knigiToolStripFill()
        {
            buttonDeleteRecord.Visible = true;
            listBoxSelect.Items.Clear();
            listBoxInfo.Items.Clear();
            indexStripMenu = 1;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT KnigaID, Ime FROM Knigi";
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string ID = reader["KnigaID"].ToString();
                    string ime = reader["Ime"].ToString();
                    string full = ID + ": " + ime;
                    listBoxSelect.Items.Add(full);
                }
                reader.Close();
            }
            con.Close();
        }
        private void avtoriToolStripFill()
        {
            listBoxSelect.Items.Clear();
            listBoxInfo.Items.Clear();
            buttonDeleteRecord.Visible = false;
            indexStripMenu = 2;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT DISTINCT Avtor FROM Knigi";
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string avtor = reader["Avtor"].ToString();
                    listBoxSelect.Items.Add(avtor);
                }
                reader.Close();
            }
            con.Close();
        }
        private void zaemaniqToolStripFill()
        {
            buttonDeleteRecord.Visible = true;
            listBoxSelect.Items.Clear();
            listBoxInfo.Items.Clear();
            indexStripMenu = 3;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT Zaemaniq.PoruchkaID, Knigi.Ime, Potrebitel.Ime AS Ime1, Potrebitel.Familia " +
                         "FROM Knigi, Zaemaniq, Potrebitel " +
                         "WHERE Zaemaniq.KlientID = Potrebitel.PotrebitelID " +
                         "AND Zaemaniq.KnigaID = Knigi.KnigaID";
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string poruchkaID = reader["PoruchkaID"].ToString();
                    string knigaIme = reader["Ime"].ToString();
                    string ime = reader["Ime1"].ToString();
                    string familia = reader["Familia"].ToString();
                    string fullName = poruchkaID.TrimEnd() + ": " + knigaIme.TrimEnd() + "-" + ime.TrimEnd() + " " + familia.TrimEnd();
                    listBoxSelect.Items.Add(fullName);
                }
                reader.Close();
            }
            con.Close();
        }
        private void listBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSelect.SelectedItem != null)
            {
                switch (indexStripMenu)
                {
                    case 0:
                        listBoxInfoFillPotrebitel(listBoxSelect.Items.IndexOf(listBoxSelect.SelectedItem));
                        break;
                    case 1:
                        listBoxInfoFillKniga(listBoxSelect.Items.IndexOf(listBoxSelect.SelectedItem));
                        break;
                    case 2:
                        listBoxInfoFillAvtor(listBoxSelect.Items[listBoxSelect.SelectedIndex].ToString());
                        break;
                    case 3:
                        listBoxInfoFillZaemaniq(listBoxSelect.Items[listBoxSelect.SelectedIndex].ToString());
                        break;
                }
            }
        }
        private void listBoxInfoFillPotrebitel(int index)
        {
            listBoxInfo.Items.Clear();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string PotrebitelID = Convert.ToString(index + 1);
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT * FROM Potrebitel WHERE PotrebitelID =" + PotrebitelID;
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    long ID = Convert.ToInt64(reader["PotrebitelID"]);
                    string ime = reader["Ime"].ToString();
                    string familia = reader["Familia"].ToString();
                    string email = reader["Email"].ToString();
                    DateTime dataNaAbonament = (DateTime)reader["DataNaAbonament"];
                    int vidAbonament = (int)reader["VidAbonament"];
                    int phoneNumber = (int)reader["PhoneNumber"];
                    string EGN = reader["EGN"].ToString();
                    listBoxInfo.Items.Add("Име: " + ime);
                    listBoxInfo.Items.Add("Фамилия: " + familia);
                    listBoxInfo.Items.Add("Email: " + email);
                    listBoxInfo.Items.Add("Дата на абонамент: " + dataNaAbonament.ToString("dd-MM-yyyy"));
                    listBoxInfo.Items.Add("Вид на абонамент: " + vidAbonament);
                    listBoxInfo.Items.Add("Тел. номер: 0" + phoneNumber);
                    listBoxInfo.Items.Add("ЕГН: " + EGN);
                }
                reader.Close();
            }
            con.Close();

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
                    listBoxInfo.Items.Add("Име: " + ime);
                    listBoxInfo.Items.Add("Автор: " + avtor);
                    listBoxInfo.Items.Add("Жанр: " + janr);
                    listBoxInfo.Items.Add("Цена: " + cena);
                }
                reader.Close();
            }
            con.Close();
        }
        private void listBoxInfoFillAvtor(string selectedAvtor)
        {
            listBoxInfo.Items.Clear();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT KnigaID, Ime FROM Knigi WHERE Avtor = '" + selectedAvtor + "'";
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    long ID = Convert.ToInt64(reader["KnigaID"]);
                    string ime = reader["Ime"].ToString();
                    listBoxInfo.Items.Add("ID: " + ID.ToString() + " Ime: " + ime);
                }
                reader.Close();
            }
            con.Close();
        }
        private void listBoxInfoFillZaemaniq(string SelectedZaemane)
        {
            listBoxInfo.Items.Clear();
            SqlConnection con = new SqlConnection(connectionString);
            int indexTochki = SelectedZaemane.IndexOf(":");
            SelectedZaemane = SelectedZaemane.Substring(0, indexTochki);
            string PoruchkaID = Convert.ToString(SelectedZaemane);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT Zaemaniq.PoruchkaID, Zaemaniq.NachalnaData, Zaemaniq.KrainaData, " +
                                 "Potrebitel.Ime AS KlientIme, Potrebitel.Familia AS KlientFamilia, " +
                                 "Knigi.Ime AS KnigaIme, Zaemaniq.Zaeta " +
                                 "FROM Zaemaniq " +
                                 "JOIN Potrebitel ON Zaemaniq.KlientID = Potrebitel.PotrebitelID " +
                                 "JOIN Knigi ON Zaemaniq.KnigaID = Knigi.KnigaID " +
                                 "WHERE Zaemaniq.PoruchkaID ="+PoruchkaID;
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string poruchkaID = reader["PoruchkaID"].ToString();
                    DateTime nachalnaData = Convert.ToDateTime(reader["NachalnaData"]);
                    string formattedNachalnaData = nachalnaData.ToString("dd/MM/yyyy");
                    DateTime krainaData = Convert.ToDateTime(reader["KrainaData"]);
                    string formattedKrainaData = krainaData.ToString("dd/MM/yyyy");
                    string klientIme = reader["KlientIme"].ToString();
                    string klientFamilia = reader["KlientFamilia"].ToString();
                    string knigaIme = reader["KnigaIme"].ToString();
                    bool zaeta = Convert.ToBoolean(reader["Zaeta"]);

                    listBoxInfo.Items.Add("ПоръчкаID: " + poruchkaID);
                    listBoxInfo.Items.Add("Начална дата: " + formattedNachalnaData);
                    listBoxInfo.Items.Add("Краина дата: " + formattedKrainaData);
                    listBoxInfo.Items.Add("Читател: " + klientIme + " " + klientFamilia);
                    listBoxInfo.Items.Add("Книга: " + knigaIme);

                    if (zaeta)
                    {
                        listBoxInfo.Items.Add("Заета: Да");
                    }
                    else
                    {
                        listBoxInfo.Items.Add("Заета: Не");
                    }
                }
                reader.Close();
            }
            con.Close();
        }

        private void DobavqneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDobavqne formDobavqne = new FormDobavqne();
            formDobavqne.Show();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Environment.Exit(0);
        }

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            if (listBoxSelect.SelectedItem != null)
            {
                switch (indexStripMenu)
                {
                    case 0:
                        DeleteRecrdPotrebitel(listBoxSelect.SelectedItem.ToString());
                        break;
                    case 1:
                        DeleteRecrdKniga(listBoxSelect.SelectedItem.ToString());
                        break;
                    case 3:
                        DeleteRecordZaemane(listBoxSelect.SelectedItem.ToString());
                        break;
                }
            }
        }
        private void DeleteRecordZaemane(string item)
        {
            int indexNaTochki = item.IndexOf(":");
            item = item.Substring(0, indexNaTochki);
            int index = Convert.ToInt32(item);
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string command = "DELETE FROM Zaemaniq WHERE PoruchkaID=" + index.ToString();
            SqlCommand sqlCommand = new SqlCommand(command, con);
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected == 1) { MessageBox.Show("Усепшно издтрихте заемане"); zaemaniqToolStripFill(); }
            con.Close();

        }
        private void DeleteRecrdPotrebitel(string item)
        {
            int indexNaTochki = item.IndexOf(":");
            item = item.Substring(0, indexNaTochki);
            int index = Convert.ToInt32(item);
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string command="SELECT COUNT(PotrebitelID) FROM Zaemaniq WHERE KlientID="+index;
            SqlCommand sqlCommand = new SqlCommand(command, con);
            int numberOfZaemaniq = Convert.ToInt32(sqlCommand.ExecuteScalar());
            if (numberOfZaemaniq == 0)
            {
                command = "DELETE FROM Potrebitel WHERE PotrebitelID=" + index.ToString();
                sqlCommand.CommandText = command;
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 1) { MessageBox.Show("Усепшно издтрихте потребител"); potrebitelToolStripFill(); }
            }
            else
            {
                MessageBox.Show("Потребителя е заел книга и не може да бъде изтрит");
            }
            con.Close();
        }
        private void DeleteRecrdKniga(string item)
        {
            int indexNaTochki = item.IndexOf(":");
            item = item.Substring(0, indexNaTochki);
            int index = Convert.ToInt32(item);
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string command= "SELECT COUNT(KnigaID) FROM Zaemaniq WHERE KnigaID = "+index;
            SqlCommand sqlCommand = new SqlCommand(command, con);
            int numberOfZaemaniq = Convert.ToInt32(sqlCommand.ExecuteScalar());
            if (numberOfZaemaniq == 0)
            {
                command = "DELETE FROM Knigi WHERE KnigaID=" + index.ToString();
                sqlCommand.CommandText = command;
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                if (rowsAffected == 1) { MessageBox.Show("Усепшно издтрихте книга"); knigiToolStripFill(); }
            }
            else
            {
                MessageBox.Show("Книгата е заета и не може да бъде изтритa");
            }
            con.Close();
        }
    }
}
