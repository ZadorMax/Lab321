using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Lab03CSharp.ViewModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab03CSharp.View
{
    /// <summary>
    /// Логика взаимодействия для UserFormView.xaml
    /// </summary>
    public partial class UserFormView : UserControl
    {
        public UserFormView()
        {
            DataContext = new UserFormViewModel();
            InitializeComponent();
        }
    }
}
