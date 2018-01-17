﻿using System;
using System.Windows.Forms;
using HTTTDN_Code;
using System.Collections.Generic;

namespace HTTTDN_Code
{
    static class Program
    {   
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new Login());
        }
    }
}