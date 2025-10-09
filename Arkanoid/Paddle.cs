namespace Arkanoid
{
    /// <summary>
    /// Класс платформы
    /// </summary>
    public class Paddle : GameObject
    {
        public float Speed { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр платформы с начальными настройками
        /// </summary>
        public Paddle()
        {
            Width = Constants.PaddleWidth;
            Height = Constants.PaddleHeight;
            Speed = Constants.PaddleSpeed;
            X = Constants.FieldWidth / 2 - Constants.PaddleWidth / 2;
            Y = Constants.PaddleY;
        }

        public void MoveLeft()
        {
            X = System.Math.Max(0, X - Speed);
        }

        public void MoveRight()
        {
            X = System.Math.Min(Constants.FieldWidth - Width, X + Speed);
        }
    }
}
