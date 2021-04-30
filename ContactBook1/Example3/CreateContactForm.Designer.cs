
namespace Example3
{
    partial class CreateContactForm
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
            this.components = new System.ComponentModel.Container();
            this.nameTxtBx = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.phoneTxtBx = new System.Windows.Forms.TextBox();
            this.addressTxtBx = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTxtBx
            // 
            this.nameTxtBx.Location = new System.Drawing.Point(76, 26);
            this.nameTxtBx.Name = "nameTxtBx";
            this.nameTxtBx.Size = new System.Drawing.Size(186, 20);
            this.nameTxtBx.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // phoneTxtBx
            // 
            this.phoneTxtBx.Location = new System.Drawing.Point(76, 61);
            this.phoneTxtBx.Name = "phoneTxtBx";
            this.phoneTxtBx.Size = new System.Drawing.Size(186, 20);
            this.phoneTxtBx.TabIndex = 2;
            // 
            // addressTxtBx
            // 
            this.addressTxtBx.Location = new System.Drawing.Point(76, 96);
            this.addressTxtBx.Name = "addressTxtBx";
            this.addressTxtBx.Size = new System.Drawing.Size(186, 20);
            this.addressTxtBx.TabIndex = 3;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(24, 29);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(33, 13);
            this.name.TabIndex = 4;
            this.name.Text = "name";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Location = new System.Drawing.Point(24, 64);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(37, 13);
            this.phone.TabIndex = 5;
            this.phone.Text = "phone";
            // 
            // address
            // 
            this.address.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.address.AutoSize = true;
            this.address.Location = new System.Drawing.Point(24, 103);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(44, 13);
            this.address.TabIndex = 6;
            this.address.Text = "address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreateContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.address);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.name);
            this.Controls.Add(this.addressTxtBx);
            this.Controls.Add(this.phoneTxtBx);
            this.Controls.Add(this.nameTxtBx);
            this.Name = "CreateContactForm";
            this.Text = "CreateContactForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox nameTxtBx;
        public System.Windows.Forms.TextBox phoneTxtBx;
        public System.Windows.Forms.TextBox addressTxtBx;
    }
}