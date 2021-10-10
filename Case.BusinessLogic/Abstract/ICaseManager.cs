using Case.Etity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.BusinessLogic.Abstract
{
    public interface IUserManager
    {
        User Login(User entity);
        User GetById(int id);
        List<User> GetAll(int page = 1, int pageSize = 0);
        string Add(User entity);
        string Update(User entity);
        string Delete(int id);
    }

    public interface IContentManager
    {
        Content GetById(int Id);
        List<Content> GetAll(int page = 1, int pageSize = 0);
        string Add(Content entity);
        string Update(Content entity);
        string Delete(int id);
    }
}
