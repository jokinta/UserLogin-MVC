using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UserLogin1
{
    public static class Logger
    {
        private static readonly List<string> currentSessionActivities = new List<string>();

        static public  void LogActivity (string activity, string username)
        {
            string activityLine = DateTime.Now + " ; "
                + username + " ; " + LoginValidation.CurrentUserRole + " ; " + activity;
                currentSessionActivities.Add(activityLine);
                File.AppendAllText("test.txt", activityLine + "\n");
            
            UserContext context = new UserContext();
            try
            {
                Logs log = new Logs(activityLine);
                context.Logs.Add(log);
                context.SaveChanges();
            } catch ( Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
            
        }

        static public void LogActivitySignForm(string activity, string username, string role)
        {
            string activityLine = DateTime.Now + " ; "
                + username + " ; " + role + " ; " + activity;
            currentSessionActivities.Add(activityLine);
            File.AppendAllText("test.txt", activityLine + "\n");

            UserContext context = new UserContext();
            try
            {
                Logs log = new Logs(activityLine);
                context.Logs.Add(log);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }

        }




        static public void DisplayLog ()
        {
            StreamReader sr = new StreamReader("test.txt");
            string line = sr.ReadLine();
            Console.WriteLine("{0}\n", line);   
        }

        static public void GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in currentSessionActivities)
            {
                sb.Append(str);
                sb.Append('\n');
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
