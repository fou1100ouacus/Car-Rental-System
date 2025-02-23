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
    public partial class ucCustomerCard : UserControl
    {
        public ucCustomerCard()
        {
            InitializeComponent();
        }
        private int? _CustomerID = null;
        private clsCustomer _CustomerDetails;

        public int? CustomerID => _CustomerID;
        public clsCustomer CustomerInfo => _CustomerDetails;



        public void Reset()
        {
            _CustomerID = null;
            _CustomerDetails = null;

            ucPersonCard1.Reset();

            lblCustomerID.Text = "[????]";
            lblDriverLicenseNumber.Text = "[????]";

            llEditCustomerInfo.Enabled = false;
        }

        private void _FillCustomerInfo()
        {
            llEditCustomerInfo.Enabled = true;

           ucPersonCard1.LoadPersonInfo(_CustomerDetails.PersonID);

            lblCustomerID.Text = _CustomerDetails.CustomerID.ToString();
            lblDriverLicenseNumber.Text = _CustomerDetails.DriverLicenseNumber;
        }

        public void LoadCustomerInfo(int? CustomerID)
        {
            _CustomerID = CustomerID;

            if (!_CustomerID.HasValue)
            {
                MessageBox.Show("There is no customer", "Missing Customer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _CustomerDetails = clsCustomer.Find(_CustomerID);// FILL

            if (_CustomerDetails == null)
            {
                MessageBox.Show($"There is no customer with id = {CustomerID}", "Missing Customer",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }
          //  ucPersonCard1.LoadPersonInfo(_CustomerDetails.PersonID);
            _FillCustomerInfo();
        }

        private void ucCustomerCard_Load(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void llEditCustomerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateCustomer EditCustomer = new frmAddUpdateCustomer(_CustomerID);
            EditCustomer.GetCustomerIDByDelegate += LoadCustomerInfo;
            EditCustomer.ShowDialog();
        }
    }
}
