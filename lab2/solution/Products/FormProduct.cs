using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        // Событие для начертания линий на форме.
        private void FormProduct_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Maroon, 1);
            e.Graphics.DrawLine(pen, 15, 30, 580, 30);
            e.Graphics.DrawLine(pen, 15, 69, 580, 69);
            e.Graphics.DrawLine(pen, 15, 215, 580, 215);
            e.Graphics.DrawLine(pen, 15, 257, 580, 257);
        }
        // Выход из приложения.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Проверка ввода целых чисел.
        private void tbCipher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 0x8))
            {
                e.Handled = true;
            }
        }

        // Проверка ввода чисел с плавающей запятой.
        private void tbSurcharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр с одной запятой
            if ((e.KeyChar == ','))
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Contains(","))
                {
                    e.Handled = true;
                }
                return;
            }

            if (!(Char.IsDigit(e.KeyChar)))
            {
                if ((e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }

        }

        private void Filling(string commandText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = commandText;
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                // Заполнение ТБ на форме. 
                while (thisReader.Read())
                {
                    tbCipher.Text = thisReader["Id"].ToString();
                    tbName.Text = thisReader["Name"].ToString();
                    tbGenre.Text = thisReader["GenreID"].ToString();
                    tbType.Text = thisReader["Type"].ToString();
                    tblNumber.Text = thisReader["Quantity"].ToString();
                    tbPrice.Text = thisReader["Price"].ToString();
                    tbSurcharge.Text = thisReader["Allowance"].ToString();
                }
                thisReader.Close();
                connection.Close();
            }
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            string commandText = @"SELECT Top 1 * 
                                   FROM Games
                                   ORDER BY id";
            Filling(commandText);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            // Сортируем по убыванию.
            string commandText = @"SELECT Top 1 *
                                   FROM Games
                                   ORDER BY Id DESC";
            Filling(commandText);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbCipher.Text == "")
            {
                MessageBox.Show("Для удаления укажите шифр!");
                return;
            }
            // Подтверждение удаления.
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что желаете удалить товар с номером {tbCipher.Text}?",
                "Предупреждение",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand thisCommand = connection.CreateCommand();
                    thisCommand.CommandText = $@"DELETE FROM Games
                                            WHERE Id = {int.Parse(tbCipher.Text)}";
                    thisCommand.ExecuteNonQuery();
                }
            }
            btnFirst.PerformClick();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            string sqlExpression = "SELECT Games.Id, Games.Name, GenreId, Genres.Name, Type, Quantity, Price, Allowance FROM Games, Genres WHERE Genres.Id = GenreId ORDER BY Id DESC";
            string sqlExpression2 = "SELECT * FROM Genres";
            Filling(sqlExpression);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        cmbGenre.Items.Add(reader.GetValue(1));
                    }
                }
                reader.Close();
                cmbGenre.SelectedIndex = Convert.ToInt32(tbGenre.Text) - 1;
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
            DialogResult dialogResult = MessageBox.Show($"Вы уверены, что желаете добавить товар с новым номером?",
                "Предупреждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
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
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string commandText = $@"SELECT * 
                                   FROM Games
                                   WHERE Id > {int.Parse(tbCipher.Text)} ORDER BY Id DESC";
            Filling(commandText);
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            string commandText = $@"SELECT * 
                                   FROM Games
                                   WHERE Id < {int.Parse(tbCipher.Text)} ORDER BY Id";
            Filling(commandText);
        }

        // Защита от SQL инъекции.
        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "'")
            {
                e.Handled = true;
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
