namespace NeuralNetworkLogicGates
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            btnPredict = new Button();
            lblOutput = new Label();
            chkInput0 = new CheckBox();
            chkInput1 = new CheckBox();
            chkInput2 = new CheckBox();
            chkInput3 = new CheckBox();
            chkInput4 = new CheckBox();
            btnTrain = new Button();
            comboBoxGate = new ComboBox();
            label1 = new Label();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // btnPredict
            // 
            btnPredict.Location = new Point(383, 336);
            btnPredict.Name = "btnPredict";
            btnPredict.Size = new Size(94, 29);
            btnPredict.TabIndex = 5;
            btnPredict.Text = "Predict";
            btnPredict.UseVisualStyleBackColor = true;
            btnPredict.Click += btnPredict_Click;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(291, 180);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(74, 20);
            lblOutput.TabIndex = 6;
            lblOutput.Text = "Output: __";
            // 
            // chkInput0
            // 
            chkInput0.Location = new Point(119, 76);
            chkInput0.Name = "chkInput0";
            chkInput0.Size = new Size(126, 30);
            chkInput0.TabIndex = 7;
            chkInput0.Text = "Input 0";
            chkInput0.UseVisualStyleBackColor = true;
            // 
            // chkInput1
            // 
            chkInput1.AutoSize = true;
            chkInput1.Location = new Point(119, 126);
            chkInput1.Name = "chkInput1";
            chkInput1.Size = new Size(77, 24);
            chkInput1.TabIndex = 8;
            chkInput1.Text = "Input 1";
            chkInput1.UseVisualStyleBackColor = true;
            // 
            // chkInput2
            // 
            chkInput2.AutoSize = true;
            chkInput2.Location = new Point(119, 180);
            chkInput2.Name = "chkInput2";
            chkInput2.Size = new Size(77, 24);
            chkInput2.TabIndex = 9;
            chkInput2.Text = "Input 2";
            chkInput2.UseVisualStyleBackColor = true;
            // 
            // chkInput3
            // 
            chkInput3.AutoSize = true;
            chkInput3.Location = new Point(119, 236);
            chkInput3.Name = "chkInput3";
            chkInput3.Size = new Size(77, 24);
            chkInput3.TabIndex = 10;
            chkInput3.Text = "Input 3";
            chkInput3.UseVisualStyleBackColor = true;
            // 
            // chkInput4
            // 
            chkInput4.AutoSize = true;
            chkInput4.Location = new Point(119, 289);
            chkInput4.Name = "chkInput4";
            chkInput4.Size = new Size(77, 24);
            chkInput4.TabIndex = 11;
            chkInput4.Text = "Input 4";
            chkInput4.UseVisualStyleBackColor = true;
            // 
            // btnTrain
            // 
            btnTrain.Location = new Point(215, 336);
            btnTrain.Name = "btnTrain";
            btnTrain.Size = new Size(94, 29);
            btnTrain.TabIndex = 12;
            btnTrain.Text = "Train";
            btnTrain.UseVisualStyleBackColor = true;
            btnTrain.Click += btnTrain_Click;
            // 
            // comboBoxGate
            // 
            comboBoxGate.FormattingEnabled = true;
            comboBoxGate.Location = new Point(261, 3);
            comboBoxGate.Name = "comboBoxGate";
            comboBoxGate.Size = new Size(151, 28);
            comboBoxGate.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 6);
            label1.Name = "label1";
            label1.Size = new Size(96, 20);
            label1.TabIndex = 14;
            label1.Text = "Select a Gate";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(comboBoxGate);
            Controls.Add(btnTrain);
            Controls.Add(chkInput4);
            Controls.Add(chkInput3);
            Controls.Add(chkInput2);
            Controls.Add(chkInput1);
            Controls.Add(chkInput0);
            Controls.Add(lblOutput);
            Controls.Add(btnPredict);
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPredict;
        private Label lblOutput;
        private CheckBox chkInput0;
        private CheckBox chkInput1;
        private CheckBox chkInput2;
        private CheckBox chkInput3;
        private CheckBox chkInput4;
        private Button btnTrain;
        private ComboBox comboBoxGate;
        private Label label1;
        private BindingSource bindingSource1;
    }
}
