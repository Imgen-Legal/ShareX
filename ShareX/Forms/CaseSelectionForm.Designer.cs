using System.Drawing;
using System.Windows.Forms;

namespace ShareX.Forms
{
    partial class CaseSelectionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.infoLabel = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.btnRedirect = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.infoLabel.Location = new System.Drawing.Point(12, 19);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(281, 20);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Enter case or patient and click Search:";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOk.Location = new System.Drawing.Point(16, 102);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(297, 34);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(319, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(296, 34);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // searchComboBox
            // 
            this.searchComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.searchComboBox.DropDownHeight = 400;
            this.searchComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchComboBox.ForeColor = System.Drawing.SystemColors.Window;
            this.searchComboBox.FormattingEnabled = true;
            this.searchComboBox.IntegralHeight = false;
            this.searchComboBox.Location = new System.Drawing.Point(16, 57);
            this.searchComboBox.Name = "searchComboBox";
            this.searchComboBox.Size = new System.Drawing.Size(473, 28);
            this.searchComboBox.TabIndex = 1;
            // 
            // btnRedirect
            // 
            this.btnRedirect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnRedirect.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnRedirect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedirect.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRedirect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedirect.Location = new System.Drawing.Point(495, 19);
            this.btnRedirect.Name = "btnRedirect";
            this.btnRedirect.Size = new System.Drawing.Size(120, 30);
            this.btnRedirect.TabIndex = 5;
            this.btnRedirect.Text = "Add Case";
            this.btnRedirect.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSearch.Location = new System.Drawing.Point(495, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // CaseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(632, 162);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRedirect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.searchComboBox);
            this.Controls.Add(this.infoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CaseSelectionForm";
            this.Text = "CaseSelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRedirect;
        private System.Windows.Forms.Button btnSearch;
    }
}