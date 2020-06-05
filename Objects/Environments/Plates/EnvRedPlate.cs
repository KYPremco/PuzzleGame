namespace PuzzleGame
{
    public class EnvRedPlate : BaseEnvironment, IEnvironmentPlate
    {
        public EnvRedPlate()
            : base("sokoban_spritesheet.png", new TextureStruct(64,192,64,64), "Env Red Plate")
        {

        }
    }
}
