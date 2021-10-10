using Case.BusinessLogic.Abstract;
using Case.DataAccess.Abstract.EntityFramework;
using Case.Etity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.BusinessLogic.Concrete
{
    public class UserManager : IUserManager
    {
        IUserRepository _repository;

        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }

        public string Add(User entity)
        {
            bool result = _repository.Insert(entity);

            return result ? "success": "failure" ;
        }

        public string Delete(int id)
        {
            bool result = _repository.Remove(id);

            return result ? "success" : "failure";
        }

        public List<User> GetAll(int page = 1, int pageSize = 0)
        {
            List<User> result = _repository.GetList();

            return result;
        }

        public User GetById(int id)
        {
            User result = _repository.Get(id);

            return result;
        }

        public User Login(User entity)
        {
            User user =_repository.Login(entity);

            return user;
        }

        public string Update(User entity)
        {
            bool result = _repository.Change(entity);

            return result ? "success" : "failure";
        }
    }

    public class ContentManager : IContentManager
    {
        IContentRepository _repository;

        public ContentManager(IContentRepository repository)
        {
            _repository = repository;
        }

        public string Add(Content entity)
        {
            bool result = _repository.Insert(entity);

            return result ? "success" : "failure";
        }

        public string Delete(int id)
        {
            bool result = _repository.Remove(id);

            return result ? "success" : "failure";
        }

        public List<Content> GetAll(int page = 1, int pageSize = 0)
        {
            List<Content> result = _repository.GetList();

            return result;
        }

        public Content GetById(int Id)
        {
            Content result = _repository.Get(Id);

            return result;
        }

        public string Update(Content entity)
        {
            bool result = _repository.Change(entity);

            return result ? "success" : "failure";
        }
    }
}
