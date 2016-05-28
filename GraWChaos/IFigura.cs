using System.Drawing;

namespace GraWChaos
{
    interface IFigura
    {
        Point[] Points { get; }
        Color[] Colors { get; }
        int MaxRandomValue { get; }
    }
}
