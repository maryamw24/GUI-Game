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
using System.Runtime.CompilerServices;

namespace MarioGameGUI
{
    public partial class GameStage : Form
    {
        private int stage;
        public int counter = 0;
        int count = 0;
        Game game;
        char movementStatus = 's';
        CollisionDetection collider;

        public int Stage { get => stage; set => stage = value; }

        public GameStage(int stage)
        {
            this.Stage = stage;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            game = new Game(this, stage);
            collider = new CollisionDetection();
            

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GenerateHealthBar();
            ShowEnding();
            CheckMario();
            SetScore();
            MoveMario();
            move();
            MoveMarioFire();
            game.RemoveFire();
            ShowMarioHealth();
            if (stage == 0)
            {
                moveTurtle();
            }
            if (stage == 1)
            {
                IsWinner();
                game.RemoveGoombas();
            SetPrincessFree();
                movePrincessDown();
                MoveGoombaFire();
                moveGoomba();
                if (counter == 5)
                {
                    game.GenerateGoombaFire();
                }
                if (counter == 10)
                {
                    counter = 0;
                }
            }
            counter++;
        }
        private void GenerateHealthBar()
        {
            if(stage ==   0)
            {
                progressBar1.Value = game.Turtle1.Health;
            }
            else if(stage == 1)
            {

                progressBar1.Value = game.GoombaHealth;
                
                label1.Text = "Goombas Health";
                
                
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }
        private void MoveMario()
        {
            CheckNextStage();
            Mario mario = game.Mario;
            GameCell potentialNewCell = mario.CurrentCell;
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                mario.SetImage(MarioGameGUI.Properties.Resources.MarioLeft);
                mario.Direction = GameDirection.Left;
                potentialNewCell = mario.CurrentCell.nextCell(GameDirection.Left);
                GameCell currentCell = mario.CurrentCell;
                currentCell.SetGameObject(Game.getBlankGameObject());
                increaseScore(potentialNewCell);
                mario.move(potentialNewCell);
                movementStatus = 'd';
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                mario.Direction = GameDirection.Right;
                mario.SetImage(MarioGameGUI.Properties.Resources.Mario);
                potentialNewCell = mario.CurrentCell.nextCell(GameDirection.Right);
                GameCell currentCell = mario.CurrentCell;
                currentCell.SetGameObject(Game.getBlankGameObject());
                increaseScore(potentialNewCell);
                mario.move(potentialNewCell);
                movementStatus = 'd';
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                mario.Direction = GameDirection.Up;
                movementStatus = 'u';

            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                GenerateFire(mario.Direction);
            }
            
            
        }
        private void CheckMario()
        {
            if (game.Mario.IsDead == true)
            {
                timer1.Stop();
                WLForm f = new WLForm(game.Score,"You Loose!",MarioGameGUI.Properties.Resources.Sad_Marioo);
                f.Show();
                this.Hide();
            }
        }
        private void ShowMarioHealth()
        {

            /*health.Text = game.GetHealth().ToString();*/
            MarioHealth.Value = game.GetHealth();
            MarioHealth.ForeColor = Color.AliceBlue;
        }
        private void SetScore()
        {
            Score.Text = game.Score.ToString();
        }
        private void moveTurtle()
        {
            Turtle Turtle = game.Turtle1;
            if (collider.isMarioCollidedWithTurtle(Turtle))
            {
                if (game.Mario.Health > 0)
                {
                    game.Mario.Health -= 10;
                }
                else
                {
                    game.Mario.IsDead = true;
                }
            }
            if (Turtle.Health == 0)
            {
                Turtle.CurrentCell.CurrentGameObject = Game.getBlankGameObject();
                Turtle.CurrentCell.nextCell(Turtle.Direction).CurrentGameObject = GameCell.getBlankGameObject();
                Turtle.IsDead = true;
            }
            else
            {
                Turtle.move(Turtle.nextCell());
            }
        }
        private void moveGoomba()
        {
            foreach (GoombaH g in game.Goombas)
            {
                g.move(g.nextCell());
            }
        }
        private void MoveGoombaFire()
        {
            foreach (Fire f in game.GFires)
            {
                if (collider.isMarioCollideWithBullet(f))
                {
                    if (game.Mario.Health > 0)
                    {
                        game.Mario.Health -= 10;
                    }
                    else
                    {
                        game.Mario.IsDead = true;
                    }
                }
                f.move(f.nextCell());
            }
        }
        private void MoveMarioFire()
        {
            foreach (Fire f in game.MFires)
            {
                if (collider.isTurtleCollideWithBullet(f))
                {
                    game.Turtle1.Health = game.Turtle1.Health - 10;
                }
                if(collider.isGoombaCollideWithBullet(game.Goombas, f))
                {
                    
                }

                f.move(f.nextCell());
            }
        }
        private void SetPrincessFree()
        {
            if(game.Count == 4)
            {
                game.removeAllFires();
                game.Grid.getCell(3, 65).CurrentGameObject = Game.getBlankGameObject();
                game.Grid.getCell(3, 66).CurrentGameObject = Game.getBlankGameObject();
                game.Grid.getCell(3, 67).CurrentGameObject = Game.getBlankGameObject();
            }
        }

