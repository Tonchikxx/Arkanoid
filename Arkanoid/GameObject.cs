namespace Arkanoid
{
    /// <summary>
    /// Класс для всех игровых объектов
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// X-координата объекта
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y-координата объекта
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Ширина объекта
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота объекта
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Получает прямоугольник, представляющий границы объекта для collision detection
        /// </summary>
        public virtual Rectangle GetBounds()
        {
            return new Rectangle((int)X, (int)Y, Width, Height);
        }
    }
}
