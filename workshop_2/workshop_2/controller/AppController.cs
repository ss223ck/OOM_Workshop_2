using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop_2.model;
using workshop_2.view;

namespace workshop_2.controller
{
    class AppController
    {
        public StartView StartView{ get; private set; }
        public CrudBLL CrudBLL{ get; private set; }
        public AppController(StartView strtView, CrudBLL crudBLL)
        {
            StartView = strtView;
            CrudBLL = crudBLL;
        }

        public void startApplication()
        {
            ComandValues cmdValues;
            do
            {
                StartView.StartOptions();
                cmdValues = StartView.GetKeyPressed();
                switch (cmdValues)
                {
                    case ComandValues.Member:
                        Console.Clear();
                        CrudeControl(cmdValues);
                        break;
                    case ComandValues.Boat:
                        Console.Clear();
                        CrudeControl(cmdValues);
                        break;
                    case ComandValues.Quit:
                        return;
                    default:
                        cmdValues = ComandValues.Faulty;
                        Console.Clear();
                        StartView.AskNewInput();
                        break;
                }
            } while (cmdValues != ComandValues.Quit);
        }
        
        private void CrudeControl(ComandValues cmdValues)
        {
            ComandValues cmdValuesOption;
            do
            {
                StartView.ShowCrudeOption(cmdValues);
                cmdValuesOption = StartView.GetKeyPressed();

                Console.Clear();
                switch (cmdValuesOption)
                {
                    case ComandValues.Add:
                        if(cmdValues == ComandValues.Member)
                        {
                            AddFunctionalityMember(cmdValues);
                        }
                        else
                        {
                            AddFunctionalityBoat(cmdValues);
                        }
                        break;
                    case ComandValues.Get:
                        if (cmdValues == ComandValues.Member)
                        {
                            GetFunctionalityMember();
                        }
                        else
                        {
                            GetFunctionalityBoat();
                        }
                        break;
                    case ComandValues.Update:
                        if (cmdValues == ComandValues.Member)
                        {
                            UpdateMember();
                        }
                        else
                        {
                            UpdateBoat();
                        }
                        break;
                    case ComandValues.Delete:
                        if (cmdValues == ComandValues.Member)
                        {
                            DeleteMember();
                        }
                        else
                        {
                            DeleteBoat();
                        }
                        break;
                    case ComandValues.Quit:
                        return;
                    default:
                        cmdValuesOption = ComandValues.Faulty;
                        StartView.AskNewInput();
                        break;
                }
            } while (cmdValuesOption == ComandValues.Faulty);
        }

        private void DeleteBoat()
        {
            bool testIfDelete;
            do
            {
                testIfDelete = CrudBLL.DeleteBoat(StartView.DeleteBoat());
                if (testIfDelete)
                {
                    StartView.DeleteBoatSuccess();
                    return;
                }
                else
                {
                    StartView.DeleteBoatFail();
                }
            } while (!testIfDelete);
        }

        private void DeleteMember()
        {
            bool testIfDelete;
            do
            {
                testIfDelete = CrudBLL.DeleteMember(StartView.DeleteMember()); 
                if(testIfDelete)
                {
                    StartView.DeleteMemberSuccess();
                    return;
                }
                else
                {
                    StartView.DeleteMemberFailed();
                }
            } while (!testIfDelete);
        }

        private void UpdateBoat()
        {
            
            bool testIfExists;
            do
            {
                Boat boat = StartView.UpdateBoat(new Boat());
                List<Boat> boatList = CrudBLL.GetBoats();

                testIfExists = boatList.Any(x => x.BoatID == boat.BoatID);
                if (testIfExists)
                {
                    CrudBLL.UpdateBoat(boat);
                }
                else
                {
                    StartView.WrongBoatInput();
                }
            } while (!testIfExists);
        }

        private void UpdateMember()
        {
            bool testIfExists;
            do
            {
                int userPersonalNumber = StartView.UpdateMember();
                List<User> UserList = CrudBLL.GetMembers();

                testIfExists = UserList.Any(x => x.PersonalNumber == userPersonalNumber);
                User user = StartView.ChangeMember(new User());
                user.PersonalNumber = userPersonalNumber;
                if(testIfExists)
                {
                    CrudBLL.UpdateMember(user, userPersonalNumber);

                }
                else
                {
                    StartView.WrongMemberInput();
                }
            } while (!testIfExists);
        }

        private void GetFunctionalityBoat()
        {
            List<Boat> boatlist = CrudBLL.GetBoats();
            StartView.ShowBoats(boatlist);
        }

        private void GetFunctionalityMember()
        {
            ComandValues cmdValues;
            do
            {
                StartView.ShowGetOptions();
                cmdValues = StartView.GetKeyPressed();
                if(cmdValues == ComandValues.CompactList || cmdValues == ComandValues.VerboseList)
                {
                    StartView.ShowMembersList(CrudBLL.GetMembersAndBoats(), cmdValues);
                }
                else if(cmdValues == ComandValues.Specific)
                {
                    StartView.ShowSpecificMember(CrudBLL.GetMembersAndBoats());
                }
                else
                {
                    cmdValues = ComandValues.Faulty;
                    StartView.AskNewInput();
                }
            } while (cmdValues == ComandValues.Faulty);
        }

        private void AddFunctionalityBoat(ComandValues cmdValues)
        {
            bool isSaved;
            do
            {
                Boat newBoat;
                newBoat = StartView.AddNewBoat(new Boat());

                isSaved = CrudBLL.SaveBoat(newBoat);

                if (isSaved)
                {
                    StartView.SuccessMessage(cmdValues);
                    return;
                }
                else
                {
                    StartView.ErrorAddingBoat();
                }
            } while (isSaved == false);
        }
        private void AddFunctionalityMember(ComandValues cmdValues)
        {
            bool isSaved;
            do
            {
                User newUser;

                newUser = StartView.AddNewMember(new User());

                isSaved = CrudBLL.SaveMember(newUser);

                if (isSaved)
                {
                    StartView.SuccessMessage(cmdValues);
                    return;
                }
                else
                {
                    StartView.ErrorAddingMember();
                } 
            } while (isSaved == false);
            
        }
    }
}
