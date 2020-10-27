using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.DataClasses
{
    public class ExpenseIncomeBLL
    {
        DAL.DataClasses.ExpenseIncomeDAL ExInObj = new DAL.DataClasses.ExpenseIncomeDAL();
        public int AddRecord(Models.Records rec)
        {
            int result = 0;
            result = ExInObj.AddRecord(rec);
            return result;
        }
    }
}
