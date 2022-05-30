using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Model
{
    public class OperationModel : INotifyPropertyChanged
    {
        private string _operationType;
        private decimal _operationSum;
        private string _category;
        private string _comment;
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

        public decimal OperationSum{
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
