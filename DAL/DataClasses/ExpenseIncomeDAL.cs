using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.DataClasses
{
    public class ExpenseIncomeDAL
    {

        public int AddRecord(Models.Records rec)
        {
            int result = 0;
            using (var db = new Expense_ManagerEntities())
            {
                record recDAL = new record();
                recDAL.userid = rec.userid;
                recDAL.expense_income = rec.expense_income;
                recDAL.amount = rec.amount;
                recDAL.category = rec.category;
                recDAL.date = rec.date;
                recDAL.notes = rec.notes;

                db.record.Add(recDAL);
                db.SaveChanges();
                result = 1;

            }
            return result;
        }

    }
}
