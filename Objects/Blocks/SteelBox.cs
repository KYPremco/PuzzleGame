namespace PuzzleGame
{
    public class SteelBox : MoveableBlock
    {
        public SteelBox()
            : base("sokoban_spritesheet.png", new TextureStruct(320,512,64,64), "Steel box")
        {

        }

        public override void SwitchTexture()
        {
            IsActivated = !IsActivated;
            texture = IsActivated ? new TextureStruct(256, 448, 64, 64) : new TextureStruct(320, 512, 64, 64);
        }
    }
}
