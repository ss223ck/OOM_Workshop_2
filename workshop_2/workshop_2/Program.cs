using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop_2.model.DAL;

namespace workshop_2
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDAL usrdal = new UserDAL();
            usrdal.GetUsers();
        }
    }
}
