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

namespace PZW_dr_1.Controls
{
    /// <summary>
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }

        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon_post.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
            this.EditIcon_post.MouseDown += (obj, eventHandler) => RaiseEditEvent();
        }


        public string Ime_post
        {
            get { return (string)GetValue(Ime_postProperty); }
            set { SetValue(Ime_postProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Ime_post.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Ime_postProperty =
            DependencyProperty.Register("Ime_post", typeof(string), typeof(Post), new UIPropertyMetadata("Name"));



        public string Sadrzaj
        {
            get { return (string)GetValue(SadrzajProperty); }
            set { SetValue(SadrzajProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sadrzaj.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SadrzajProperty =
            DependencyProperty.Register("Sadrzaj", typeof(string), typeof(Post), new UIPropertyMetadata("Moj komentar"));



        public string Putanja_post
        {
            get { return (string)GetValue(Putanja_postProperty); }
            set { SetValue(Putanja_postProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Putanja_post.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Putanja_postProperty =
            DependencyProperty.Register("Putanja_post", typeof(string), typeof(Post), new UIPropertyMetadata("/Resources/Images/User_unknown.png"));


        //DELETE event
        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
                 (
                    "Delete", //ime eventa
                     RoutingStrategy.Bubble,
                     typeof(RoutedEventHandler),
                     typeof(Post) //tip elementa koji posjeduje event
                 );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        //EDIT event

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
                 (
                    "Edit", //ime eventa
                     RoutingStrategy.Bubble,
                     typeof(RoutedEventHandler),
                     typeof(Post) //tip elementa koji posjeduje event
                 );

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.EditEvent);
            RaiseEvent(newEventArgs);
        }
    }
}
