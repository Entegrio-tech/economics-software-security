
namespace COCOMO_Basic
{
    partial class FormBasicModel
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblName2 = new System.Windows.Forms.Label();
            this.tbCodeSize = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblLaboriousness = new System.Windows.Forms.Label();
            this.lblDebvelop = new System.Windows.Forms.Label();
            this.lblProductivity = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName1.Location = new System.Drawing.Point(12, 9);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(120, 23);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "Тип проекта:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(16, 35);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(176, 31);
            this.cmbType.TabIndex = 1;
            // 
            // lblName2
            // 
            this.lblName2.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.Location = new System.Drawing.Point(12, 79);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(167, 46);
            this.lblName2.TabIndex = 2;
            this.lblName2.Text = "Количество строк кода (тысяч):";
            // 
            // tbCodeSize
            // 
            this.tbCodeSize.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodeSize.Location = new System.Drawing.Point(16, 128);
            this.tbCodeSize.MaxLength = 8;
            this.tbCodeSize.Name = "tbCodeSize";
            this.tbCodeSize.Size = new System.Drawing.Size(176, 30);
            this.tbCodeSize.TabIndex = 3;
            this.tbCodeSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodeSize_KeyPress);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(16, 176);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(176, 30);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Рассчитать!";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblLaboriousness
            // 
            this.lblLaboriousness.AutoSize = true;
            this.lblLaboriousness.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaboriousness.Location = new System.Drawing.Point(253, 20);
            this.lblLaboriousness.Name = "lblLaboriousness";
            this.lblLaboriousness.Size = new System.Drawing.Size(138, 23);
            this.lblLaboriousness.TabIndex = 5;
            this.lblLaboriousness.Text = "Трудоемкость: ";
            // 
            // lblDebvelop
            // 
            this.lblDebvelop.AutoSize = true;
            this.lblDebvelop.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebvelop.Location = new System.Drawing.Point(253, 70);
            this.lblDebvelop.Name = "lblDebvelop";
            this.lblDebvelop.Size = new System.Drawing.Size(137, 23);
            this.lblDebvelop.TabIndex = 6;
            this.lblDebvelop.Text = "Длительность: ";
            // 
            // lblProductivity
            // 
            this.lblProductivity.AutoSize = true;
            this.lblProductivity.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductivity.Location = new System.Drawing.Point(253, 170);
            this.lblProductivity.Name = "lblProductivity";
            this.lblProductivity.Size = new System.Drawing.Size(159, 23);
            this.lblProductivity.TabIndex = 7;
            this.lblProductivity.Text = "Продуктивность: ";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Font = new System.Drawing.Font("Malgun Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.Location = new System.Drawing.Point(253, 120);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(147, 23);
            this.lblStaff.TabIndex = 7;
            this.lblStaff.Text = "Разработчиков: ";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 161);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 12);
            this.lblError.TabIndex = 8;
            // 
            // FormBasicModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 230);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.lblProductivity);
            this.Controls.Add(this.lblDebvelop);
            this.Controls.Add(this.lblLaboriousness);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.tbCodeSize);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblName1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormBasicModel";
            this.Text = "COCOMO:Basic";
            this.Load += new System.EventHandler(this.FormBasicModel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.TextBox tbCodeSize;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblLaboriousness;
        private System.Windows.Forms.Label lblDebvelop;
        private System.Windows.Forms.Label lblProductivity;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblError;
    }
}

