using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop_2.view
{
    enum ComandValues { Quit, Faulty, Boat, Member, Get, Update, Add, Delete};
    abstract class SuperView
    {
        const char quitKey = 'q';

        const char memberKey= 'm';

        const char boatKey = 'b';

        const char getKey = 'g';

        const char updatetKey = 'u';

        const char addKey = 'a';

        const char deleteKey = 'd';

        protected char GetQuitKey { get { return quitKey; } }

        protected char GetMemberKey { get { return memberKey; } }

        protected char GetBoatKey { get { return boatKey; } }

        protected char GetGetKey { get { return getKey; } }

        protected char GetUpdateKey { get { return updatetKey; } }

        protected char GetAddKey { get { return addKey; } }

        protected char GetDeleteKey { get { return deleteKey; } }

        public ComandValues GetConvertedInput(ConsoleKeyInfo cki)
        {
            switch(cki.KeyChar)
            {
                case quitKey:
                    return ComandValues.Quit;
                case memberKey:
                    return ComandValues.Member;
                case boatKey:
                    return ComandValues.Boat;
                case getKey:
                    return ComandValues.Get;
                case updatetKey:
                    return ComandValues.Update;
                case addKey:
                    return ComandValues.Add;
                case deleteKey:
                    return ComandValues.Delete;
                default:
                    return ComandValues.Faulty;

            }
        }
    }
}
