namespace MyCTS.Presentation
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tableLayoutContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutBanner = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonIntegra = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGEA = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInforma = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTotalTrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonQueue = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonViewInvoice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPaxReceive = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReports = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEinvoice = new System.Windows.Forms.ToolStripButton();
            this.lblVersion = new System.Windows.Forms.ToolStripLabel();
            this.lblQueue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBanner = new System.Windows.Forms.Label();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlArea = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusNotification = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutContainer.SuspendLayout();
            this.tableLayoutBanner.SuspendLayout();
            this.toolStripTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.statusNotification.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutContainer
            // 
            this.tableLayoutContainer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutContainer.ColumnCount = 1;
            this.tableLayoutContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutContainer.Controls.Add(this.tableLayoutBanner, 0, 0);
            this.tableLayoutContainer.Controls.Add(this.tableLayoutMain, 0, 1);
            this.tableLayoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutContainer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutContainer.Name = "tableLayoutContainer";
            this.tableLayoutContainer.RowCount = 2;
            this.tableLayoutContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.58192F));
            this.tableLayoutContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.41808F));
            this.tableLayoutContainer.Size = new System.Drawing.Size(409, 709);
            this.tableLayoutContainer.TabIndex = 0;
            // 
            // tableLayoutBanner
            // 
            this.tableLayoutBanner.ColumnCount = 1;
            this.tableLayoutBanner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBanner.Controls.Add(this.toolStripTop, 0, 0);
            this.tableLayoutBanner.Controls.Add(this.lblQueue, 0, 2);
            this.tableLayoutBanner.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBanner.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutBanner.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBanner.Name = "tableLayoutBanner";
            this.tableLayoutBanner.RowCount = 4;
            this.tableLayoutBanner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutBanner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutBanner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutBanner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBanner.Size = new System.Drawing.Size(407, 81);
            this.tableLayoutBanner.TabIndex = 0;
            // 
            // toolStripTop
            // 
            this.toolStripTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonIntegra,
            this.toolStripButtonGEA,
            this.toolStripButtonInforma,
            this.toolStripButtonTotalTrip,
            this.toolStripButtonQueue,
            this.toolStripButtonViewInvoice,
            this.toolStripButtonPaxReceive,
            this.toolStripButtonReports,
            this.toolStripButtonEinvoice,
            this.lblVersion});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(407, 34);
            this.toolStripTop.TabIndex = 0;
            this.toolStripTop.Text = "toolStrip1";
            // 
            // toolStripButtonIntegra
            // 
            this.toolStripButtonIntegra.Image = global::MyCTS.Presentation.Properties.Resources.Integra;
            this.toolStripButtonIntegra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonIntegra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIntegra.Name = "toolStripButtonIntegra";
            this.toolStripButtonIntegra.Size = new System.Drawing.Size(48, 31);
            this.toolStripButtonIntegra.Text = "Integra";
            this.toolStripButtonIntegra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonIntegra.Click += new System.EventHandler(this.toolStripButtonIntegra_Click);
            // 
            // toolStripButtonGEA
            // 
            this.toolStripButtonGEA.Image = global::MyCTS.Presentation.Properties.Resources.GEA;
            this.toolStripButtonGEA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGEA.Name = "toolStripButtonGEA";
            this.toolStripButtonGEA.Size = new System.Drawing.Size(40, 31);
            this.toolStripButtonGEA.Text = " Gea  ";
            this.toolStripButtonGEA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonGEA.Click += new System.EventHandler(this.toolStripButtonGEA_Click);
            // 
            // toolStripButtonInforma
            // 
            this.toolStripButtonInforma.Image = global::MyCTS.Presentation.Properties.Resources.Informa;
            this.toolStripButtonInforma.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonInforma.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInforma.Name = "toolStripButtonInforma";
            this.toolStripButtonInforma.Size = new System.Drawing.Size(53, 31);
            this.toolStripButtonInforma.Text = "Informa";
            this.toolStripButtonInforma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonInforma.Click += new System.EventHandler(this.toolStripButtonInforma_Click);
            // 
            // toolStripButtonTotalTrip
            // 
            this.toolStripButtonTotalTrip.Image = global::MyCTS.Presentation.Properties.Resources.TotalTrip;
            this.toolStripButtonTotalTrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTotalTrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTotalTrip.Name = "toolStripButtonTotalTrip";
            this.toolStripButtonTotalTrip.Size = new System.Drawing.Size(62, 31);
            this.toolStripButtonTotalTrip.Text = "Total Trip";
            this.toolStripButtonTotalTrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonTotalTrip.Click += new System.EventHandler(this.toolStripButtonTotalTrip_Click);
            // 
            // toolStripButtonQueue
            // 
            this.toolStripButtonQueue.Image = global::MyCTS.Presentation.Properties.Resources.Symbol_Refresh2;
            this.toolStripButtonQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQueue.Name = "toolStripButtonQueue";
            this.toolStripButtonQueue.Size = new System.Drawing.Size(51, 31);
            this.toolStripButtonQueue.Text = "Queues";
            this.toolStripButtonQueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonQueue.Visible = false;
            this.toolStripButtonQueue.Click += new System.EventHandler(this.toolStripButtonQueues_Click);
            // 
            // toolStripButtonViewInvoice
            // 
            this.toolStripButtonViewInvoice.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonViewInvoice.Image")));
            this.toolStripButtonViewInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewInvoice.Name = "toolStripButtonViewInvoice";
            this.toolStripButtonViewInvoice.Size = new System.Drawing.Size(70, 31);
            this.toolStripButtonViewInvoice.Text = "Ver Factura";
            this.toolStripButtonViewInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonViewInvoice.Click += new System.EventHandler(this.toolStripButtonViewInvoice_Click);
            // 
            // toolStripButtonPaxReceive
            // 
            this.toolStripButtonPaxReceive.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPaxReceive.Image")));
            this.toolStripButtonPaxReceive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaxReceive.Name = "toolStripButtonPaxReceive";
            this.toolStripButtonPaxReceive.Size = new System.Drawing.Size(69, 31);
            this.toolStripButtonPaxReceive.Text = "PaxReceive";
            this.toolStripButtonPaxReceive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonPaxReceive.ToolTipText = "Passenger Receive";
            this.toolStripButtonPaxReceive.Click += new System.EventHandler(this.toolStripButtonPassengerReceive_Click);
            // 
            // toolStripButtonReports
            // 
            this.toolStripButtonReports.Image = global::MyCTS.Presentation.Properties.Resources.Reportes;
            this.toolStripButtonReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReports.Name = "toolStripButtonReports";
            this.toolStripButtonReports.Size = new System.Drawing.Size(57, 35);
            this.toolStripButtonReports.Text = "Reportes";
            this.toolStripButtonReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonReports.Click += new System.EventHandler(this.toolStripButtonReports_Click);
            // 
            // toolStripButtonEinvoice
            // 
            this.toolStripButtonEinvoice.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEinvoice.Image")));
            this.toolStripButtonEinvoice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEinvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEinvoice.Name = "toolStripButtonEinvoice";
            this.toolStripButtonEinvoice.Size = new System.Drawing.Size(55, 35);
            this.toolStripButtonEinvoice.Text = "Facturas";
            this.toolStripButtonEinvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEinvoice.Click += new System.EventHandler(this.toolStripButtonEinvoice_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Navy;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.Text = "Versión";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblQueue
            // 
            this.lblQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueue.ForeColor = System.Drawing.Color.Red;
            this.lblQueue.Location = new System.Drawing.Point(3, 42);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(258, 11);
            this.lblQueue.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBanner);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 22);
            this.panel1.TabIndex = 2;
            // 
            // lblBanner
            // 
            this.lblBanner.AutoSize = true;
            this.lblBanner.Location = new System.Drawing.Point(307, 4);
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Size = new System.Drawing.Size(91, 13);
            this.lblBanner.TabIndex = 0;
            this.lblBanner.Text = "Texto marquesina";
            this.lblBanner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBanner.DoubleClick += new System.EventHandler(this.lblBanner_DoubleClick);
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.97519F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.02481F));
            this.tableLayoutMain.Controls.Add(this.pnlMiddle, 0, 1);
            this.tableLayoutMain.Controls.Add(this.pnlArea, 1, 0);
            this.tableLayoutMain.Controls.Add(this.pnlLeft, 0, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(1, 83);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutMain.Size = new System.Drawing.Size(407, 625);
            this.tableLayoutMain.TabIndex = 1;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AutoScroll = true;
            this.pnlMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutMain.SetColumnSpan(this.pnlMiddle, 2);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 25);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(407, 600);
            this.pnlMiddle.TabIndex = 0;
            // 
            // pnlArea
            // 
            this.pnlArea.BackColor = System.Drawing.Color.LightGray;
            this.pnlArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlArea.Location = new System.Drawing.Point(284, 0);
            this.pnlArea.Margin = new System.Windows.Forms.Padding(0);
            this.pnlArea.Name = "pnlArea";
            this.pnlArea.Size = new System.Drawing.Size(123, 25);
            this.pnlArea.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.LightGray;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(284, 25);
            this.pnlLeft.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusNotification
            // 
            this.statusNotification.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusNotification.Location = new System.Drawing.Point(0, 687);
            this.statusNotification.Name = "statusNotification";
            this.statusNotification.Size = new System.Drawing.Size(409, 22);
            this.statusNotification.TabIndex = 1;
            this.statusNotification.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Lime;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel1.Text = "  Status Connection  ";
            // 
            // frmMain
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(409, 709);
            this.Controls.Add(this.statusNotification);
            this.Controls.Add(this.tableLayoutContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(600, 0);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MyCTS-Corporate Travel Services";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tableLayoutContainer.ResumeLayout(false);
            this.tableLayoutBanner.ResumeLayout(false);
            this.tableLayoutBanner.PerformLayout();
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutMain.ResumeLayout(false);
            this.statusNotification.ResumeLayout(false);
            this.statusNotification.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBanner;
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripButton toolStripButtonIntegra;
        private System.Windows.Forms.ToolStripButton toolStripButtonGEA;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlArea;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonInforma;
        private System.Windows.Forms.ToolStripButton toolStripButtonTotalTrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonReports;
        private System.Windows.Forms.ToolStripLabel lblVersion;
        private System.Windows.Forms.ToolStripButton toolStripButtonQueue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBanner;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewInvoice;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaxReceive;
        private System.Windows.Forms.ToolStripButton toolStripButtonEinvoice;
        private System.Windows.Forms.StatusStrip statusNotification;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}

