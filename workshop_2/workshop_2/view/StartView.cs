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

        public User AddNewMember(User user)
        {
            bool test;
            do
            {
                Console.Write("State name: ");
                user.Name = Console.ReadLine();
                if (user.Name.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You must have atleast type one char");
                }
            } while (user.Name.Length == 0);
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
                    Console.WriteLine("Try to state a number again");
                }
            } while (test == false);

            return user;
        }

        public void SuccessMessage(ComandValues cmdValues)
        {
            Console.Clear();
            Console.WriteLine(string.Format("You added a {0}", cmdValues));
        }

        public void ErrorAddingMember()
        {
            Console.WriteLine("There is already a person with that personal number");
        }

        public Boat AddNewBoat(Boat boat)
        {
            bool test;

            do
            {
                Console.Write("State boat type: ");
                boat.BoatType = Console.ReadLine();
                if (boat.BoatType.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You must state boat type");
                }
            } while (boat.BoatType.Length == 0);
            do
            {
                int n;
                Console.Write("State boat lenght: ");
                string s = Console.ReadLine();
                test = int.TryParse(s, out n);
                if (test)
                {
                    boat.BoatLenght = n;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Try to state a number again");
                }
            } while (test == false);
            do
            {
                int n;
                Console.Write("State personal number: ");
                string s = Console.ReadLine();
                test = int.TryParse(s, out n);
                if (test)
                {
                    boat.Personalnumber = n;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Try to state a number again");
                }
            } while (test == false);

            return boat;
        }

        public void ErrorAddingBoat()
        {
            Console.WriteLine("There is no member with that personal number");
        }

        public void ShowGetOptions()
        {
            Console.WriteLine(string.Format("Press {0} for compact list or {1} för verbose list or {2} for specific member", GetCompactListKey, GetVerboseListKey, GetSpecificKey));
        }

        public void ShowMembersList(List<MemberInformation> list, ComandValues cmdValues)
        {
            foreach (MemberInformation mbmInfo in list)
            {
                Console.WriteLine("");
                Console.WriteLine(string.Format("{0} , {1}, Boats: ", mbmInfo.User.Name, mbmInfo.User.PersonalNumber));

                if (cmdValues == ComandValues.VerboseList)
                {
                    foreach (Boat boat in mbmInfo.BoatList)
                    {
                        Console.WriteLine(string.Format("Type: {0}", boat.BoatType));
                        Console.WriteLine(string.Format("Lenght: {0}", boat.BoatLenght));
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine(mbmInfo.BoatList.Count);
                }
            }
            Console.WriteLine("");
        }

        public void ShowBoats(List<Boat> boatlist)
        {
            foreach (Boat boat in boatlist)
            {
                Console.WriteLine("");
                Console.WriteLine(string.Format("Boat ID:{0}", boat.BoatID));
                Console.WriteLine(string.Format("Boat Type:{0}", boat.BoatType));
                Console.WriteLine(string.Format("Boat Lenght:{0}", boat.BoatLenght));
                Console.WriteLine(string.Format("Belongs to ID:{0}", boat.Personalnumber));
                Console.WriteLine("");
            }
        }

        public int UpdateMember()
        {
            bool testValue = false;
            int inputValue;

            do
            {
                Console.Write("State your personalnumber: ");
                string inputString = Console.ReadLine();

                testValue = int.TryParse(inputString, out inputValue);

            } while (!testValue);
            return inputValue;
        }

        public User ChangeMember(User user)
        {
            Console.WriteLine("Change member info");
            do
            {
                Console.Write("State name:");
                user.Name = Console.ReadLine();
                if (user.Name == "" || user.Name == null)
                {
                    Console.Clear();
                    Console.WriteLine("Try state a name again");
                }
            } while (user.Name == "" || user.Name == null);
            do
            {
                Console.Write("State personal number:");
                string userNumber = Console.ReadLine();
                int parsedNumber;
                int.TryParse(userNumber, out parsedNumber);
                if (parsedNumber == 0 )
                {
                    Console.Clear();
                    Console.WriteLine("Try state a number again");
                }
                else
                {
                    user.PersonalNumber = parsedNumber;
                }
            } while (user.Name == "" || user.Name == null);
            return user;
        }

        public void WrongMemberInput()
        {
            Console.Clear();
            Console.WriteLine("The Personal key you stated didnt belong to any User.");
        }
        public void WrongBoatInput()
        {
            Console.Clear();
            Console.WriteLine("The boatID you stated didnt belong to any boat.");
        }

        public Boat UpdateBoat(Boat boat)
        {
            Console.WriteLine("Change boat info");

            do
            {
                Console.Write("State boatID:");
                string boatID = Console.ReadLine();
                int parsedNumber;
                int.TryParse(boatID, out parsedNumber);
                if (parsedNumber == 0 )
                {
                    Console.Clear();
                    Console.WriteLine("Try state a number again");
                }
                else
                {
                    boat.BoatID = parsedNumber;
                }
            } while (boat.BoatID == 0 );
            do
            {
                Console.Write("State boat personalnumber:");
                string personalNumber = Console.ReadLine();
                int parsedNumber;
                int.TryParse(personalNumber, out parsedNumber);
                if (parsedNumber == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Try state a number again");
                }
                else
                {
                    boat.Personalnumber = parsedNumber;
                }
            } while (boat.BoatID == 0);
            do
            {
                Console.Write("State boat type:");
                boat.BoatType = Console.ReadLine();
                if (boat.BoatType == "" || boat.BoatType == null)
                {
                    Console.Clear();
                    Console.WriteLine("Try state a boat type again");
                }
            } while (boat.BoatType == "" || boat.BoatType == null);
            do
            {
                Console.Write("State boat lenght:");
                string boatID = Console.ReadLine();
                int parsedNumber;
                int.TryParse(boatID, out parsedNumber);
                if (parsedNumber == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Try state a number again");
                }
                else
                {
                    boat.BoatLenght = parsedNumber;
                }
            } while (boat.BoatID == 0);
            return boat;
        }

        public int DeleteMember()
        {
            bool testNumber;
            int parsedNumber;

            do
            {
                Console.WriteLine("State personal number: ");
                string personalNumber = Console.ReadLine();

                testNumber = int.TryParse(personalNumber, out parsedNumber);
                if (testNumber)
                {
                    return parsedNumber;
                }
            } while (!testNumber);
            return parsedNumber;
        }
        public int DeleteBoat()
        {
            bool testNumber;
            int parsedNumber;

            do
            {
                Console.WriteLine("State boat id: ");
                string boatID = Console.ReadLine();

                testNumber = int.TryParse(boatID, out parsedNumber);
                if (testNumber)
                {
                    return parsedNumber;
                }
            } while (!testNumber);
            return parsedNumber;
        }

        internal void DeleteMemberSuccess()
        {
            Console.Clear();
            Console.WriteLine("Succesfully deleted member");
        }

        internal void DeleteMemberFailed()
        {
            Console.Clear();
            Console.WriteLine("Couldnt delete member");
        }

        internal void DeleteBoatSuccess()
        {
            Console.Clear();
            Console.WriteLine("Succesfully deleted boat");
        }

        internal void DeleteBoatFail()
        {
            Console.Clear();
            Console.WriteLine("Couldnt deleted boat");
        }

        public void ShowSpecificMember(List<MemberInformation> memberAndBoatList)
        {
            bool testIfCanConvert;
            do
            {
                Console.Clear();
                Console.Write("State personal number: ");
                string userPersonalNumber = Console.ReadLine();
                int convertedPersonalNumber;
                testIfCanConvert = int.TryParse(userPersonalNumber, out convertedPersonalNumber);
                if (testIfCanConvert)
                {
                    if (memberAndBoatList.Any(x => x.User.PersonalNumber == convertedPersonalNumber))
                    {
                        Console.WriteLine(string.Format("MemberID: {0}", memberAndBoatList.Find(x => x.User.PersonalNumber == convertedPersonalNumber).User.MemberID));
                        Console.WriteLine(string.Format("Name: {0}", memberAndBoatList.Find(x => x.User.PersonalNumber == convertedPersonalNumber).User.Name));
                        Console.WriteLine(string.Format("Personal number: {0}", memberAndBoatList.Find(x => x.User.PersonalNumber == convertedPersonalNumber).User.PersonalNumber));
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("State a personal number with only numbers");
                }
            } while (!testIfCanConvert);
        }
    }
}
