using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Drawing;

namespace MarioGameGUI.GL
{
    public class GameGrid
    {
        private GameCell[,] maze;
        private int rows;
        private int cols;

        public GameCell[,] Maze { get => maze; set => maze = value; }
        public int Rows { get => rows; set => rows = value; }
        public int Cols { get => cols; set => cols = value; }
        public GameGrid(int rows, int columns, string path)
        {
            this.rows = rows;
            this.cols = columns;
            this.maze = new GameCell[rows, columns];
            this.LoadMaze(path);
        }
        public void setGrid(int rows, int columns, string path)
        {
            this.rows = rows;
            this.cols = columns;
            this.maze = new GameCell[rows, columns];
            this.LoadMaze(path);
        }
        public GameCell getCell(int row, int column)
        {
            return maze[row, column];   
        }
        private void LoadMaze(string path)
        {
            StreamReader file = new StreamReader(path);
            for(int i = 0; i < rows; i++)
            {
                string line = file.ReadLine();
                for(int j = 0; j < this.cols; j++)
                {
                    GameCell cell = new GameCell(i, j,this);
                    char dchar = line[j];
                    GameObjectType type = GameObject.GetGameObjectType(dchar);
                    Image img = Game.GetGameObject(dchar);
                    GameObject gameObject = new GameObject(type, img);
                    cell.SetGameObject(gameObject);
                    maze[i,j] = cell;
                }
            }
            file.Close();
        }
    }
}
