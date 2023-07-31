using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MarioGameGUI.GL
{
    public class Turtle : GameObject
    {
        bool isDead = false;
        GameDirection direction;
        int health = 100;
        public Turtle(Image image, GameCell startCell) : base(GameObjectType.Turtle, image)
        {
            base.CurrentCell = startCell;
        }

        public int Health { get => health; set => health = value; }
        public bool IsDead { get => isDead; set => isDead = value; }
        public GameDirection Direction { get => direction; set => direction = value; }

        public void move(GameCell gameCell)
        {
            if (base.CurrentCell != null)
            {
                base.CurrentCell.SetGameObject(Game.getBlankGameObject());
            }

            base.CurrentCell = gameCell;
        }

        public GameCell nextCell()
        {
            GameCell gameCell = base.CurrentCell;
            GameCell gameCell2 = base.CurrentCell.nextCell(Direction);
            if (gameCell2 == gameCell)
            {
                if (Direction == GameDirection.Right)
                {
                    Direction = GameDirection.Left;
                }
                else if (Direction == GameDirection.Left)
                {
                    Direction = GameDirection.Right;
                }
            }
            else
            {
                gameCell = gameCell2;
            }

            return gameCell;
        }
    }
}
