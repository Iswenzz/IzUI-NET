namespace Iswenzz.UI.Controls.Layout
{
    partial class MKW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MKW));
            this.label1 = new System.Windows.Forms.Label();
            this.labelSpecial1 = new Iswenzz.UI.Controls.Data.LabelSpecial();
            this.timeTrialCard1 = new Iswenzz.UI.Controls.Game.MKW.TimeTrialCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(697, 54);
            this.label1.TabIndex = 24;
            this.label1.Text = "MKW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpecial1
            // 
            this.labelSpecial1.Animations.HoverColor = System.Drawing.Color.Empty;
            this.labelSpecial1.Animations.HoverColorLeave = System.Drawing.Color.Empty;
            this.labelSpecial1.Animations.HoverColorText = System.Drawing.Color.Empty;
            this.labelSpecial1.Animations.HoverColorTextLeave = System.Drawing.Color.Empty;
            this.labelSpecial1.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecial1.Border.Radius = 0;
            this.labelSpecial1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpecial1.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelSpecial1.Location = new System.Drawing.Point(22, 89);
            this.labelSpecial1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelSpecial1.Name = "labelSpecial1";
            this.labelSpecial1.Size = new System.Drawing.Size(144, 46);
            this.labelSpecial1.TabIndex = 29;
            this.labelSpecial1.Text = "TimeTrialCard";
            this.labelSpecial1.TextLayouts.Angle = 0;
            this.labelSpecial1.TextLayouts.ContentAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeTrialCard1
            // 
            this.timeTrialCard1.Animations.HoverColor = System.Drawing.Color.Empty;
            this.timeTrialCard1.Animations.HoverColorLeave = System.Drawing.Color.Empty;
            this.timeTrialCard1.Animations.HoverColorText = System.Drawing.Color.Empty;
            this.timeTrialCard1.Animations.HoverColorTextLeave = System.Drawing.Color.Empty;
            this.timeTrialCard1.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("timeTrialCard1.BackgroundImage")));
            this.timeTrialCard1.Border.Radius = 0;
            this.timeTrialCard1.CardImage = ((System.Drawing.Bitmap)(resources.GetObject("timeTrialCard1.CardImage")));
            this.timeTrialCard1.ComboImage = ((System.Drawing.Bitmap)(resources.GetObject("timeTrialCard1.ComboImage")));
            this.timeTrialCard1.ControllerImage = ((System.Drawing.Bitmap)(resources.GetObject("timeTrialCard1.ControllerImage")));
            this.timeTrialCard1.FlagImage = ((System.Drawing.Bitmap)(resources.GetObject("timeTrialCard1.FlagImage")));
            this.timeTrialCard1.Layouts.Angle = 0;
            this.timeTrialCard1.Location = new System.Drawing.Point(172, 89);
            this.timeTrialCard1.Name = "timeTrialCard1";
            this.timeTrialCard1.Size = new System.Drawing.Size(492, 272);
            this.timeTrialCard1.TabIndex = 30;
            this.timeTrialCard1.Text = "timeTrialCard1";
            // 
            // MKW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.timeTrialCard1);
            this.Controls.Add(this.labelSpecial1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MKW";
            this.Size = new System.Drawing.Size(697, 386);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Controls.Data.LabelSpecial labelSpecial1;
        private Game.MKW.TimeTrialCard timeTrialCard1;
    }
}
