using project_team.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_team.Forms
{
    public partial class PlanForm : Form
    {
        Subject[] subjects;
        int count;
        public PlanForm(StudyPlanItem[] plan)
        {
            InitializeComponent();

            lstPlan.Items.Clear();

            foreach (var item in plan)
            {
                lstPlan.Items.Add(item);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SubjectForm s = new SubjectForm();
            s.Show();
            this.Hide();

        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlanForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
