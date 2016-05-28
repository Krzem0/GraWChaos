using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraWChaos
{
    public class Trojkat : IFigura
    {
        private List<Point> _pointList;
        private Color[] _colorList = new [] { Color.Red, Color.Green, Color.Blue };

        public Trojkat()
        {
            _pointList = new List<Point>();
            double s = Math.PI / 1.5;

            // Dla trzech wierzchołków
            for (int i = 0; i < 3; i++)
            {
                Point p = new Point();

                // x = (cos(obrot poczatkowy + i * s) * promień) + przesunięcie w prawo;
                p.X = (int)(Math.Cos((Math.PI * 30 / 180.0) + i * s) * 200) + 220;

                // y = (sin(obrot poczatkowy + i * s) * promień) + przesunięcie w lewo;
                p.Y = (int)(Math.Sin((Math.PI * 30 / 180.0) + i * s) * 200) + 220;
                _pointList.Add(p);
            }
        }

        public Point[] Points { get { return _pointList.ToArray(); } }
        public Color[] Colors { get { return _colorList; } }
        public int MaxRandomValue { get { return _pointList.Count; } }
    }
}
