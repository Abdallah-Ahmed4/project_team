using System;
using System.IO;

namespace project_team.Models
{
    public class user
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public user(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void savetofile()
        {
            string path = "user.txt";
            string data = Name + "," + Email + "," + Password;
            File.AppendAllText(path, data + Environment.NewLine);
        }

        public static user load(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            string path = "user.txt";

            if (!File.Exists(path))
                return null;

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (data.Length == 3)
                {
                    string name = data[0];
                    string storedEmail = data[1];
                    string storedPassword = data[2];

                    if (storedEmail == email && storedPassword == password)
                    {
                        return new user(name, storedEmail, storedPassword);
                    }
                }
            }

            return null;
        }

        public class Login
        {
            public static user LoadLogin(string email, string password)
            {
                user u = user.load(email, password);

                if (u != null)
                {
                    Console.WriteLine("Login successful!");
                    return u;
                }
                else
                {
                    Console.WriteLine("Invalid email or password.");
                    return null;
                }
            }
        }
    }
}