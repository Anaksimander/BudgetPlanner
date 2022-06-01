using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Model
{
    public class OperationModel : INotifyPropertyChanged/*, IDataErrorInfo*/
    {
        private int _operationId;
        private string _operationType;
        private decimal? _operationSum;
        private string _category;
        private string _comment;
        public int OperationId
        {
            get
            {
                return _operationId;
            }
            set
            {
                _operationId = value;
                OnPropertyChanged();
            }
        }
        public string OperationType{
            get
            {
                return _operationType;
            }
            set
            {
                _operationType = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
