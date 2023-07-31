using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace MarioGameGUI.GL
{
    public class Mario : GameObject
    {
        private int health = 100;
        private GameDirection direction;
        private bool isDead = false; 
        public Mario(Image image,GameCell startCell, GameDirection direction) : base(GameObjectType.Player, image)
        {
            base.CurrentCell = startCell;
            this.Direction = direction;
        }
        public void SetMario(GameCell startCell)
        {
            base.CurrentCell = startCell;
        }

        public int Health { get => health; set => health = value; }
        public GameDirection Direction { get => direction; set => direction = value; }
        public bool IsDead { get => isDead; set => isDead = value; }

        public void move(GameCell gameCell)
        {
            if (gameCell.CurrentGameObject.GameObjectType == GameObjectType.Turtle)
            {
                CurrentCell = gameCell;
                GameCell nCell = CurrentCell.nextCell(GameDirection.Right);
                gameCell = nCell;
            }
            else
            {
                CurrentCell = gameCell;
            }
        }
    }
}
