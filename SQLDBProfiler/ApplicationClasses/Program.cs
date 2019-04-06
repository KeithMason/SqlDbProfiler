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
            bool result;
            var mutex = new System.Threading.Mutex(true, "MasonsoftSqlDbProfiler", out result);

            if (!result)
            {
                MessageBox.Show(
                    "Another instance of SQL DB Profiler\nis already running.", 
                    "SQL DB Profiler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SqlDbProfiler());

            GC.KeepAlive(mutex);
        }
    }
}
