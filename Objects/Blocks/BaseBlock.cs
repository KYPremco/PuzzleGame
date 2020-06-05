namespace PuzzleGame
{
    public class BaseBlock : BaseObject
    {
        public BaseBlock(string spriteName, TextureStruct texture, string name)
            : base(spriteName, texture, ObjectType.Block, name)
        {
            
        }
    }
}