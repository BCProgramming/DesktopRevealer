using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Show_Desktop
{
    public partial class frmShowDesktop : Form
    {
        [DllImport("user32.dll")]
        private static extern Int16 GetAsyncKeyState(int vKey);

        public frmShowDesktop()
        {
            InitializeComponent();
        }

        private void frmShowDesktop_Load(object sender, EventArgs e)
        {
            Invalidate();
            Refresh();
        }

        private void frmShowDesktop_Shown(object sender, EventArgs e)
        {
            Location = new Point(-10000, -10000); //we need it to be "visible" but don't want it to be seen...
        }
        bool Started = false;
        private void frmShowDesktop_Activated(object sender, EventArgs e)
        {
            if(!Started)
            {
                Started = true;
                return;
            }
            if (GetAsyncKeyState((int)Keys.ControlKey) != 0)
            {
                Application.Exit();
            }
            else
            {
                Shell32.ShellClass objShel = new Shell32.ShellClass();
                objShel.ToggleDesktop();
            }
        }
    }
}
