using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormDobavqne : Form
    {
        string connectionString = ConnectDatabaseString.SharedString;
        bool filled=false;
        public FormDobavqne()
        {
            InitializeComponent();
            Nulirane();
        }
        private void Nulirane()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            dateTimePicker1.Visible=false;
            dateTimePicker2.Visible=false;
            dateTimePicker3.Visible=false;
            textBox1.ReadOnly=false;
            textBox2.ReadOnly=false;
            textBox4.ReadOnly=false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBoxKnigaID.Visible=false;
            comboBoxPotrebitelID.Visible=false;
            checkBox1.Checked=false;
            checkBox1.Visible=false;
        }
        private void ComboBoxNaglasqne()
        {
            comboBoxKnigaID.Visible = true;
            comboBoxPotrebitelID.Visible = true;
            textBox3.Visible = false;
            textBox4.Visible = false;
            if (filled == false)
            {
                comboBoxIDKfill();
                comboBoxIDPfill();
                filled = true;
            }

        }
        private void comboBoxIDKfill()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string command = "SELECT Knigi.Ime, Knigi.KnigaID " +
                                "FROM Knigi " +
                                "LEFT JOIN Zaemaniq ON Knigi.KnigaID = Zaemaniq.KnigaID " +
                                "WHERE Zaemaniq.KnigaID IS NULL OR Zaemaniq.Zaeta = 0";

                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string ime = reader["Ime"].ToString();
                    string ID = reader["KnigaID"].ToString();
                    string full = ID + ": " + ime;
                    comboBoxKnigaID.Items.Add(full.TrimEnd());
                }
                reader.Close();
            }
            con.Close();
        }
        private void comboBoxIDPfill()
        { 
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
                    string ime = reader["Ime"].ToString().TrimEnd();
                    string familia = reader["Familia"].ToString().TrimStart();
                    string fullName = ID + ": " + ime + " " + familia;
                    comboBoxPotrebitelID.Items.Add(fullName);
                }

                reader.Close();
            }
            con.Close();
        }
        private void comboBoxIzbor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxIzbor.SelectedIndex)
            {
                case 0:
                    Nulirane();
                    label1.Text = "Начална дата: ";
                    label2.Text = "Крайна дата: ";
                    label3.Text = "ID Книга: ";
                    label4.Text = "ID Потребител: ";
                    label5.Text = "Щети: ";
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    checkBox1.Visible = true;
                    ComboBoxNaglasqne();
                    break;
                case 1:
                    Nulirane();
                    label1.Text = "Заглавие: ";
                    label2.Text = "Автор: ";
                    label3.Text = "Жанр: ";
                    label4.Text = "Цена:";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    break;
                case 2:
                    Nulirane();
                    label1.Text = "Име: ";
                    label2.Text = "Фамилия: ";
                    label3.Text = "Email: ";
                    label4.Text = "Дата на абонамент: ";
                    label5.Text = "Вид на абонамент: ";
                    label6.Text = "Телефонен номер:";
                    label7.Text = "ЕГН: ";
                    textBox4.ReadOnly = true;
                    dateTimePicker3.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    break;
            }
        }
        private void buttonDobavqne_Click(object sender, EventArgs e)
        {
            switch (comboBoxIzbor.SelectedIndex)
            {
                case 0:
                    DobavqneNaZaemane();
                    break;
                case 1:
                    DobavqneNaKniga();
                    break;
                case 2:
                    DobavqneNaPotrebitel();
                    break;
            }
        }
        private bool ProverkaZaZaetaKniga(int knigaID)
        {
            bool alreadyTaken = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = "SELECT COUNT(*) FROM Zaemaniq WHERE KnigaID = "+knigaID+" AND Zaeta = 1";
                SqlCommand sqlCommand = new SqlCommand(command, con);

                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (count > 0)
                {
                    alreadyTaken = true;
                    MessageBox.Show("Книгата вече е заета");
                }
                con.Close();
            }

            return alreadyTaken;
        }
        private bool ProverkaZaPodredbaNaDatite(string NachalnaDataS, string KrainaDataS)
        {
            DateTime NachalnaData = DateTime.Parse(NachalnaDataS);
            DateTime KrainaData = DateTime.Parse(KrainaDataS);
            bool result=false; 
            if(NachalnaData<KrainaData)
            {
                result = true;
            }
            else
            {
                MessageBox.Show("Началната дата е преди крайната дата, променете датите");
            }
            return result;
        }
        private void DobavqneNaZaemane()
        {
            if (comboBoxKnigaID.SelectedItem != null&&comboBoxPotrebitelID.SelectedItem!=null)
            {
                string KnigaID = comboBoxKnigaID.SelectedItem.ToString();
                string PotrebitelID = comboBoxPotrebitelID.SelectedItem.ToString();
                int indexK = KnigaID.IndexOf(":");
                int indexP = PotrebitelID.IndexOf(":");
                KnigaID = KnigaID.Substring(0, indexK);
                PotrebitelID = PotrebitelID.Substring(0, indexP);
                if (KnigaID != "" && PotrebitelID != "" && !ProverkaZaZaetaKniga(Convert.ToInt32(KnigaID))
                    && textBox1.Text != "" && textBox2.Text != ""&& ProverkaZaPodredbaNaDatite(textBox1.Text,textBox2.Text))
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string INS = "INSERT INTO Zaemaniq(NachalnaData,KrainaData,KnigaID,KlientID,Shteti,Zaeta) VALUES" +
                         "('" + textBox1.Text + "','" + textBox2.Text + "'," + KnigaID + "," + PotrebitelID + ",'" + textBox5.Text + "',"+Convert.ToInt32(checkBox1.Checked)+")";
                    SqlCommand command = new SqlCommand(INS, con);
                    int rowsAfected = command.ExecuteNonQuery();
                    if (rowsAfected == 1) MessageBox.Show("Успешно Добавяне");
                    con.Close();
                }
            }
        }
        private void DobavqneNaKniga()
        {
            if (textBox1.Text != "" && textBox2.Text != ""&&textBox4.Text!="")
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string INS = "INSERT INTO Knigi(Ime,Avtor,Janr,Cena) VALUES" +
                    "('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ")";
                SqlCommand command = new SqlCommand(INS, con);
                int rowsAfected = command.ExecuteNonQuery();
                if (rowsAfected == 1) MessageBox.Show("Успешно Добавяне");
                con.Close();
            }
        }
        private void DobavqneNaPotrebitel()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "" && textBox4.Text != "" &&
                textBox6.Text != "")
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string INS = "INSERT INTO Potrebitel(Ime,Familia,Email,DataNaAbonament,VidAbonament,PhoneNumber,EGN) VALUES" +
                    "('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," +
                            textBox5.Text + "," + textBox6.Text + ",'" + textBox7.Text + "')";
                SqlCommand command = new SqlCommand(INS, con);
                int rowsAfected = command.ExecuteNonQuery();
                if (rowsAfected == 1) MessageBox.Show("Успешно Добавяне");
                con.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text=dateTimePicker1.Value.ToString("yyyy/MM/dd").Replace(".","/");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text=dateTimePicker2.Value.ToString("yyyy/MM/dd").Replace(".", "/");
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text=dateTimePicker3.Value.ToString("yyyy/MM/dd").Replace(".", "/");
        }
    }
}
