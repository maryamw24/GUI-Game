using MarioGameGUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MarioGameGUI.GL
{
    public class Game
    {
        GameGrid grid;
        Form gameGUI;
        Mario mario;
        Turtle Turtle;
        List<Fire> mFires = new List<Fire>();

        public Game(Form gameGUI)
        {
            this.gameGUI = gameGUI;
            Grid = new GameGrid(13,79);
            mario = new Mario(MarioGameGUI.Properties.Resources.Mario, Grid.getCell(11, 5));
            Turtle1 = new Turtle(MarioGameGUI.Properties.Resources.Turtle, Grid.getCell(11, 25));
            printMaze(Grid);

        }
        public int GetHealth()
        {
            return Turtle.Health;
        }

        public void addMarioFire(Fire f)
        {
            MFires.Add(f);
        }
        

        public Mario Mario { get => mario; set => mario = value; }
        public GameGrid Grid { get => grid; set => grid = value; }
        public List<Fire> MFires { get => mFires; set => mFires = value; }
        public Turtle Turtle1 { get => Turtle; set => Turtle = value; }

        public static Image GetGameObject(char displayCharacter)
        {
            Image img = MarioGameGUI.Properties.Resources.sky;
            if(displayCharacter == '|' )
            {
                img = MarioGameGUI.Properties.Resources.Pipe;
            }
            else if(displayCharacter == '%')
            {
                 img = MarioGameGUI.Properties.Resources.Brick;
            }
            else if (displayCharacter == '=')
            {
                img = MarioGameGUI.Properties.Resources.brick2;
            }
            else if(displayCharacter == 'm')
            {
                img = MarioGameGUI.Properties.Resources.Mario;
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
        }
        public static GameObject getBlankGameObject()
        {
            return new GameObject(GameObjectType.None, Resources.sky);
        }


    }
}
