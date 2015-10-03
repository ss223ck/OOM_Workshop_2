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
            do
            {
                startView.StartOptions();
                if (startView.GetKeyPressed() == ComandValues.Member)
                {
                    Console.Clear();
                    MembersControl();
                }
                else if (startView.GetKeyPressed() == ComandValues.Boat)
                {
                    BoatControll();
                }
                else if (startView.GetKeyPressed() == ComandValues.Quit)
                {
                    return;
                }
                else
                {
                    startView.AskNewInput();
                }
            } while (startView.GetKeyPressed() == ComandValues.Faulty);
        }

        private void BoatControll()
        {
            throw new NotImplementedException();
        }

        private void MembersControl()
        {
            throw new NotImplementedException();
        }
    }
}
