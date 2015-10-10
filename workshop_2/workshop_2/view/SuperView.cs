using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop_2.view
{
    enum ComandValues { Quit, Faulty, Boat, Member, Get, Update, Add, Delete, CompactList, VerboseList, Specific};
    abstract class SuperView
    {
        const char quitKey = 'q';

        const char memberKey= 'm';

        const char boatKey = 'b';

        const char getKey = 'g';

        const char updatetKey = 'u';

        const char addKey = 'a';

        const char deleteKey = 'd';

        const char compactListKey = 'c';

        const char VerboseListKey = 'v';

        const char SpecificKey = 's';

        protected char GetQuitKey { get { return quitKey; } }

        protected char GetMemberKey { get { return memberKey; } }

        protected char GetBoatKey { get { return boatKey; } }

        protected char GetGetKey { get { return getKey; } }

        protected char GetUpdateKey { get { return updatetKey; } }

        protected char GetAddKey { get { return addKey; } }

        protected char GetDeleteKey { get { return deleteKey; } }

        protected char GetVerboseListKey { get { return VerboseListKey; } }

        protected char GetCompactListKey { get { return compactListKey; } }


        protected char GetSpecificKey { get { return SpecificKey; } }

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
                case compactListKey:
                    return ComandValues.CompactList;
                case VerboseListKey:
                    return ComandValues.VerboseList;
                case SpecificKey:
                    return ComandValues.Specific;
                default:
                    return ComandValues.Faulty;

            }
        }
    }
}
