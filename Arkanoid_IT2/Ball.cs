using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_IT2
{
    public class Ball : GameObject
    {
        public double Size { get; set; }
        public Vector MoveVector { get; set; }
        public Ellipse ball = new Ellipse();
        

        public Ball(double size)
        {
            Size = size;
        }

        public override void Draw(Canvas canvas)
        {
            
            ball.Width = Size;
            ball.Height = Size;
            ball.Fill = Brushes.White;
            Canvas.SetTop(ball, Location.Y - Size / 2);
            Canvas.SetLeft(ball, Location.X - Size / 2);
            canvas.Children.Add(ball);
        }

        public void Move(Rectangle rectangle, Board board)
        {
            Location  = Point.Add(Location, MoveVector);
            if (Location.Y > rectangle.Height || Location.Y < 0)
            {
                MoveVector = new Vector(MoveVector.X, -MoveVector.Y);
            }
            if (Location.X > rectangle.Width || Location.X < 0)
            {
                MoveVector = new Vector(-MoveVector.X, MoveVector.Y);
            }
            Rect ballRect = new Rect(Location.X - Size / 2, Location.Y - Size / 2, Size, Size);
            Rect boardRect = new Rect(board.Location.X - board.Width / 2, board.Location.Y, board.Width, board.Height);

            if (ballRect.IntersectsWith(boardRect))
            {
                MoveVector = new Vector(MoveVector.X, -MoveVector.Y);
                // Posun míčku nad desku, aby se předešlo opakovaným kolizím
                Location = new Point(Location.X, board.Location.Y - Size / 2 - 1);
            }
        }
    }
}