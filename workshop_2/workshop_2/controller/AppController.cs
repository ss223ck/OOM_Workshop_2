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
        public StartView startView{ get; private set; }
        public AppController(StartView strtView)
        {
            startView = strtView;
        }

        public void startApplication()
        {
            ComandValues cmdValues;
            do
            {
                startView.StartOptions();
                cmdValues = startView.GetKeyPressed();
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
                        startView.AskNewInput();
                        break;
                }
            } while (cmdValues != ComandValues.Quit);
        }
        
        private void CrudeControl(ComandValues cmdValues)
        {
            ComandValues cmdValuesOption;
            do
            {
                startView.ShowCrudeOption(cmdValues);
                cmdValuesOption = startView.GetKeyPressed();

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
                        startView.AskNewInput();
                        break;
                }
            } while (cmdValuesOption == ComandValues.Faulty);
        }

        private void DeleteBoat()
        {
            CrudBLL crudBLL = new CrudBLL();
            bool testIfDelete;
            do
            {
                testIfDelete = crudBLL.DeleteBoat(startView.DeleteBoat());
                if (testIfDelete)
                {
                    startView.DeleteBoatSuccess();
                    return;
                }
                else
                {
                    startView.DeleteBoatFail();
                }
            } while (!testIfDelete);
        }

        private void DeleteMember()
        {
            CrudBLL crudBLL = new CrudBLL();
            bool testIfDelete;
            do
            {
                testIfDelete = crudBLL.DeleteMember(startView.DeleteMember()); 
                if(testIfDelete)
                {
                    startView.DeleteMemberSuccess();
                    return;
                }
                else
                {
                    startView.DeleteMemberFailed();
                }
            } while (!testIfDelete);
        }

        private void UpdateBoat()
        {
            CrudBLL crudBLL = new CrudBLL();
            bool testIfExists;
            do
            {
                Boat boat = startView.UpdateBoat();
                List<Boat> boatList = crudBLL.GetBoats();

                testIfExists = boatList.Any(x => x.BoatID == boat.BoatID);
                if (testIfExists)
                {
                    crudBLL.UpdateBoat(boat);
                }
                else
                {
                    startView.WrongBoatInput();
                }
            } while (!testIfExists);
        }

        private void UpdateMember()
        {
            CrudBLL crudBLL = new CrudBLL();
            bool testIfExists;
            do
            {
                int userPersonalNumber = startView.UpdateMember();
                List<User> UserList = crudBLL.GetMembers();

                testIfExists = UserList.Any(x => x.PersonalNumber == userPersonalNumber);
                if(testIfExists)
                {
                    crudBLL.UpdateMember(startView.ChangeMember(), userPersonalNumber);
                }
                else
                {
                    startView.WrongMemberInput();
                }
            } while (!testIfExists);
        }

        private void GetFunctionalityBoat()
        {
            CrudBLL crudBLL = new CrudBLL();
            List<Boat> boatlist = crudBLL.GetBoats();
            startView.ShowBoats(boatlist);
        }

        private void GetFunctionalityMember()
        {
            startView.ShowGetOptions();
            ComandValues cmdValues;
            CrudBLL crudBLL = new CrudBLL();
            do
            {
                cmdValues = startView.GetKeyPressed();
                if(cmdValues == ComandValues.CompactList || cmdValues == ComandValues.VerboseList)
                {
                    startView.ShowMembersList(crudBLL.GetMembersAndBoats(), cmdValues);
                }
                else
                {
                    cmdValues = ComandValues.Faulty;
                    startView.AskNewInput();
                }
            } while (cmdValues == ComandValues.Faulty);
        }

        private void AddFunctionalityBoat(ComandValues cmdValues)
        {
            bool isSaved;
            do
            {
                Boat newBoat;
                newBoat = startView.AddNewBoat();

                CrudBLL crdBLL = new CrudBLL();
                isSaved = crdBLL.SaveBoat(newBoat);

                if (isSaved)
                {
                    startView.SuccessMessage(cmdValues);
                    return;
                }
                else
                {
                    startView.ErrorAddingBoat();
                }
            } while (isSaved == false);
        }
        private void AddFunctionalityMember(ComandValues cmdValues)
        {
            bool isSaved;
            do
            {
                User newUser;
                newUser = startView.AddNewMember();

                CrudBLL crdBLL = new CrudBLL();
                isSaved = crdBLL.SaveMember(newUser);

                if (isSaved)
                {
                    startView.SuccessMessage(cmdValues);
                    return;
                }
                else
                {
                    startView.ErrorAddingMember();
                } 
            } while (isSaved == false);
            
        }
    }
}
