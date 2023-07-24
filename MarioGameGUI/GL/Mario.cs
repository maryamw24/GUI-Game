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
        public Mario(Image image,GameCell startCell) : base(GameObjectType.Player,image)
        {
            base.CurrentCell = startCell;
        }

        public int Health { get => health; set => health = value; }

        public void move(GameCell gameCell)
        {
            CurrentCell = gameCell;
        }
    }
}
