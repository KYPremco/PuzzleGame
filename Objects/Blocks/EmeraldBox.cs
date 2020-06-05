namespace PuzzleGame
{
    public class EmeraldBox : MoveableBlock
    {
        public EmeraldBox()
            : base("sokoban_spritesheet.png", new TextureStruct(384,0,64,64), "Emerald box")
        {

        }

        public override void SwitchTexture()
        {
            IsActivated = !IsActivated;
            texture = IsActivated ? new TextureStruct(256, 512, 64, 64) : new TextureStruct(384, 0, 64, 64);
        }
    }
}