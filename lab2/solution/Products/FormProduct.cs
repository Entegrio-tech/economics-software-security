using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Products
{
    public partial class FormProduct : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            string sqlExpression = "SELECT Games.Id, Games.Name, GenreId, Genres.Name, Type, Quantity, Price, Allowance FROM Games, Genres WHERE Genres.Id = GenreId";
            string sqlExpression2 = "SELECT * FROM Genres";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows) // если есть данные
                {
                    tbCipher.Text = reader.GetInt32(0).ToString();
                    tbName.Text = reader.GetString(1);
                    tbGenre.Text = reader.GetInt32(2).ToString();
                    cmbGenre.Text = reader.GetString(3);
                    tbType.Text = reader.GetString(4);
                    tblNumber.Text = reader.GetInt32(5).ToString();
                    tbPrice.Text = reader.GetDecimal(6).ToString();
                    tbSurcharge.Text = reader.GetInt32(7).ToString();
                }
                reader.Close();

                command = new SqlCommand(sqlExpression2, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        cmbGenre.Items.Add(reader.GetValue(1));
                    }
                }
                reader.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sqlExpression = $"SELECT * FROM Games WHERE Id = '{tbCipher.Text}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    DialogResult dialogResult = MessageBox.Show($"Точно изменить запись {tbCipher.Text}?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dialogResult == DialogResult.Yes)
                    {    
                        string sqlExpression2 = $"UPDATE Games SET Name='{tbName.Text}', GenreId={tbGenre.Text}, Type='{tbType.Text}', Quantity={tblNumber.Text}, Price={tbPrice.Text}, Allowance={tbSurcharge.Text} WHERE Games.Id='{tbCipher.Text}'";
                        command = new SqlCommand(sqlExpression2, connection);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось изменить данные. Товара с таким шифром не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = $"INSERT INTO Games (Name, GenreId, Type, Quantity, Price, Allowance) VALUES ('{tbName.Text}', {tbGenre.Text}, '{tbType.Text}', {tblNumber.Text}, {tbPrice.Text}, {tbSurcharge.Text})";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Товар успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGenre.Text == "Action")
                tbGenre.Text = "1";
            if (cmbGenre.Text == "Simulation")
                tbGenre.Text = "2";
            if (cmbGenre.Text == "Strategy")
                tbGenre.Text = "3";
            if (cmbGenre.Text == "Role-playing Games")
                tbGenre.Text = "4";
            if (cmbGenre.Text == "Adventure")
                tbGenre.Text = "5";
            if (cmbGenre.Text == "Puzzle")
                tbGenre.Text = "6";
        }
    }
}
