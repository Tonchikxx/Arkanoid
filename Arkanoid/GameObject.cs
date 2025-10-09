namespace Arkanoid
{
    public abstract class GameObject
    {
        /// <summary>
        /// Класс для всех игровых объектов
        /// </summary>
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual Rectangle GetBounds()
        {
            return new Rectangle((int)X, (int)Y, Width, Height);
        }
    }
}
