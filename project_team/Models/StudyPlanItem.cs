using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_team.Models
{
    public class StudyPlanItem
    {
        public string SubjectName { get; set; }
        public double Hours { get; set; }
        public string Priority { get; set; }

        public StudyPlanItem() { }

        public StudyPlanItem(string subjectName, double hours, string priority)
        {
            SubjectName = subjectName;
            Hours = hours;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{SubjectName} -> {Hours:0.0} hours ({Priority})";
        }
    }
    public class StudyPlanGenerator
    {
        private Subject[] subjects;
        private int count;

        public StudyPlanGenerator(Subject[] subjects, int count)
        {
            this.subjects = subjects;
            this.count = count;
        }

        public StudyPlanItem[] Generate(double dailyHours)
        {
            StudyPlanItem[] plan = new StudyPlanItem[count];

            int totalWeight = 0;
            int[] weights = new int[count];

            for (int i = 0; i < count; i++)
            {
                weights[i] = subjects[i].ProbabilityScore();
                totalWeight += weights[i];
            }

            if (totalWeight == 0)
                totalWeight = 1;

            for (int i = 0; i < count; i++)
            {
                double ratio = (double)weights[i] / totalWeight;

                plan[i] = new StudyPlanItem
                {
                    SubjectName = subjects[i].Name,
                    Hours = ratio * dailyHours,
                    Priority = subjects[i].GetPriority()
                };
            }

            return plan;
        }
    }
}