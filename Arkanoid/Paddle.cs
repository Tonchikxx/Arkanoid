namespace Arkanoid
{
    /// <summary>
    /// Класс платформы
    /// </summary>
    public class Paddle : GameObject
    {
        /// <summary>
        /// Скорость движения платформы
        /// </summary>
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

        /// <summary>
        /// Перемещает платформу влево с учетом границ игрового поля
        /// </summary>
        public void MoveLeft()
        {
            X = Math.Max(0, X - Speed);
        }

        /// <summary>
        /// Перемещает платформу вправо с учетом границ игрового поля
        /// </summary>
        public void MoveRight()
        {
            X = Math.Min(Constants.FieldWidth - Width, X + Speed);
        }
    }
}
