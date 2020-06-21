namespace RAF_Ochimpo
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
            this.addButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tableView = new System.Windows.Forms.DataGridView();
            this.column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_COD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_HireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(132, 50);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Agregar";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(490, 50);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(75, 23);
            this.reportButton.TabIndex = 1;
            this.reportButton.Text = "Ver Reporte!";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(250, 50);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Editar";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(363, 50);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Eliminar";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // tableView
            // 
            this.tableView.AllowUserToAddRows = false;
            this.tableView.AllowUserToDeleteRows = false;
            this.tableView.AllowUserToResizeColumns = false;
            this.tableView.AllowUserToResizeRows = false;
            this.tableView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_ID,
            this.column_COD,
            this.column_FirstName,
            this.column_LastName,
            this.column_HireDate,
            this.column_Salary});
            this.tableView.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.tableView.Location = new System.Drawing.Point(31, 104);
            this.tableView.Name = "tableView";
            this.tableView.ReadOnly = true;
            this.tableView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableView.Size = new System.Drawing.Size(698, 236);
            this.tableView.TabIndex = 4;
            this.tableView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClick);
            // 
            // column_ID
            // 
            this.column_ID.HeaderText = "ID";
            this.column_ID.Name = "column_ID";
            // 
            // column_COD
            // 
            this.column_COD.HeaderText = "Código";
            this.column_COD.Name = "column_COD";
            // 
            // column_FirstName
            // 
            this.column_FirstName.HeaderText = "Nombres";
            this.column_FirstName.Name = "column_FirstName";
            // 
            // column_LastName
            // 
            this.column_LastName.HeaderText = "Apellidos";
            this.column_LastName.Name = "column_LastName";
            // 
            // column_HireDate
            // 
            this.column_HireDate.HeaderText = "Contratado";
            this.column_HireDate.Name = "column_HireDate";
            // 
            // column_Salary
            // 
            this.column_Salary.HeaderText = "Salario";
            this.column_Salary.Name = "column_Salary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableView);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.addButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView tableView;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_COD;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_HireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_Salary;
        private System.Windows.Forms.Label label1;
    }
}

