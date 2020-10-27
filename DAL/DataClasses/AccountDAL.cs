using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.DataClasses
{


    public class AccountDAL
    {
       public int Register(Models.UserInfo info)
        {
           int  result = 0;
            using (var db=new Expense_ManagerEntities())
            {
                user_info DALInfo = new user_info();
                DALInfo.firstname = info.firstname;
                DALInfo.lastname = info.lastname;
                DALInfo.email = info.email;
                DALInfo.password = info.password;
                DALInfo.confirm_password = info.confirm_password;
                DALInfo.profile_pic_path = info.profile_pic_path;

                db.user_info.Add(DALInfo);
                db.SaveChanges();
                result=1;
            }
                return result;

        }

        public int IsUserExistWithUsernamePass(Models.Login info)
        {
            int result = 1;
            using (var db = new Expense_ManagerEntities())
            {
                bool isUserexist = db.user_info.Any(x => x.email == info.email);
                bool isCorrectPass=false;
                if (isUserexist)
                {
                    isCorrectPass= db.user_info.Any(x => x.email == info.email && x.password == info.password);
                    if (!isCorrectPass)
                    {
                        result = -1;
                    }

                }
                else
                {
                    result = -2;
                }
            }
            return result;

        }

        public Models.UserInfo FetchUserInfo(Models.Login info)
        {
            Models.UserInfo BALinfo = new Models.UserInfo();
            using (var db = new Expense_ManagerEntities())
            {
                bool isvalid = db.user_info.Any(x => x.email == info.email && x.password == info.password);
                if (isvalid)
                {

                    DAL.user_info DALinfo = db.user_info.Where(x => x.email == info.email && x.password == info.password).FirstOrDefault();
                    BALinfo.id = DALinfo.id;
                    BALinfo.firstname = DALinfo.firstname;
                    BALinfo.lastname = DALinfo.lastname;
                    BALinfo.email = DALinfo.email;
                    BALinfo.password = DALinfo.password;
                    BALinfo.confirm_password = DALinfo.confirm_password;
                    BALinfo.month_start_date = DALinfo.month_start_date;
                    BALinfo.profile_pic_path = DALinfo.profile_pic_path;

                    //var userdetail2 = from s in db.user_info where s.email == info.email && s.password == info.password select s;

                }
            }
            return BALinfo;

        }

        public int CheckUsernameIsExist(string email)
        {
            int result = 0;
            using (var db = new Expense_ManagerEntities())
            {
                bool isvalid = db.user_info.Any(x => x.email ==email);
                if (isvalid)
                {
                    result = 1;
                }
            }
            return result;
        }

    }
}
