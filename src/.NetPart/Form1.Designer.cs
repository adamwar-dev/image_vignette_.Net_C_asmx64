
namespace ProjectAssembler
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxUpload = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.uploadButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.textResult = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.timeResult = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.threadsNumber = new System.Windows.Forms.Label();
            this.cPlusPlus = new System.Windows.Forms.CheckBox();
            this.asm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxUpload
            // 
            this.pictureBoxUpload.Location = new System.Drawing.Point(49, 21);
            this.pictureBoxUpload.Name = "pictureBoxUpload";
            this.pictureBoxUpload.Size = new System.Drawing.Size(288, 198);
            this.pictureBoxUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUpload.TabIndex = 4;
            this.pictureBoxUpload.TabStop = false;
            this.pictureBoxUpload.Click += new System.EventHandler(this.pictureBoxUpload_Click);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(452, 21);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(297, 198);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 5;
            this.pictureBoxResult.TabStop = false;
            this.pictureBoxResult.Click += new System.EventHandler(this.pictureBoxResult_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uploadButton.Location = new System.Drawing.Point(74, 235);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(108, 40);
            this.uploadButton.TabIndex = 6;
            this.uploadButton.TabStop = false;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // runButton
            // 
            this.runButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.runButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.runButton.Location = new System.Drawing.Point(203, 235);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(108, 40);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // textResult
            // 
            this.textResult.AutoSize = true;
            this.textResult.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textResult.Location = new System.Drawing.Point(449, 247);
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(42, 16);
            this.textResult.TabIndex = 11;
            this.textResult.Text = "Done";
            this.textResult.Click += new System.EventHandler(this.textResult_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.saveButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(540, 235);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 40);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // timeResult
            // 
            this.timeResult.AutoSize = true;
            this.timeResult.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeResult.Location = new System.Drawing.Point(681, 247);
            this.timeResult.Name = "timeResult";
            this.timeResult.Size = new System.Drawing.Size(54, 16);
            this.timeResult.TabIndex = 13;
            this.timeResult.Text = "Time: 0";
            this.timeResult.Click += new System.EventHandler(this.timeResult_Click);
            // 
            // trackBar
            // 
            this.trackBar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.trackBar.Location = new System.Drawing.Point(131, 344);
            this.trackBar.Maximum = 64;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(559, 56);
            this.trackBar.TabIndex = 14;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // threadsNumber
            // 
            this.threadsNumber.AutoSize = true;
            this.threadsNumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.threadsNumber.Location = new System.Drawing.Point(322, 383);
            this.threadsNumber.Name = "threadsNumber";
            this.threadsNumber.Size = new System.Drawing.Size(124, 17);
            this.threadsNumber.TabIndex = 15;
            this.threadsNumber.Text = "Threads number: ";
            this.threadsNumber.Click += new System.EventHandler(this.threadsNumber_Click);
            // 
            // cPlusPlus
            // 
            this.cPlusPlus.AutoSize = true;
            this.cPlusPlus.Location = new System.Drawing.Point(365, 274);
            this.cPlusPlus.Name = "cPlusPlus";
            this.cPlusPlus.Size = new System.Drawing.Size(55, 21);
            this.cPlusPlus.TabIndex = 16;
            this.cPlusPlus.Text = "C++";
            this.cPlusPlus.UseVisualStyleBackColor = true;
            this.cPlusPlus.CheckedChanged += new System.EventHandler(this.cSharp_CheckedChanged);
            // 
            // asm
            // 
            this.asm.AutoSize = true;
            this.asm.Location = new System.Drawing.Point(365, 301);
            this.asm.Name = "asm";
            this.asm.Size = new System.Drawing.Size(56, 21);
            this.asm.TabIndex = 17;
            this.asm.Text = "asm";
            this.asm.UseVisualStyleBackColor = true;
            this.asm.CheckedChanged += new System.EventHandler(this.asm_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.asm);
            this.Controls.Add(this.cPlusPlus);
            this.Controls.Add(this.threadsNumber);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.timeResult);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxUpload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxUpload;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label textResult;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label timeResult;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label threadsNumber;
        private System.Windows.Forms.CheckBox cPlusPlus;
        private System.Windows.Forms.CheckBox asm;
    }
}

