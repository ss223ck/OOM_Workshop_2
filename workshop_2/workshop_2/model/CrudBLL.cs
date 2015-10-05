using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop_2.model.DAL;

namespace workshop_2.model
{
    class CrudBLL
    {

        public bool SaveMember(User user)
        {
            UserDAL usrDAL = new UserDAL();
            List<User> userlist = usrDAL.GetUsers();
            if (userlist.Exists(x => x.PersonalNumber == user.PersonalNumber))
            {
                return false;
            }
            else
            {
                usrDAL.AddMember(user);
                return true;
            }
        }
    }
}
