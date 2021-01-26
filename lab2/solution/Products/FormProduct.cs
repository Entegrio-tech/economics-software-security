using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void OnlyNumb()
        { 
        
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
    }
}
