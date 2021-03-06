﻿using System;
using System.Threading;
using System.Windows.Forms;

using ErrorControlSystem;

namespace ErrorControlSystem.Examples.WinFormsDotNet2
{
    static class Program
    {
        private static IErrorHandlerAdapter iErrorHandler;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Type myClassAdapterType = Type.GetTypeFromProgID("ErrorControlSystemAdapter.ErrorHandlerAdapter");
            var myClassAdapterType = Type.GetTypeFromCLSID(new Guid("11BE9CF0-218D-45C6-A9AD-55C891F936F0"));
            var myClassAdapterInstance = Activator.CreateInstance(myClassAdapterType);
            iErrorHandler = (IErrorHandlerAdapter)myClassAdapterInstance;



            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Catch all unhandled exceptions.
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Catch all unhandled exceptions in all threads.
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Catch all handled exceptions in managed code, before the runtime searches the Call Stack 
            // AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            iErrorHandler.Raise(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString());
            iErrorHandler.Raise((Exception)e.ExceptionObject);
        }
    }
}
