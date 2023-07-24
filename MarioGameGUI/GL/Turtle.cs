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
        GameDirection direction;
        public Turtle(Image image, GameCell startCell) : base(GameObjectType.Turtle, image)
        {
            base.CurrentCell = startCell;
        }
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
            GameCell gameCell2 = base.CurrentCell.nextCell(direction);
            if (gameCell2 == gameCell)
            {
                if (direction == GameDirection.Right)
                {
                    direction = GameDirection.Left;
                }
                else if (direction == GameDirection.Left)
                {
                    direction = GameDirection.Right;
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
