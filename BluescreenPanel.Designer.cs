namespace smokescreen
{
    partial class BluescreenPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSadface = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.pnlQrCode = new System.Windows.Forms.Panel();
            this.lblHelpText = new System.Windows.Forms.Label();
            this.lblSupportInfo = new System.Windows.Forms.Label();
            this.lblStopCodeInfo = new System.Windows.Forms.Label();
            this.lblStopCode = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlBottomRight = new System.Windows.Forms.Panel();
            this.pnlQrContainer = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomRight.SuspendLayout();
            this.pnlQrContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSadface
            // 
            this.lblSadface.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSadface.Font = new System.Drawing.Font("Segoe UI Semilight", 210F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSadface.Location = new System.Drawing.Point(150, 122);
            this.lblSadface.Name = "lblSadface";
            this.lblSadface.Size = new System.Drawing.Size(1570, 260);
            this.lblSadface.TabIndex = 0;
            this.lblSadface.Text = ":(";
            this.lblSadface.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semilight", 30.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMessage.Location = new System.Drawing.Point(200, 390);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1520, 180);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Your PC ran into a problem and needs to restart. We\'re\r\njust collecting some erro" +
    "r info, and then we\'ll restart for\r\nyou.\r\n";
            // 
            // lblPercentage
            // 
            this.lblPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI Semilight", 30.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPercentage.Location = new System.Drawing.Point(200, 593);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(468, 62);
            this.lblPercentage.TabIndex = 2;
            this.lblPercentage.Text = "00% complete";
            // 
            // pnlQrCode
            // 
            this.pnlQrCode.BackColor = System.Drawing.Color.Transparent;
            this.pnlQrCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlQrCode.Location = new System.Drawing.Point(0, 0);
            this.pnlQrCode.MinimumSize = new System.Drawing.Size(115, 115);
            this.pnlQrCode.Name = "pnlQrCode";
            this.pnlQrCode.Size = new System.Drawing.Size(115, 115);
            this.pnlQrCode.TabIndex = 3;
            // 
            // lblHelpText
            // 
            this.lblHelpText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelpText.Font = new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHelpText.Location = new System.Drawing.Point(0, 0);
            this.lblHelpText.Name = "lblHelpText";
            this.lblHelpText.Size = new System.Drawing.Size(1395, 51);
            this.lblHelpText.TabIndex = 4;
            this.lblHelpText.Text = "For more information about this issue and possible fixes, visit https://www.windo" +
    "ws.com/stopcode";
            // 
            // lblSupportInfo
            // 
            this.lblSupportInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupportInfo.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSupportInfo.Location = new System.Drawing.Point(0, 55);
            this.lblSupportInfo.Name = "lblSupportInfo";
            this.lblSupportInfo.Size = new System.Drawing.Size(1395, 34);
            this.lblSupportInfo.TabIndex = 5;
            this.lblSupportInfo.Text = "If you call a support person, give them this info:";
            // 
            // lblStopCodeInfo
            // 
            this.lblStopCodeInfo.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStopCodeInfo.Location = new System.Drawing.Point(0, 89);
            this.lblStopCodeInfo.Name = "lblStopCodeInfo";
            this.lblStopCodeInfo.Size = new System.Drawing.Size(86, 26);
            this.lblStopCodeInfo.TabIndex = 6;
            this.lblStopCodeInfo.Text = "Stop code: ";
            // 
            // lblStopCode
            // 
            this.lblStopCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStopCode.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStopCode.Location = new System.Drawing.Point(81, 89);
            this.lblStopCode.Name = "lblStopCode";
            this.lblStopCode.Size = new System.Drawing.Size(1314, 26);
            this.lblStopCode.TabIndex = 7;
            this.lblStopCode.Text = "CRITICAL_PROCESS_DIED";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.pnlBottomRight);
            this.pnlBottom.Controls.Add(this.pnlQrContainer);
            this.pnlBottom.Location = new System.Drawing.Point(210, 674);
            this.pnlBottom.MinimumSize = new System.Drawing.Size(0, 115);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1510, 115);
            this.pnlBottom.TabIndex = 8;
            // 
            // pnlBottomRight
            // 
            this.pnlBottomRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottomRight.Controls.Add(this.lblStopCode);
            this.pnlBottomRight.Controls.Add(this.lblHelpText);
            this.pnlBottomRight.Controls.Add(this.lblStopCodeInfo);
            this.pnlBottomRight.Controls.Add(this.lblSupportInfo);
            this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomRight.Location = new System.Drawing.Point(115, 0);
            this.pnlBottomRight.Name = "pnlBottomRight";
            this.pnlBottomRight.Size = new System.Drawing.Size(1395, 115);
            this.pnlBottomRight.TabIndex = 1;
            // 
            // pnlQrContainer
            // 
            this.pnlQrContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlQrContainer.Controls.Add(this.pnlQrCode);
            this.pnlQrContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlQrContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlQrContainer.MinimumSize = new System.Drawing.Size(115, 115);
            this.pnlQrContainer.Name = "pnlQrContainer";
            this.pnlQrContainer.Size = new System.Drawing.Size(115, 115);
            this.pnlQrContainer.TabIndex = 0;
            // 
            // BluescreenPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.lblSadface);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pnlBottom);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "BluescreenPanel";
            this.Size = new System.Drawing.Size(1920, 1080);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomRight.ResumeLayout(false);
            this.pnlQrContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblSadface;
        private Label lblMessage;
        private Label lblPercentage;
        private Panel pnlQrCode;
        private Label lblHelpText;
        private Label lblSupportInfo;
        private Label lblStopCodeInfo;
        private Label lblStopCode;
        private System.Windows.Forms.Timer timer;
        private Panel pnlBottom;
        private Panel pnlBottomRight;
        private Panel pnlQrContainer;
    }
}
