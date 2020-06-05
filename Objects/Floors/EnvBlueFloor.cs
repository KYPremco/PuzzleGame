namespace PuzzleGame
{
    public class EnvBlueFloor : BaseFloor, IMoveable
    {
        public EnvBlueFloor()
            : base("sokoban_spritesheet.png", new TextureStruct(64,0,64,64), "Env blue floor")
        {

        }
    }
}
