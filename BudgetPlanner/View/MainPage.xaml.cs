using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BudgetPlanner.ViewModel;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace BudgetPlanner.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new OperationViewModel();
            // по умолчанию открываем страницу
            myFrame.Navigate(typeof(OperationHistory), DataContext);
            TitleTextBlock.Text = "История";
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (history.IsSelected)
            {
                myFrame.Navigate(typeof(OperationHistory), DataContext);
                TitleTextBlock.Text = "История";
            }
            else if (adding.IsSelected)
            {
                myFrame.Navigate(typeof(AddingOperation), DataContext);
                TitleTextBlock.Text = "Добавить";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is OperationViewModel operationViewModel)
                this.DataContext = operationViewModel;
            base.OnNavigatedTo(e);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}
