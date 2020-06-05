namespace PuzzleGame
{
    public class EnvWoodPlate : BaseEnvironment, IEnvironmentPlate
    {
        public EnvWoodPlate()
            : base("sokoban_spritesheet.png", new TextureStruct(64,384,64,64), "Env Wood plate")
        {

        }

        public override void PressAction(int x, int y)
        {
            if (Game.grid.GetTile(x, y).gameObject.GetType() == Blocks.WOOD_BOX && typeof(IMoveableObject).IsAssignableFrom(Game.grid.GetTile(x, y).gameObject.GetType()))
            {
                IsPressed = !IsPressed;
                ((IMoveableObject)Game.grid.GetTile(x, y).gameObject).SwitchTexture();
            }
        }

        public override void UnPressAction(int x, int y)
        {
            if (Game.grid.GetTile(x, y).gameObject.GetType() == Blocks.WOOD_BOX && typeof(IMoveableObject).IsAssignableFrom(Game.grid.GetTile(x, y).gameObject.GetType()))
            {
                IsPressed = !IsPressed;
                ((IMoveableObject)Game.grid.GetTile(x, y).gameObject).SwitchTexture();
            }
        }
    }
}
