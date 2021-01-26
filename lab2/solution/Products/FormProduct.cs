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

        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Maroon, 1);
            e.Graphics.DrawLine(pen, 15, 30, 580, 30);
            e.Graphics.DrawLine(pen, 15, 69, 580, 69);
            e.Graphics.DrawLine(pen, 15, 215, 580, 215);
            e.Graphics.DrawLine(pen, 15, 257, 580, 257);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbCipher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 0x8))
            {
                e.Handled = true;
            }
        }

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
            Console.WriteLine(connectionString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand thisCommand = connection.CreateCommand();
                thisCommand.CommandText = commandText;
                SqlDataReader thisReader = thisCommand.ExecuteReader();
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
            string commandText = @"select Top 1 * from Games order by id";
            Filling(commandText);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            string commandText = @"select Top 1 * from Games order by id desc";
            Filling(commandText);
        }
    }
}
