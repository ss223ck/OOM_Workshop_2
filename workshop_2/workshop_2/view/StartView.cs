using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ShowMemberOption()
        {
            Console.WriteLine(string.Format("Press '{0}' to get members, '{1}' to add member, '{2}' to delete member or '{3}' to update memeber", GetGetKey, GetAddKey, GetDeleteKey, GetUpdateKey));
        }
    }
}
