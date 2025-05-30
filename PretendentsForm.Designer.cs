namespace PR8
{
    partial class PretendentsForm
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
            pretendentsList = new FlowLayoutPanel();
            npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            back = new Button();
            post = new ComboBox();
            searchBtn = new Button();
            label2 = new Label();
            label7 = new Label();
            education = new TextBox();
            label9 = new Label();
            qualification = new TextBox();
            label10 = new Label();
            otherInfo = new TextBox();
            label1 = new Label();
            experience = new TextBox();
            SuspendLayout();
            // 
            // pretendentsList
            // 
            pretendentsList.AutoScroll = true;
            pretendentsList.BackColor = Color.FromArgb(250, 179, 132);
            pretendentsList.Location = new Point(12, 9);
            pretendentsList.Name = "pretendentsList";
            pretendentsList.Size = new Size(534, 351);
            pretendentsList.TabIndex = 0;
            // 
            // npgsqlCommandBuilder1
            // 
            npgsqlCommandBuilder1.QuotePrefix = "\"";
            npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // back
            // 
            back.BackColor = Color.FromArgb(0, 147, 53);
            back.Font = new Font("Segoe UI", 9F);
            back.ForeColor = Color.White;
            back.Location = new Point(552, 178);
            back.Margin = new Padding(3, 2, 3, 2);
            back.Name = "back";
            back.Size = new Size(130, 24);
            back.TabIndex = 7;
            back.Text = "Назад";
            back.UseVisualStyleBackColor = false;
            back.Click += back_Click;
            // 
            // post
            // 
            post.BackColor = Color.FromArgb(250, 179, 132);
            post.FormattingEnabled = true;
            post.Location = new Point(666, 6);
            post.Name = "post";
            post.Size = new Size(121, 23);
            post.TabIndex = 9;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = Color.FromArgb(0, 147, 53);
            searchBtn.Font = new Font("Segoe UI", 9F);
            searchBtn.ForeColor = Color.White;
            searchBtn.Location = new Point(552, 150);
            searchBtn.Margin = new Padding(3, 2, 3, 2);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(235, 24);
            searchBtn.TabIndex = 12;
            searchBtn.Text = "Искать";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(552, 9);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 13;
            label2.Text = "Должность";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(552, 67);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 22;
            label7.Text = "Образование";
            // 
            // education
            // 
            education.BackColor = Color.FromArgb(250, 179, 132);
            education.Location = new Point(666, 64);
            education.Name = "education";
            education.Size = new Size(121, 23);
            education.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(552, 38);
            label9.Name = "label9";
            label9.Size = new Size(88, 15);
            label9.TabIndex = 26;
            label9.Text = "Квалификация";
            // 
            // qualification
            // 
            qualification.BackColor = Color.FromArgb(250, 179, 132);
            qualification.Location = new Point(666, 35);
            qualification.Name = "qualification";
            qualification.Size = new Size(121, 23);
            qualification.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(552, 125);
            label10.Name = "label10";
            label10.Size = new Size(100, 15);
            label10.TabIndex = 28;
            label10.Text = "Др. информация";
            // 
            // otherInfo
            // 
            otherInfo.BackColor = Color.FromArgb(250, 179, 132);
            otherInfo.Location = new Point(666, 122);
            otherInfo.Name = "otherInfo";
            otherInfo.Size = new Size(121, 23);
            otherInfo.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(552, 96);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 30;
            label1.Text = "Стаж";
            // 
            // experience
            // 
            experience.BackColor = Color.FromArgb(250, 179, 132);
            experience.Location = new Point(666, 93);
            experience.Name = "experience";
            experience.Size = new Size(121, 23);
            experience.TabIndex = 29;
            // 
            // PretendentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(792, 367);
            Controls.Add(label1);
            Controls.Add(experience);
            Controls.Add(label10);
            Controls.Add(otherInfo);
            Controls.Add(label9);
            Controls.Add(qualification);
            Controls.Add(label7);
            Controls.Add(education);
            Controls.Add(label2);
            Controls.Add(searchBtn);
            Controls.Add(post);
            Controls.Add(back);
            Controls.Add(pretendentsList);
            Name = "PretendentsForm";
            Text = "SalesForm";
            Load += PretendentsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel pretendentsList;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private Button back;
        private ComboBox post;
        private Button searchBtn;
        private Label label2;
        private Label label7;
        private TextBox education;
        private Label label9;
        private TextBox qualification;
        private Label label10;
        private TextBox otherInfo;
        private Label label1;
        private TextBox experience;
    }
}