using System;
using System.Windows.Forms;

namespace COCOMO_Basic
{
    public partial class FormBasicModel : Form
    {
        public FormBasicModel()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Проверка на пустоту текстбокса.
            if (string.IsNullOrWhiteSpace(tbCodeSize.Text))
            {
                lblError.Text = "Поле ввода не может быть пустым!";
                return;
            }
            lblError.Text = "";

            int codeSize = int.Parse(tbCodeSize.Text);
            BasicModel.ProjectType type = (BasicModel.ProjectType)Enum.Parse(typeof(BasicModel.ProjectType), cmbType.Text);

            lblLaboriousness.Text = "Трудоёмкость: " + Math.Round(
                BasicModel.GetLaboriousness(codeSize, type), 4).ToString() + " чел/мес.";
            lblDebvelop.Text = "Длительность: " + Math.Round(
                BasicModel.GetDevelopmentTime(codeSize, type), 4).ToString() + " мес.";
            lblStaff.Text = "Разработчиков: " + Math.Round(
                BasicModel.GetNumberStaff(codeSize, type), 4).ToString() + " чел.";
            lblProductivity.Text = "Продуктивность: " + Math.Round(
                BasicModel.GetProductivity(codeSize, type), 4).ToString();
        }

        private void FormBasicModel_Load(object sender, EventArgs e)
        {
            cmbType.Items.AddRange(Enum.GetNames(typeof(BasicModel.ProjectType)));
            cmbType.Text = cmbType.Items[0].ToString();
        }

        private void tbCodeSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            // Позволяем вводить только цифры и Backspace.
            if (!Char.IsDigit(number) && number != 8)
            {
                lblError.Text = "Разрешено вводить только цифры!";
                e.Handled = true;
            }
            else
            {
                lblError.Text = "";
            }
        }
    }
}