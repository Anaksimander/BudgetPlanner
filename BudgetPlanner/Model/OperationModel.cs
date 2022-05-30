using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Model
{
    public class OperationModel
    {
        public string OperationType { get; set; }
        public decimal OperationSum { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
    }
}
