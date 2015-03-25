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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
            this.EditIcon.MouseDown += (obj, eventHandler) => RaiseEditEvent();
        }


        //property IME

        public string Ime
        {
            get { return (string)GetValue(ImeProperty); }
            set { SetValue(ImeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Ime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImeProperty =
            DependencyProperty.Register("Ime", typeof(string), typeof(User), new UIPropertyMetadata("Name"));


        //property PUTANJA
        public string Putanja
        {
            get { return (string)GetValue(PutanjaProperty); }
            set { SetValue(PutanjaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Putanja.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PutanjaProperty =
            DependencyProperty.Register("Putanja", typeof(string), typeof(User), new UIPropertyMetadata("/Resources/Images/User_unknown.png"));

        
        //DELETE event
        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
                 (
                    "Delete", //ime eventa
                     RoutingStrategy.Bubble,
                     typeof(RoutedEventHandler),
                     typeof(User) //tip elementa koji posjeduje event
                 );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.DeleteEvent);
            RaiseEvent(newEventArgs);
        }
       
        //EDIT event

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
                 (
                    "Edit", //ime eventa
                     RoutingStrategy.Bubble,
                     typeof(RoutedEventHandler),
                     typeof(User) //tip elementa koji posjeduje event
                 );

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.EditEvent);
            RaiseEvent(newEventArgs);
        }
  
    }
}
