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
using PZW_dr_1.Controls;
//using Microsoft.VisualBasic;

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
            foreach (var child in this.UsersContainer.Children)
            {
                if (!(child is User)) { continue; }
                var user = child as User;
                user.Delete += OnUserDelete;
                user.Edit += OnUserEdit;
            }
            OnlineUser.Edit += OnUserEdit;

            foreach (var child in this.LinesContainer.Children)
            {
                if (!(child is Post)) { continue; }
                var post = child as Post;
                post.Delete += OnPostDelete;
                post.Edit += OnPostEdit;
            }

        }
        
        private void OnUserDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var user = sender as User;
            this.UsersContainer.Children.Remove(user);
        }

        private void OnPostDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }
            var post = sender as Post;
            this.LinesContainer.Children.Remove(post);
        }

        private void OnUserEdit(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var user = sender as User;
            user.Ime = "Zrinka";
            user.Putanja = "/Resources/Images/User_girl1.png";
            //user.Ime = Microsoft.VisualBasic.Interaction.InputBox("Unesite ime", "Uredi korisnika", user.Ime,0, 0);
            //user.Putanja = Microsoft.VisualBasic.Interaction.InputBox("Unesite putanju do slike", "Uredi korisnika", user.Putanja, 0, 0);
        }

        private void OnPostEdit(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }
            var post = sender as Post;
            post.Sadrzaj = "Ovaj komentar je uredjivan!";
        }
        void RightButton_Click(object sender, RoutedEventArgs e)
        {
            Post post = new Post()
            {
                Width = 300,
                Height = 70,
                Margin = new Thickness(15, 5, 15, 5)
            };
            post.Edit += OnPostEdit;
            post.Delete += OnPostDelete;
            this.LinesContainer.Children.Add(post);
        }

        void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                Width = 80,
                Height = 80,
                Margin = new Thickness(0, 5, 0, 5)
            };
            user.Delete += OnUserDelete;
            user.Edit += OnUserEdit;
            this.UsersContainer.Children.Add(user);
        }
    }
}
