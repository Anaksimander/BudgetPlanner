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
        OperationHistory historyControl;
        AddingOperation addingControl;
        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new OperationViewModel();
            historyControl = new OperationHistory();
            addingControl = new AddingOperation();
        }


        private void nvAll_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (nvAll.Content is AddingOperation)
                nvAll.Content = historyControl;
            else
                nvAll.Content = addingControl;

            addItem.IsEnabled = !addItem.IsEnabled;
            historyItem.IsEnabled = !historyItem.IsEnabled;
        }

        private void nvAll_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (nvAll.Content is AddingOperation)
                nvAll.Content = historyControl;
            else
                nvAll.Content = addingControl;

            addItem.IsEnabled = !addItem.IsEnabled;
            historyItem.IsEnabled = !historyItem.IsEnabled;
        }
    }
}
