namespace PuzzleGame
{
    public class Coin : BaseItem, IAction
    {
        public Coin()
            : base("sokoban_spritesheet.png", new TextureStruct(156,568,28,28), "Coin")
        {

        }

        public void Action()
        {
            Game.grid.user.score++;
        }
    }
}
