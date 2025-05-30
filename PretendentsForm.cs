using Npgsql;
using System.Data;

namespace PR8
{
    public partial class PretendentsForm : Form
    {
        NpgsqlCommand cmd;
        NpgsqlDataReader reader;
        DataTable dataTable;

        public PretendentsForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            cmd = new NpgsqlCommand("select должность from соискатели group by должность;", MainForm.conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
                post.Items.Add(reader[0].ToString());

            cmd.Cancel();
            reader.Close();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            pretendentsList.Controls.Clear();
            string query = $"select фио, ((date(now()) - дата_рождения) / 365) возраст, пол, должность, образование, квалификация, зп, стаж, дата_заполнения, доп_информация from соискатели where ин is not null";
            if (post.Text != "") query += $" and должность like '%{post.Text}%'";
            if (qualification.Text != "") query += $" and квалификация like '%{qualification.Text}%'";
            if (education.Text != "") query += $" and образование like '%{education.Text}%'";
            if (experience.Text != "") query += $" and стаж = {experience.Text}";
            if (otherInfo.Text != "") query += $" and доп_информация like '%{otherInfo.Text}%'";
            try
            {

                cmd = new NpgsqlCommand(query, MainForm.conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выполнения запроса: " + ex.Message);
                return;
            }

            while (reader.Read())
            {

                Panel pretententPanel = new Panel();
                {
                    pretententPanel.AutoScroll = true;
                    pretententPanel.Location = new Point(3, 3);
                    pretententPanel.BackColor = Color.White;
                    pretententPanel.Name = "panel1";
                    pretententPanel.Size = new Size(pretendentsList.Width - 30, 170);
                    pretententPanel.TabIndex = 0;
                }

                CreateLabel(pretententPanel, new Point(10, 1), "ФИО: " + reader["фио"].ToString());
                CreateLabel(pretententPanel, new Point(10, 16), "Возраст: " + reader["возраст"].ToString());
                CreateLabel(pretententPanel, new Point(10, 31), "Пол: " + reader["пол"].ToString());
                CreateLabel(pretententPanel, new Point(10, 46), "Должность: " + reader["должность"].ToString());
                CreateLabel(pretententPanel, new Point(10, 61), "Образование: " + reader["образование"].ToString());
                CreateLabel(pretententPanel, new Point(10, 76), "Квалификация: " + reader["квалификация"].ToString());
                CreateLabel(pretententPanel, new Point(10, 91), "Стаж: " + reader["стаж"].ToString());
                CreateLabel(pretententPanel, new Point(10, 106), "Предп. З/П: " + reader["зп"].ToString());
                CreateLabel(pretententPanel, new Point(10, 121), "Дата заполнения: " + reader["дата_заполнения"].ToString());
                CreateLabel(pretententPanel, new Point(10, 136), "Доп. информация: " + reader["доп_информация"].ToString());

                pretendentsList.Controls.Add(pretententPanel);
            }
            cmd.Cancel();
            reader.Close();
        }

        private void CreateLabel(Panel parent, Point pos, string text, string? name = "label")
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = pos;
            label.Name = name;
            label.Size = new Size(80, 15);
            label.TabIndex = 11;
            label.Text = text;
            parent.Controls.Add(label);
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PretendentsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
