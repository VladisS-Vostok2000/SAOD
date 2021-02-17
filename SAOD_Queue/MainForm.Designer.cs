
namespace SAOD_Queue {
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
            this.components = new System.ComponentModel.Container();
            this.MainFormTxtbxNewTalon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MainFormLblWindow1Timer = new System.Windows.Forms.Label();
            this.MainFormLblWindow2Timer = new System.Windows.Forms.Label();
            this.MainFormLblWindow3Timer = new System.Windows.Forms.Label();
            this.MainFormBttnGetTalon = new System.Windows.Forms.Button();
            this.MainFormTmrWindow1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.MainFormTmrWindow2 = new System.Windows.Forms.Timer(this.components);
            this.MainFormTmrWindow3 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.MainFormTrckbrSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.MainFormTrckbrSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // MainFormTxtbxNewTalon
            // 
            this.MainFormTxtbxNewTalon.Location = new System.Drawing.Point(12, 25);
            this.MainFormTxtbxNewTalon.Name = "MainFormTxtbxNewTalon";
            this.MainFormTxtbxNewTalon.ReadOnly = true;
            this.MainFormTxtbxNewTalon.Size = new System.Drawing.Size(181, 20);
            this.MainFormTxtbxNewTalon.TabIndex = 0;
            this.MainFormTxtbxNewTalon.TextChanged += new System.EventHandler(this.MainFormTxtbxNewTalon_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер талона и окна появится здесь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Окно 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Окно 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Окно 3";
            // 
            // MainFormLblWindow1Timer
            // 
            this.MainFormLblWindow1Timer.AutoSize = true;
            this.MainFormLblWindow1Timer.Location = new System.Drawing.Point(12, 61);
            this.MainFormLblWindow1Timer.Name = "MainFormLblWindow1Timer";
            this.MainFormLblWindow1Timer.Size = new System.Drawing.Size(28, 13);
            this.MainFormLblWindow1Timer.TabIndex = 2;
            this.MainFormLblWindow1Timer.Text = "0:00";
            // 
            // MainFormLblWindow2Timer
            // 
            this.MainFormLblWindow2Timer.AutoSize = true;
            this.MainFormLblWindow2Timer.Location = new System.Drawing.Point(80, 61);
            this.MainFormLblWindow2Timer.Name = "MainFormLblWindow2Timer";
            this.MainFormLblWindow2Timer.Size = new System.Drawing.Size(28, 13);
            this.MainFormLblWindow2Timer.TabIndex = 2;
            this.MainFormLblWindow2Timer.Text = "0:00";
            // 
            // MainFormLblWindow3Timer
            // 
            this.MainFormLblWindow3Timer.AutoSize = true;
            this.MainFormLblWindow3Timer.Location = new System.Drawing.Point(151, 61);
            this.MainFormLblWindow3Timer.Name = "MainFormLblWindow3Timer";
            this.MainFormLblWindow3Timer.Size = new System.Drawing.Size(28, 13);
            this.MainFormLblWindow3Timer.TabIndex = 2;
            this.MainFormLblWindow3Timer.Text = "0:00";
            // 
            // MainFormBttnGetTalon
            // 
            this.MainFormBttnGetTalon.Location = new System.Drawing.Point(12, 77);
            this.MainFormBttnGetTalon.Name = "MainFormBttnGetTalon";
            this.MainFormBttnGetTalon.Size = new System.Drawing.Size(181, 23);
            this.MainFormBttnGetTalon.TabIndex = 3;
            this.MainFormBttnGetTalon.Text = "Получить талон";
            this.MainFormBttnGetTalon.UseVisualStyleBackColor = true;
            this.MainFormBttnGetTalon.Click += new System.EventHandler(this.MainFormBttnGetTalon_Click);
            // 
            // MainFormTmrWindow1
            // 
            this.MainFormTmrWindow1.Interval = 1000;
            // 
            // MainFormTmrWindow2
            // 
            this.MainFormTmrWindow2.Interval = 1000;
            // 
            // MainFormTmrWindow3
            // 
            this.MainFormTmrWindow3.Interval = 1000;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Время";
            // 
            // MainFormTrckbrSpeed
            // 
            this.MainFormTrckbrSpeed.Location = new System.Drawing.Point(13, 120);
            this.MainFormTrckbrSpeed.Maximum = 200;
            this.MainFormTrckbrSpeed.Minimum = 1;
            this.MainFormTrckbrSpeed.Name = "MainFormTrckbrSpeed";
            this.MainFormTrckbrSpeed.Size = new System.Drawing.Size(180, 45);
            this.MainFormTrckbrSpeed.SmallChange = 5;
            this.MainFormTrckbrSpeed.TabIndex = 5;
            this.MainFormTrckbrSpeed.TickFrequency = 5;
            this.MainFormTrckbrSpeed.Value = 100;
            this.MainFormTrckbrSpeed.Scroll += new System.EventHandler(this.MainFormTrckbrSpeed_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 166);
            this.Controls.Add(this.MainFormTrckbrSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MainFormBttnGetTalon);
            this.Controls.Add(this.MainFormLblWindow3Timer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MainFormLblWindow2Timer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MainFormLblWindow1Timer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainFormTxtbxNewTalon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(238, 205);
            this.Name = "MainForm";
            this.Text = "Очередь";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainFormTrckbrSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MainFormTxtbxNewTalon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label MainFormLblWindow1Timer;
        private System.Windows.Forms.Label MainFormLblWindow2Timer;
        private System.Windows.Forms.Label MainFormLblWindow3Timer;
        private System.Windows.Forms.Button MainFormBttnGetTalon;
        private System.Windows.Forms.Timer MainFormTmrWindow1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer MainFormTmrWindow2;
        private System.Windows.Forms.Timer MainFormTmrWindow3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar MainFormTrckbrSpeed;
    }
}

