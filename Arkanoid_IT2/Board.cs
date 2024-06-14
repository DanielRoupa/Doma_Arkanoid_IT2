using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_IT2
{
 public class Board : GameObject
 {
        public double Width { get; set; }
        public double Height { get; set; }
        public int Size { get; }
        public Rectangle rectangle = new Rectangle();

    public Board(int size)
    {
        Size = size;
    }

        public override void Draw(Canvas canvas)
        {

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://C:\\Users\\Danek\\Downloads\\Arkanoid_IT2_Nov--master\\Arkanoid_IT2\\Images\\blockBackground.JPG"));

            rectangle.Width = Size + 200;
            rectangle.Height = 100;
            rectangle.Fill = imageBrush;
            Canvas.SetBottom(rectangle, 20);
            Canvas.SetLeft(rectangle, Location.X - (Size + 200) / 2);
            canvas.Children.Add(rectangle);
        }
 }
}
