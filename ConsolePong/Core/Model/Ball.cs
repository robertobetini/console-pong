namespace ConsolePong.Core.Model
{
    public class Ball : GameEntity
    {
        public int[] velocity;

        public Ball(int[] velocity_, int x = 1, int y = 1)
        {
            SetPosition(new int[2] { x, y });
            velocity = velocity_;
        }

        public override void Move()
        {
            Move(velocity);
        }

        public int[] NextPosition()
        {
            int[] nextPosition = new int[2];
            for (int i = 0; i < _position.Length; i++)
                nextPosition[i] = _position[i] + velocity[i];

            return nextPosition;
        }

        public bool CollidesWithPaddle(Paddle paddle)
        {
            var nextPosition = NextPosition();
            var paddlePosition = paddle.GetPosition();

            // Check if next position's x is equal to paddles x 
            if (nextPosition[0] != paddlePosition[0])
                return false;

            for (int i = 0; i < paddle.Length; i++)
            {
                // Already check position's x, we must check if collides within the length of the paddle
                if (nextPosition[1] == paddlePosition[1] + i)
                    return true;
            }

            return false;
        }

        public bool CollidesWithHorizontalWall(Board board)
        {
            var nextPosition = NextPosition();
            if (nextPosition[1] == 0 || nextPosition[1] == board.Height - 1)
                return true;

            return false;
        }

        public bool CollidesWithVerticalWall(Board board)
        {
            var nextPosition = NextPosition();
            if (nextPosition[0] == 0 || nextPosition[0] == board.Width - 1)
                return true;

            return false;
        }

        public void ReflectHorizontally()
        {
            velocity[1] *= -1;
        }

        public void ReflectVertically()
        {
            velocity[0] *= -1;
        }
    }
}
