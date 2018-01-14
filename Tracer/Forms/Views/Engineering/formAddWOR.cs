using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Engineering
{
    public partial class formAddWOR : Form
    {

        public formAddWOR()
        {
            InitializeComponent();
        }

        private void formAddWOR_Load(object sender, EventArgs e)
        {
            txtWORLot.Text = ucPerformEngineeringTask.WORText + "/" + ucPerformEngineeringTask.LotText;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Create a new db connection
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

            //Set WORLotReleased = True
            db.releaseWorkOrder(ucPerformEngineeringTask.WORText, ucPerformEngineeringTask.LotText);

            if (ckParts.Checked == true)
            {
                //Set PartsRequired
                db.setPartsRequired(ucPerformEngineeringTask.WORText, ucPerformEngineeringTask.LotText);
            }

            if (ckPCBs.Checked == true)
            {
                //Set PCBRequired
                db.setPCBRequired(ucPerformEngineeringTask.WORText, ucPerformEngineeringTask.LotText);
            }
            
            if (ckStencils.Checked == true)
            {
                //Set StencilsRequired
                db.setStencilsRequired(ucPerformEngineeringTask.WORText, ucPerformEngineeringTask.LotText);
            }

            this.Close();
        }
    }
}
