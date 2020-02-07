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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConvertToJson
            // 
            this.btnConvertToJson.Location = new System.Drawing.Point(91, 25);
            this.btnConvertToJson.Name = "btnConvertToJson";
            this.btnConvertToJson.Size = new System.Drawing.Size(172, 84);
            this.btnConvertToJson.TabIndex = 0;
            this.btnConvertToJson.Text = "ConvertToJson";
            this.btnConvertToJson.UseVisualStyleBackColor = true;
            this.btnConvertToJson.Click += new System.EventHandler(this.btnConvertToJson_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "fix file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 87);
            this.button2.TabIndex = 2;
            this.button2.Text = "UTF8 without BOM";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 371);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConvertToJson);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvertToJson;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

