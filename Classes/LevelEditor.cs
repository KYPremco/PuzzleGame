using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI.WebControls;

namespace PuzzleGame.Editor
{
    public class LevelEditor
    {
        public GridStruct grid;

        public List<Type> objectList = new List<Type>();


        public LevelEditor(Pos range)
        {
            grid = new GridStruct(range.x, range.y);

            for (int x = 0; x < grid.width; x++)
            {
                for (int y = 0; y < grid.height; y++)
                {
                    grid.SetTile(x, y, Floors.EMPTY_FLOOR, Blocks.EMPTY, Blocks.EMPTY);
                }
            }
            LoadBlocks();
        }

        public LevelEditor(GridStruct grid)
        {
            this.grid = grid;
        }

        private void LoadBlocks()
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in a.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(BaseObject)) && type != typeof(BaseFloor) && type != typeof(BaseEntity) && type != typeof(BaseBlock) && type != typeof(MoveableBlock) && type != typeof(BaseEnvironment) && type != typeof(BaseItem))
                    {
                        objectList.Add(type);
                    }
                }
            }
        }

        public void DestroyGrid()
        {
            grid = new GridStruct(0,0);
        }
    }
}
