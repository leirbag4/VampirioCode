namespace VampirioCode
{
    partial class App
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
            codeContainer = new Panel();
            testButton = new Button();
            SuspendLayout();
            // 
            // codeContainer
            // 
            codeContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            codeContainer.Location = new Point(12, 45);
            codeContainer.Name = "codeContainer";
            codeContainer.Size = new Size(776, 393);
            codeContainer.TabIndex = 0;
            // 
            // testButton
            // 
            testButton.FlatStyle = FlatStyle.Flat;
            testButton.ForeColor = Color.DarkOrchid;
            testButton.Location = new Point(12, 10);
            testButton.Name = "testButton";
            testButton.Size = new Size(94, 29);
            testButton.TabIndex = 1;
            testButton.Text = "test";
            testButton.UseVisualStyleBackColor = true;
            testButton.Click += OnTestPressed;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(800, 450);
            Controls.Add(testButton);
            Controls.Add(codeContainer);
            Name = "App";
            Text = "Vampirio Code";
            ResumeLayout(false);
        }

        #endregion

        private Panel codeContainer;
        private Button testButton;
    }
}
