using System;
using System.Windows.Forms;
using NogardTheDragon.Utilities;

namespace NogardTheDragon
{
    public partial class Form1 : Form
    {
        private NogardGame game;
        public bool GameSaved;
        public HighScore hs;

        public Form1(NogardGame game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hs = new HighScore(textBox1.Text, NogardGame.TotalScore);
            hs.ReadFromFile();
            hs.hsList.Add(hs);
            hs.SaveToFile();
            GameSaved = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}