namespace PuzzleGame
{
    public class MoveableBlock : BaseBlock, IMoveableObject
    {
        public bool IsActivated { get; set; } = false;

        public MoveableBlock(string spriteName, TextureStruct texture, string name)
            : base(spriteName, texture, name)
        {
            
        }

        /// <summary>
        /// Move moveable objects with actions performed of block beneath
        /// </summary>
        /// <param name="pos">location where object is</param>
        /// <param name="direction">Direction object need to be moved</param>
        /// <see cref="newPos">new location in the grid after moving</see>
        /// <returns></returns>
        public bool Move(Pos pos, Move direction)
        {
            Pos newPos = GridHelper.GetNewLocation(pos.x, pos.y, direction);
            if (GridHelper.IsInGrid(newPos, Game.grid) && Game.grid.CanMove(newPos))
            {
                //Activate UnpressAction on old tile
                if (Game.grid.GetTile(pos.x, pos.y).environmentObject.GetType().IsSubclassOf(typeof(BaseEnvironment)))
                {
                    ((BaseEnvironment)Game.grid.GetTile(pos.x, pos.y).environmentObject).UnPressAction(pos.x, pos.y);
                }

                //Activate pressAction on new tile
                if (Game.grid.GetTile(newPos.x, newPos.y).environmentObject.GetType().IsSubclassOf(typeof(BaseEnvironment)))
                {
                    ((BaseEnvironment)Game.grid.GetTile(newPos.x, newPos.y).environmentObject).PressAction(pos.x, pos.y);
                }

                Game.grid.MoveObject(pos.x, pos.y, direction);

                return true;
            }
            return false;
        }

        public virtual void SwitchTexture()
        {
            
        }
    }
}