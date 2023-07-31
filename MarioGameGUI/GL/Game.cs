using MarioGameGUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MarioGameGUI.GL
{
    public class Game
    {
        int count = 0; 
        int stage;
        GameGrid grid;
        Form gameGUI;
        Mario mario;
        Turtle Turtle;
        int score;
        int goombaHealth = 100;
        List<GoombaH> goombas;
        List<Fire> mFires = new List<Fire>();
        List<Fire> gFires = new List<Fire>();

        public Game(Form gameGUI, int s)
        {
            this.Stage = s;
            Goombas = new List<GoombaH>();
            this.gameGUI = gameGUI;
            if (this.Stage == 0)
            {
                Grid = new GameGrid(13, 77,"Maze.txt");
                mario = new Mario(MarioGameGUI.Properties.Resources.Mario, Grid.getCell(11, 10), GameDirection.Right);
                Turtle1 = new Turtle(MarioGameGUI.Properties.Resources.Turtle, Grid.getCell(11, 25));
                printMaze(Grid);
            }
            if (this.Stage == 1)
            {
                Grid = new GameGrid(14, 79, "Maze1.txt");
                mario = new Mario(MarioGameGUI.Properties.Resources.Mario, Grid.getCell(11, 10), GameDirection.Right);
                Turtle1 = new Turtle(MarioGameGUI.Properties.Resources.Princess, Grid.getCell(2, 66));
                InitializeGoombas(); 
                printMaze(Grid);
            }
            
        }
        public void SetStage()
        {
            if (this.Stage == 2)
            {
                Grid.setGrid(14, 79, "Maze1.txt");
                mario.SetMario(Grid.getCell(11, 10));
                InitializeGoombas();
                printMaze(Grid);
            }
        }
        private void InitializeGoombas()
        {
            GoombaH g1 = new GoombaH(MarioGameGUI.Properties.Resources.goomba, Grid.getCell(4, 6), GameDirection.Left);
            GoombaH g3 = new GoombaH(MarioGameGUI.Properties.Resources.goomba, Grid.getCell(12, 6), GameDirection.Right);
            GoombaH g2 = new GoombaH(MarioGameGUI.Properties.Resources.goomba, Grid.getCell(3, 50), GameDirection.Right);
            GoombaH g4 = new GoombaH(MarioGameGUI.Properties.Resources.goomba, Grid.getCell(12, 50), GameDirection.Left);
            AddGoombaas(g1);
            AddGoombaas(g2);
            AddGoombaas(g3);
            AddGoombaas(g4);
        }
        
        public void RemoveGoombas()
        {
            CheckGoomba();
            for (int i = 0; i < Goombas.Count; i++)
            {
                if (Goombas[i].IsDead)
                {
                    GoombaHealth -= 25;
                    Goombas.RemoveAt(i);
                    Score += 10;
                }
            }
        }
        public void removeAllFires()
        {
            for(int i =0; i < MFires.Count; i++) {
                MFires.RemoveAt(i);
            }        
        }
        private void CheckGoomba()
        {
            foreach (GoombaH g in Goombas)
            {
                if (g.Health <= 0)
                {
                    g.IsDead = true;
                    Count++;
                }
            }
            
        }
        private void AddGoombaas(GoombaH g)
        {
            Goombas.Add(g);
        }
        public int GetHealth()
        {
            return Mario.Health;
        }

        public void addMarioFire(Fire f)
        {
            MFires.Add(f);
        }
        public void addGoombaFire(Fire f)
        {
            GFires.Add(f);
        }


        public Mario Mario { get => mario; set => mario = value; }
        public GameGrid Grid { get => grid; set => grid = value; }
        public List<Fire> MFires { get => mFires; set => mFires = value; }
        public Turtle Turtle1 { get => Turtle; set => Turtle = value; }

        public List<GoombaH> Goombas { get => goombas; set => goombas = value; }
        public List<Fire> GFires { get => gFires; set => gFires = value; }
        public int Score { get => score; set => score = value; }
        public int Stage { get => stage; set => stage = value; }
        public int Count { get => count; set => count = value; }
        public int GoombaHealth { get => goombaHealth; set => goombaHealth = value; }

        public static Image GetGameObject(char displayCharacter)
        {
            Image img = MarioGameGUI.Properties.Resources.sky;
            if (displayCharacter == '|')
            {
                img = MarioGameGUI.Properties.Resources.Pipe;
            }
            else if (displayCharacter == '%')
            {
                img = MarioGameGUI.Properties.Resources.wall1;
            }
            else if (displayCharacter == '=')
            {
                img = MarioGameGUI.Properties.Resources.brick2;
            }
            else if (displayCharacter == 'm')
            {
                img = MarioGameGUI.Properties.Resources.Mario;
            }
            else if(displayCharacter== '!')
            {
                img = MarioGameGUI.Properties.Resources.End;
            }
            else if (displayCharacter == 'c')
            {
                img = MarioGameGUI.Properties.Resources.coin;
            }
            return img;
        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    gameGUI.Controls.Add(cell.PictureBox);
                }
            }
        }
        public void GenerateGoombaFire()
        {
            foreach (GoombaH g in Goombas)
            {
                if ( g. CurrentCell.Row == mario.CurrentCell.Row && g.CurrentCell.Column < mario.CurrentCell.Column)
                {

                    GameCell cell = g.CurrentCell.nextCell(GameDirection.Right);
                    Fire f = new Fire(MarioGameGUI.Properties.Resources.bullet, cell, GameDirection.Right);
                    gFires.Add(f);
                }
                else if (g.CurrentCell.Row == mario.CurrentCell.Row && g.CurrentCell.Column > mario.CurrentCell.Column)
                {
                    GameCell cell = g.CurrentCell.nextCell(GameDirection.Left);
                    Fire f = new Fire(MarioGameGUI.Properties.Resources.bullet, cell, GameDirection.Left);
                    gFires.Add(f);
                }

            }

        }
        public void RemoveFire()
        {
            for (int i = 0; i < MFires.Count; i++)
            {
                if (MFires[i].Stopped)
                {
                    MFires[i].CurrentCell.SetGameObject(getBlankGameObject());
                    MFires.RemoveAt(i);
                }
            }
            for (int i = 0; i < GFires.Count; i++)
            {
                if (GFires[i].Stopped)
                {
                    GFires[i].CurrentCell.SetGameObject(getBlankGameObject());
                    GFires.RemoveAt(i);
                }
            }

        }
        public static GameObject getBlankGameObject()
        {
            return new GameObject(GameObjectType.None, Resources.sky);
        }


    }
}
