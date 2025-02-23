namespace Car_Rental
{
    partial class frmAddUpdateBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpCustomerDetails = new System.Windows.Forms.TabPage();
            this.ucCustomerCardWithFilter1 = new Car_Rental.ucCustomerCardWithFilter();
            this.tpVechicleDetails = new System.Windows.Forms.TabPage();
            this.ucVechicleCardWithFilter1 = new Car_Rental.ucVechicleCardWithFilter();
            this.tpBookingDetails = new System.Windows.Forms.TabPage();
            this.btnBook = new Guna.UI2.WinForms.Guna2Button();
            this.txtPickUpLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtInitailCheckNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPaymentDetails = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDropOffLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInitialRentalDays = new System.Windows.Forms.Label();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblInitialTotalDueAmount = new System.Windows.Forms.Label();
            this.lblRentalPricePerDay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVehicleID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.tpCustomerDetails.SuspendLayout();
            this.tpVechicleDetails.SuspendLayout();
            this.tpBookingDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.guna2TabControl1);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(983, 571);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Vechicle Booking";
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.tpCustomerDetails);
            this.guna2TabControl1.Controls.Add(this.tpVechicleDetails);
            this.guna2TabControl1.Controls.Add(this.tpBookingDetails);
            this.guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 40);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(983, 531);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tpCustomerDetails
            // 
            this.tpCustomerDetails.Controls.Add(this.ucCustomerCardWithFilter1);
            this.tpCustomerDetails.Location = new System.Drawing.Point(184, 4);
            this.tpCustomerDetails.Name = "tpCustomerDetails";
            this.tpCustomerDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomerDetails.Size = new System.Drawing.Size(795, 523);
            this.tpCustomerDetails.TabIndex = 0;
            this.tpCustomerDetails.Text = "Customer Details";
            this.tpCustomerDetails.UseVisualStyleBackColor = true;
            // 
            // ucCustomerCardWithFilter1
            // 
            this.ucCustomerCardWithFilter1.FilterEnabled = true;
            this.ucCustomerCardWithFilter1.Location = new System.Drawing.Point(-4, -4);
            this.ucCustomerCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucCustomerCardWithFilter1.Name = "ucCustomerCardWithFilter1";
            this.ucCustomerCardWithFilter1.ShowAddMemberButton = true;
            this.ucCustomerCardWithFilter1.Size = new System.Drawing.Size(853, 527);
            this.ucCustomerCardWithFilter1.TabIndex = 0;
            this.ucCustomerCardWithFilter1.OnCustomerSelected += new System.EventHandler<Car_Rental.ucCustomerCardWithFilter.CustomerSelectedEventArgs>(this.ucCustomerCardWithFilter1_OnCustomerSelected);
            // 
            // tpVechicleDetails
            // 
            this.tpVechicleDetails.Controls.Add(this.ucVechicleCardWithFilter1);
            this.tpVechicleDetails.Location = new System.Drawing.Point(184, 4);
            this.tpVechicleDetails.Name = "tpVechicleDetails";
            this.tpVechicleDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpVechicleDetails.Size = new System.Drawing.Size(795, 523);
            this.tpVechicleDetails.TabIndex = 1;
            this.tpVechicleDetails.Text = "Vechicle Details";
            this.tpVechicleDetails.UseVisualStyleBackColor = true;
            // 
            // ucVechicleCardWithFilter1
            // 
            this.ucVechicleCardWithFilter1.FilterEnabled = true;
            this.ucVechicleCardWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ucVechicleCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucVechicleCardWithFilter1.Name = "ucVechicleCardWithFilter1";
            this.ucVechicleCardWithFilter1.Size = new System.Drawing.Size(852, 489);
            this.ucVechicleCardWithFilter1.TabIndex = 0;
            this.ucVechicleCardWithFilter1.OnVehicleSelected += new System.EventHandler<Car_Rental.ucVechicleCardWithFilter.vechicleSelectedEventArgs>(this.ucVechicleCardWithFilter1_OnVehicleSelected);
            // 
            // tpBookingDetails
            // 
            this.tpBookingDetails.Controls.Add(this.btnBook);
            this.tpBookingDetails.Controls.Add(this.txtPickUpLocation);
            this.tpBookingDetails.Controls.Add(this.txtInitailCheckNotes);
            this.tpBookingDetails.Controls.Add(this.txtPaymentDetails);
            this.tpBookingDetails.Controls.Add(this.txtDropOffLocation);
            this.tpBookingDetails.Controls.Add(this.dtpStartDate);
            this.tpBookingDetails.Controls.Add(this.label4);
            this.tpBookingDetails.Controls.Add(this.label9);
            this.tpBookingDetails.Controls.Add(this.label10);
            this.tpBookingDetails.Controls.Add(this.label6);
            this.tpBookingDetails.Controls.Add(this.lblInitialRentalDays);
            this.tpBookingDetails.Controls.Add(this.dtpEndDate);
            this.tpBookingDetails.Controls.Add(this.label5);
            this.tpBookingDetails.Controls.Add(this.label3);
            this.tpBookingDetails.Controls.Add(this.label12);
            this.tpBookingDetails.Controls.Add(this.lblInitialTotalDueAmount);
            this.tpBookingDetails.Controls.Add(this.lblRentalPricePerDay);
            this.tpBookingDetails.Controls.Add(this.label7);
            this.tpBookingDetails.Controls.Add(this.label2);
            this.tpBookingDetails.Controls.Add(this.lblVehicleID);
            this.tpBookingDetails.Controls.Add(this.label11);
            this.tpBookingDetails.Controls.Add(this.label1);
            this.tpBookingDetails.Controls.Add(this.lblCustomerID);
            this.tpBookingDetails.Controls.Add(this.label22);
            this.tpBookingDetails.Controls.Add(this.lblBookingID);
            this.tpBookingDetails.Location = new System.Drawing.Point(184, 4);
            this.tpBookingDetails.Name = "tpBookingDetails";
            this.tpBookingDetails.Size = new System.Drawing.Size(795, 523);
            this.tpBookingDetails.TabIndex = 2;
            this.tpBookingDetails.Text = "Booking Details";
            this.tpBookingDetails.UseVisualStyleBackColor = true;
            // 
            // btnBook
            // 
            this.btnBook.Animated = true;
            this.btnBook.AutoRoundedCorners = true;
            this.btnBook.BorderRadius = 21;
            this.btnBook.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBook.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBook.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(211, 284);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(404, 45);
            this.btnBook.TabIndex = 277;
            this.btnBook.Text = "Book now";
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // txtPickUpLocation
            // 
            this.txtPickUpLocation.Animated = true;
            this.txtPickUpLocation.AutoRoundedCorners = true;
            this.txtPickUpLocation.BorderRadius = 15;
            this.txtPickUpLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPickUpLocation.DefaultText = "";
            this.txtPickUpLocation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPickUpLocation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPickUpLocation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPickUpLocation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPickUpLocation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPickUpLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPickUpLocation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPickUpLocation.Location = new System.Drawing.Point(548, 110);
            this.txtPickUpLocation.Name = "txtPickUpLocation";
            this.txtPickUpLocation.PasswordChar = '\0';
            this.txtPickUpLocation.PlaceholderText = "";
            this.txtPickUpLocation.SelectedText = "";
            this.txtPickUpLocation.Size = new System.Drawing.Size(185, 32);
            this.txtPickUpLocation.TabIndex = 276;
            // 
            // txtInitailCheckNotes
            // 
            this.txtInitailCheckNotes.Animated = true;
            this.txtInitailCheckNotes.AutoRoundedCorners = true;
            this.txtInitailCheckNotes.BorderRadius = 15;
            this.txtInitailCheckNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInitailCheckNotes.DefaultText = "";
            this.txtInitailCheckNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInitailCheckNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInitailCheckNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInitailCheckNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInitailCheckNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInitailCheckNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInitailCheckNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInitailCheckNotes.Location = new System.Drawing.Point(548, 192);
            this.txtInitailCheckNotes.Name = "txtInitailCheckNotes";
            this.txtInitailCheckNotes.PasswordChar = '\0';
            this.txtInitailCheckNotes.PlaceholderText = "";
            this.txtInitailCheckNotes.SelectedText = "";
            this.txtInitailCheckNotes.Size = new System.Drawing.Size(185, 32);
            this.txtInitailCheckNotes.TabIndex = 275;
            // 
            // txtPaymentDetails
            // 
            this.txtPaymentDetails.Animated = true;
            this.txtPaymentDetails.AutoRoundedCorners = true;
            this.txtPaymentDetails.BorderRadius = 15;
            this.txtPaymentDetails.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPaymentDetails.DefaultText = "";
            this.txtPaymentDetails.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPaymentDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPaymentDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPaymentDetails.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPaymentDetails.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPaymentDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPaymentDetails.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPaymentDetails.Location = new System.Drawing.Point(548, 233);
            this.txtPaymentDetails.Name = "txtPaymentDetails";
            this.txtPaymentDetails.PasswordChar = '\0';
            this.txtPaymentDetails.PlaceholderText = "";
            this.txtPaymentDetails.SelectedText = "";
            this.txtPaymentDetails.Size = new System.Drawing.Size(185, 32);
            this.txtPaymentDetails.TabIndex = 274;
            // 
            // txtDropOffLocation
            // 
            this.txtDropOffLocation.Animated = true;
            this.txtDropOffLocation.AutoRoundedCorners = true;
            this.txtDropOffLocation.BorderRadius = 15;
            this.txtDropOffLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDropOffLocation.DefaultText = "";
            this.txtDropOffLocation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDropOffLocation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDropOffLocation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDropOffLocation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDropOffLocation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDropOffLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDropOffLocation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDropOffLocation.Location = new System.Drawing.Point(548, 151);
            this.txtDropOffLocation.Name = "txtDropOffLocation";
            this.txtDropOffLocation.PasswordChar = '\0';
            this.txtDropOffLocation.PlaceholderText = "";
            this.txtDropOffLocation.SelectedText = "";
            this.txtDropOffLocation.Size = new System.Drawing.Size(185, 32);
            this.txtDropOffLocation.TabIndex = 273;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AutoRoundedCorners = true;
            this.dtpStartDate.BorderRadius = 15;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dtpStartDate.ForeColor = System.Drawing.Color.White;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(548, 28);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(2023, 11, 8, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(185, 32);
            this.dtpStartDate.TabIndex = 272;
            this.dtpStartDate.Value = new System.DateTime(2023, 11, 8, 23, 9, 0, 486);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(369, 233);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 20);
            this.label4.TabIndex = 271;
            this.label4.Text = "Payment Details:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(369, 186);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 20);
            this.label9.TabIndex = 270;
            this.label9.Text = "Initial Check Notes:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(369, 150);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 20);
            this.label10.TabIndex = 269;
            this.label10.Text = "Drop off Location:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 20);
            this.label6.TabIndex = 267;
            this.label6.Text = "Initial Rental Days:";
            // 
            // lblInitialRentalDays
            // 
            this.lblInitialRentalDays.AutoSize = true;
            this.lblInitialRentalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialRentalDays.Location = new System.Drawing.Point(240, 150);
            this.lblInitialRentalDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitialRentalDays.Name = "lblInitialRentalDays";
            this.lblInitialRentalDays.Size = new System.Drawing.Size(53, 20);
            this.lblInitialRentalDays.TabIndex = 268;
            this.lblInitialRentalDays.Text = "[????]";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.AutoRoundedCorners = true;
            this.dtpEndDate.BorderRadius = 15;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dtpEndDate.ForeColor = System.Drawing.Color.White;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(548, 69);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(2023, 11, 8, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(185, 32);
            this.dtpEndDate.TabIndex = 266;
            this.dtpEndDate.Value = new System.DateTime(2023, 11, 8, 23, 9, 0, 486);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(369, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 265;
            this.label5.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 264;
            this.label3.Text = "Start Date:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 187);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 20);
            this.label12.TabIndex = 263;
            this.label12.Text = "Rental Price/Day:";
            // 
            // lblInitialTotalDueAmount
            // 
            this.lblInitialTotalDueAmount.AutoSize = true;
            this.lblInitialTotalDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialTotalDueAmount.Location = new System.Drawing.Point(240, 221);
            this.lblInitialTotalDueAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitialTotalDueAmount.Name = "lblInitialTotalDueAmount";
            this.lblInitialTotalDueAmount.Size = new System.Drawing.Size(53, 20);
            this.lblInitialTotalDueAmount.TabIndex = 262;
            this.lblInitialTotalDueAmount.Text = "[????]";
            // 
            // lblRentalPricePerDay
            // 
            this.lblRentalPricePerDay.AutoSize = true;
            this.lblRentalPricePerDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalPricePerDay.Location = new System.Drawing.Point(240, 186);
            this.lblRentalPricePerDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRentalPricePerDay.Name = "lblRentalPricePerDay";
            this.lblRentalPricePerDay.Size = new System.Drawing.Size(53, 20);
            this.lblRentalPricePerDay.TabIndex = 261;
            this.lblRentalPricePerDay.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 222);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 20);
            this.label7.TabIndex = 260;
            this.label7.Text = "Initial Total Due Amount:\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 258;
            this.label2.Text = "Vehicle ID:";
            // 
            // lblVehicleID
            // 
            this.lblVehicleID.AutoSize = true;
            this.lblVehicleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleID.Location = new System.Drawing.Point(240, 109);
            this.lblVehicleID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVehicleID.Name = "lblVehicleID";
            this.lblVehicleID.Size = new System.Drawing.Size(53, 20);
            this.lblVehicleID.TabIndex = 259;
            this.lblVehicleID.Text = "[????]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(369, 109);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 20);
            this.label11.TabIndex = 257;
            this.label11.Text = "Pick up Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 255;
            this.label1.Text = "Customer ID:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.Location = new System.Drawing.Point(240, 74);
            this.lblCustomerID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(53, 20);
            this.lblCustomerID.TabIndex = 256;
            this.lblCustomerID.Text = "[????]";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(23, 39);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 20);
            this.label22.TabIndex = 253;
            this.label22.Text = "Booking ID:";
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingID.Location = new System.Drawing.Point(240, 39);
            this.lblBookingID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(53, 20);
            this.lblBookingID.TabIndex = 254;
            this.lblBookingID.Text = "[????]";
            // 
            // frmAddUpdateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(983, 571);
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "frmAddUpdateBooking";
            this.Text = "frmAddUpdateBooking";
            this.Load += new System.EventHandler(this.frmAddUpdateBooking_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2TabControl1.ResumeLayout(false);
            this.tpCustomerDetails.ResumeLayout(false);
            this.tpVechicleDetails.ResumeLayout(false);
            this.tpBookingDetails.ResumeLayout(false);
            this.tpBookingDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tpCustomerDetails;
        private System.Windows.Forms.TabPage tpVechicleDetails;
        private System.Windows.Forms.TabPage tpBookingDetails;
        private ucCustomerCardWithFilter ucCustomerCardWithFilter1;
        private ucVechicleCardWithFilter ucVechicleCardWithFilter1;
        private Guna.UI2.WinForms.Guna2Button btnBook;
        private Guna.UI2.WinForms.Guna2TextBox txtPickUpLocation;
        private Guna.UI2.WinForms.Guna2TextBox txtInitailCheckNotes;
        private Guna.UI2.WinForms.Guna2TextBox txtPaymentDetails;
        private Guna.UI2.WinForms.Guna2TextBox txtDropOffLocation;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInitialRentalDays;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblInitialTotalDueAmount;
        private System.Windows.Forms.Label lblRentalPricePerDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVehicleID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblBookingID;
    }
}