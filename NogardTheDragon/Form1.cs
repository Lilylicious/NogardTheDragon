using NogardTheDragon.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NogardTheDragon
{
    public partial class Form1 : Form
    {
        NogardGame game;
        public HighScore hs;
        public bool GameSaved;

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
