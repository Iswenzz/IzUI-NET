namespace IzUI.WinForms.Tests
{
    partial class Fixture
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
            data1 = new UI.Data();
            inputs1 = new UI.Inputs();
            layout1 = new UI.Layout();
            SuspendLayout();
            // 
            // data1
            // 
            data1.BackColor = Color.FromArgb(42, 42, 42);
            data1.Location = new Point(-1, -1);
            data1.Margin = new Padding(3, 4, 3, 4);
            data1.Name = "data1";
            data1.Size = new Size(735, 370);
            data1.TabIndex = 0;
            // 
            // inputs1
            // 
            inputs1.BackColor = Color.FromArgb(42, 42, 42);
            inputs1.Location = new Point(664, -1);
            inputs1.Margin = new Padding(3, 4, 3, 4);
            inputs1.Name = "inputs1";
            inputs1.Size = new Size(710, 370);
            inputs1.TabIndex = 1;
            // 
            // layout1
            // 
            layout1.BackColor = Color.FromArgb(42, 42, 42);
            layout1.Location = new Point(-1, 337);
            layout1.Margin = new Padding(3, 4, 3, 4);
            layout1.Name = "layout1";
            layout1.Size = new Size(1375, 377);
            layout1.TabIndex = 2;
            // 
            // Fixture
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 42, 42);
            ClientSize = new Size(1371, 712);
            Controls.Add(layout1);
            Controls.Add(inputs1);
            Controls.Add(data1);
            Name = "Fixture";
            Text = "Fixture";
            ResumeLayout(false);
        }

        #endregion

        private UI.Data data1;
        private UI.Inputs inputs1;
        private UI.Layout layout1;
    }
}