namespace PuzzleGame
{
    public class BaseEntity : BaseObject
    {
        private Pos position { get; set; }

        public int x { get { return position.x; } set { position.x = value; } }
        public int y { get { return position.y; } set { position.y = value; } }

        public BaseEntity(string spriteName, TextureStruct texture, string name)
            : base(spriteName, texture, ObjectType.Entity, name)
        {
            position = new Pos(0, 0);
        }

        public bool Move(Move direction)
        {
            Pos newPos = GridHelper.GetNewLocation(x, y, direction);
            if(GridHelper.IsInGrid(newPos, Game.grid))
            {
                if(MoveWithMoveableBlock(newPos, direction) || MoveWithAction(newPos, direction) || Game.grid.CanMove(newPos)) {
                    //Update movement texture
                    UpdateTextureMovement(direction);

                    //Move Entity
                    position = Game.grid.MoveObject(x, y, direction);

                    //Check Environment
                    if (IsOnEnvironment())
                        ActivateEnvironment();

                    return true;
                }
            }
            return false;
        }

        private bool MoveWithMoveableBlock(Pos pos, Move direction)
        {
            if (Game.grid.GetTile(pos.x, pos.y).gameObject.GetType().BaseType == typeof(MoveableBlock))
            {
                MoveableBlock obj = (MoveableBlock)Game.grid.GetTile(pos.x, pos.y).gameObject;
                if (obj.Move(pos, direction))
                {
                    return true;
                }
            }
            return false;
        }

        private bool MoveWithAction(Pos pos, Move direction)
        {
            if (Game.grid.GetTile(pos.x, pos.y).gameObject is IAction)
            {
                ((IAction)Game.grid.GetTile(pos.x, pos.y).gameObject).Action();
                return true;
            }
            return false;
        }

        private bool IsOnEnvironment()
        {
            if(Game.grid.GetTile(position.x, position.y).environmentObject.GetType() != Blocks.EMPTY)
            {
                return true;
            }
            return false;
        }

        protected virtual void UpdateTextureMovement(Move direction)
        {

        }

        private void ActivateEnvironment()
        {
            //Message.Warning("test");
        }
    }
}