﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Arkanoid_IT2
{
 /// <summary>
 /// Interaction logic for MainWindow.xaml
 /// </summary>
 public partial class MainWindow : Window
 {
  private Game game;
  private DispatcherTimer timerGUI;
        private bool Ispaused = false;

  public MainWindow()
  {
   InitializeComponent();
            this.KeyDown += new KeyEventHandler(Onkeydown); 
  }
        private const int PaddleWidth = 100;
        private const int PaddleHeight = 20;
        private const int BallDiameter = 20;
        private const int BlockWidth = 75;
        private const int BlockHeight = 20; // Updated height to match bloky
        private const int BlockRows = 4;
        private const int BlockColumns = 5;

        private Rectangle paddle;
        private Ellipse ball;
        private double ballDX = 4;
        private double ballDY = -4;
        private DispatcherTimer timer;
        private List<bloky> blocks;

        private void MenuPrototype()
  {
   int w = 200;
   int h = 200;
   double menuX = (GameCanvas.ActualWidth - w) / 2;
   double menuY = (GameCanvas.ActualHeight - h) / 2;
   Rectangle menu = new Rectangle();
   menu.Width = w;
   menu.Height = h;
   menu.Fill = Brushes.White;
   Canvas.SetLeft(menu, menuX);
   Canvas.SetTop(menu, menuY);
   GameCanvas.Children.Add(menu);

   Rectangle item1 = new Rectangle();
   item1.Width = w * 0.8;
   item1.Height = h * 0.35;
   item1.Stroke = Brushes.Black;
   item1.Fill = Brushes.WhiteSmoke;
   Canvas.SetLeft(item1, menuX + w * 0.1);
   Canvas.SetTop(item1, menuY + h * 0.1);
   GameCanvas.Children.Add(item1);

   Rectangle item2 = new Rectangle();
   item2.Width = w * 0.8;
   item2.Height = h * 0.35;
   item2.Stroke = Brushes.Black;
   item2.Fill = Brushes.WhiteSmoke;
   Canvas.SetLeft(item2, menuX + w * 0.1);
   Canvas.SetTop(item2, menuY + h * 0.2 + item1.Height);
   GameCanvas.Children.Add(item2);
  }

  private void Window_Loaded(object sender, RoutedEventArgs e)
  {
   game = new Game();
   timerGUI = new DispatcherTimer();
   timerGUI.Interval = TimeSpan.FromMilliseconds(30);
   timerGUI.Tick += Timer_Tick;
   timerGUI.Start();
  }

  private void Timer_Tick(object? sender, EventArgs e)
  {
   game.Move(new Rectangle() { Width = GameCanvas.ActualWidth, Height = GameCanvas.ActualHeight });
   GameCanvas.Children.Clear(); 
   game.Draw(GameCanvas);
  }

  private void GameCanvas_MouseMove(object sender, MouseEventArgs e)
  {
   game.SetBoardLocation(e.GetPosition(GameCanvas).X);
  }
        private void Onkeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (Ispaused)
                {
                    resumeGame();
                }
                else
                {
                       PauseGame();
                }

            }
        }
        private void PauseGame()
        {
            Ispaused = true;
            timerGUI.Stop();
        }
        private void resumeGame()
        {
            Ispaused = false;
            timerGUI.Start();
        }
 }
}