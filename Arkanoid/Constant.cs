namespace Arkanoid
{
    /// <summary>
    /// Класс констант
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Размеры игрового поля
        /// </summary>
        public const int FieldWidth = 585;
        public const int FieldHeight = 700;

        /// <summary>
        /// Параметры платформы
        /// </summary>
        public const int PaddleWidth = 100;
        public const int PaddleHeight = 20;
        public const int PaddleSpeed = 10;
        public const int PaddleY = 650;

        /// <summary>
        /// Параметры мяча
        /// </summary>
        public const int BallSize = 20;
        public const int BallStartY = 600; 
        public const float BallStartSpeedX = 4;
        public const float BallStartSpeedY = -4;
        public const int BallStartDamage = 1;

        /// <summary>
        /// Параметры блоков
        /// </summary>
        public const int BlockWidth = 80;
        public const int BlockHeight = 30;
        public const int BlockRows = 5;
        public const int BlockCols = 6;
        public const int BlockSpacing = 5;
        public const int BlockStartX = 30;
        public const int BlockStartY = 50;

        /// <summary>
        /// Настройки игры
        /// </summary>
        public const int GameTimerInterval = 16; 
        public const int PowerUpChance = 20;

        /// <summary>
        /// Цвета блоков по рядам
        /// </summary>
        public static readonly Color[] BlockColors = new[]
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Orange
        };
    }
}
