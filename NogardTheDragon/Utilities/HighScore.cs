using System.Collections.Generic;
using System.IO;

namespace NogardTheDragon.Utilities
{
    public class HighScore
    {
        public List<HighScore> hsList;
        private readonly string name;
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
            var file = new StreamReader(@"Content/HighScore.txt");
            string line;
            hsList.Clear();
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                var temp = line.Split(',');
                var score = int.Parse(temp[1]);
                var h = new HighScore(temp[0], score);
                hsList.Add(h);
            }
            file.Close();
        }

        public void SaveToFile()
        {
            var file = new StreamWriter(@"Content/HighScore.txt");

            for (var i = 0; i < hsList.Count; i++)
                file.WriteLine(hsList[i].ToString());
            file.Close();
        }
    }
}