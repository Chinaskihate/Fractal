using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс для кривой Коха.
    /// </summary>
    class FractalKoch : Fractal
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
        private int _width;
        private Color _backGroundColor;
        #endregion

        /// <summary>
        /// Конструктор кривой Коха.
        /// </summary>
        /// <param name="bmp"> Битмап на котором будет фрактал. </param>
        public FractalKoch(Bitmap bmp)
        {
            Bmp = bmp;
        }

        /// <summary>
        /// Метод для отрисовки кривой Коха. Не понял почему не полностью стирается предыдущий
        /// отрезок.
        /// </summary>
        /// <param name="x"> Координата точки которая делит отрезок 1:2. </param>
        /// <param name="y"> Координата точки которая делит отрезок 1:2. </param>
        /// <param name="len"> Длина стороны треугольника. </param>
        /// <param name="directionAngle"> Направление в котором нужно рисовать. </param>
        public override void Draw(int x, int y, int len, double directionAngle = 0)
        {
            if (_currStep++ < Steps)
            {
                // Расчет нового цвета.
                int r = StartRGB[0] + StepRBG[0] * _currStep;
                int g = StartRGB[1] + StepRBG[1] * _currStep;
                int b = StartRGB[2] + StepRBG[2] * _currStep;

                Pen pen = new Pen(Color.FromArgb(Alpha, r, g, b), Width);

                // Первая прямая.
                if (_currStep == 1)
                {
                    Gr.DrawLine(pen, x, y, x + len, y);
                    Draw(x + (int)(len * Math.Cos(directionAngle) / Ratio), y, (int)(len / Ratio), directionAngle + Math.PI / 3);
                }
                else
                {
                    // Координаты точек для отрисовки треугольника.
                    int x1 = x + (int)(len * Math.Cos(directionAngle));
                    int y1 = y - (int)(len * Math.Sin(directionAngle));
                    int x2 = x + (int)(len * Math.Cos(directionAngle - Math.PI / 3));
                    int y2 = y - (int)(len * Math.Sin(directionAngle - Math.PI / 3));

                    // Рисуем, рисуем, стираем.
                    Gr.DrawLine(pen, x, y, x1, y1);
                    Gr.DrawLine(pen, x1, y1, x2, y2);
                    Gr.DrawLine(BackGroundPen, x, y, x2, y2);
                    
                    // Проверка на то имеет ли смысл рисовать дальше.
                    if ((int)(len / Ratio) != 0)
                    {
                        // В фотографии koch попытался показать что происходит.
                        Draw(x + (int)((Ratio - 1) * len * Math.Cos(directionAngle + 2 * Math.PI / 3) / Ratio), y - (int)((Ratio - 1) * len * Math.Sin(directionAngle + 2 * Math.PI / 3) / Ratio), (int)(len / Ratio), directionAngle);
                        _currStep--;
                        Draw(x + (int)((x1 - x) / Ratio), y + (int)((y1 - y) / Ratio), (int)(len / Ratio), directionAngle + Math.PI / 3);
                        _currStep--;
                        Draw(x1 + (int)((x2 - x1) / Ratio), (int)(y1 + (y2 - y1) / Ratio), (int)(len / Ratio), directionAngle - Math.PI / 3);
                        _currStep--;
                        Draw(x + (int)((Ratio + 1) * len * Math.Cos(directionAngle - Math.PI / 3) / Ratio), y - (int)((Ratio + 1) * len * Math.Sin(directionAngle - Math.PI / 3) / Ratio), (int)(len / Ratio), directionAngle);
                        _currStep--;
                    }
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
        /// Максимальное число шагов для кривой Коха.
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
        /// Отношение длин фигур - для кривой Коха
        /// это отношение в котором точка делит текущий отрезок.
        /// </summary>
        public double Ratio
        {
            get => _ratio;

            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentException("Отношение длин отрезков должно принадлежать [1;5].");

                _ratio = value;
            }
        }

        /// <summary>
        /// Ручка которой будет закрашиваться лишние отрезки.
        /// </summary>
        private Pen BackGroundPen { get; set; }

        /// <summary>
        /// Отсюда задаем цвет ручки снаружи.
        /// </summary>
        public Color BackGroundColor
        {
            get => _backGroundColor;
            set
            {
                _backGroundColor = value;
                BackGroundPen = new Pen(_backGroundColor, Width);
            }
        }
    }
}