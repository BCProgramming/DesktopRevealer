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
        NotifyIcon ni = null;
        ContextMenuStrip niMenu = null;
        private void frmShowDesktop_Load(object sender, EventArgs e)
        {
            Invalidate();
            Refresh();
            ni = new NotifyIcon();
            ni.Icon = this.Icon;
            ni.Text = "Show Desktop Utility";
            niMenu = new ContextMenuStrip();
            niMenu.Renderer = new ToolStripProfessionalRenderer();
            ToolStripMenuItem tsItem = new ToolStripMenuItem("E&xit");
            tsItem.Click += TsItemExit_Click;
            niMenu.Items.Add(tsItem);
            ni.ContextMenuStrip = niMenu;
            ni.Visible = true;
            
        }

        private void TsItemExit_Click(object sender, EventArgs e)
        {
            ni.Dispose();
            Application.Exit();
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
