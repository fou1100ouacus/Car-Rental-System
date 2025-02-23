using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental
{
    public partial class ucBookingAndRetrun : UserControl
    {
        public ucBookingAndRetrun()
        {
            InitializeComponent();
        }
        public int? BookingID => ucBookingInfo1.BookingID;
        public int? ReturnID => unRetrunVechile1.ReturnID;

        public clsBooking BookingInfo => ucBookingInfo1.BookingInfo;
        public clsReturn ReturnInfo => unRetrunVechile1.ReturnInfo;
        public void LoadBookingAndReturnInfo(int? BookingID, int? ReturnID)
        {
            ucBookingInfo1.LoadBookingInfo(BookingID);
            unRetrunVechile1.LoadReturnInfo(ReturnID);
        }

        public void Clear()
        {
            ucBookingInfo1.Reset();
            unRetrunVechile1.Reset();
        }

        private void ucBookingInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
