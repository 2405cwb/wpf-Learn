using SimpleDataManager001.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataManager001.Db.MyInterface
{
    public interface DataInterface
    {

        //增加
        public bool Add(User user);

        //删除

        public bool Delete(int id);
        //修改

        public bool Update(int id,string newName);
        //查找
        public List<User> Get();


        public User getUserById(int id);
        //查找通过姓名

        public List<User> GetUsersByName(string name);
    }
}
