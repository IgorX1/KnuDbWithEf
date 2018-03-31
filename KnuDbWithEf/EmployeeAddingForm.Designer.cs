namespace KnuDbWithEf
{
    partial class EmployeeAddingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeAddingForm));
            this.degreeComboBox2 = new System.Windows.Forms.ComboBox();
            this.dEGREELISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cathedraComboBox2 = new System.Windows.Forms.ComboBox();
            this.cATHEDRABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentComboBox2 = new System.Windows.Forms.ComboBox();
            this.dEPARTMENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.yearTextBox2 = new System.Windows.Forms.TextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.attentionTextBox = new System.Windows.Forms.Label();
            this.upperTextBox = new System.Windows.Forms.Label();
            this.saveNewBtn = new System.Windows.Forms.Button();
            this.cancelNewBtn = new System.Windows.Forms.Button();
            this.photoNewBtn = new System.Windows.Forms.Button();
            this.ratingTextBox2 = new System.Windows.Forms.TextBox();
            this.ratingLabel2 = new System.Windows.Forms.Label();
            this.degreeLabel2 = new System.Windows.Forms.Label();
            this.emailTextBox2 = new System.Windows.Forms.TextBox();
            this.emailLabel2 = new System.Windows.Forms.Label();
            this.cathedraLabel2 = new System.Windows.Forms.Label();
            this.departmentLabel2 = new System.Windows.Forms.Label();
            this.nameTextBox2 = new System.Windows.Forms.TextBox();
            this.nameLabel2 = new System.Windows.Forms.Label();
            this.employeePhotoPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dEGREELISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cATHEDRABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPARTMENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePhotoPB)).BeginInit();
            this.SuspendLayout();
            // 
            // degreeComboBox2
            // 
            this.degreeComboBox2.DataSource = this.dEGREELISTBindingSource;
            this.degreeComboBox2.DisplayMember = "D_NAME";
            this.degreeComboBox2.FormattingEnabled = true;
            this.degreeComboBox2.Location = new System.Drawing.Point(155, 273);
            this.degreeComboBox2.Name = "degreeComboBox2";
            this.degreeComboBox2.Size = new System.Drawing.Size(446, 24);
            this.degreeComboBox2.TabIndex = 56;
            this.degreeComboBox2.ValueMember = "ID";
            // 
            // dEGREELISTBindingSource
            // 
            this.dEGREELISTBindingSource.DataSource = typeof(EmployeeEf.DEGREELIST);
            // 
            // cathedraComboBox2
            // 
            this.cathedraComboBox2.DataSource = this.cATHEDRABindingSource;
            this.cathedraComboBox2.DisplayMember = "C_NAME";
            this.cathedraComboBox2.FormattingEnabled = true;
            this.cathedraComboBox2.Location = new System.Drawing.Point(155, 209);
            this.cathedraComboBox2.Name = "cathedraComboBox2";
            this.cathedraComboBox2.Size = new System.Drawing.Size(446, 24);
            this.cathedraComboBox2.TabIndex = 55;
            this.cathedraComboBox2.ValueMember = "ID";
            // 
            // cATHEDRABindingSource
            // 
            this.cATHEDRABindingSource.DataSource = typeof(EmployeeEf.CATHEDRA);
            this.cATHEDRABindingSource.CurrentChanged += new System.EventHandler(this.cATHEDRABindingSource_CurrentChanged);
            // 
            // departmentComboBox2
            // 
            this.departmentComboBox2.DataSource = this.dEPARTMENTBindingSource;
            this.departmentComboBox2.DisplayMember = "D_NAME";
            this.departmentComboBox2.FormattingEnabled = true;
            this.departmentComboBox2.Location = new System.Drawing.Point(155, 179);
            this.departmentComboBox2.Name = "departmentComboBox2";
            this.departmentComboBox2.Size = new System.Drawing.Size(446, 24);
            this.departmentComboBox2.TabIndex = 54;
            this.departmentComboBox2.ValueMember = "ID";
            this.departmentComboBox2.SelectedIndexChanged += new System.EventHandler(this.departmentComboBox2_SelectedIndexChanged);
            // 
            // dEPARTMENTBindingSource
            // 
            this.dEPARTMENTBindingSource.DataSource = typeof(EmployeeEf.DEPARTMENT);
            // 
            // yearTextBox2
            // 
            this.yearTextBox2.Location = new System.Drawing.Point(155, 310);
            this.yearTextBox2.Name = "yearTextBox2";
            this.yearTextBox2.Size = new System.Drawing.Size(446, 22);
            this.yearTextBox2.TabIndex = 53;
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(48, 315);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(107, 17);
            this.yearLabel.TabIndex = 52;
            this.yearLabel.Text = "Рік отримання:";
            // 
            // attentionTextBox
            // 
            this.attentionTextBox.AutoSize = true;
            this.attentionTextBox.Location = new System.Drawing.Point(147, 28);
            this.attentionTextBox.Name = "attentionTextBox";
            this.attentionTextBox.Size = new System.Drawing.Size(397, 51);
            this.attentionTextBox.TabIndex = 51;
            this.attentionTextBox.Text = "Увага! Залишати незаповнені поля заборонено!\r\nВи ж не хочете, щоб Ваш викладач ма" +
    "в ім\'я UNKNOWN :) ?\r\n\r\n";
            // 
            // upperTextBox
            // 
            this.upperTextBox.AutoSize = true;
            this.upperTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upperTextBox.Location = new System.Drawing.Point(144, 7);
            this.upperTextBox.Name = "upperTextBox";
            this.upperTextBox.Size = new System.Drawing.Size(459, 17);
            this.upperTextBox.TabIndex = 50;
            this.upperTextBox.Text = "Введіть інформацію про співробітника та оберіть його фото";
            // 
            // saveNewBtn
            // 
            this.saveNewBtn.Location = new System.Drawing.Point(155, 382);
            this.saveNewBtn.Name = "saveNewBtn";
            this.saveNewBtn.Size = new System.Drawing.Size(102, 42);
            this.saveNewBtn.TabIndex = 57;
            this.saveNewBtn.Text = "Save";
            this.saveNewBtn.Click += new System.EventHandler(this.saveNewBtn_Click);
            // 
            // cancelNewBtn
            // 
            this.cancelNewBtn.Location = new System.Drawing.Point(321, 382);
            this.cancelNewBtn.Name = "cancelNewBtn";
            this.cancelNewBtn.Size = new System.Drawing.Size(116, 42);
            this.cancelNewBtn.TabIndex = 48;
            this.cancelNewBtn.Text = "Очистити";
            this.cancelNewBtn.UseVisualStyleBackColor = true;
            this.cancelNewBtn.Click += new System.EventHandler(this.cancelNewBtn_Click);
            // 
            // photoNewBtn
            // 
            this.photoNewBtn.Location = new System.Drawing.Point(485, 382);
            this.photoNewBtn.Name = "photoNewBtn";
            this.photoNewBtn.Size = new System.Drawing.Size(116, 42);
            this.photoNewBtn.TabIndex = 47;
            this.photoNewBtn.Text = "Обрати фото";
            this.photoNewBtn.UseVisualStyleBackColor = true;
            this.photoNewBtn.Click += new System.EventHandler(this.photoNewBtn_Click);
            // 
            // ratingTextBox2
            // 
            this.ratingTextBox2.Location = new System.Drawing.Point(155, 338);
            this.ratingTextBox2.Name = "ratingTextBox2";
            this.ratingTextBox2.Size = new System.Drawing.Size(446, 22);
            this.ratingTextBox2.TabIndex = 46;
            // 
            // ratingLabel2
            // 
            this.ratingLabel2.AutoSize = true;
            this.ratingLabel2.Location = new System.Drawing.Point(48, 343);
            this.ratingLabel2.Name = "ratingLabel2";
            this.ratingLabel2.Size = new System.Drawing.Size(65, 17);
            this.ratingLabel2.TabIndex = 45;
            this.ratingLabel2.Text = "Рейтинг:";
            // 
            // degreeLabel2
            // 
            this.degreeLabel2.AutoSize = true;
            this.degreeLabel2.Location = new System.Drawing.Point(48, 287);
            this.degreeLabel2.Name = "degreeLabel2";
            this.degreeLabel2.Size = new System.Drawing.Size(60, 17);
            this.degreeLabel2.TabIndex = 44;
            this.degreeLabel2.Text = "Звання:";
            // 
            // emailTextBox2
            // 
            this.emailTextBox2.Location = new System.Drawing.Point(155, 245);
            this.emailTextBox2.Name = "emailTextBox2";
            this.emailTextBox2.Size = new System.Drawing.Size(446, 22);
            this.emailTextBox2.TabIndex = 43;
            // 
            // emailLabel2
            // 
            this.emailLabel2.AutoSize = true;
            this.emailLabel2.Location = new System.Drawing.Point(48, 250);
            this.emailLabel2.Name = "emailLabel2";
            this.emailLabel2.Size = new System.Drawing.Size(56, 17);
            this.emailLabel2.TabIndex = 42;
            this.emailLabel2.Text = "Пошта:";
            // 
            // cathedraLabel2
            // 
            this.cathedraLabel2.AutoSize = true;
            this.cathedraLabel2.Location = new System.Drawing.Point(48, 218);
            this.cathedraLabel2.Name = "cathedraLabel2";
            this.cathedraLabel2.Size = new System.Drawing.Size(72, 17);
            this.cathedraLabel2.TabIndex = 41;
            this.cathedraLabel2.Text = "Кафедра:";
            // 
            // departmentLabel2
            // 
            this.departmentLabel2.AutoSize = true;
            this.departmentLabel2.Location = new System.Drawing.Point(48, 179);
            this.departmentLabel2.Name = "departmentLabel2";
            this.departmentLabel2.Size = new System.Drawing.Size(84, 17);
            this.departmentLabel2.TabIndex = 40;
            this.departmentLabel2.Text = "Факультет:";
            // 
            // nameTextBox2
            // 
            this.nameTextBox2.Location = new System.Drawing.Point(155, 135);
            this.nameTextBox2.Name = "nameTextBox2";
            this.nameTextBox2.Size = new System.Drawing.Size(446, 22);
            this.nameTextBox2.TabIndex = 39;
            // 
            // nameLabel2
            // 
            this.nameLabel2.AutoSize = true;
            this.nameLabel2.Location = new System.Drawing.Point(48, 140);
            this.nameLabel2.Name = "nameLabel2";
            this.nameLabel2.Size = new System.Drawing.Size(42, 17);
            this.nameLabel2.TabIndex = 38;
            this.nameLabel2.Text = "П.І.Б:";
            // 
            // employeePhotoPB
            // 
            this.employeePhotoPB.Image = ((System.Drawing.Image)(resources.GetObject("employeePhotoPB.Image")));
            this.employeePhotoPB.Location = new System.Drawing.Point(9, 7);
            this.employeePhotoPB.Name = "employeePhotoPB";
            this.employeePhotoPB.Size = new System.Drawing.Size(132, 114);
            this.employeePhotoPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeePhotoPB.TabIndex = 37;
            this.employeePhotoPB.TabStop = false;
            // 
            // EmployeeAddingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 431);
            this.Controls.Add(this.degreeComboBox2);
            this.Controls.Add(this.cathedraComboBox2);
            this.Controls.Add(this.departmentComboBox2);
            this.Controls.Add(this.yearTextBox2);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.attentionTextBox);
            this.Controls.Add(this.upperTextBox);
            this.Controls.Add(this.saveNewBtn);
            this.Controls.Add(this.cancelNewBtn);
            this.Controls.Add(this.photoNewBtn);
            this.Controls.Add(this.ratingTextBox2);
            this.Controls.Add(this.ratingLabel2);
            this.Controls.Add(this.degreeLabel2);
            this.Controls.Add(this.emailTextBox2);
            this.Controls.Add(this.emailLabel2);
            this.Controls.Add(this.cathedraLabel2);
            this.Controls.Add(this.departmentLabel2);
            this.Controls.Add(this.nameTextBox2);
            this.Controls.Add(this.nameLabel2);
            this.Controls.Add(this.employeePhotoPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeAddingForm";
            this.ShowIcon = false;
            this.Text = "Додати співробітника";
            this.Load += new System.EventHandler(this.EmployeeAddingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dEGREELISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cATHEDRABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPARTMENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePhotoPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox degreeComboBox2;
        private System.Windows.Forms.ComboBox cathedraComboBox2;
        private System.Windows.Forms.ComboBox departmentComboBox2;
        private System.Windows.Forms.TextBox yearTextBox2;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label attentionTextBox;
        private System.Windows.Forms.Label upperTextBox;
        private System.Windows.Forms.Button saveNewBtn;
        private System.Windows.Forms.Button cancelNewBtn;
        private System.Windows.Forms.Button photoNewBtn;
        private System.Windows.Forms.TextBox ratingTextBox2;
        private System.Windows.Forms.Label ratingLabel2;
        private System.Windows.Forms.Label degreeLabel2;
        private System.Windows.Forms.TextBox emailTextBox2;
        private System.Windows.Forms.Label emailLabel2;
        private System.Windows.Forms.Label cathedraLabel2;
        private System.Windows.Forms.Label departmentLabel2;
        private System.Windows.Forms.TextBox nameTextBox2;
        private System.Windows.Forms.Label nameLabel2;
        private System.Windows.Forms.PictureBox employeePhotoPB;
        private System.Windows.Forms.BindingSource dEPARTMENTBindingSource;
        private System.Windows.Forms.BindingSource dEGREELISTBindingSource;
        private System.Windows.Forms.BindingSource cATHEDRABindingSource;
    }
}