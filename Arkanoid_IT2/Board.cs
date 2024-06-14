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
   
   rectangle.Width = Size;
   rectangle.Height = 20;
   rectangle.Fill = Brushes.White;
   Canvas.SetBottom(rectangle, 20);
   Canvas.SetLeft(rectangle, Location.X - Size / 2);
   canvas.Children.Add(rectangle);
  }
 }
}
