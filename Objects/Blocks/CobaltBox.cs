namespace PuzzleGame
{
    public class CobaltBox : MoveableBlock
    {
        public CobaltBox()
            : base("sokoban_spritesheet.png", new TextureStruct(384,64,64,64), "Cobalt box")
        {

        }

        public override void SwitchTexture()
        {
            IsActivated = !IsActivated;
            texture = IsActivated ? new TextureStruct(320, 0, 64, 64) : new TextureStruct(384, 64, 64, 64);
        }
    }
}
