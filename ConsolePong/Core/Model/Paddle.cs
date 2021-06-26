namespace ConsolePong.Core.Model
{
    public class Paddle : GameEntity
    {
        public int Length { get; set; }
        public Player Player;

        public Paddle(int length, Player player)
        {
            Length = length;
            Player = player;
        }
    }
}
