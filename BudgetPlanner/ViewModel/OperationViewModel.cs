using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BudgetPlanner.Model;
using BudgetPlanner;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace BudgetPlanner.ViewModel
{
    public class OperationViewModel : INotifyPropertyChanged
    {
        private OperationModel _newOperation;
        public OperationModel NewOperation
        {
            get
            {
                return _newOperation;
            }
            set
            {
                _newOperation = value;
                OnPropertyChanged("NewOperation");
            }
        }

        public string OperationType
        {
            get
            {
                return NewOperation.OperationType;
            }
            set
            {
                NewOperation.OperationType = value;
                OnPropertyChanged("OperationType");
                AddCommand.RaisCanExecuteChanged();
            }
        }

        public decimal? OperationSum
        {
            get
            {
                return NewOperation.OperationSum;
            }
            set
            {
                NewOperation.OperationSum = value;
                OnPropertyChanged("OperationSum");
                AddCommand.RaisCanExecuteChanged();
            }
        }

        public string Category
        {
            get
            {
                return NewOperation.Category;
            }
            set
            {
                NewOperation.Category = value;
                OnPropertyChanged("Category");
                AddCommand.RaisCanExecuteChanged();
            }
        }
        public string Comment
        {
            get
            {
                return NewOperation.Comment;
            }
            set
            {
                NewOperation.Comment = value;
                OnPropertyChanged("Comment");
            }
        }

        public ObservableCollection<OperationModel> Operations { get; set; }

        public OperationViewModel()
        {
            NewOperation = new OperationModel();
            Operations = new ObservableCollection<OperationModel>
            {
                new OperationModel {OperationType="доход", OperationSum=1000, Category="заработная плата", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="доход", OperationSum=1000, Category="возврат долга", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="доход", OperationSum=1000, Category="дивиденды", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="транспорт", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="еда", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" }
            };


            
        }

        private BaseCommand _addCommand;
        public BaseCommand AddCommand{
            get
            {
                {
                    return _addCommand ??
                      (_addCommand = new BaseCommand(
                        obj =>
                        {
                            Operations.Add(_newOperation);
                            //NewOperation = new OperationModel();

                        },
                        obj =>
                        {
                            if (Category == null || OperationSum == null || OperationType == null)
                                return false;
                            else
                            {
                                return true;
                            }

                        }));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
