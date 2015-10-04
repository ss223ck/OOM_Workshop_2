using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        MembersControl();
                        break;
                    case ComandValues.Boat:
                        Console.Clear();
                        BoatControll();
                        break;
                    case ComandValues.Quit:
                        Console.Clear();
                        MembersControl();
                        break;
                    default:
                        cmdValues = ComandValues.Faulty;
                        Console.Clear();
                        startView.AskNewInput();
                        break;
                }
            } while (cmdValues == ComandValues.Faulty);
        }

        private void BoatControll()
        {
            throw new NotImplementedException();
        }

        private void MembersControl()
        {
            ComandValues cmdValues;
            do
            {
                startView.StartOptions();
                cmdValues = startView.GetKeyPressed();
                switch (cmdValues)
                {
                case ComandValues.Add:
                    Console.Clear();
                    MembersControl();
                    break;
                case ComandValues.Get:
                    Console.Clear();
                    BoatControll();
                    break;
                case ComandValues.Update:
                    Console.Clear();
                    MembersControl();
                    break;
                case ComandValues.Delete:
                    Console.Clear();
                    MembersControl();
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
    }
}
