namespace PuzzleGame
{
    public class PlayerEntity : BaseEntity
    {
        public PlayerEntity()
            : base("sokoban_spritesheet.png", new TextureStruct(554, 208, 50, 42) , "Player")
        {

        }

        protected override void UpdateTextureMovement(Move direction)
        {
            switch (direction)
            {
                case PuzzleGame.Move.UP:
                    texture = new TextureStruct(554, 158, 50, 42);
                    break;
                case PuzzleGame.Move.RIGHT:
                    texture = new TextureStruct(512, 108, 50, 42);
                    break;
                case PuzzleGame.Move.DOWN:
                    texture = new TextureStruct(554, 208, 50, 42);
                    break;
                case PuzzleGame.Move.LEFT:
                    texture = new TextureStruct(543, 440, 50, 42);
                    break;
                default:
                    texture = new TextureStruct(554, 208, 50, 42);
                    break;
            }
        }
    }
}