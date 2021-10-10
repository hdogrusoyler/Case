using Case.Core.DataAccess;
using Case.DataAccess.Abstract.EntityFramework;
using Case.Etity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.DataAccess.Concrete.EntityFramework
{
    public class EfUserRepository : BaseRepository<User, DataContext>, IUserRepository
    {
        private static List<User> userList = new List<User>();
        private static int id = 0;

        public EfUserRepository()
        {
            
        }

        public EfUserRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public bool Change(User entity)
        {
            bool result = false;

            try
            {
                if (entity != null && entity.Id > 0)
                {
                    User user = userList.FirstOrDefault(x => x.Id == entity.Id);

                    if (user != null)
                    {
                        user.Name = entity.Name;
                        user.Password = entity.Password;
                        user.Role = entity.Role;

                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public User Get(int Id)
        {
            User user = new User();

            if (Id > 0)
            {
                user = userList.Where(x => x.Id == Id).FirstOrDefault();
            }

            return user;
        }

        public List<User> GetList()
        {
            return userList;
        }

        public bool Insert(User entity)
        {
            bool result = false;

            try
            {
                if (entity != null && entity.Id == 0)
                {
                    entity.Id = ++id;

                    userList.Add(entity);

                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public User Login(User user)
        {
            User loginUser = userList.Where(x => x.Name == user.Name && x.Password == user.Password).FirstOrDefault();

            return loginUser;
        }

        public bool Remove(int Id)
        {
            bool result = false;

            try
            {
                if (Id > 0)
                {
                    User user = userList.FirstOrDefault(x => x.Id == Id);

                    if (user != null)
                    {
                        userList.Remove(user);

                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
    }

    public class EfContentRepository : BaseRepository<Content, DataContext>, IContentRepository
    {
        private static List<Content> contentList = new List<Content>();
        private static int id = 0;

        public EfContentRepository()
        {

        }

        public EfContentRepository(DataContext dbContext) : base(dbContext)
        {

        }

        public bool Change(Content entity)
        {
            bool result = false;

            try
            {
                if (entity != null && entity.Id > 0)
                {
                    Content content = contentList.Where(x => x.Id == entity.Id).FirstOrDefault();

                    if (content != null)
                    {
                        content = entity;

                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public Content Get(int id)
        {
            Content user = new Content();

            if (id > 0)
            {
                user = contentList.Where(x => x.Id == id).FirstOrDefault();
            }

            return user;
        }

        public List<Content> GetList()
        {
            return contentList;
        }

        public bool Insert(Content entity)
        {
            bool result = false;

            try
            {
                if (entity != null && entity.Id == 0)
                {
                    entity.Id = ++id;

                    contentList.Add(entity);

                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public bool Remove(int id)
        {
            bool result = false;

            try
            {
                if (id > 0)
                {
                    Content content = contentList.Where(x => x.Id == id).FirstOrDefault();

                    if (content != null)
                    {
                        contentList.Remove(content);

                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
    }
}
