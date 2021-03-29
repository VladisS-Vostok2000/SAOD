
namespace SAOD_Hash {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.MainFormBttnAdd = new System.Windows.Forms.Button();
            this.MainFormBttnFind = new System.Windows.Forms.Button();
            this.MainFormBttnRemove = new System.Windows.Forms.Button();
            this.MainFormLstbx = new System.Windows.Forms.ListBox();
            this.MainFormTxtbxAdd = new System.Windows.Forms.TextBox();
            this.MainFormTxtbxFind = new System.Windows.Forms.TextBox();
            this.MainFormTxtbxRemove = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MainFormBttnAdd
            // 
            this.MainFormBttnAdd.Location = new System.Drawing.Point(12, 12);
            this.MainFormBttnAdd.Name = "MainFormBttnAdd";
            this.MainFormBttnAdd.Size = new System.Drawing.Size(75, 23);
            this.MainFormBttnAdd.TabIndex = 0;
            this.MainFormBttnAdd.Text = "Добавить";
            this.MainFormBttnAdd.UseVisualStyleBackColor = true;
            this.MainFormBttnAdd.Click += new System.EventHandler(this.MainFormBttnAdd_Click);
            // 
            // MainFormBttnFind
            // 
            this.MainFormBttnFind.Location = new System.Drawing.Point(12, 41);
            this.MainFormBttnFind.Name = "MainFormBttnFind";
            this.MainFormBttnFind.Size = new System.Drawing.Size(75, 23);
            this.MainFormBttnFind.TabIndex = 2;
            this.MainFormBttnFind.Text = "Найти";
            this.MainFormBttnFind.UseVisualStyleBackColor = true;
            this.MainFormBttnFind.Click += new System.EventHandler(this.MainFormBttnFind_Click);
            // 
            // MainFormBttnRemove
            // 
            this.MainFormBttnRemove.Location = new System.Drawing.Point(12, 70);
            this.MainFormBttnRemove.Name = "MainFormBttnRemove";
            this.MainFormBttnRemove.Size = new System.Drawing.Size(75, 23);
            this.MainFormBttnRemove.TabIndex = 4;
            this.MainFormBttnRemove.Text = "Удалить";
            this.MainFormBttnRemove.UseVisualStyleBackColor = true;
            this.MainFormBttnRemove.Click += new System.EventHandler(this.MainFormBttnRemove_Click);
            // 
            // MainFormLstbx
            // 
            this.MainFormLstbx.FormattingEnabled = true;
            this.MainFormLstbx.Location = new System.Drawing.Point(199, 12);
            this.MainFormLstbx.Name = "MainFormLstbx";
            this.MainFormLstbx.Size = new System.Drawing.Size(120, 82);
            this.MainFormLstbx.TabIndex = 1;
            this.MainFormLstbx.TabStop = false;
            // 
            // MainFormTxtbxAdd
            // 
            this.MainFormTxtbxAdd.Location = new System.Drawing.Point(93, 14);
            this.MainFormTxtbxAdd.Name = "MainFormTxtbxAdd";
            this.MainFormTxtbxAdd.Size = new System.Drawing.Size(100, 22);
            this.MainFormTxtbxAdd.TabIndex = 1;
            // 
            // MainFormTxtbxFind
            // 
            this.MainFormTxtbxFind.Location = new System.Drawing.Point(93, 42);
            this.MainFormTxtbxFind.Name = "MainFormTxtbxFind";
            this.MainFormTxtbxFind.Size = new System.Drawing.Size(100, 22);
            this.MainFormTxtbxFind.TabIndex = 3;
            // 
            // MainFormTxtbxRemove
            // 
            this.MainFormTxtbxRemove.Location = new System.Drawing.Point(93, 70);
            this.MainFormTxtbxRemove.Name = "MainFormTxtbxRemove";
            this.MainFormTxtbxRemove.Size = new System.Drawing.Size(100, 22);
            this.MainFormTxtbxRemove.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 111);
            this.Controls.Add(this.MainFormTxtbxRemove);
            this.Controls.Add(this.MainFormTxtbxFind);
            this.Controls.Add(this.MainFormTxtbxAdd);
            this.Controls.Add(this.MainFormLstbx);
            this.Controls.Add(this.MainFormBttnRemove);
            this.Controls.Add(this.MainFormBttnFind);
            this.Controls.Add(this.MainFormBttnAdd);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Hash";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MainFormBttnAdd;
        private System.Windows.Forms.Button MainFormBttnFind;
        private System.Windows.Forms.Button MainFormBttnRemove;
        private System.Windows.Forms.ListBox MainFormLstbx;
        private System.Windows.Forms.TextBox MainFormTxtbxAdd;
        private System.Windows.Forms.TextBox MainFormTxtbxFind;
        private System.Windows.Forms.TextBox MainFormTxtbxRemove;
    }
}

