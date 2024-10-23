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
            data1.Location = new Point(830, 0);
            data1.Margin = new Padding(4, 5, 4, 5);
            data1.Name = "data1";
            data1.Size = new Size(578, 624);
            data1.TabIndex = 0;
            // 
            // inputs1
            // 
            inputs1.BackColor = Color.FromArgb(42, 42, 42);
            inputs1.Location = new Point(-1, 0);
            inputs1.Margin = new Padding(4, 5, 4, 5);
            inputs1.Name = "inputs1";
            inputs1.Size = new Size(833, 624);
            inputs1.TabIndex = 1;
            // 
            // layout1
            // 
            layout1.BackColor = Color.FromArgb(42, 42, 42);
            layout1.Location = new Point(1404, 0);
            layout1.Margin = new Padding(4, 5, 4, 5);
            layout1.Name = "layout1";
            layout1.Size = new Size(547, 624);
            layout1.TabIndex = 2;
            // 
            // Fixture
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 42, 42);
            ClientSize = new Size(1980, 624);
            Controls.Add(layout1);
            Controls.Add(inputs1);
            Controls.Add(data1);
            Margin = new Padding(4);
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