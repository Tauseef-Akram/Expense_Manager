using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.DataClasses;

namespace BLL.DataClasses
{

    public class CategoryBLL
    {
        DAL.DataClasses.CategoryDAL categoryDAL = new CategoryDAL();
        public int AddCategory(Models.Category CategoryName)
        {

            int result = categoryDAL.AddCategory(CategoryName);
            return result;
        }

        public List<Category> GetCategoryList(string userid)
        {

            return categoryDAL.GetCategoryList(userid);

        }

        public int DeleteCategory(int ctgryId)
        {
            return categoryDAL.DeleteCategory(ctgryId);
        }

        public int EditCategory(int id, string name)
        {
            return categoryDAL.EditCategory(id, name);
        }



    }
}
