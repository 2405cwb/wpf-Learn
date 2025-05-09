using ImTools;
using SimpleDataManager001.Db.MyInterface;
using SimpleDataManager001.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleDataManager001.Db.MyEntitys
{
    public class MyDb : DataInterface
    {

        private   List<User> _users = null;

        public MyDb()
        {
            Init();
        }

        public void Init()
        {
            _users = new List<User>();
            for (int i = 0; i < 30; i++)
            {
                _users.Add(new User()
                {
                    Id = i,
                    Name= $"name_{i}"
                });
            }
        }
        private readonly object _lock = new object();
        public bool Add(User user)
        {
            lock (_lock)
            {
                user.Id = _users.Max(u => u.Id) + 1;
                _users.Add(user);
                return true;
            }
        }

        public bool Delete(int id)
        {
           var user = this._users.FirstOrDefault(u => u.Id == id);
            if (user!= null)
            {

                this._users.Remove(user);
                return true;
            }
         
            return false;
        }

        public List<User> Get()
        {
            return this._users;
        }

        public bool Update(int id,string newName)
        {
            var user = this._users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                //更新
                user.Name = newName;
                return true;  
            }

            return false;
        }

        public List<User> GetUsersByName(string name)
        {

            return this._users.Where(u => u.Name.Contains(name)).ToList(); 
        }

        public User getUserById(int id)
        {
          return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}
