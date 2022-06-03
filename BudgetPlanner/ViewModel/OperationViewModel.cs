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
                return _selectedOperation;
            }
            set
            {
                _selectedOperation = value;
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
            SaveCommand = new BaseCommand(SaveOperation, CanSaveOperation);
            NewOperation = new OperationModel();
            _selectedOperation = new OperationModel();

            bd = new DataBaseWorker();
            try
            {
                List<string[]> list = bd.ExecuteQuery($"SELECT operationId, operationType, operationSum, category, comment FROM Operations", 5);

                if (list != null)
                {
                    IEnumerable<OperationModel> collection = list.Select(
                    (x) =>
                    {
                        return new OperationModel()
                        {
                            OperationId = int.Parse(x[0]),
                            OperationType = x[1],
                            OperationSum = decimal.Parse(x[2]),
                            Category = x[3],
                            Comment = x[4]
                        };
                    });
                    Operations = new ObservableCollection<OperationModel>(collection);
                }
                else
                {
                    Operations = new ObservableCollection<OperationModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;//тут должно быть всплывающее окно 
            }
            
            
        }

        public BaseCommand AddCommand{
            get;
        }

        public BaseCommand SaveCommand
        {
            get;
        }

        private void SaveOperation(object obj)
        {
            OperationModel item = (OperationModel)obj;
            string strOperationSum = $"{item.OperationSum}".Replace(',', '.');
            try
            {
                bd.ExecuteNonQuery($"UPDATE Operations SET operationType = '{item.OperationType}', operationSum = {strOperationSum}, category = '{item.Category}', comment = '{item.Comment}' WHERE operationId = {item.OperationId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;//тут должно быть всплывающее окно 
            }
        }
        private bool CanSaveOperation(object obj)
        {
            OperationModel item = (OperationModel)obj;
            if (obj == null || item.Category == null || item.OperationSum == null || item.OperationType == null ||
                            item.Category == "" || item.OperationType == "")
                return false;
            else
                return true;
        }

        private void AddOperation(object obj)
        {
            Operations.Add(_newOperation);
            string strOperationSum = $"{OperationSum}".Replace(',', '.');
            try
            {
                bd.ExecuteNonQuery($"INSERT INTO Operations(operationType, operationSum, category, comment) VALUES('{OperationType}', {strOperationSum}, '{Category}', '{Comment}')");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;//тут должно быть всплывающее окно 
            }
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
                return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
