namespace Arkanoid
{
    /// <summary>
    /// Класс блока
    /// </summary>
    public class Block : GameObject
    {
        public Color Color { get; set; }
        public int Health { get; set; }
        public float Weight { get; set; }
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

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsDestroyed()
        {
            return Health <= 0;
        }

        public int GetScoreValue()
        {
            return (int)(Weight * 10);
        }
    }
}
