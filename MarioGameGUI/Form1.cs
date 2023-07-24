using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarioGameGUI.GL;
using EZInput;
using System.Drawing.Drawing2D;

namespace MarioGameGUI
{
    public partial class Form1 : Form
    {
        Game game;
        char movementStatus = 's';
        public Form1()
        {
            InitializeComponent();
            game = new Game(this);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveMario();
            move();
            MoveFire();
            game.RemoveFire();
            moveTurtle();
        }
        private void moveTurtle()
        {
            Turtle Turtle = game.Turtle1;
            Turtle.move(Turtle.nextCell());
        }
        private void MoveFire()
        {

            foreach (Fire f in game.MFires)
            {
                if (!f.Stopped)
                {
                    f.move(f.nextCell());
                }
                else
                {
                    continue;
                }

            }
        }

        private void MoveMario()
        {
            Mario mario = game.Mario;
            GameCell potentialNewCell = mario.CurrentCell;
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                potentialNewCell = mario.CurrentCell.nextCell(GameDirection.Left);
                GameCell currentCell = mario.CurrentCell;
                currentCell.SetGameObject(Game.getBlankGameObject());
                mario.move(potentialNewCell);
                movementStatus = 'd';
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                potentialNewCell = mario.CurrentCell.nextCell(GameDirection.Right);
                GameCell currentCell = mario.CurrentCell;
                currentCell.SetGameObject(Game.getBlankGameObject());
                mario.move(potentialNewCell);
                movementStatus = 'd';
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                int jumpCount = 0;
                for (int i = 0; i < 7; i++)
                {
                    potentialNewCell = mario.CurrentCell.nextCell(GameDirection.Up);
                    jumpCount++;
                GameCell currentCell = mario.CurrentCell;
                currentCell.SetGameObject(Game.getBlankGameObject());
                mario.move(potentialNewCell);
                }

                if (jumpCount == 7)
                {
                    movementStatus = 'd';

                }

            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                GameCell NewCell = mario.CurrentCell.nextCell(GameDirection.Right);
                Fire f = new Fire(MarioGameGUI.Properties.Resources.fire, NewCell, GameDirection.Right);
                game.addMarioFire(f);
            }


        }
        private void move()
        {
            Mario mario = game.Mario;
            GameCell potentialNewCell = mario.CurrentCell;
            GameCell nextCell;
            if (movementStatus == 'd')
            {
                nextCell = mario.CurrentCell.nextCell(GameDirection.Down);
                if (nextCell != potentialNewCell)
                {
                    GameCell currentCell = mario.CurrentCell;
                    currentCell.SetGameObject(Game.getBlankGameObject());
                    mario.move(nextCell);
                }
                else
                {
                    movementStatus = 's';
                }
            }


        }

        
    }
}


