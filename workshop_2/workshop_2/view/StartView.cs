using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop_2.model;

namespace workshop_2.view
{
    class StartView : SuperView
    {
        public void StartOptions()
        {
            Console.WriteLine(string.Format("Press '{0}' to handel members or press '{1}' to handle boats or '{2}' to quit", GetMemberKey, GetBoatKey, GetQuitKey));
        }

        public ComandValues GetKeyPressed()
        {
            return GetConvertedInput(Console.ReadKey());
        }
        public void AskNewInput()
        {
            Console.WriteLine("Try to press a correct key");
        }

        //cmd if the output should be members or boats
        public void ShowCrudeOption(ComandValues cmdValues)
        {
            Console.WriteLine(string.Format("Press '{0}' to get {4}s, '{1}' to add {4}, '{2}' to delete {4} or '{3}' to update {4}", GetGetKey, GetAddKey, GetDeleteKey, GetUpdateKey, cmdValues));
        }

        public User AddNew(ComandValues cmdValues)
        {
            bool test;
            User user = new User();
            Console.Write("State name: ");
            user.Name = Console.ReadLine();
            do
            {
                int n;
                Console.Write("State personal number: ");
                string s = Console.ReadLine();
                test = Int32.TryParse(s, out n);
                if (test)
                {
                    user.PersonalNumber = n;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Try to state a number again");
                }
            } while (test == false);

            return user;
        }

        public void SuccessMessage(ComandValues cmdValues)
        {
            Console.Write(string.Format("You added a {0}", cmdValues));
        }

        public void ErrorAddingMember()
        {
            Console.WriteLine("There is already a person with that personal number");
        }
    }
}
