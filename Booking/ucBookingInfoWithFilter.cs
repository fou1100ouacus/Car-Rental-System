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
    public partial class ucBookingInfoWithFilter : UserControl
    {
        public ucBookingInfoWithFilter()
        {
            InitializeComponent();
        }
        #region Declare Event
        public class BookingSelectedEventArgs : EventArgs
        {
            public int? BookingID { get; }

            public BookingSelectedEventArgs(int? BookingID)
            {
                this.BookingID = BookingID;
            }
        }

        public event EventHandler<BookingSelectedEventArgs> OnBookingSelected;

        public void RaiseOnBookingSelected(int? BookingID)
        {
            RaiseOnBookingSelected(new BookingSelectedEventArgs(BookingID));
        }

        protected virtual void RaiseOnBookingSelected(BookingSelectedEventArgs e)
        {
            OnBookingSelected?.Invoke(this, e);
        }
        #endregion







        private bool _ShowAddBookingButton = true;
        public bool ShowAddBookingButton
        {
            get => _ShowAddBookingButton;

            set
            {
                _ShowAddBookingButton = value;
                btnAddNew.Visible = _ShowAddBookingButton;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get => _FilterEnabled;

            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int? BookingID => ucBookingInfo1.BookingID;
        public clsBooking SelectedBookingInfo => ucBookingInfo1.BookingInfo;

        private void ucBookingInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
          
            frmAddUpdateBooking frm = new frmAddUpdateBooking();
            frm.Show();
        }
        public void LoadBookingInfo(int? BookingID)
        {
            txtFilterValue.Text = BookingID.ToString();
            ucBookingInfo1.LoadBookingInfo(BookingID);

            if (OnBookingSelected != null)
            {
                // Raise the event with a parameter
                RaiseOnBookingSelected(ucBookingInfo1.BookingID);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the Error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            LoadBookingInfo(int.Parse(txtFilterValue.Text.Trim()));

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            // to make sure that the user can enter only numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }
    }
}
