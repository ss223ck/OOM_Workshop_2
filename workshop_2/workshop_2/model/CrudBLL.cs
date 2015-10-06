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

        public bool SaveBoat(Boat newBoat)
        {
            UserDAL usrDAL = new UserDAL();
            List<User> userlist = usrDAL.GetUsers();
            if (userlist.Exists(x => x.PersonalNumber == newBoat.Personalnumber))
            {
                usrDAL.AddBoat(newBoat);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<MemberInformation> GetMembersAndBoats()
        {
            UserDAL usrDAL = new UserDAL();
            List<User> usrList = usrDAL.GetUsers();
            List<MemberInformation> memberAndBoats = new List<MemberInformation>(100);

            foreach(User user in usrList)
            {
                memberAndBoats.Add(new MemberInformation
                {
                    User = user,
                    BoatList = usrDAL.GetMembersBoats(user.PersonalNumber)
                });
            }
            memberAndBoats.TrimExcess();
            return memberAndBoats;
        }

        public List<Boat> GetBoats()
        {
            UserDAL usrDAL = new UserDAL();
            return usrDAL.GetBoats();
        }

        public List<User> GetMembers()
        {
            List<User> usrList;
            UserDAL usrDAL = new UserDAL();
            usrList = usrDAL.GetUsers();
            return usrList;
        }

        public void UpdateMember(User user, int userPersonalNumber)
        {
            UserDAL usrDAL = new UserDAL();
            usrDAL.UpdateMember(user, userPersonalNumber);
        }

        public void UpdateBoat(Boat boat)
        {
            UserDAL usrDAL = new UserDAL();
            usrDAL.UpdateBoat(boat);
        }

        public bool DeleteMember(int p)
        {
            UserDAL usrDAL = new UserDAL();
            List<User> usrList = usrDAL.GetUsers();
            if(usrList.Exists(x => x.PersonalNumber == p))
            {
                usrDAL.DeleteMember(p);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteBoat(int p)
        {
            UserDAL usrDAL = new UserDAL();
            List<Boat> boatList = usrDAL.GetBoats();
            if (boatList.Exists(x => x.BoatID == p))
            {
                usrDAL.DeleteBoat(p);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
