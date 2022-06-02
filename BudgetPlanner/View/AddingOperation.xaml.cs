using BudgetPlanner.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace BudgetPlanner.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AddingOperation : UserControl
    {
        public AddingOperation()
        {
            this.InitializeComponent();
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    if (e.Parameter is OperationViewModel operationViewModel)
        //        this.DataContext = operationViewModel;
        //    base.OnNavigatedTo(e);
        //}

        ///уверен что это делается как-то элементарно - но я не смог понять как сделать валидатор как в wpf
        private void SumBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            var str = sender.Text;
            if (str.Length > 0)
            {
                if ((str.Last() == ',') && (str.IndexOf(',') != str.Length - 1))
                {
                    sender.Text = str.Remove(str.Length - 1);
                }else
                if(!((decimal.TryParse(sender.Text, out decimal number) && number >= 0))){
                    str = new string((from c in str
                                      where char.IsNumber(c) || c == ','
                                      select c
                   ).ToArray());
                    sender.Text = str;
                }
            }
        }
    }
}
