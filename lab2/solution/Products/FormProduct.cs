using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Products
{
    public partial class FormProduct : Form
    {

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
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
                MessageBoxButtons.YesNo);
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
                    connection.Close();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string commandText = $@"SELECT * 
                                   FROM Games
                                   WHERE Id = {int.Parse(tbCipher.Text) + 1}";
            Filling(commandText);
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            string commandText = $@"SELECT * 
                                   FROM Games
                                   WHERE Id = {int.Parse(tbCipher.Text) - 1}";
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
    }
}
