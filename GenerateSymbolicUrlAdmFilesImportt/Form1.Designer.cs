namespace GenerateSymbolicUrlAdmFilesImportt
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSsoDisposition = new System.Windows.Forms.ComboBox();
            this.dgArguments = new System.Windows.Forms.DataGridView();
            this.clmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRequiredArgument = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnArgumentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmnArgumentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAppendAsArgument = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnSubstituateInText = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUrlName = new System.Windows.Forms.TextBox();
            this.fileDialogSessionName = new System.Windows.Forms.SaveFileDialog();
            this.btnRemoveArgument = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgArguments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(42, 29);
            this.txtURL.MaxLength = 250;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(592, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "http://www.google.com";
            this.txtURL.Validating += new System.ComponentModel.CancelEventHandler(this.txtURL_Validating);
            this.txtURL.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "SSO Disposition";
            // 
            // cmdSsoDisposition
            // 
            this.cmdSsoDisposition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdSsoDisposition.FormattingEnabled = true;
            this.cmdSsoDisposition.Items.AddRange(new object[] {
            "Form Redirect",
            "Server Redirect",
            "Inline",
            "IFrame",
            "WebControl"});
            this.cmdSsoDisposition.Location = new System.Drawing.Point(90, 58);
            this.cmdSsoDisposition.Name = "cmdSsoDisposition";
            this.cmdSsoDisposition.Size = new System.Drawing.Size(111, 21);
            this.cmdSsoDisposition.TabIndex = 2;
            // 
            // dgArguments
            // 
            this.dgArguments.AllowUserToOrderColumns = true;
            this.dgArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgArguments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArguments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnName,
            this.clmnRequiredArgument,
            this.clmnArgumentType,
            this.clmnArgumentValue,
            this.clmnSequence,
            this.clmnAppendAsArgument,
            this.clmnSubstituateInText});
            this.dgArguments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgArguments.Location = new System.Drawing.Point(3, 115);
            this.dgArguments.Name = "dgArguments";
            this.dgArguments.Size = new System.Drawing.Size(746, 186);
            this.dgArguments.TabIndex = 3;
            this.dgArguments.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgArguments_CellEndEdit);
            this.dgArguments.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgArguments_CellValidating);
            this.dgArguments.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgArguments_DefaultValuesNeeded);
            this.dgArguments.Validating += new System.ComponentModel.CancelEventHandler(this.dgArguments_Validating);
            // 
            // clmnName
            // 
            this.clmnName.HeaderText = "Name";
            this.clmnName.MaxInputLength = 100;
            this.clmnName.Name = "clmnName";
            // 
            // clmnRequiredArgument
            // 
            this.clmnRequiredArgument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmnRequiredArgument.HeaderText = "Required Argument";
            this.clmnRequiredArgument.Name = "clmnRequiredArgument";
            this.clmnRequiredArgument.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmnArgumentType
            // 
            this.clmnArgumentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmnArgumentType.HeaderText = "Argument Type";
            this.clmnArgumentType.Items.AddRange(new object[] {
            "Constant",
            "Field",
            "URL Argument",
            "Language Value",
            "Command",
            "Profile Attribute",
            "Field - All Values"});
            this.clmnArgumentType.Name = "clmnArgumentType";
            this.clmnArgumentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmnArgumentValue
            // 
            this.clmnArgumentValue.HeaderText = "Argument Value";
            this.clmnArgumentValue.MaxInputLength = 100;
            this.clmnArgumentValue.Name = "clmnArgumentValue";
            this.clmnArgumentValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clmnSequence
            // 
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.clmnSequence.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmnSequence.HeaderText = "Sequence #";
            this.clmnSequence.MaxInputLength = 22;
            this.clmnSequence.Name = "clmnSequence";
            // 
            // clmnAppendAsArgument
            // 
            this.clmnAppendAsArgument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmnAppendAsArgument.HeaderText = "Append As Argument";
            this.clmnAppendAsArgument.Name = "clmnAppendAsArgument";
            this.clmnAppendAsArgument.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmnSubstituateInText
            // 
            this.clmnSubstituateInText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmnSubstituateInText.HeaderText = "Substituate In Text";
            this.clmnSubstituateInText.Name = "clmnSubstituateInText";
            this.clmnSubstituateInText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // txtUrlName
            // 
            this.txtUrlName.Location = new System.Drawing.Point(42, -1);
            this.txtUrlName.MaxLength = 100;
            this.txtUrlName.Name = "txtUrlName";
            this.txtUrlName.Size = new System.Drawing.Size(338, 20);
            this.txtUrlName.TabIndex = 0;
            this.txtUrlName.Text = "ITO ";
            this.txtUrlName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUrlName_Validating);
            this.txtUrlName.Validated += new System.EventHandler(this.Control_Validated);
            // 
            // fileDialogSessionName
            // 
            this.fileDialogSessionName.RestoreDirectory = true;
            this.fileDialogSessionName.Title = "Session Name";
            // 
            // btnRemoveArgument
            // 
            this.btnRemoveArgument.Location = new System.Drawing.Point(3, 86);
            this.btnRemoveArgument.Name = "btnRemoveArgument";
            this.btnRemoveArgument.Size = new System.Drawing.Size(105, 23);
            this.btnRemoveArgument.TabIndex = 5;
            this.btnRemoveArgument.Text = "Remove argument";
            this.btnRemoveArgument.UseVisualStyleBackColor = true;
            this.btnRemoveArgument.Click += new System.EventHandler(this.btnRemoveArgument_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Argument Value";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = "0";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn3.HeaderText = "Sequence #";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 22;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 342);
            this.Controls.Add(this.btnRemoveArgument);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgArguments);
            this.Controls.Add(this.cmdSsoDisposition);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.txtUrlName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Validating += new System.ComponentModel.CancelEventHandler(this.Form1_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.dgArguments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmdSsoDisposition;
        private System.Windows.Forms.DataGridView dgArguments;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrlName;
        private System.Windows.Forms.SaveFileDialog fileDialogSessionName;
        private System.Windows.Forms.Button btnRemoveArgument;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnRequiredArgument;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmnArgumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnArgumentValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnSequence;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnAppendAsArgument;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnSubstituateInText;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

