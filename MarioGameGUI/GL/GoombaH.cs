using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MarioGameGUI.GL
{
   
    public class GoombaH : GameObject
    {
        private int health = 100;
        private bool isDead = false;
        private GameDirection direction;
        private ProgressBar progressBar;
     
        public GoombaH(Image img, GameCell startCell, GameDirection direction) : base(GameObjectType.Goomba, img)
        {
            this.Direction = direction;
            base.CurrentCell = startCell;
            /*this.progressBar.Value = 100;*/
        }
        public int Health { get => health; set => health = value; }
        public bool IsDead { get => isDead; set => isDead = value; }
        public GameDirection Direction { get => direction; set => direction = value; }
        public ProgressBar ProgressBar { get => progressBar; set => progressBar = value; }

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
            GameCell gameCell3 = base.CurrentCell.DownCell();
            GameCell gameCell4 = gameCell3.nextCell(Direction);
            if ( gameCell != gameCell2 && gameCell4.CurrentGameObject.GameObjectType == GameObjectType.Floor)
            {
                 gameCell = gameCell2;
            }
            
            else
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

            return gameCell;
        }
    }
}
