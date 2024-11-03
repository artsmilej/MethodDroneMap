namespace DroneMapApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            gMapControl = new GMap.NET.WindowsForms.GMapControl();
            btnSetStartPoint = new Button();
            btnSetEndPoint = new Button();
            txtRadius = new TextBox();
            lblRadius = new Label();
            SuspendLayout();
            // 
            // gMapControl
            // 
            gMapControl.Bearing = 0F;
            gMapControl.CanDragMap = true;
            gMapControl.EmptyTileColor = Color.Navy;
            gMapControl.GrayScaleMode = false;
            gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.DragButton = MouseButtons.Left;
            gMapControl.Location = new Point(12, 1);
            gMapControl.MarkersEnabled = true;
            gMapControl.MaxZoom = 200;
            gMapControl.MinZoom = 5;
            gMapControl.MouseWheelZoomEnabled = true;
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl.Name = "gMapControl";
            gMapControl.NegativeMode = false;
            gMapControl.PolygonsEnabled = true;
            gMapControl.RetryLoadTile = 0;
            gMapControl.RoutesEnabled = true;
            gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl.SelectedAreaFillColor = Color.FromArgb(50, 0, 0, 255);
            gMapControl.ShowTileGridLines = false;
            gMapControl.Size = new Size(1518, 716);
            gMapControl.TabIndex = 0;
            gMapControl.Zoom = 6D;
            // 
            // btnSetStartPoint
            // 
            btnSetStartPoint.Location = new Point(12, 723);
            btnSetStartPoint.Name = "btnSetStartPoint";
            btnSetStartPoint.Size = new Size(120, 30);
            btnSetStartPoint.TabIndex = 1;
            btnSetStartPoint.Text = "Встановити початкову точку";
            btnSetStartPoint.UseVisualStyleBackColor = true;
            btnSetStartPoint.Click += btnSetStartPoint_Click;
            // 
            // btnSetEndPoint
            // 
            btnSetEndPoint.Location = new Point(157, 723);
            btnSetEndPoint.Name = "btnSetEndPoint";
            btnSetEndPoint.Size = new Size(120, 30);
            btnSetEndPoint.TabIndex = 2;
            btnSetEndPoint.Text = "Встановити кінцеву точку";
            btnSetEndPoint.UseVisualStyleBackColor = true;
            btnSetEndPoint.Click += btnSetEndPoint_Click;
            // 
            // txtRadius
            // 
            txtRadius.Location = new Point(311, 723);
            txtRadius.Name = "txtRadius";
            txtRadius.Size = new Size(100, 23);
            txtRadius.TabIndex = 3;
            // 
            // lblRadius
            // 
            lblRadius.AutoSize = true;
            lblRadius.Location = new Point(427, 726);
            lblRadius.Name = "lblRadius";
            lblRadius.Size = new Size(127, 15);
            lblRadius.TabIndex = 4;
            lblRadius.Text = "Радіус ураження (км):";
            // 
            // MainForm
            // 
            ClientSize = new Size(1542, 989);
            Controls.Add(gMapControl);
            Controls.Add(btnSetStartPoint);
            Controls.Add(btnSetEndPoint);
            Controls.Add(txtRadius);
            Controls.Add(lblRadius);
            Name = "MainForm";
            Text = "Симулятор удару дронів";
            ResumeLayout(false);
            PerformLayout();
        }

        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Button btnSetStartPoint;
        private System.Windows.Forms.Button btnSetEndPoint;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label lblRadius;
    }
}