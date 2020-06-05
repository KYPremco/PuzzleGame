namespace PuzzleGame
{
    public class EnvCobaltPlate : BaseEnvironment, IEnvironmentPlate
    {
        public EnvCobaltPlate()
            : base("sokoban_spritesheet.png", new TextureStruct(64,0,64,64), "Env Cobalt plate")
        {

        }
        public override void PressAction(int x, int y)
        {
            if (Game.grid.GetTile(x, y).gameObject.GetType() == Blocks.COBALT_BOX && typeof(IMoveableObject).IsAssignableFrom(Game.grid.GetTile(x, y).gameObject.GetType()))
            {
                IsPressed = !IsPressed;
                ((IMoveableObject)Game.grid.GetTile(x, y).gameObject).SwitchTexture();
            }
        }

        public override void UnPressAction(int x, int y)
        {
            if (Game.grid.GetTile(x, y).gameObject.GetType() == Blocks.COBALT_BOX && typeof(IMoveableObject).IsAssignableFrom(Game.grid.GetTile(x, y).gameObject.GetType()))
            {
                IsPressed = !IsPressed;
                ((IMoveableObject)Game.grid.GetTile(x, y).gameObject).SwitchTexture();
            }
        }
    }
}
