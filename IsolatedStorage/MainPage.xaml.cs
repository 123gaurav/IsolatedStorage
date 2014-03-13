using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IsolatedStorage.Resources;
using System.IO.IsolatedStorage;
using System.IO;

namespace IsolatedStorage
{
    public partial class MainPage : PhoneApplicationPage
    {
        private int i = 0;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            i++;
            string text = "Book" + i + "details:  Book Name:" + title.Text + "\tBook Author:" + auth.Text + "\tBook Description:" + desc.Text;
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists("bookstore.txt"))
                {
                    using(IsolatedStorageFileStream ars = isf.OpenFile("bookstore.txt",FileMode.Append))
                    {
                        StreamWriter writer = new StreamWriter(ars);
                        writer.Write(writer.NewLine+text); 
                        writer.Close();
                    }
                }
                else
                {
                    using (IsolatedStorageFileStream rawStream = isf.CreateFile("bookstore.txt"))
                    {
                        StreamWriter writer = new StreamWriter(rawStream); 
                        writer.Write(text); 
                        writer.Close();
                    }
                }
            } 
           /* i++;
            store.Add("Book" + i + "details:","  ");
            store.Add("Book Name:",title.Text+" ");
            store.Add("Book Author:", auth.Text+" ");
            store.Add("Book Description:", desc.Text+"\n");*/
            
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            Application.Current.Terminate();
        }

        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}