using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGameGUI.GL
{
    public class Fire: GameObject
    {
        GameDirection direction;
        bool stopped = false;
        public Fire(Image img, GameCell startCell, GameDirection direction) : base(GameObjectType.Fire, img)
        {
            this.direction = direction;
            base.CurrentCell = startCell;
        }

        public bool Stopped { get => stopped; set => stopped = value; }

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
                Stopped = true;
            }
            else
            {
                gameCell = gameCell2;
            }
            return gameCell;
        }
    }
}
