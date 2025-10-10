namespace Arkanoid
{
    /// <summary>
    /// Класс блока
    /// </summary>
    public class Block : GameObject
    {
        /// <summary>
        /// Цвет блока
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Текущее количество жизней блока
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Вес блока, влияющий на количество очков при разрушении
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Содержит ли блок усиление для мяча
        /// </summary>
        public bool HasPowerUp { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр блока с указанными координатами сетки
        /// </summary>
        public Block(int row, int col)
        {
            Width = Constants.BlockWidth;
            Height = Constants.BlockHeight;
            X = col * (Constants.BlockWidth + Constants.BlockSpacing) + Constants.BlockStartX;
            Y = row * (Constants.BlockHeight + Constants.BlockSpacing) + Constants.BlockStartY;
            Color = Constants.BlockColors[row];
            Health = row + 1;
            Weight = (row + 1) * 0.5f;
        }

        /// <summary>
        /// Наносит урон блоку
        /// </summary>
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        /// <summary>
        /// Проверяет, разрушен ли блок
        /// </summary>
        public bool IsDestroyed()
        {
            return Health <= 0;
        }

        /// <summary>
        /// Получает количество очков за разрушение этого блока
        /// </summary>
        public int GetScoreValue()
        {
            return (int)(Weight * 10);
        }
    }
}
