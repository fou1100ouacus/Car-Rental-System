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
    public partial class ucSelectedBooking_CustomerVehicleCardWithFilter : UserControl
    {
        public ucSelectedBooking_CustomerVehicleCardWithFilter()
        {
            InitializeComponent();
        }
        private int? _SelectedCustomerID = null;
        private int? _SelectedVehicleID = null;

        public int? CustomerID => ucCustomerCardWithFilter1.CustomerID;
        public int? VehicleID => ucVechicleCardWithFilter1.VechicleID;

        public clsCustomer SelectedCustomerInfo => ucCustomerCardWithFilter1.SelectedCustomerInfo;
        public clsVehicle SelectedVehicleInfo => ucVechicleCardWithFilter1.SelectedVehicleInfo;

        private bool _FilterEnable = false;
        public bool FilterEnable
        {
            get => _FilterEnable;

            set
            {
                _FilterEnable = value;
                ucCustomerCardWithFilter1.FilterEnabled = value;
                ucVechicleCardWithFilter1.FilterEnabled = value;
            }
        }

        private void ucSelectedBooking_CustomerVehicleCardWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
