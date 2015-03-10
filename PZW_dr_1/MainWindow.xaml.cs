using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZW_dr_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LeftButton.Click += new RoutedEventHandler(LeftButton_Click);
            this.RightButton.Click += new RoutedEventHandler(RightButton_Click);
        }

        void RightButton_Click(object sender, RoutedEventArgs e)
        {
            this.LinesContainer.Children.Add(new Rectangle()
            {
                Width = 300,
                Height = 40,
                Margin = new Thickness(15, 5, 15, 5),
                Fill = Brushes.Red
            });
        }

        void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            this.RectangleContainer.Children.Add(new Rectangle()
            {
                Width = 80,
                Height = 80,
                Margin = new Thickness(0, 5, 0, 5),
                Fill = Brushes.Coral
            });
        }
    }
}
