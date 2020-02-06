namespace CreateDB64TinhThanhFromExcel
{
    partial class Form1
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
            this.btnConvertToJson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConvertToJson
            // 
            this.btnConvertToJson.Location = new System.Drawing.Point(91, 57);
            this.btnConvertToJson.Name = "btnConvertToJson";
            this.btnConvertToJson.Size = new System.Drawing.Size(172, 84);
            this.btnConvertToJson.TabIndex = 0;
            this.btnConvertToJson.Text = "ConvertToJson";
            this.btnConvertToJson.UseVisualStyleBackColor = true;
            this.btnConvertToJson.Click += new System.EventHandler(this.btnConvertToJson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 272);
            this.Controls.Add(this.btnConvertToJson);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvertToJson;
    }
}

