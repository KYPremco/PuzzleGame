namespace PuzzleGame
{
    public class EmptyObject : BaseObject
    {
        public EmptyObject()
            : base("sokoban_spritesheet.png", new TextureStruct(10,10,10,10), ObjectType.Empty, "Empty")
        {
            
        }
    }
}