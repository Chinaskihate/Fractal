using System.Drawing;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Базовый класс фрактал.
    /// </summary>
    abstract class Fractal
    {
        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Fractal()
        {

        }

        /// <summary>
        /// Конструктор как в производных классах. Каждый фрактал привязан к битмапу.
        /// </summary>
        /// <param name="bmp"> Битмап на котором будем рисовать. </param>
        public Fractal(Bitmap bmp)
        {
            Bmp = bmp;
        }

        /// <summary>
        /// Метод для отрисовки фрактала.
        /// </summary>
        /// <param name="x"> Координата по оси х. </param>
        /// <param name="y"> Координата по оси y. </param>
        /// <param name="len"> Длина отрезков фрактала. </param>
        /// <param name="specialModifier"> Специальный модификатор - уникальный для каждого фрактала. </param>
        abstract public void Draw(int x, int y, int len, double specialModifier);
        
        /// <summary>
        /// Свойство, обращаясь к которому можно рисовать на битмапе.
        /// </summary>
        abstract public Graphics Gr { get; }

        /// <summary>
        /// Битмап фрактала.
        /// </summary>
        abstract public Bitmap Bmp { get; set; }

        /// <summary>
        /// Толщина фигуры.
        /// </summary>
        abstract public int Width { get; set; }

        /// <summary>
        /// Максимальное число шагов для этого фрактала.
        /// </summary>
        abstract public int MaxSteps { get; }

        /// <summary>
        /// Количество шагов которое надо отрисовать.
        /// </summary>
        abstract public int Steps { get; set; }

        /// <summary>
        /// Коэффициент прозрачности.
        /// </summary>
        abstract public byte Alpha { get; set; }

        /// <summary>
        /// Массив из 3 элементов c значениями начального
        /// цвета, [0]-R, [1]-G, [2]-B.
        /// </summary>
        abstract public byte[] StartRGB { get; set; }

        /// <summary>
        /// Массив из 3 элементов c значениями конечного
        /// цвета, [0]-R, [1]-G, [2]-B.
        /// </summary>
        abstract public byte[] EndRGB { get; set; }
    }
}