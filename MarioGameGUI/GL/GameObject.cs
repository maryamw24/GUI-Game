using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace MarioGameGUI.GL
{
     public class GameObject
    {
        private GameCell currentCell;
        private char displayCharacter;
        private GameObjectType gameObjectType;
        private Image img;

        public GameCell CurrentCell { get { return currentCell; } set { currentCell = value; currentCell.SetGameObject(this); } }
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public Image Img { get => img; set => img = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }

        public GameObject(GameObjectType objectType, Image img)
        {
            this.gameObjectType = objectType;
            this.img = img;
        }
        public GameObject(char displayCharacter, GameObjectType objectType)
        {
            this.displayCharacter= displayCharacter;
            this.gameObjectType = objectType;
        }
        public static GameObjectType GetGameObjectType(char displayCharacter)
        {
            GameObjectType type = GameObjectType.None;
            if (displayCharacter == '|')
            {
                 type = GameObjectType.Pipe;
            }
            else if (displayCharacter == '%' || displayCharacter == '=')
            {
                type = GameObjectType.Floor;
            }
            else if (displayCharacter == 'm')
            {
                type = GameObjectType.Player;
            }
            
            return type;
        }
    }
}
