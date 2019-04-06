// ----------------------------------------------------------------------
// <copyright file="ListViewComponent.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Windows.Forms;

    /// <summary>
    /// List View
    /// </summary>
    public class ListViewComponent : ListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewComponent" /> class.
        /// </summary>
        public ListViewComponent()
        {
            //// Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //// Enable the OnNotifyMessage event so we get a chance to filter out 
            //// Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        /// <summary>
        /// Notifies the control of Windows messages.
        /// </summary>
        /// <param name="m">A <see cref="T:System.Windows.Forms.Message" /> that represents the Windows message.</param>
        protected override void OnNotifyMessage(Message m)
        {
            ////Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}