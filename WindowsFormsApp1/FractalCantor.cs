using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс для множества Кантора.
    /// </summary>
    class FractalCantor : Fractal
    {
        /// <summary>
        /// Поля, соответствующие своим свойствам.
        /// </summary>
        #region
        private Graphics _gr = null;
        private Bitmap _bmp = null;
        private int _currStep = 0;
        private int _maxsteps = 10;
        private double _ratio = 1.5;
        private int _steps = 0;
        private byte _alpha = 0;
        private byte[] _startRGB = null;
        private byte[] _endRGB = null;
        private int[] _stepRGB = null;
        private int _width = 0;
        #endregion

        /// <summary>
        /// Конструктор множества Кантора.
        /// </summary>
        /// <param name="bmp"> Битмап на котором будет фрактал. </param>
        public FractalCantor(Bitmap bmp)
        {
            Bmp = bmp;
        }

        /// <summary>
        /// Метод для отрисовки множества Кантора.
        /// </summary>
        /// <param name="x"> Левая координата отрезка.</param>
        /// <param name="y"> Верхняя координата отрезка.</param>
        /// <param name="len"> Длина отрезка. </param>
        /// <param name="distance"> Дистанция между отрезками. </param>
        public override void Draw(int x, int y, int len, double distance)
        {
            if (_currStep++ < Steps)
            {
                // Конец текущего отрезка
                int x1 = x + len;

                // Расчет нового цвета.
                int r = StartRGB[0] + StepRBG[0] * _currStep;
                int g = StartRGB[1] + StepRBG[1] * _currStep;
                int b = StartRGB[2] + StepRBG[2] * _currStep;

                Pen pen = new Pen(Color.FromArgb(Alpha, r, g, b), Width);

                Gr.DrawLine(pen, x, y, x1, y);

                // Проверка на то имеет ли смысл рисовать дальше.
                if((int)(len/Ratio)!=0)
                {
                    // Отрисовка левого отрезка.
                    Draw(x, y + (int)distance, (int)(len / Ratio), distance);
                    _currStep--;
                    
                    // Отрисовка правого отрезка.
                    Draw(x + len * 2 / 3, y + (int)distance, (int)(len / Ratio), distance);
                    _currStep--;
                }
            }
        }

        /// <summary>
        /// Через данное свойство обращаемся к отрисовке снаружи.
        /// (_gr всегда привязан к своему битмапу.)
        /// </summary>
        public override Graphics Gr
        {
            get => _gr;
        }

        /// <summary>
        /// Через данное свойство обращаемся к битмапу фрактала.
        /// Здесь _gr привязывается к битмапу.
        /// </summary>
        public override Bitmap Bmp
        {
            get => _bmp;
            set
            {
                _bmp = value;
                _gr = Graphics.FromImage(_bmp);
            }
        }

        /// <summary>
        /// Толщина фигуры.
        /// </summary>
        public override int Width 
        { 
            get => _width; 
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentException("Толщина ручки должна быть целым числом в [1;10]");

                _width = value;
            }
        }

        /// <summary>
        /// Максимальное число шагов для множества Кантора.
        /// </summary>
        public override int MaxSteps => _maxsteps;

        /// <summary>
        /// Количество шагов которое надо отрисовать.
        /// </summary>
        public override int Steps
        {
            get => _steps;

            set
            {
                if (value < 0 || value > _maxsteps)
                    throw new ArgumentException($"Глубина рекурсии должна быть неотрицательным целым не больше {_maxsteps}");

                _steps = value;
                // Обнуляем  текущий шаг если попросили нарисовать другое кол-во шагов.
                _currStep = 0;
            }
        }

        /// <summary>
        /// Коэффициент прозрачности.
        /// </summary>
        public override byte Alpha { get => _alpha; set => _alpha = value; }

        /// <summary>
        /// Массив из 3 элементов c значениями начального
        /// цвета, [0]-R, [1]-G, [2]-B.
        /// </summary>
        public override byte[] StartRGB
        {
            get => _startRGB;

            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Массив цветов должен иметь длину 3.");

                _startRGB = value;

                // Перерасчет градиента.
                if (EndRGB != null)
                {
                    int[] step = new int[3];
                    for (int i = 0; i < StartRGB.Length; i++)
                        step[i] = (EndRGB[i] - StartRGB[i]) / Steps;

                    StepRBG = step;
                }
            }
        }

        /// <summary>
        /// Массив из 3 элементов c значениями конечного
        /// цвета, [0]-R, [1]-G, [2]-B.
        /// </summary>
        public override byte[] EndRGB
        {
            get => _endRGB;

            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Массив цветов должен иметь длину 3.");

                _endRGB = value;

                // Перерасчет градиента.
                if (StartRGB != null)
                {
                    int[] step = new int[3];
                    for (int i = 0; i < EndRGB.Length; i++)
                        step[i] = (EndRGB[i] - StartRGB[i]) / Steps;

                    StepRBG = step;
                }
            }
        }

        /// <summary>
        /// Массив из 3 элементов c значениями шага
        /// цвета, [0]-R, [1]-G, [2]-B.
        /// </summary>
        private int[] StepRBG
        {
            get => _stepRGB;

            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Массив цветов должен иметь длину 3.");

                foreach (var elem in value)
                    if (elem < -255 || elem > 255)
                        throw new ArgumentOutOfRangeException("Целое значение разницы должно принадлежать [-255;255]");

                _stepRGB = value;
            }
        }

        /// <summary>
        /// Отношение длин фигур - для множества Кантора
        /// это нижний отрезок к верхнему.
        /// </summary>
        public double Ratio
        {
            get => _ratio;

            set
            {
                if (value < 2 || value > 10)
                    throw new ArgumentException("Отношение длин отрезков должно принадлежать (2;10].");

                _ratio = value;
            }
        }
    }
}