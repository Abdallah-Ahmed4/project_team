using System;
using System.IO;

namespace project_team.Models
{ 
    public enum DifficultyLevel { Easy = 1, Medium = 2, Hard = 3 }

    public abstract class Subject
    {
        public string Name { get; set; }
        public int DaysLeft { get; set; }
        public DifficultyLevel Level { get; set; }

        public Subject(string name, DifficultyLevel level, int daysLeft)
        {
            Name = name;
            Level = level;
            DaysLeft = daysLeft;
        }

        public abstract int ProbabilityScore();

        public string GetPriority()
        {
            
            return $"{Name} | {Level} | Days Left: {DaysLeft} | Score: {ProbabilityScore()}";
        }
        

 
        public static bool operator <(Subject a, Subject b)
        {
            return a.ProbabilityScore() < b.ProbabilityScore();

        }

        public static bool operator >(Subject a, Subject b)
        {
            return a.ProbabilityScore() > b.ProbabilityScore();
        }
    }


    public class ScientificSubject : Subject
    {
        public ScientificSubject(string name, DifficultyLevel level, int daysLeft)
            : base(name, level, daysLeft){ }

        public override int ProbabilityScore()
        {
            int urgency = DaysLeft <= 3 ? 3 : DaysLeft <= 7 ? 2 : 1;
            return (int)Level + urgency;
        }
    }


    public class LiterarySubject : Subject
    {
        public LiterarySubject(string name, DifficultyLevel level, int daysLeft)
            : base(name, level, daysLeft)
        {
        }

        public override int ProbabilityScore()
        {
            int urgency = DaysLeft <= 3 ? 3 : DaysLeft <= 7 ? 2 : 1;
            return (int)Level + urgency;
        }
    }


    public class SubjectManager
    {
        private Subject[] subjects;
        private int count;

        public SubjectManager(int size = 100)
        {
            subjects = new Subject[size];
            count = 0;
        }

        public void AddSubject(Subject s)
        {
            if (count >= subjects.Length)
                throw new Exception("Array is full!");

            subjects[count++] = s;
        }

        public Subject[] GetAll()
        {
            Subject[] result = new Subject[count];
            for (int i = 0; i < count; i++)
                result[i] = subjects[i];

            return result;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= count)
                throw new Exception("Invalid index!");

            for (int i = index; i < count - 1; i++)
                subjects[i] = subjects[i + 1];

            count--;
        }

        public void SaveToFile()
        {
            string[] lines = new string[count];

            for (int i = 0; i < count; i++)
            {
                lines[i] = $"{subjects[i].Name},{subjects[i].Level},{subjects[i].DaysLeft}";
            }

            File.WriteAllLines("subjects.txt", lines);
        }

   
        public void LoadFromFile()
        {
            if (!File.Exists("subjects.txt")) return;

            var lines = File.ReadAllLines("subjects.txt");
            count = 0;

            foreach (var line in lines)
            {
                var p = line.Split(',');

                string name = p[0];
                DifficultyLevel level = (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), p[1]);
                int days = int.Parse(p[2]);

                subjects[count++] = new ScientificSubject(name, level, days);
            }
        }
        public int Count
        {
            get { return count; }
        }

        public void SortByPriority()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (subjects[j] < subjects[j + 1])
                    {
                        Subject temp = subjects[j];
                        subjects[j] = subjects[j + 1];
                        subjects[j + 1] = temp;
                    }
                }
            }
        }
    }
}