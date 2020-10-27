using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.DataClasses
{
    public class CategoryDAL
    {

        public int AddCategory(Models.Category Category)
        {
            int result = 0;
            using(var db =new Expense_ManagerEntities())
            {
                if (Category.category_name != null)
                {
                    category cat = new category();
                    cat.category_name = Category.category_name;
                    cat.user_id = Category.user_id;
                    if (IsCategoryExist(cat))
                        return 2;
                    db.category.Add(cat);
                    db.SaveChanges();
                    result = 1;
                }

            }
            return result;
        }

        public bool IsCategoryExist(category Category)
        {
            bool result;
            using (var db = new Expense_ManagerEntities())
            {
                    category cat = new category();
                    result= db.category.Where(x => x.category_name == Category.category_name && x.user_id == Category.user_id).Any();
            }
            return result;
        }

        public List<Category> GetCategoryList(string userid)
        {
            List<Category> catListModel=new List<Category>();
            if (userid != null)
            {
                using (var db = new Expense_ManagerEntities())
                {
                    int id = int.Parse(userid);
                    int count = db.category.Where(m => m.user_id == id).Count();
                    List<category> catListDAL = new List<category>();
                    catListDAL = db.category.Where(m => m.user_id ==id).ToList();
                    foreach (var item in catListDAL)
                    {
                        Category catModel = new Category();
                        catModel.id = item.id;
                        catModel.category_name = item.category_name;
                        catModel.user_id = item.user_id;
                        catListModel.Add(catModel);
                    }
                    catListModel.Reverse();  //i am reversing it to display the latest added data on top
                }
            }
            return catListModel;

        }

        public int DeleteCategory(int ctgryId)
        {
            int result = 0;
            if (ctgryId > 0)
            {
                using (var db = new Expense_ManagerEntities())
                {
                    var a = db.category.Find(ctgryId);
                    db.category.Remove(a);
                    db.SaveChanges();
                    result = 1;
                }

            }
            return result;
        }

        public int EditCategory(int id,string name)
        {
            int result = 0;
            if (id>0 && name!=null)
            {
                using (var db = new Expense_ManagerEntities())
                {
                    var a = db.category.FirstOrDefault(x=>x.id==id);
                    if (a != null)
                    {
                        a.category_name = name;
                        db.SaveChanges();
                        result = 1;
                    }
                }

            }
            return result;
        }
    }
}
