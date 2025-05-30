using Npgsql;
using System.Data;

namespace PR8
{
    public partial class MainForm : Form
    {
        public static NpgsqlConnection conn;
        NpgsqlDataAdapter adapter;
        DataTable dataTable;
        string currentTable;
        Dictionary<string, Dictionary<int, string>> lookupData = new Dictionary<string, Dictionary<int, string>>();

        Dictionary<string, Dictionary<string, string>> foreignKeysMap = new Dictionary<string, Dictionary<string, string>>
        {
            ["сделки"] = new Dictionary<string, string>
            {
                ["соискатель"] = "соискатели",
                ["вакансия"] = "работодатели",
                ["сотрудник"] = "сотрудники"
            }
        };

        public MainForm()
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=YP_DB;Username=postgres;Password=4825;");
            conn.Open();
            comboBox1.Items.AddRange(new Object[] { "работодатели", "соискатели", "сотрудники", "сделки" });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTable = comboBox1.Text;
            LoadLookupTables();

            adapter = new NpgsqlDataAdapter($"select * from {currentTable};", conn);
            dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["ин"].Visible = false;

            ReplaceForeignKeyColumns();

            dataGridView1.DefaultValuesNeeded -= dataGridView1_DefaultValuesNeeded;
            dataGridView1.DefaultValuesNeeded += dataGridView1_DefaultValuesNeeded;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            NpgsqlCommandBuilder npgsqlCommandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(dataTable);
            MessageBox.Show("Изменения сохранены.");
        }

        private string GetValueColumn(string tableName)
        {
            switch (tableName)
            {
                case "соискатели":
                case "сотрудники":
                    return "фио";
                case "работодатели":
                    return "организация";
                default:
                    return "ин";
            }
        }
        private void LoadLookupTables()
        {
            var requiredLookups = foreignKeysMap.Values
                .SelectMany(d => d.Values)
                .Distinct()
                .ToList();

            foreach (var table in requiredLookups)
            {
                string keyColumn = "ин";
                string valueColumn = GetValueColumn(table);
                lookupData[table] = LoadLookup(table, keyColumn, valueColumn);
            }
        }

        private Dictionary<int, string> LoadLookup(string table, string key, string column)
        {
            var dict = new Dictionary<int, string>();
            try
            {
                using (var cmd = new NpgsqlCommand($"select {key}, {column} from {table};", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dict.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }

            return dict;
        }

        private void ReplaceForeignKeyColumns()
        {
            if (!foreignKeysMap.TryGetValue(currentTable, out var fkColumns))
                return;

            foreach (var fk in fkColumns)
            {
                string columnName = fk.Key;
                string lookupTable = fk.Value;

                if (!dataTable.Columns.Contains(columnName))
                    continue;

                var combo = new DataGridViewComboBoxColumn
                {
                    Name = columnName,
                    DataPropertyName = columnName,
                    DataSource = lookupData[lookupTable].ToList(),
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    FlatStyle = FlatStyle.Flat
                };

                int index = dataGridView1.Columns[columnName].Index;
                dataGridView1.Columns.Remove(columnName);
                dataGridView1.Columns.Insert(index, combo);
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (!foreignKeysMap.TryGetValue(currentTable, out var fkColumns))
                return;

            foreach (var fk in fkColumns)
            {
                string columnName = fk.Key;
                string lookupTable = fk.Value;

                if (lookupData.TryGetValue(lookupTable, out var lookup) && lookup.Count > 0)
                {
                    e.Row.Cells[columnName].Value = lookup.First().Key;
                }
            }
        }
        private void pretendents_Click(object sender, EventArgs e)
        {
            PretendentsForm form = new PretendentsForm();
            form.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}