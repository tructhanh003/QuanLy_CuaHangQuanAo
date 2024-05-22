using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_ReportSP : Form
    {
        public frm_ReportSP()
        {
            InitializeComponent();
        }

        private void frm_ReportSP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyShopQuanAoDataSet.khohang1' table. You can move, or remove it, as needed.
            this.khohang1TableAdapter.Fill(this.quanLyShopQuanAoDataSet.khohang1);
            // TODO: This line of code loads data into the 'quanLyShopQuanAoDataSet.ThongTin_Kho' table. You can move, or remove it, as needed.


            this.reportSP.RefreshReport();
        }
    }
}
