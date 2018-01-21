using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Executive
{
    public partial class ucSuperHot : UserControl
    {
        //Holders for Selected Rows
        int quoteRow;

        //This is used to pass the WOR/Lot info to the Form
        public static string WORText;
        public static string LotText;

        //Quote Holder
        List<Classes.DatabaseTables.LotNumbers> activeLotNumbers = new List<Classes.DatabaseTables.LotNumbers>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucSuperHot _instance;
        public static ucSuperHot Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSuperHot();
                return _instance;
            }
        }

        public ucSuperHot()
        {
            InitializeComponent();
            ShowLotNumbers();
        }

        public void ShowLotNumbers()
        {   //Takes Care of Loading the DataGridView with all Active Quotes

            dgActiveWOR.DataSource = null;
            Classes.DataAccess.ExecutiveDataAccess db = new Classes.DataAccess.ExecutiveDataAccess();
            activeLotNumbers = db.GetLotNumbers();

            dgActiveWOR.DataSource = activeLotNumbers;

            dgActiveWOR.Columns["LotID"].Visible = false;
            dgActiveWOR.Columns["OrderQuantity"].Visible = false;
            dgActiveWOR.Columns["PartDescription"].Visible = false;
            dgActiveWOR.Columns["KitDueDate"].Visible = false;
            dgActiveWOR.Columns["MasterDueDate"].Visible = false;
            dgActiveWOR.Columns["TurnTime"].Visible = false;
            dgActiveWOR.Columns["Turnkey"].Visible = false;
            dgActiveWOR.Columns["Consigned"].Visible = false;
            dgActiveWOR.Columns["JobComments"].Visible = false;

            dgActiveWOR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgActiveWOR.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        //Physical Events-----------------------------------------------------------------------------------------------

        private void btnSet_Click(object sender, EventArgs e)
        {
            string message = "Are you setting a Super Hot Priority Level for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.ExecutiveDataAccess db = new Classes.DataAccess.ExecutiveDataAccess();

                //Set SuperHot = True
                db.setSuperHot(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Refresh
                ShowLotNumbers();

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string message = "Are you re-setting the Super Hot Priority Level for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + " / " + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.ExecutiveDataAccess db = new Classes.DataAccess.ExecutiveDataAccess();

                //Set SuperHot = True
                db.resetSuperHot(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Refresh
                ShowLotNumbers();

            }
        }

        private void dgActiveWOR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedLotRow = dgActiveWOR.Rows[e.RowIndex];

                quoteRow = e.RowIndex;

                btnSet.Enabled = true;
                btnReset.Enabled = true;
            }
        }
    }
}
