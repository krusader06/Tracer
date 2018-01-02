using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Default
{
    public partial class ucDefaultMenu : UserControl
    {
        //Event Handlers--------------------------------------------------------------
        public static event EventHandler ExitButtonClicked;

        //On Load Stuff--------------------------------------------------------------
        private static ucDefaultMenu _instance;
        public static ucDefaultMenu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucDefaultMenu();
                return _instance;
            }
        }

        public ucDefaultMenu()
        {
            InitializeComponent();
        }

        //Button Event Handlers--------------------------------------------------------------

        private void onExitButtonClick()
        {
            if (ExitButtonClicked != null)
            {
                ExitButtonClicked(this, EventArgs.Empty);
            }
        }

        //Physical Button Events--------------------------------------------------------------

        private void btnExit_Click(object sender, EventArgs e)
        {
            onExitButtonClick();
        }
    }
}
