namespace workOrderForm
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.NameLabel = new System.Windows.Forms.Label();
            this.PlaneLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.PlaneBox = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.RecordButton2 = new System.Windows.Forms.Button();
            this.RecordButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(80, 233);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            this.NameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PlaneLabel
            // 
            this.PlaneLabel.AutoSize = true;
            this.PlaneLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlaneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaneLabel.Location = new System.Drawing.Point(80, 282);
            this.PlaneLabel.Name = "PlaneLabel";
            this.PlaneLabel.Size = new System.Drawing.Size(49, 20);
            this.PlaneLabel.TabIndex = 1;
            this.PlaneLabel.Text = "Plane";
            this.PlaneLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(150, 233);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 2;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // PlaneBox
            // 
            this.PlaneBox.Location = new System.Drawing.Point(150, 282);
            this.PlaneBox.Name = "PlaneBox";
            this.PlaneBox.Size = new System.Drawing.Size(100, 20);
            this.PlaneBox.TabIndex = 3;
            this.PlaneBox.TextChanged += new System.EventHandler(this.PlaneBox_TextChanged);
            // 
            // GoButton
            // 
            this.GoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoButton.Location = new System.Drawing.Point(395, 261);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(79, 27);
            this.GoButton.TabIndex = 4;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // RecordButton2
            // 
            this.RecordButton2.Location = new System.Drawing.Point(277, 282);
            this.RecordButton2.Name = "RecordButton2";
            this.RecordButton2.Size = new System.Drawing.Size(33, 23);
            this.RecordButton2.TabIndex = 7;
            this.RecordButton2.Text = "P";
            this.RecordButton2.UseVisualStyleBackColor = true;
            this.RecordButton2.Click += new System.EventHandler(this.RecordButton2_Click);
            // 
            // RecordButton1
            // 
            this.RecordButton1.Location = new System.Drawing.Point(277, 233);
            this.RecordButton1.Name = "RecordButton1";
            this.RecordButton1.Size = new System.Drawing.Size(33, 23);
            this.RecordButton1.TabIndex = 8;
            this.RecordButton1.Text = "P";
            this.RecordButton1.UseVisualStyleBackColor = true;
            this.RecordButton1.Click += new System.EventHandler(this.RecordButton1_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(578, 321);
            this.Controls.Add(this.RecordButton1);
            this.Controls.Add(this.RecordButton2);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.PlaneBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.PlaneLabel);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in Here";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PlaneLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox PlaneBox;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button RecordButton2;
        private System.Windows.Forms.Button RecordButton1;
    }
}

