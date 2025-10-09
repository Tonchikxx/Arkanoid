namespace Arkanoid
{
    /// <summary>
    /// Класс мяча
    /// </summary>
    public class Ball : GameObject
    {
        public int Size { get; set; }
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }
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

        public void ReverseX()
        {
            SpeedX *= -1;
        }

        public void ReverseY()
        {
            SpeedY *= -1;
        }

        public bool IsOutOfBounds()
        {
            return Y >= Constants.FieldHeight;
        }

        public bool HitLeftWall()
        {
            return X <= 0;
        }

        public bool HitRightWall()
        {
            return X >= Constants.FieldWidth - Size;
        }

        public bool HitTopWall()
        {
            return Y <= 0;
        }

        public void IncreaseDamage()
        {
            Damage++;
        }
    }
}
