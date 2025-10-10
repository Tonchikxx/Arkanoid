namespace Arkanoid
{
    /// <summary>
    /// Класс мяча
    /// </summary>
    public class Ball : GameObject
    {
        /// <summary>
        /// Размер мяча
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Скорость движения по оси X
        /// </summary>
        public float SpeedX { get; set; }

        /// <summary>
        /// Скорость движения по оси Y
        /// </summary>
        public float SpeedY { get; set; }

        /// <summary>
        /// Урон, наносимый блокам при столкновении
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр мяча с начальными настройками
        /// </summary>
        public Ball()
        {
            Size = Constants.BallSize;
            X = Constants.FieldWidth / 2 - Constants.BallSize / 2;
            Y = Constants.BallStartY;
            SpeedX = Constants.BallStartSpeedX;
            SpeedY = Constants.BallStartSpeedY;
            Damage = Constants.BallStartDamage;
        }

        /// <summary>
        /// Получает прямоугольник, представляющий границы мяча
        /// </summary>
        public override Rectangle GetBounds()
        {
            return new Rectangle((int)X, (int)Y, Size, Size);
        }

        /// <summary>
        /// Обновляет позицию мяча на основе текущей скорости
        /// </summary>
        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }

        /// <summary>
        /// Изменяет направление движения по оси X
        /// </summary>
        public void ReverseX()
        {
            SpeedX *= -1;
        }

        /// <summary>
        /// Изменяет направление движения по оси Y (отскок от горизонтальных поверхностей)
        /// </summary>
        public void ReverseY()
        {
            SpeedY *= -1;
        }

        /// <summary>
        /// Проверяет, вышел ли мяч за нижнюю границу игрового поля
        /// </summary>
        public bool IsOutOfBounds()
        {
            return Y >= Constants.FieldHeight;
        }

        /// <summary>
        /// Проверяет столкновение с левой стенкой
        /// </summary>
        public bool HitLeftWall()
        {
            return X <= 0;
        }

        /// <summary>
        /// Проверяет столкновение с правой стенкой
        /// </summary>
        public bool HitRightWall()
        {
            return X >= Constants.FieldWidth - Size;
        }

        /// <summary>
        /// Проверяет столкновение с верхней стенкой
        /// </summary>
        public bool HitTopWall()
        {
            return Y <= 0;
        }

        /// <summary>
        /// Увеличивает урон мяча (эффект усиления)
        /// </summary>
        public void IncreaseDamage()
        {
            Damage++;
        }
    }
}
