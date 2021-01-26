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

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
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
    }
}
