namespace CRA.ModelLayer.ACC
{
    partial class ACC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACC));
            this.btnLoadDomainClasses = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmbMainMethod = new System.Windows.Forms.ComboBox();
            this.chkIncludeAgromanagementActEvents = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOpenACCDefinition = new System.Windows.Forms.Button();
            this.txtIStrategyPostfix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblXMLFileName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnResetDomainClasses = new System.Windows.Forms.Button();
            this.btnDeveloper = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataSetACCDefinitions = new System.Data.DataSet();
            this.dataTableSpecifications = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataTableDomainClases = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataTableParamDescriptions = new System.Data.DataTable();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataTableClassDescriptions = new System.Data.DataTable();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetACCDefinitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSpecifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDomainClases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableParamDescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableClassDescriptions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadDomainClasses
            // 
            this.btnLoadDomainClasses.Location = new System.Drawing.Point(12, 121);
            this.btnLoadDomainClasses.Name = "btnLoadDomainClasses";
            this.btnLoadDomainClasses.Size = new System.Drawing.Size(195, 23);
            this.btnLoadDomainClasses.TabIndex = 0;
            this.btnLoadDomainClasses.Text = "Load Domain Classes";
            this.btnLoadDomainClasses.UseVisualStyleBackColor = true;
            this.btnLoadDomainClasses.Click += new System.EventHandler(this.btnLoadDomainClasses_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 152);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(195, 147);
            this.listBox1.TabIndex = 1;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // cmbMainMethod
            // 
            this.cmbMainMethod.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMainMethod.FormattingEnabled = true;
            this.cmbMainMethod.Items.AddRange(new object[] {
            "Estimate",
            "Update"});
            this.cmbMainMethod.Location = new System.Drawing.Point(245, 138);
            this.cmbMainMethod.Name = "cmbMainMethod";
            this.cmbMainMethod.Size = new System.Drawing.Size(105, 24);
            this.cmbMainMethod.TabIndex = 2;
            this.cmbMainMethod.TextChanged += new System.EventHandler(this.cmbMainMethod_TextChanged);
            // 
            // chkIncludeAgromanagementActEvents
            // 
            this.chkIncludeAgromanagementActEvents.AutoSize = true;
            this.chkIncludeAgromanagementActEvents.Location = new System.Drawing.Point(230, 269);
            this.chkIncludeAgromanagementActEvents.Name = "chkIncludeAgromanagementActEvents";
            this.chkIncludeAgromanagementActEvents.Size = new System.Drawing.Size(148, 17);
            this.chkIncludeAgromanagementActEvents.TabIndex = 3;
            this.chkIncludeAgromanagementActEvents.Text = "Include AgroManagement";
            this.chkIncludeAgromanagementActEvents.UseVisualStyleBackColor = true;
            this.chkIncludeAgromanagementActEvents.CheckedChanged += new System.EventHandler(this.chkIncludeAgromanagementActEvents_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select or enter name of the calculate method";
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.Location = new System.Drawing.Point(219, 310);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(89, 23);
            this.btnSaveXML.TabIndex = 5;
            this.btnSaveXML.Text = "save XML";
            this.btnSaveXML.UseVisualStyleBackColor = true;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXML_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(329, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "namespace loaded from first domain class selected";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtParameters);
            this.groupBox1.Location = new System.Drawing.Point(221, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 117);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "method parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "ActEvents";
            // 
            // txtParameters
            // 
            this.txtParameters.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParameters.Location = new System.Drawing.Point(7, 18);
            this.txtParameters.Multiline = true;
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(465, 66);
            this.txtParameters.TabIndex = 0;
            this.txtParameters.Text = "();";
            this.txtParameters.Leave += new System.EventHandler(this.txtParameters_Leave);
            // 
            // lblNamespace
            // 
            this.lblNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNamespace.Location = new System.Drawing.Point(13, 68);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(311, 23);
            this.lblNamespace.TabIndex = 0;
            this.lblNamespace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNamespace.TextChanged += new System.EventHandler(this.lblNamespace_TextChanged);
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Location = new System.Drawing.Point(314, 310);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(85, 23);
            this.btnGenerateCode.TabIndex = 8;
            this.btnGenerateCode.Text = "generate code";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(543, 310);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(624, 310);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOpenACCDefinition
            // 
            this.btnOpenACCDefinition.Location = new System.Drawing.Point(12, 16);
            this.btnOpenACCDefinition.Name = "btnOpenACCDefinition";
            this.btnOpenACCDefinition.Size = new System.Drawing.Size(130, 23);
            this.btnOpenACCDefinition.TabIndex = 11;
            this.btnOpenACCDefinition.Text = "Open API definition";
            this.btnOpenACCDefinition.UseVisualStyleBackColor = true;
            this.btnOpenACCDefinition.Click += new System.EventHandler(this.btnOpenACCDefinition_Click);
            // 
            // txtIStrategyPostfix
            // 
            this.txtIStrategyPostfix.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIStrategyPostfix.Location = new System.Drawing.Point(244, 109);
            this.txtIStrategyPostfix.Name = "txtIStrategyPostfix";
            this.txtIStrategyPostfix.Size = new System.Drawing.Size(106, 22);
            this.txtIStrategyPostfix.TabIndex = 12;
            this.txtIStrategyPostfix.TextChanged += new System.EventHandler(this.txtIStrategyPostfix_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Enter postfix for the                           -  inherited interface name";
            // 
            // lblXMLFileName
            // 
            this.lblXMLFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblXMLFileName.Location = new System.Drawing.Point(158, 7);
            this.lblXMLFileName.Name = "lblXMLFileName";
            this.lblXMLFileName.Size = new System.Drawing.Size(535, 51);
            this.lblXMLFileName.TabIndex = 14;
            this.lblXMLFileName.Text = "XML file name";
            this.lblXMLFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(449, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "IStrategy";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnResetDomainClasses
            // 
            this.btnResetDomainClasses.Location = new System.Drawing.Point(13, 309);
            this.btnResetDomainClasses.Name = "btnResetDomainClasses";
            this.btnResetDomainClasses.Size = new System.Drawing.Size(194, 23);
            this.btnResetDomainClasses.TabIndex = 16;
            this.btnResetDomainClasses.Text = "Reset Domain Classes";
            this.btnResetDomainClasses.UseVisualStyleBackColor = true;
            this.btnResetDomainClasses.Click += new System.EventHandler(this.btnResetDomainClasses_Click);
            // 
            // btnDeveloper
            // 
            this.btnDeveloper.Location = new System.Drawing.Point(424, 310);
            this.btnDeveloper.Name = "btnDeveloper";
            this.btnDeveloper.Size = new System.Drawing.Size(90, 23);
            this.btnDeveloper.TabIndex = 17;
            this.btnDeveloper.Text = "developer";
            this.btnDeveloper.UseVisualStyleBackColor = true;
            this.btnDeveloper.Click += new System.EventHandler(this.btnDeveloper_Click);
            // 
            // dataSetACCDefinitions
            // 
            this.dataSetACCDefinitions.DataSetName = "API_Definitions";
            this.dataSetACCDefinitions.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableSpecifications,
            this.dataTableDomainClases,
            this.dataTableParamDescriptions,
            this.dataTableClassDescriptions});
            // 
            // dataTableSpecifications
            // 
            this.dataTableSpecifications.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn6});
            this.dataTableSpecifications.TableName = "Specifications";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "FileName";
            this.dataColumn1.ColumnName = "Col_FileName";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Postfix";
            this.dataColumn2.ColumnName = "Col_Postfix";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "MainMethod";
            this.dataColumn3.ColumnName = "Col_MainMethod";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "MethodParameters";
            this.dataColumn4.ColumnName = "Col_MethodParameters";
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "NameSpace";
            this.dataColumn6.ColumnName = "Col_NameSpace";
            // 
            // dataTableDomainClases
            // 
            this.dataTableDomainClases.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn5});
            this.dataTableDomainClases.TableName = "DomainClasses";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "ClassFileNames";
            this.dataColumn5.ColumnName = "Col_ClassFileNames";
            // 
            // dataTableParamDescriptions
            // 
            this.dataTableParamDescriptions.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9});
            this.dataTableParamDescriptions.TableName = "ParamDescriptions";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "ParamName";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "ClassDescription";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "ClassName";
            // 
            // dataTableClassDescriptions
            // 
            this.dataTableClassDescriptions.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn10,
            this.dataColumn11});
            this.dataTableClassDescriptions.TableName = "ClassDescriptions";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "ClassName";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "ClassDescription";
            // 
            // ACC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 345);
            this.Controls.Add(this.btnDeveloper);
            this.Controls.Add(this.btnResetDomainClasses);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblXMLFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIStrategyPostfix);
            this.Controls.Add(this.btnOpenACCDefinition);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.lblNamespace);
            this.Controls.Add(this.chkIncludeAgromanagementActEvents);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveXML);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMainMethod);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnLoadDomainClasses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ACC";
            this.Text = "API Class Coder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetACCDefinitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSpecifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDomainClases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableParamDescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableClassDescriptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDomainClasses;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cmbMainMethod;
        private System.Windows.Forms.CheckBox chkIncludeAgromanagementActEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveXML;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOpenACCDefinition;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.TextBox txtIStrategyPostfix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblXMLFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnResetDomainClasses;
        private System.Windows.Forms.Button btnDeveloper;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Data.DataSet dataSetACCDefinitions;
        private System.Data.DataTable dataTableSpecifications;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataTable dataTableDomainClases;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataTable dataTableParamDescriptions;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataTable dataTableClassDescriptions;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
    }
}

