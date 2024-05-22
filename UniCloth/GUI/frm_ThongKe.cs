using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class frm_ThongKe : Form
    {
        List<CTHD_DTO> lstDT;
        public frm_ThongKe()
        {
            InitializeComponent();
        }
        public void fillChart()
        {
            DataTable dt = CTHD_BUS.ThongKe_DT_Thang_BUS();
            chart1.DataSource = dt;
            chart1.Series.Clear();
            Series series = new Series("Doanh thu");
            foreach (DataRow row in dt.Rows)
            {
                int month = Convert.ToInt32(row["Tháng"]);
                decimal totalRevenue = Convert.ToDecimal(row["Tổng doanh thu"]);
                series.Points.AddXY(month, totalRevenue);
            }

            chart1.Series.Add(series);
        }

        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            fillChart();
        }
    }
}
