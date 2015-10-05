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
            } while (cmdValues == ComandValues.Faulty);
        }
        
        private void CrudeControl(ComandValues cmdValues)
        {
            ComandValues cmdValuesOption;
            do
            {
                startView.ShowCrudeOption(cmdValues);
                cmdValuesOption = startView.GetKeyPressed();
                switch (cmdValuesOption)
                {
                case ComandValues.Add:
                    Console.Clear();
                    AddFunctionality(cmdValues);
                    break;
                case ComandValues.Get:
                    Console.Clear();
                    break;
                case ComandValues.Update:
                    Console.Clear();
                    break;
                case ComandValues.Delete:
                    Console.Clear();
                    break;
                case ComandValues.Quit:
                    return;
                default:
                    cmdValuesOption = ComandValues.Faulty;
                    Console.Clear();
                    startView.AskNewInput();
                    break;
                }
            } while (cmdValuesOption == ComandValues.Faulty);
        }
        private void AddFunctionality(ComandValues cmdValues)
        {
            bool isSaved;
            do
            {
                User newUser;
                newUser = startView.AddNew(cmdValues);

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
