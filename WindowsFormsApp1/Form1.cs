using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс формы.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Вспомогательные поля.
        /// </summary>
        #region
        private string[] fractalsName = new string[] { "Обдуваемое ветром дерево", "Множество Кантора", "Ковер Серпинского", "Треугольник Серпинского", "Кривая Коха" };
        private Fractal fractal = null;
        private int defaultPanel1Height = 453;
        private double _zoom = 1;
        // Координаты точки отрисовки(для скролбаров).
        private int _h = 0, _v = 0;
        // Модификатор для каждого фрактала.
        private double _specialModifier = 0;
        #endregion

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            
            fractalsBox.Items.Clear();
            fractalsBox.Items.AddRange(fractalsName);
            
            // Почему-то кнопки и текст не хотели выходить поверх trackBar-ов,
            // сделал вручную.
            labelRightAngle.BringToFront();
            labelLeftAngle.BringToFront();
            labelWidth.BringToFront();
            buttonStartColor.BringToFront();
            buttonEndColor.BringToFront();
            
            // Цвета по умолчанию.
            buttonStartColor.BackColor = Color.White;
            buttonStartColor.ForeColor = Color.Black;
            buttonBackGroundColor.BackColor = Color.Black;
            buttonBackGroundColor.ForeColor = Color.White;
            panel1.BackColor = Color.Black;
        }

        /// <summary>
        /// Отрисовка фрактала.
        /// </summary>
        private void pictureBox1_paint()
        {
            if (fractal != null)
            {
                pictureBoxFract.Size = fractal.Bmp.Size;
                pictureBoxFract.Image = fractal.Bmp;
                fractal.Gr.Clear(buttonBackGroundColor.BackColor);
                
                fractal.Steps = trackBarSteps.Value;
                fractal.Width = trackBarWidth.Value;
                SpecialProperties();
                
                fractal.Alpha = (byte)(byte.MaxValue - trackBarAlpha.Value);
                fractal.StartRGB = new byte[] { buttonStartColor.BackColor.R, buttonStartColor.BackColor.G, buttonStartColor.BackColor.B };
                fractal.EndRGB = new byte[] { buttonEndColor.BackColor.R, buttonEndColor.BackColor.G, buttonEndColor.BackColor.B };
                
                fractal.Draw(fractal.Bmp.Width / 2 - (int)(_h * _zoom), fractal.Bmp.Height / 3 - (int)(_v * _zoom), (int)(_zoom * trackBarLength.Value * fractal.Bmp.Height / defaultPanel1Height), _specialModifier);
            }
        }

        /// <summary>
        /// Присваивание специальных свойств для фрактала.
        /// Ratio везде подсчитывался вручную исходя из размера trackBar-а и возможных
        /// границ для данного фрактала.
        /// </summary>
        private void SpecialProperties()
        {
            switch (fractal.GetType().Name)
            {
                case "FractalTree":
                    (fractal as FractalTree).LeftAngle = trackBarLeftAngle.Value * Math.PI / 180;
                    (fractal as FractalTree).RightAngle = (-trackBarRightAngle.Value) * Math.PI / 180;
                    (fractal as FractalTree).Ratio = 0.75 + ((double)trackBarRatio.Value / 100);
                    _specialModifier = 0;
                    break;

                case "FractalCantor":
                    (fractal as FractalCantor).Ratio = 2 + (double)trackBarRatio.Value * 4 / 75;
                    _specialModifier = (1 + trackBarLeftAngle.Value) * _zoom;
                    break;

                case "FractalCarpet":
                    (fractal as FractalCarpet).Ratio = 1 + (double)trackBarRatio.Value * 2 / 75;
                    break;

                case "FractalTriangle":
                    (fractal as FractalTriangle).Ratio = 1 + (double)trackBarRatio.Value * 2 / 75;
                    _specialModifier = 1;
                    break;

                case "FractalKoch":
                    (fractal as FractalKoch).Ratio = 1 + (double)trackBarRatio.Value * 2 / 75;
                    _specialModifier = 0;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Событие на выбор фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fractalsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            // Базовые операции исходя из типа фрактала.
            switch (fractalsBox.SelectedIndex)
            {
                case 0:
                    TreeDefault(bmp);
                    break;

                case 1:
                    CantorDefault(bmp);
                    break;

                case 2:
                    CarpetDefault(bmp);
                    break;

                case 3:
                    TriangleDefault(bmp);
                    break;

                case 4:
                    KochDefault(bmp);
                    break;

                default:
                    break;
            }
            pictureBox1_paint();
        }

        /// <summary>
        /// Базовые операции для фрактального дерева.
        /// </summary>
        /// <param name="bmp"> Битмап для конструктора. </param>
        private void TreeDefault(Bitmap bmp)
        {
            fractal = new FractalTree(bmp);
            labelLeftAngle.Text = "Левый угол наклона";
            labelLeftAngle.Visible = true;
            labelRightAngle.Visible = true;
            trackBarLeftAngle.Visible = true;
            trackBarRightAngle.Visible = true;
            // Чтобы сразу было нормально видно.
            trackBarLeftAngle.Value = 45;
            trackBarRightAngle.Value = 45;
            trackBarRatio.Value = 50;
            trackBarSteps.Value = 3;
            trackBarSteps.Maximum = fractal.MaxSteps;
        }

        /// <summary>
        /// Базовые операции для множества Кантора.
        /// </summary>
        /// <param name="bmp"></param>
        private void CantorDefault(Bitmap bmp)
        {
            fractal = new FractalCantor(bmp);
            labelLeftAngle.Visible = true;
            trackBarLeftAngle.Visible = true;
            // Можно было создать новый label и trackBar и не обращаться к левому углу,
            // но разницы для пользователя нет.
            labelLeftAngle.Text = "Расстояние между отрезками:";
            labelRightAngle.Visible = false;
            trackBarRightAngle.Visible = false;
            // Чтобы сразу было нормально видно.
            trackBarLength.Value = 100;
            trackBarRatio.Value = 19;
            trackBarSteps.Value = 3;
            trackBarSteps.Maximum = fractal.MaxSteps;
        }

        /// <summary>
        /// Базовые операции для ковра Серпинского.
        /// </summary>
        /// <param name="bmp"> Битмап для конструктора. </param>
        private void CarpetDefault(Bitmap bmp)
        {
            fractal = new FractalCarpet(bmp);
            labelLeftAngle.Visible = false;
            labelRightAngle.Visible = false;
            trackBarLeftAngle.Visible = false;
            trackBarRightAngle.Visible = false;
            // Чтобы сразу было нормально видно.
            trackBarRatio.Value = 75;
            trackBarSteps.Maximum = fractal.MaxSteps;
            trackBarLength.Value = 50;
        }

        /// <summary>
        /// Базовые операции для треугольника Серпинского.
        /// </summary>
        /// <param name="bmp"> Битмап для конструктора. </param>
        private void TriangleDefault(Bitmap bmp)
        {
            fractal = new FractalTriangle(bmp);
            labelLeftAngle.Visible = false;
            labelRightAngle.Visible = false;
            trackBarLeftAngle.Visible = false;
            trackBarRightAngle.Visible = false;
            // Чтобы сразу было нормально видно.
            trackBarRatio.Value = 37;
            trackBarSteps.Value = 3;
            trackBarLength.Value = 50;
            trackBarSteps.Maximum = fractal.MaxSteps;
        }

        /// <summary>
        /// Базовые операции для кривой Коха.
        /// </summary>
        /// <param name="bmp"> Битмап для конструктора. </param>
        private void KochDefault(Bitmap bmp)
        {
            fractal = new FractalKoch(bmp);
            labelLeftAngle.Visible = false;
            labelRightAngle.Visible = false;
            trackBarLeftAngle.Visible = false;
            trackBarRightAngle.Visible = false;
            (fractal as FractalKoch).BackGroundColor = buttonBackGroundColor.BackColor;
            // Чтобы сразу было нормально видно.
            trackBarSteps.Value = 3;
            trackBarSteps.Maximum = fractal.MaxSteps;
            trackBarRatio.Value = 75;
            trackBarLength.Value = 100;
        }

        /// <summary>
        /// Событие на изменение прозрачности.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarAlpha_Scroll(object sender, EventArgs e)
        {
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие на изменение размера панели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Resize(object sender, EventArgs e)
        {
            // Проверка на то не свернуто ли окно.
            if (panel1.Width != 0 && panel1.Height != 0 && fractal != null)
            {
                fractal.Bmp = new Bitmap(panel1.Width, panel1.Height);
                pictureBox1_paint();
            }
        }

        /// <summary>
        /// Событие на изменение количества шагов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarSteps_Scroll(object sender, EventArgs e)
        {
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие на изменение длины отрезка фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarLength_Scroll(object sender, EventArgs e)
        {
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие на изменение левого угла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarLeftAngle_Scroll(object sender, EventArgs e)
        {
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие на изменение правого угла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarRightAngle_Scroll(object sender, EventArgs e)
        {
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие на изменение отношения длин.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarRatio_Scroll(object sender, EventArgs e)
        {
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие на изменение величины зума
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            _zoom = 1 + (double)trackBarZoom.Value / 90;
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие при горизонтальном скролле.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _h = hScrollBar1.Value;
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие при вертикальном скролле.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _v = vScrollBar1.Value;
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие при выборе начального цвета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            buttonStartColor.BackColor = colorDialog.Color;
            // Чтобы текст на кнопке был виден.
            buttonStartColor.ForeColor = Color.FromArgb(0, 255 - colorDialog.Color.R, 255 - colorDialog.Color.G, 255 - colorDialog.Color.B);
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие при выборе конечного цвета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            buttonEndColor.BackColor = colorDialog.Color;
            // Чтобы текст на кнопке был виден.
            buttonEndColor.ForeColor = Color.FromArgb(0, 255 - colorDialog.Color.R, 255 - colorDialog.Color.G, 255 - colorDialog.Color.B);
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие при выборе цвета фона.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBackGroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            buttonBackGroundColor.BackColor = colorDialog.Color;
            // Чтобы текст на кнопке был виден.
            buttonBackGroundColor.ForeColor = Color.FromArgb(0, 255 - colorDialog.Color.R, 255 - colorDialog.Color.G, 255 - colorDialog.Color.B);
            pictureBox1_paint();
        }

        /// <summary>
        /// Событие при изменении толщины отрезка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarWidth_Scroll(object sender, EventArgs e)
        {
            pictureBox1_paint();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Событие при сохранении картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (fractal != null)
            {
                using (saveFileDialog1)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        fractal.Bmp.Save(saveFileDialog1.OpenFile(), System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            else
            {
                MessageBox.Show("Нельзя сохранить картинку пока не выбран фрактал.","Ошибка");
            }
        }
    }
}