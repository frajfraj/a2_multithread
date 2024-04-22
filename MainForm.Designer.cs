namespace a2_multithread
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOK = new Button();
            lstOutput = new ListBox();
            btnStop = new Button();
            lstItems = new ListBox();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(201, 948);
            btnOK.Margin = new Padding(4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(305, 78);
            btnOK.TabIndex = 0;
            btnOK.Text = "Start";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // lstOutput
            // 
            lstOutput.Font = new Font("Courier New", 10F);
            lstOutput.FormattingEnabled = true;
            lstOutput.ItemHeight = 25;
            lstOutput.Location = new Point(34, 17);
            lstOutput.Margin = new Padding(5, 6, 5, 6);
            lstOutput.Name = "lstOutput";
            lstOutput.Size = new Size(472, 904);
            lstOutput.TabIndex = 1;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(551, 948);
            btnStop.Margin = new Padding(5, 6, 5, 6);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(305, 78);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lstItems
            // 
            lstItems.Font = new Font("Courier New", 10F);
            lstItems.FormattingEnabled = true;
            lstItems.ItemHeight = 25;
            lstItems.Location = new Point(551, 17);
            lstItems.Margin = new Padding(4);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(1200, 904);
            lstItems.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1773, 1072);
            Controls.Add(lstItems);
            Controls.Add(btnStop);
            Controls.Add(lstOutput);
            Controls.Add(btnOK);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Equipment Loaning System";
            FormClosing += MainForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOK;
        private ListBox lstOutput;
        private Button btnStop;
        private ListBox lstItems;
    }
}
