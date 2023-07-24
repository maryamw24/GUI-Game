using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGameGUI.GL
{
    public class CollisionDetection
    {
        public bool isTurtleCollideWithBullet(Fire f)
        {
            bool flag = false;
            if (f.nextCell().CurrentGameObject.GameObjectType == GameObjectType.Turtle)
            {
                flag = true;
                f.Stopped = true;
            }

            return flag;
        }
    }
}
