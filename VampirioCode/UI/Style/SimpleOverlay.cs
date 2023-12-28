using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Style
{
    public class SimpleOverlay : Form
    {
        public static bool ENABLE = true;

        private static List<SimpleOverlay> OVERLAYS;

        public static void showFX(ContainerControl applyTo)
        {
            if (!ENABLE)
                return;

            if (OVERLAYS == null)
                OVERLAYS = new List<SimpleOverlay>();

            if (applyTo == null)
                OVERLAYS.Add(null);
            else
                OVERLAYS.Add(new SimpleOverlay(applyTo));
        }

        public static void hideFX()
        {
            if (OVERLAYS == null)
                return;

            if (OVERLAYS.Count <= 0)
                return;

            if (OVERLAYS[OVERLAYS.Count - 1] != null)
                OVERLAYS[OVERLAYS.Count - 1].Close();
            OVERLAYS.RemoveAt(OVERLAYS.Count - 1);
        }

        private SimpleOverlay(ContainerControl tocover)
        {
            this.BackColor = Color.Black;
            this.Opacity = 0.50;      // Tweak as desired
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Location = tocover.PointToScreen(Point.Empty);
            this.ClientSize = tocover.ClientSize;
            tocover.LocationChanged += Cover_LocationChanged;
            tocover.ClientSizeChanged += Cover_ClientSizeChanged;
            this.Show(tocover);
            tocover.Focus();
            // Disable Aero transitions, the plexiglass gets too visible
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
        }
        private void Cover_LocationChanged(object sender, EventArgs e)
        {
            // Ensure the plexiglass follows the owner
            this.Location = this.Owner.PointToScreen(Point.Empty);
        }
        private void Cover_ClientSizeChanged(object sender, EventArgs e)
        {
            // Ensure the plexiglass keeps the owner covered
            this.ClientSize = this.Owner.ClientSize;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Restore owner
            this.Owner.LocationChanged -= Cover_LocationChanged;
            this.Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
            if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            base.OnFormClosing(e);
        }
        /*protected override void OnActivated(EventArgs e)
        {
            // Always keep the owner activated instead
            this.BeginInvoke(new Action(() => this.Owner.Activate()));
        }*/
        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);
    }
}
