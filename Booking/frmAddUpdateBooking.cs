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
    public partial class frmAddUpdateBooking : Form
    {
        private int? _SelectedCustomerID;
        private int? _SelectedVehicleID;
        private int? _TransactionID;

        public frmAddUpdateBooking()
        {
            InitializeComponent();
        }
        public Action<int?> GetBookingIDByDelegate;

        private void btnBook_Click(object sender, EventArgs e)
        {
            clsTransaction Transaction = new clsTransaction();


            Transaction.CustomerID = ucCustomerCardWithFilter1.CustomerID;
            Transaction.VehicleID = ucVechicleCardWithFilter1.VechicleID;
            Transaction.RentalStartDate = dtpStartDate.Value;
            Transaction.RentalEndDate = dtpEndDate.Value;
            Transaction.PickupLocation = txtPickUpLocation.Text.Trim();
            Transaction.DropoffLocation = txtDropOffLocation.Text.Trim();
            Transaction.RentalPricePerDay = ucVechicleCardWithFilter1.SelectedVehicleInfo.RentalPricePerDay;
            Transaction.InitialCheckNotes = txtInitailCheckNotes.Text.Trim();




            Transaction.PaidInitialTotalDueAmount = Convert.ToSingle(lblInitialTotalDueAmount.Text);
            Transaction.PaymentDetails = txtPaymentDetails.Text.Trim();


            if (!Transaction.Save())
            {
                MessageBox.Show("Vehicle Booked Failed", "Failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                //_Reset();

                return;
            }

            MessageBox.Show($"Vehicle Booked Successfully with Transaction ID = {Transaction.TransactionID.Value}", "Booked",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            _TransactionID = Transaction.TransactionID;

            lblBookingID.Text = Transaction.BookingID.Value.ToString();

    //        llTransactionInfo.Enabled = true;

    //        _Reset();

            GetBookingIDByDelegate?.Invoke(Transaction.BookingID.Value);

        }
        private void _LoadData()
        {
            dtpStartDate.MinDate = DateTime.Now;
            dtpEndDate.MinDate = DateTime.Now.AddDays(10); 

            int InitialDays = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days;
            lblInitialRentalDays.Text = InitialDays.ToString();
        }
        private void frmAddUpdateBooking_Load(object sender, EventArgs e)
        {
            _LoadData();
            ucCustomerCardWithFilter1.SendCustomerID += _FillBookingDetailsOnSelectedCustomer;
            ucVechicleCardWithFilter1.SendVehicleID += _FillBookingDetailsOnSelectedVehicle;


        }

        private void _FillBookingDetailsOnSelectedCustomer(int? CustomerID)
        {
            clsCustomer Customer = clsCustomer.Find(CustomerID);

            if (Customer == null)
            {
                lblCustomerID.Text = "[????]";
                btnBook.Enabled = false;

                return;
            }

            lblCustomerID.Text = Customer.CustomerID.ToString();

            if (ucVechicleCardWithFilter1.VechicleID.HasValue)
            {
                // here I already choose the vehicle, so I enable the btnBook
                btnBook.Enabled = true;
            }
        }

        private void _FillBookingDetailsOnSelectedVehicle(int? VehicleID)
        {
            clsVehicle Vehicle = clsVehicle.Find(VehicleID);

            if (Vehicle == null)
            {
                btnBook.Enabled = false;
                return;
            }

            lblVehicleID.Text = Vehicle.VehicleID.ToString();
            lblRentalPricePerDay.Text = Vehicle.RentalPricePerDay.ToString("N");
            lblInitialTotalDueAmount.Text = ((Vehicle.RentalPricePerDay) * (int.Parse(lblInitialRentalDays.Text))).ToString("N");

            btnBook.Enabled = true;
        }

        private void ucCustomerCardWithFilter1_OnCustomerSelected(object sender, ucCustomerCardWithFilter.CustomerSelectedEventArgs e)
        {
            _SelectedCustomerID = e.CustomerID;

            if (!_SelectedCustomerID.HasValue)
            {
                //btnNext.Enabled = false;

                ucCustomerCardWithFilter1.SendCustomerID?.Invoke(null);
                return;
            }

          //  btnNext.Enabled = true;
          ucCustomerCardWithFilter1.SendCustomerID?.Invoke(ucCustomerCardWithFilter1.CustomerID);
        }

        private void ucVechicleCardWithFilter1_OnVehicleSelected(object sender, ucVechicleCardWithFilter.vechicleSelectedEventArgs e)
        {
            _SelectedVehicleID = e.VehicleID;

            if (!_SelectedVehicleID.HasValue)
            {
              //  SendVehicleID?.Invoke(null); // to disable btnBook in the frmAddBooking
                return;
            }

            if (!ucVechicleCardWithFilter1.SelectedVehicleInfo.IsAvailableForRent)
            {
                MessageBox.Show("This car in NOT available for rent now!", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

               ucVechicleCardWithFilter1.SendVehicleID?.Invoke(null); // to disable btnBook in the frmAddBooking
                return;
            }
            ucVechicleCardWithFilter1. SendVehicleID?.Invoke(ucVechicleCardWithFilter1.VechicleID);
        }
    }
}
