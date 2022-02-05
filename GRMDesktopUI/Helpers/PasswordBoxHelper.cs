using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GRMDesktopUI.Helpers
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword",
                typeof(string),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(string.Empty, onBoundPasswordChanged));


        public static string GetBoundPassword(DependencyObject d)
        {
            var box = d as PasswordBox;

            if(box != null)
            {
                //this funny little dance here ensures that we've hooker the
                // PasswordChaged event once, and only once.
                box.PasswordChanged -= PasswordChanged;
                box.PasswordChanged += PasswordChanged;
            }

            return (string)d.GetValue(BoundPasswordProperty);
        }

        private static void onBoundPasswordChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var box = d as PasswordBox;

            if(box == null)
                return;

            box.Password = GetBoundPassword(d);

        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox password = sender as PasswordBox;

            SetBoundPassowrd(password,password.Password);

            //set cursor past the llast character in the box
            password.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(password, new object[] { password.Password.Length, 0});
        }


        public static void SetBoundPassowrd(DependencyObject d, string value)
        {
            if (string.Equals(value, GetBoundPassword(d)))
                return; //and this is how we prevent infinite recursion

            d.SetValue(BoundPasswordProperty, value);
        }

   

     
    }
}
