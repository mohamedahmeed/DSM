using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.DAL;
using DSM.DTO;
using DSM.TABLES.Pepole;

namespace DSM.BLL.PEPOLE
{
    public class UserBLL
    {
        private readonly IRepository<User> userrepo;

        public UserBLL(IRepository<User> userrepo)
        {
            this.userrepo = userrepo;
        }

        #region get
        public resultDTO getusers()
        {
            resultDTO result = new resultDTO();
            result.data = new
            {                                                                      //??????
                users = userrepo.GetAllAsNoTracking().Where(p => p.IsActive && p.ID != userrepo.UserId).Select(p => new
                {
                    id = p.ID,
                    name = p.Name,
                })
            };
            return result;
        }
           
        public User getbyid(Guid id)
        {
            return userrepo.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }



        #endregion

        #region web

        public resultDTO saveuser(userDTO newUser)
        {
            resultDTO newresult = new resultDTO()
            {
                message = "error"

            };
            var user =userrepo.GetById(newUser.id);
            if(user == null)
            {
                user.Name = newUser.userName;
                user.ID = newUser.id;
                user.IsActive = newUser.isActive;
                user.CreatedDate = newUser.addedDate;
                user.Email = newUser.Email;

                userrepo.Insert(user);
                userrepo.SaveChange();
                resultDTO result = new resultDTO()
                {
                    message = "success"

                };
                return result;
            }
            return newresult;

        }

        #endregion

    }
}
