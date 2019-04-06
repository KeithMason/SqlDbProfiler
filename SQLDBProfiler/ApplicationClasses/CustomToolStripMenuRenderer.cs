// ----------------------------------------------------------------------
// <copyright file="CustomToolStripMenuRenderer.cs" company="MasonSoft Technology Ltd">
//     Copyright. All right reserved
// </copyright>
// ----------------------------------------------------------------------
namespace SQLDBProfiler
{
    using System.Windows.Forms;

    /// <summary>
    /// Custom ToolStrip Menu Renderer
    /// </summary>
    public class CustomToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        /// <summary> On Render Menu Item Background
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        /// <summary> On Render Button Background
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
    }
}
