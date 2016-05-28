using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraWChaos
{
    public class Osmiokat : IFigura
    {
        private List<Point> _pointList;
        private Color[] _colorList = new[] { Color.Red, Color.Green, 
            Color.Blue, Color.Yellow, Color.Violet, Color.Gold, Color.Aqua,
            Color.ForestGreen
        };

        public Osmiokat()
        {
            _pointList = new List<Point>();
            double s = Math.PI / 4;
            for (int i = 0; i < 8; i++)
            {
                Point p = new Point();
                p.X = (int)(Math.Cos((Math.PI * 0 / 180.0) + i * s) * 185) + 220;
                p.Y = (int)(Math.Sin((Math.PI * 0 / 180.0) + i * s) * 185) + 185;
                _pointList.Add(p);
            }
        }

        #region Implementation of IFigura

        public Point[] Points
        {
            get { return _pointList.ToArray(); }
        }

        public Color[] Colors
        {
            get { return _colorList; }
        }

        public int MaxRandomValue
        {
            get { return _pointList.Count; }
        }

        #endregion
    }
}
