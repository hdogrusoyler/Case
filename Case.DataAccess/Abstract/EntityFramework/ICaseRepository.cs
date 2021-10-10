using Case.Core.DataAccess;
using Case.Etity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.DataAccess.Abstract.EntityFramework
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Login(User user);
        List<User> GetList();
        User Get(int id);
        bool Insert(User entity);
        bool Change(User entity);
        bool Remove(int id);
    }

    public interface IContentRepository : IBaseRepository<Content>
    {
        List<Content> GetList();
        Content Get(int id);
        bool Insert(Content entity);
        bool Change(Content entity);
        bool Remove(int id);
    }
}
