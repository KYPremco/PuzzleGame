namespace PuzzleGame
{
    public class EnvRedFloor : BaseFloor, IMoveable
    {
        public EnvRedFloor()
            : base("sokoban_spritesheet.png", new TextureStruct(64,192,64,64), "Env red floor")
        {

        }
    }
}
