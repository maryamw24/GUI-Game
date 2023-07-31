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
        public bool isMarioCollidedWithTurtle(Turtle Turtle)
        {
            bool flag = false;
            if(Turtle.CurrentCell.CurrentGameObject.GameObjectType == GameObjectType.Player)
            {
                flag = true;
            }
            return flag;
        }
        public bool isMarioCollidedWithCoin(GameCell g)
        {
            bool flag = false;
            if(g.CurrentGameObject.GameObjectType == GameObjectType.coin)
            {
                flag = true;
            }
            return flag;
        }
        public bool isGoombaCollideWithBullet(List<GoombaH> g,Fire f)
        {
            bool flag = false;
            GameObject c = f.nextCell().CurrentGameObject;
            foreach(GoombaH g1 in g)
            {
                if (c == g1)
                {
                        g1.Health -= 50;
                        flag = true;
                    
                    f.Stopped = true;
                    return flag;
                }
            }
            return flag;
        }
        public bool isMarioCollideWithBullet(Fire f)
        {
            bool flag = false;
            if(f.nextCell().CurrentGameObject.GameObjectType == GameObjectType.Player)
            {
                flag = true;
            }
            return flag;
        }
    }
}
