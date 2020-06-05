namespace PuzzleGame
{
    public class WoodBox : MoveableBlock
    {
        public WoodBox()
            : base("sokoban_spritesheet.png", new TextureStruct(384,192,64,64), "Wooden box")
        {

        }

        public override void SwitchTexture()
        {
            IsActivated = !IsActivated;
            texture = IsActivated ? new TextureStruct(320, 128, 64, 64) : new TextureStruct(384, 192, 64, 64);
        }
    }
}