namespace PuzzleGame
{
    public class EmptyFloor : BaseFloor
    {
        public EmptyFloor()
            : base("sokoban_spritesheet.png", new TextureStruct(64,256,64,64), "No floor")
        {

        }
    }
}
