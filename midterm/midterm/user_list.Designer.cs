namespace midterm
{
    partial class user_list
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.midtermDataSet = new midterm.midtermDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new midterm.midtermDataSetTableAdapters.usersTableAdapter();
            this.usercnicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useremailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userpassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userisLockedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.useridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midtermDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(-8, -20);
            this.panel1.MaximumSize = new System.Drawing.Size(917, 541);
            this.panel1.MinimumSize = new System.Drawing.Size(917, 541);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 541);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usercnicDataGridViewTextBoxColumn,
            this.useremailDataGridViewTextBoxColumn,
            this.userpassDataGridViewTextBoxColumn,
            this.userisLockedDataGridViewCheckBoxColumn,
            this.useridDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.usersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(155, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 361);
            this.dataGridView1.TabIndex = 0;
            // 
            // midtermDataSet
            // 
            this.midtermDataSet.DataSetName = "midtermDataSet";
            this.midtermDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            this.usersBindingSource.DataSource = this.midtermDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // usercnicDataGridViewTextBoxColumn
            // 
            this.usercnicDataGridViewTextBoxColumn.DataPropertyName = "user_cnic";
            this.usercnicDataGridViewTextBoxColumn.HeaderText = "user_cnic";
            this.usercnicDataGridViewTextBoxColumn.Name = "usercnicDataGridViewTextBoxColumn";
            // 
            // useremailDataGridViewTextBoxColumn
            // 
            this.useremailDataGridViewTextBoxColumn.DataPropertyName = "user_email";
            this.useremailDataGridViewTextBoxColumn.HeaderText = "user_email";
            this.useremailDataGridViewTextBoxColumn.Name = "useremailDataGridViewTextBoxColumn";
            // 
            // userpassDataGridViewTextBoxColumn
            // 
            this.userpassDataGridViewTextBoxColumn.DataPropertyName = "user_pass";
            this.userpassDataGridViewTextBoxColumn.HeaderText = "user_pass";
            this.userpassDataGridViewTextBoxColumn.Name = "userpassDataGridViewTextBoxColumn";
            // 
            // userisLockedDataGridViewCheckBoxColumn
            // 
            this.userisLockedDataGridViewCheckBoxColumn.DataPropertyName = "user_isLocked";
            this.userisLockedDataGridViewCheckBoxColumn.HeaderText = "user_isLocked";
            this.userisLockedDataGridViewCheckBoxColumn.Name = "userisLockedDataGridViewCheckBoxColumn";
            // 
            // useridDataGridViewTextBoxColumn
            // 
            this.useridDataGridViewTextBoxColumn.DataPropertyName = "user_id";
            this.useridDataGridViewTextBoxColumn.HeaderText = "user_id";
            this.useridDataGridViewTextBoxColumn.Name = "useridDataGridViewTextBoxColumn";
            this.useridDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Gill Sans MT", 13F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(361, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 27);
            this.label5.TabIndex = 30;
            this.label5.Text = "All Users";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(323, 461);
            this.button1.MinimumSize = new System.Drawing.Size(131, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back to Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // user_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 502);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(917, 541);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(917, 541);
            this.Name = "user_list";
            this.ShowIcon = false;
            this.Text = "All Users";
            this.Load += new System.EventHandler(this.user_list_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midtermDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private midtermDataSet midtermDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private midtermDataSetTableAdapters.usersTableAdapter usersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn usercnicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn useremailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userpassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn userisLockedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn useridDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}