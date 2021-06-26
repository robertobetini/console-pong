namespace ConsolePong.Core.Model
{
    public class Ball : GameEntity
    {
        int[] _velocity;

        public Ball(int[] velocity)
        {
            _velocity = velocity;
        }

        public override void Move()
        {
            Move(_velocity);
        }
    }
}
