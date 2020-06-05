namespace PuzzleGame
{
    public class EnvYellowFloor : BaseFloor, IMoveable
    {
        public EnvYellowFloor()
            : base("sokoban_spritesheet.png", new TextureStruct(64,384,64,64), "Env yellow floor")
        {

        }
    }
}
