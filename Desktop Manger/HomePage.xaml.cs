﻿using System;
using System.Collections.Generic;
using System.IO;
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

using IWshRuntimeLibrary;
namespace Desktop_Manger
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    /// To Do:
    ///         I Have to change the string array for file extension to normal string with string.contain
    public partial class HomePage : Page
    {
        double PageHeight, PageWidth;
        List<AppInfo> AppsList = new List<AppInfo>();
        //int AppsListCount = 0;
        public HomePage(double height, double width)
        {   
            InitializeComponent();
            PageHeight = height;
            PageWidth = width;
            canv1.Height = height;
            canv1.Width = width;
            HomePageLayout layout = new HomePageLayout();
            layout.ParentCanvas = canv1;
            layout.onStart(canv1);
           // layout.SetVideoAsBackground(@"D:\Videos\bf4.mp4");

        }

        private void canv1_Drop(object sender, DragEventArgs e)
        {
            string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in Files)
            {
                AppInfo app = new AppInfo(file);
                Canvas.SetLeft(app, e.GetPosition(canv1).X);
                Canvas.SetTop(app, e.GetPosition(canv1).Y);
                canv1.Children.Add(app);
                app.ParentCanvas = canv1;
                AppsList.Add(app);
            }
        }
      

        private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            canv1.Focus();
        }

       
    }
}
