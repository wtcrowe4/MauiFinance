using MauiFinance.ViewModels;
using System.Runtime.CompilerServices;

namespace MauiFinance.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}