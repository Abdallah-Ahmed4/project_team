using project_team.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace project_team.Forms
{
    public partial class SubjectForm : Form
    {
        SubjectManager manager = new SubjectManager();

        public object numHours { get; private set; }

        public SubjectForm()
        {
            InitializeComponent();

            cmbDifficulty.DataSource = Enum.GetValues(typeof(DifficultyLevel));
            cmbType.Items.Add("Scientific");
            cmbType.Items.Add("Literary");
            manager.LoadFromFile();
            RefreshList();
        }
        void RefreshList()
        {
            lstSubjects.Items.Clear();

            foreach (var s in manager.GetAll())
            {
                lstSubjects.Items.Add($" {s.GetPriority()}");
            }
        }
        private void SubjectForm_Load(object sender, EventArgs e)
        {
         
           
        
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {


        }



        private void cmDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                DifficultyLevel diff = (DifficultyLevel)cmbDifficulty.SelectedItem;
                int days = int.Parse(txtDays.Text);
                Subject s;

                if (cmbType.SelectedItem.ToString() == "Scientific")
                    s = new ScientificSubject(name, diff, days);
                else
                    s = new LiterarySubject(name, diff, days);

                manager.AddSubject(s);
                manager.SortByPriority();
                RefreshList();

                MessageBox.Show("Added!");
            }

            catch
            {
                MessageBox.Show("Invalid data!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            manager.SaveToFile();
            MessageBox.Show("Saved!");
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator5_Click(object sender, EventArgs e)
        {

        }

        public void lstSubjects_Paint(object sender, PaintEventArgs e)

        {

        }

        private void Add_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (manager.Count == 0)
            {
                MessageBox.Show("Add subjects first");
                return; 
            }



            double hours = (double)guna2NumericUpDown1.Value;
            var gen = new StudyPlanGenerator(manager.GetAll(), manager.Count);
            var plan = gen.Generate(hours);

            PlanForm f = new PlanForm(plan);
            f.Show();

            this.Hide();
        }
    }
} 
