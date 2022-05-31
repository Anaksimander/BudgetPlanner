using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Model
{
    public class OperationModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _operationType;
        private decimal? _operationSum;
        private string _category;
        private string _comment;
        public int OperationId { get; set; }
        public string OperationType{
            get
            {
                return _operationType;
            }
            set
            {
                _operationType = value;
                OnPropertyChanged("OperationType");
            }
        }
        public decimal? OperationSum{
            get
            {
                return _operationSum;
            }
            set
            {
                _operationSum = value;
                OnPropertyChanged("OperationSum");
            }
        }
        public string Category {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }
        public string Comment {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "OperationType":
                        if ((OperationSum < 0))
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;
                    case "OperationSum":
                        //Обработка ошибок для свойства Name
                        break;
                    case "Category":
                        //Обработка ошибок для свойства Position
                    case "Comment":
                        //Обработка ошибок для свойства Position
                        break;
                }
                return error;
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
