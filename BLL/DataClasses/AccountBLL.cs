using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataClasses;

namespace BLL
{

    public class AccountBLL
    {
        AccountDAL account = new AccountDAL();
        public int Register(Models.UserInfo info)
        {
            int Result = 0;
            Result = account.Register(info);
            return Result;
        }

        public int IsUserExistWithUsernamePass(Models.Login info)
        {
            int result = account.IsUserExistWithUsernamePass(info);
            return result;

        }

        public Models.UserInfo FetchUserInfo(Models.Login info)
        {
            Models.UserInfo BALinfo = new Models.UserInfo();
            BALinfo = account.FetchUserInfo(info);
            return BALinfo;

        }

        public int CheckUsernameIsExist(string email)
        {
            int result = 0;
            result = account.CheckUsernameIsExist(email);
            return result;
        }
    }
}
