using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MarioGameGUI.GL
{
    public class GameCell
    {
        private int row;
        private int col;
        private GameObject currentGameObject;
        private PictureBox pictureBox;
        private int height = 25;
        private int width = 20;
        private GameGrid grid;

        public int Row { get => row; set => row = value; }
        public int Column { get => col; set => col = value; }
        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }
        public GameGrid Grid { get => grid; set => grid = value; }
        public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }

        public GameCell(int row, int col, GameGrid grid)
        {
            this.row = row;
            this.col = col;
            pictureBox = new PictureBox();
            pictureBox.Left = col * width;
            pictureBox.Top = row * height;
            pictureBox.Size = new Size(width, height);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackgroundImage = MarioGameGUI.Properties.Resources.sky;
            this.grid = grid;
        }
        public void SetCell(int height, int width)
        {
            this.height = height;
            this.width = width;
        }
        public void SetGameObject(GameObject gameObject)
        {
            this.CurrentGameObject = gameObject;
            this.pictureBox.Image = gameObject.Img;
            
        }
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.None, MarioGameGUI.Properties.Resources.sky);
            return blankGameObject;
        }
        public GameCell nextCell(GameDirection direction)
        {
            if (direction == GameDirection.Left && col > 0)
            {
                GameCell cell = grid.getCell(row, col - 1);
                if (cell.CurrentGameObject.GameObjectType == GameObjectType.None || cell.CurrentGameObject.GameObjectType == GameObjectType.Player || cell.CurrentGameObject.GameObjectType == GameObjectType.Turtle)
                {
                    return cell;
                }
            }

            if (direction == GameDirection.Right && col < grid.Cols - 1)
            {
                GameCell cell2 = grid.getCell(row, col + 1);
                if (cell2.CurrentGameObject.GameObjectType  == GameObjectType.None || cell2.CurrentGameObject.GameObjectType == GameObjectType.Player || cell2.CurrentGameObject.GameObjectType == GameObjectType.Turtle)
                {
                    return cell2;
                }
            }

            if (direction == GameDirection.Up && row > 0)
            {
                GameCell cell3 = grid.getCell(row - 1, col);
                if (cell3.CurrentGameObject.GameObjectType == GameObjectType.None || cell3.CurrentGameObject.GameObjectType == GameObjectType.Player  || cell3.CurrentGameObject.GameObjectType == GameObjectType.Turtle)
                {
                    return cell3;
                }
            }

            if (direction == GameDirection.Down && row < grid.Rows - 2)
            {
                GameCell cell4 = grid.getCell(row + 1, col);
                if (cell4.CurrentGameObject.GameObjectType == GameObjectType.None || cell4.CurrentGameObject.GameObjectType == GameObjectType.Player || cell4.CurrentGameObject.GameObjectType == GameObjectType.Turtle)
                {
                    return cell4;
                }
            }

            return this;
        }
    }
}
