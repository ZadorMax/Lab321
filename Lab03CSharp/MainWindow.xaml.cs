using Lab03CSharp.ViewModel;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}

