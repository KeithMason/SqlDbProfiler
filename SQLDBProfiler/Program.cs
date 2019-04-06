// ----------------------------------------------------------------------
// <copyright file="Program.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Program starting point for the application
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
