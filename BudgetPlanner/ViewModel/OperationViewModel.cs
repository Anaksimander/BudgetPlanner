using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BudgetPlanner.Model;

namespace BudgetPlanner.ViewModel
{
    public class OperationViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OperationModel> Operations { get; set; }

        public OperationViewModel()
        {
            Operations = new ObservableCollection<OperationModel>
            {
                new OperationModel {OperationType="доход", OperationSum=1000, Category="заработная плата", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="доход", OperationSum=1000, Category="возврат долга", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="доход", OperationSum=1000, Category="дивиденды", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="транспорт", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="еда", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" },
                new OperationModel {OperationType="расход", OperationSum=100, Category="развлечения", Comment= "Для уведомления системы об изменениях свойств модель" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
