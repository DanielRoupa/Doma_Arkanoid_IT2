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
            double startX = (canvas.ActualWidth) / 2 - 550;
            double startY = (canvas.ActualHeight);

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://C:\\Users\\Danek\\Downloads\\Arkanoid_IT2_Nov--master\\Arkanoid_IT2\\Images\\blockBackground.JPG"));
            for (int i = 0; i < 5; i++)
            {
                  for (int j = 0; j < 10; j++)
                  {
                        Rectangle rectangle = new Rectangle
                        {
                            Width = Size,
                            Height = 20,
                            Fill = imageBrush
                        };

                        Canvas.SetTop(rectangle, 100 + i * 25); // Každý další řádek dolů o 25 pixelů
                        Canvas.SetLeft(rectangle,startX + j * (Size + 5)); // Každý další obdélník doprava o (Size + 5) pixelů

                        canvas.Children.Add(rectangle);
                  }
            }
        }
    }
}
