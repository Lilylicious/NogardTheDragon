using Microsoft.Xna.Framework;
using NogardTheDragon.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Utilities
{
    public class HighScore
    {
        public List<HighScore> hsList;
        string name;
        public int score;

        public HighScore(string name, int score)
        {
            this.name = name;
            this.score = score;
            hsList = new List<HighScore>();
        }

        public override string ToString()
        {
            return name + "," + score;
        }

        public string ScoreToString()
        {
            return score.ToString();
        }
        public string NameToString()
        {
            return name;
        }

        public void ReadFromFile()
        {
            StreamReader file = new StreamReader(@"HighScore.txt");
            string line;
            hsList.Clear();
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                string[] temp = line.Split(',');
                int score = int.Parse(temp[1]);
                HighScore h = new HighScore(temp[0], score);
                hsList.Add(h);
            }
            file.Close();
        }

        public void SaveToFile()
        {
            StreamWriter file = new StreamWriter(@"HighScore.txt");
            
            for (int i = 0; i < hsList.Count; i++)
            {
                file.WriteLine(hsList[i].ToString());
            }
            file.Close();
        }
    }
}
