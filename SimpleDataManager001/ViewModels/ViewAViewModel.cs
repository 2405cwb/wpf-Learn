using Prism.Commands;
using Prism.Mvvm;
using SimpleDataManager001.Db.MyInterface;
using SimpleDataManager001.Model;
using SimpleDataManager001.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleDataManager001.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public ViewAViewModel(DataInterface data)
        {
            m_data = data;
            GetCurAllUsers();
             FindMethod = new DelegateCommand(ExecuteMyCommand);
            ResetMethod = new DelegateCommand(() =>
            {
                People = new ObservableCollection<User>(m_data.Get());
            });
            AddMethod = new DelegateCommand(ExecuteAddMethod);
            EditMethod = new DelegateCommand<int?>(ExecuteEditMethod); // 确保这里正确
            DeleteCommand = new DelegateCommand<int?>(ExecuteDelMethod);
        }

        private void GetCurAllUsers()
        {
            People = new ObservableCollection<User>(m_data.Get());

        }

        private string findStr;

        public string FindStr
        {
            get { return findStr; }
            set { SetProperty(ref findStr, value); }
        }

        public DelegateCommand FindMethod { get; }

        public DelegateCommand ResetMethod { get; }

        public DelegateCommand AddMethod { get; }

        public DelegateCommand<int?> EditMethod { get; set; }

        public DelegateCommand<int?> DeleteCommand { get; set; }

        private readonly DataInterface m_data;

        private ObservableCollection<User> _people;
        public ObservableCollection<User> People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        private void ExecuteAddMethod()
        {
            User user = new User();

            UserChangeForm form = new UserChangeForm(user);

           var r= form.ShowDialog();
            if (r.Value)
            {
               
                m_data.Add(user);
                GetCurAllUsers();
            }

        }

        private void ExecuteEditMethod(int? id)
        {
            if (id.HasValue)
            {
                User user = m_data.getUserById(id.Value);
                UserChangeForm form = new UserChangeForm(user);

                var r = form.ShowDialog();
                if (r.Value)
                {

                    m_data.Update(user.Id, user.Name);
                    GetCurAllUsers();
                }
            }
            

        }

        private void ExecuteDelMethod(int? id)
        {
            if (id.HasValue)
            {
                User user = m_data.getUserById(id.Value);
                var result = MessageBox.Show($"确定要删除{user.Name}吗？", "提示操作", MessageBoxButton.OK, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    m_data.Delete(id.Value);
                    GetCurAllUsers();
                }
            }
               
        }


        private void ExecuteMyCommand()
        {
           List<User> data =   m_data.GetUsersByName(FindStr);
            People = new ObservableCollection<User>();
            if (data!=null)
            {
                if (data.Count > 0)
                {
                    foreach (var user in data) {
                        People.Add(user);
                    }

                }
            }
         
        }




    }
}