        private void GenerateFire(GameDirection d)
        {
            GameCell g;
            Fire f;
            if(d == GameDirection.Left)
            {
                g = game.Mario.CurrentCell.nextCell(GameDirection.Left);
                f = new Fire(MarioGameGUI.Properties.Resources.fire, g, GameDirection.Left);
                game.addMarioFire(f);
            }
            if(d == GameDirection.Right)
            {
                g = game.Mario.CurrentCell.nextCell(GameDirection.Right);
                f = new Fire(MarioGameGUI.Properties.Resources.fire, g, GameDirection.Right);
            game.addMarioFire(f);
            }
        }
        private void ShowEnding()
        {
            if(game.Turtle1.IsDead == true)
            {
                game.Grid.getCell(11, 72).CurrentGameObject.SetGameObject(GameObjectType.End, MarioGameGUI.Properties.Resources.End);
            }
        }
        private void CheckNextStage()
        {
            if(game.Mario.CurrentCell.nextCell(game.Mario.Direction).CurrentGameObject.GameObjectType == GameObjectType.End && game.Turtle1.IsDead == true)
            {
                NextStage();
            }
        }
        private void IsWinner()
        {
            if(game.Mario.CurrentCell.nextCell(game.Mario.Direction).CurrentGameObject.GameObjectType == GameObjectType.Turtle)
            {
                WLForm f = new WLForm(game.Score, "You Won !!", MarioGameGUI.Properties.Resources.Winnning_Mario);
                f.Show();
                this.Hide();
                timer1.Stop();
            }
        }
        private void movePrincessDown()
        {
            Turtle Princess = game.Turtle1;
            GameCell potentialNewCell = Princess.CurrentCell;
            GameCell nextCell = Princess.CurrentCell.nextCell(GameDirection.Down);
            if (nextCell != potentialNewCell)
            {
                GameCell currentCell = Princess.CurrentCell;
                currentCell.SetGameObject(Game.getBlankGameObject());
                increaseScore(nextCell);
                Princess.move(nextCell);
            }
        }
        private void NextStage()
        {
            timer1.Stop();
            GameStage f = new GameStage(1);
            f.game.Mario.Health = this.game.Mario.Health;
            f.game.Score = this.game.Score;
            this.Hide();
            f.Show();
        }

        private void increaseScore(GameCell g)
        {
            if (collider.isMarioCollidedWithCoin(g))
            {
                game.Score++;
            }

        }

        private void move()
        {
            Mario mario = game.Mario;
            GameCell potentialNewCell = mario.CurrentCell;
            GameCell nextCell;
            if (movementStatus == 'u')
            {
                int jumpCount = 0;
                for (int i = 0; i < 4; i++)
                {
                    nextCell = mario.CurrentCell.nextCell(GameDirection.Up);
                    jumpCount++;
                    GameCell currentCell = mario.CurrentCell;
                    currentCell.SetGameObject(Game.getBlankGameObject());
                    increaseScore(nextCell);
                    mario.move(nextCell);
                }
                if (jumpCount == 4)
                {
                    mario.Direction = GameDirection.Down;
                    movementStatus = 'd';

                }
            }
            if (movementStatus == 'd')
            {
                nextCell = mario.CurrentCell.nextCell(GameDirection.Down);
                if (nextCell != potentialNewCell)
                {
                    GameCell currentCell = mario.CurrentCell;
                    currentCell.SetGameObject(Game.getBlankGameObject());
                    increaseScore(nextCell);
                    mario.move(nextCell);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(count == 0)
            {
                timer1.Stop();
                button2.Text = "Resume";
                count++;
            }
            else if(count == 1)
            {
                timer1.Start();
                button2.Text = "Pause";
                count = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameStage f = new GameStage(0);
            f.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainPage f = new MainPage();
            f.Show();
            this.Hide();
        }
    }
}


