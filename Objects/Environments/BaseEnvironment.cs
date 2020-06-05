namespace PuzzleGame
{
    public class BaseEnvironment : BaseObject
    {
        public bool IsPressed { get; set; } = false;

        public BaseEnvironment(string spriteName, TextureStruct texture, string name)
            : base(spriteName, texture, ObjectType.Environment, name)
        {

        }

        public virtual void PressAction(int x, int y)
        {
        }

        public virtual void UnPressAction(int x, int y)
        {
        }
    }
}
