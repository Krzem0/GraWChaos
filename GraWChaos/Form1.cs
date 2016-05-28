using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraWChaos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pobiera z interfejsu liczbę iteracji
            int loopCount = 0;
            int.TryParse(textBox1.Text, out loopCount);

            // Tworzy nową bitmapę
            Bitmap bitmap = new Bitmap(460, 390);

            // Tworzy odpowiedni obiekt fiugry na podstawie podanego
            // przez użytkownika
            IFigura figura = GetFigure(comboBox1.Text);


            #region Krok poczatkowy

            Random r = new Random();
            // Losuje punkty początkowe
            int random1 = 0;
            int random2 = 0;

            // Dopuki nie wylosuje dwóch różnych punktów...
            while (random1 == random2)
            {
                random1 = r.Next(0, figura.MaxRandomValue);
            }

            // Pobiera punkty z figury
            Point p1 = figura.Points[random1];
            Point p2 = figura.Points[random2];

            // Oblicza punkt środkowy
            Point halfPoint = HalfPoint(p1, p2);

            // Rysuje punkt na bitmapie
            bitmap.SetPixel(halfPoint.X, halfPoint.Y, figura.Colors[random1]);
            
            #endregion Krokpoczatkowy


            #region Iteracja
            
            // Standardowa iteracja
            for (int i = 0; i < loopCount; i++)
            {
                // Losuje nowy punkt z figury
                random1 = r.Next(0, figura.MaxRandomValue);

                // Pobiera punkt
                p1 = figura.Points[random1];

                // Wyznacza nowy punkt w połowie między teraz wylosowanym,
                // a ostatnio narysowanym
                halfPoint = HalfPoint(p1, halfPoint);

                // Rysuje punkt na bitmapie
                bitmap.SetPixel(halfPoint.X, halfPoint.Y, figura.Colors[random1]);
            }

            #endregion Iteracja


            // Binduje bitmapę do kontrolki
            pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// Oblicza współrzędne punktu środkowego.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Point HalfPoint(Point a, Point b)
        {
            return new Point(((a.X + b.X) / 2), ((a.Y + b.Y) / 2));
        }

        /// <summary>
        /// Fabryka obiektów figur
        /// </summary>
        /// <param name="figureName"></param>
        /// <returns></returns>
        private IFigura GetFigure(string figureName)
        {
            switch (figureName)
            {
                case "Trójkąt":
                    return new Trojkat();
                case "Kwadrat":
                    return new Kwadrat();
                case "Pięciokąt":
                    return new Pieciokat();
                case "Sześciokąt":
                    return new Szesciokat();
                case "Siedmiokąt":
                    return new Siedmiokat();
                case "Ośmiokąt":
                    return new Osmiokat();
                default: throw new Exception("Nie znana figura!!! 0o0o0o0o0o0o");
            }
        }
    }
}
