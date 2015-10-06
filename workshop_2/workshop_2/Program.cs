using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop_2.controller;
using workshop_2.model.DAL;
using workshop_2.view;

namespace workshop_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StartView strtView = new StartView();
            AppController appCont = new AppController(strtView);

            try
            {
                appCont.startApplication();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
