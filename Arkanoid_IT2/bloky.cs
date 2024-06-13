using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_IT2
{
    public class bloky : GameObject
    {
        public int Size { get; }

        public bloky(int size)
        {
            Size = size;
        }

        public override void Draw(Canvas canvas)
        {
             for (int i = 0; i < 5; i++)
             {
                  for (int j = 0; j < 6; j++)
                  {
                        Rectangle rectangle = new Rectangle
                        {
                            Width = Size,
                            Height = 20,
                            Fill = Brushes.DeepSkyBlue
                        };

                        Canvas.SetTop(rectangle, 20 + i * 25); // Každý další řádek dolů o 25 pixelů
                        Canvas.SetLeft(rectangle, Location.X + j * (Size + 5)); // Každý další obdélník doprava o (Size + 5) pixelů

                        canvas.Children.Add(rectangle);
                  }
             }
        }
    }
}
