namespace PuzzleGame
{
    public class BaseItem : BaseObject
    {
        public BaseItem(string spriteName, TextureStruct texture, string name)
            : base(spriteName, texture, ObjectType.Item, name)
        {
            
        }
    }
}