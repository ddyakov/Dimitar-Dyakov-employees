namespace PairOfEmployees
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
            filePathTxt = new TextBox();
            browseBtn = new Button();
            dataGridView = new DataGridView();
            FirstEmployeeId = new DataGridViewTextBoxColumn();
            SecondEmployeeId = new DataGridViewTextBoxColumn();
            ProjectId = new DataGridViewTextBoxColumn();
            DaysWorked = new DataGridViewTextBoxColumn();
            longestWorkingPairDtoBindingSource = new BindingSource(components);
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)longestWorkingPairDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // filePathTxt
            // 
            filePathTxt.BackColor = SystemColors.ScrollBar;
            filePathTxt.Enabled = false;
            filePathTxt.ForeColor = SystemColors.WindowFrame;
            filePathTxt.Location = new Point(12, 24);
            filePathTxt.Name = "filePathTxt";
            filePathTxt.Size = new Size(546, 31);
            filePathTxt.TabIndex = 0;
            // 
            // browseBtn
            // 
            browseBtn.Location = new Point(564, 24);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(112, 31);
            browseBtn.TabIndex = 1;
            browseBtn.Text = "Browse";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { FirstEmployeeId, SecondEmployeeId, ProjectId, DaysWorked });
            dataGridView.Location = new Point(12, 120);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(664, 314);
            dataGridView.TabIndex = 2;
            // 
            // FirstEmployeeId
            // 
            FirstEmployeeId.HeaderText = "Employee ID #1";
            FirstEmployeeId.MinimumWidth = 8;
            FirstEmployeeId.Name = "FirstEmployeeId";
            FirstEmployeeId.ReadOnly = true;
            FirstEmployeeId.Width = 150;
            // 
            // SecondEmployeeId
            // 
            SecondEmployeeId.HeaderText = "Employee ID #2";
            SecondEmployeeId.MinimumWidth = 8;
            SecondEmployeeId.Name = "SecondEmployeeId";
            SecondEmployeeId.ReadOnly = true;
            SecondEmployeeId.Width = 150;
            // 
            // ProjectId
            // 
            ProjectId.HeaderText = "Project ID";
            ProjectId.MinimumWidth = 8;
            ProjectId.Name = "ProjectId";
            ProjectId.ReadOnly = true;
            ProjectId.Width = 150;
            // 
            // DaysWorked
            // 
            DaysWorked.HeaderText = "Days worked";
            DaysWorked.MinimumWidth = 8;
            DaysWorked.Name = "DaysWorked";
            DaysWorked.ReadOnly = true;
            DaysWorked.Width = 150;
            // 
            // longestWorkingPairDtoBindingSource
            // 
            longestWorkingPairDtoBindingSource.DataSource = typeof(LongestWorkingPairDto);
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(12, 75);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 25);
            lblInfo.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 449);
            Controls.Add(lblInfo);
            Controls.Add(dataGridView);
            Controls.Add(browseBtn);
            Controls.Add(filePathTxt);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)longestWorkingPairDtoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox filePathTxt;
        private Button browseBtn;
        private DataGridView dataGridView;
        private BindingSource longestWorkingPairDtoBindingSource;
        private DataGridViewTextBoxColumn FirstEmployeeId;
        private DataGridViewTextBoxColumn SecondEmployeeId;
        private DataGridViewTextBoxColumn ProjectId;
        private DataGridViewTextBoxColumn DaysWorked;
        private Label lblInfo;
    }
}
