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


namespace BudgetPlanner.ViewModel
{
    public class OperationViewModel : INotifyPropertyChanged
    {
        DataBaseWorker bd;

        private OperationModel _newOperation;
        private OperationModel _selectedOperation;
        public OperationModel NewOperation
        {
            get
            {
                return _newOperation;
            }
            set
            {
                _newOperation = value;
                OnPropertyChanged();
                AddCommand.RaisCanExecuteChanged();
            }
        }
        public OperationModel SelectedOperation
        {
            get
            {
                return _newOperation;
            }
            set
            {
                _newOperation = value;
                OnPropertyChanged();
                AddCommand.RaisCanExecuteChanged();
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
                if(value.Length <= 10)
                {
                    NewOperation.OperationType = value;
                    OnPropertyChanged("OperationType");
                    AddCommand.RaisCanExecuteChanged();
                }
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
                AddCommand.RaisCanExecuteChanged();
                OnPropertyChanged("Category");
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
            AddCommand = new BaseCommand(AddOperation, CanAddOperation);
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
            //bd = new DataBaseWorker();
            //bd.OpentConection();
            //List<string[]> list = bd.ExecuteQuery($"SELECT operationId, operationType, operationSum, category, comment FROM Operations", 5);

            //if (list != null)
            //{
            //    IEnumerable<OperationModel> collection = list.Select(
            //    (x) =>
            //    {
            //        return new OperationModel()
            //        {
            //            OperationId = int.Parse(x[0]),
            //            OperationType = x[1],
            //            OperationSum = decimal.Parse(x[2]),
            //            Category = x[3],
            //            Comment = x[4]
            //        };
            //    });
            //    Operations = new ObservableCollection<OperationModel>(collection);
            //}
            //else
            //{
            //    Operations = new ObservableCollection<OperationModel>();
            //}
        }

        public BaseCommand AddCommand{
            get;
        }

        private void AddOperation(object obj)
        {
            Operations.Add(_newOperation);

            string strOperationSum = $"{OperationSum}".Replace(',', '.');
            bd.ExecuteQuery($"INSERT INTO Operations(operationType, operationSum, category, comment) VALUES('{OperationType}', {strOperationSum}, '{Category}', '{Comment}')");

            //очищаем поля окна
            NewOperation = new OperationModel();
            OnPropertyChanged("OperationType");
            OnPropertyChanged("OperationSum");
            OnPropertyChanged("Category");
            OnPropertyChanged("Comment");  
        }
        private bool CanAddOperation(object obj)
        {
            if (NewOperation.Category == null || NewOperation.OperationSum == null || NewOperation.OperationType == null ||
                            NewOperation.Category == "" || NewOperation.OperationType == "")
                return false;
            else
            {
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
