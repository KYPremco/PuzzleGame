namespace PuzzleGame
{
    public class EnvEmeraldPlate : BaseEnvironment, IEnvironmentPlate
    {
        public EnvEmeraldPlate()
            : base("sokoban_spritesheet.png", new TextureStruct(0,448,64,64), "Env Emerald plate")
        {

        }

        public override void PressAction(int x, int y)
        {
            if (Game.grid.GetTile(x, y).gameObject.GetType() == Blocks.EMERALD_BOX && typeof(IMoveableObject).IsAssignableFrom(Game.grid.GetTile(x, y).gameObject.GetType()))
            {
                IsPressed = !IsPressed;
                ((IMoveableObject)Game.grid.GetTile(x, y).gameObject).SwitchTexture();
            }
        }

        public override void UnPressAction(int x, int y)
        {
            if (Game.grid.GetTile(x, y).gameObject.GetType() == Blocks.EMERALD_BOX && typeof(IMoveableObject).IsAssignableFrom(Game.grid.GetTile(x, y).gameObject.GetType()))
            {
                IsPressed = !IsPressed;
                ((IMoveableObject)Game.grid.GetTile(x, y).gameObject).SwitchTexture();
            }
        }
    }
}
