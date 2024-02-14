namespace EnvioWhatsApp.View;
    partial class EnvioWhatsListForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvioWhatsListForm));
        gbxMessages = new GroupBox();
        lblCountMessages = new Label();
        MessageQueueTable = new DataGridView();
        btnSendMessage = new Button();
        btnStopMessage = new Button();
        gbxMessages.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MessageQueueTable).BeginInit();
        SuspendLayout();
        // 
        // gbxMessages
        // 
        gbxMessages.Controls.Add(lblCountMessages);
        gbxMessages.Controls.Add(MessageQueueTable);
        gbxMessages.Location = new Point(12, 12);
        gbxMessages.Name = "gbxMessages";
        gbxMessages.Size = new Size(999, 473);
        gbxMessages.TabIndex = 1;
        gbxMessages.TabStop = false;
        gbxMessages.Text = "Mensagens Na Fila";
        gbxMessages.Enter += groupBox1_Enter;
        // 
        // lblCountMessages
        // 
        lblCountMessages.AutoSize = true;
        lblCountMessages.Location = new Point(18, 446);
        lblCountMessages.Name = "lblCountMessages";
        lblCountMessages.Size = new Size(148, 15);
        lblCountMessages.TabIndex = 2;
        lblCountMessages.Text = "Quantidade de Registros: 0";
        lblCountMessages.Click += label1_Click;
        // 
        // MessageQueueTable
        // 
        MessageQueueTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        MessageQueueTable.BackgroundColor = SystemColors.Window;
        MessageQueueTable.GridColor = SystemColors.ControlDark;
        MessageQueueTable.Location = new Point(18, 22);
        MessageQueueTable.Margin = new Padding(3, 2, 3, 2);
        MessageQueueTable.MultiSelect = false;
        MessageQueueTable.Name = "MessageQueueTable";
        MessageQueueTable.ReadOnly = true;
        MessageQueueTable.RowHeadersWidth = 51;
        MessageQueueTable.Size = new Size(963, 413);
        MessageQueueTable.TabIndex = 1;
        // 
        // btnSendMessage
        // 
        btnSendMessage.Cursor = Cursors.Hand;
        btnSendMessage.Image = (Image)resources.GetObject("btnSendMessage.Image");
        btnSendMessage.Location = new Point(307, 508);
        btnSendMessage.Name = "btnSendMessage";
        btnSendMessage.Size = new Size(111, 26);
        btnSendMessage.TabIndex = 2;
        btnSendMessage.Text = "Iniciar Envio";
        btnSendMessage.TextAlign = ContentAlignment.MiddleRight;
        btnSendMessage.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnSendMessage.UseVisualStyleBackColor = true;
        btnSendMessage.Click += btnIniciar_Click;
        // 
        // btnStopMessage
        // 
        btnStopMessage.Cursor = Cursors.Hand;
        btnStopMessage.Image = (Image)resources.GetObject("btnStopMessage.Image");
        btnStopMessage.Location = new Point(603, 508);
        btnStopMessage.Name = "btnStopMessage";
        btnStopMessage.Size = new Size(111, 26);
        btnStopMessage.TabIndex = 3;
        btnStopMessage.Text = "Parar Envio";
        btnStopMessage.TextAlign = ContentAlignment.MiddleRight;
        btnStopMessage.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnStopMessage.UseVisualStyleBackColor = true;
        btnStopMessage.Click += button2_Click;
        // 
        // EnvioWhatsListForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1023, 592);
        Controls.Add(btnStopMessage);
        Controls.Add(btnSendMessage);
        Controls.Add(gbxMessages);
        Name = "EnvioWhatsListForm";
        Text = "Envio de Mensagens ";
        Load += EnvioWhatsListForm_Load;
        gbxMessages.ResumeLayout(false);
        gbxMessages.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MessageQueueTable).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox gbxMessages;
    private DataGridView MessageQueueTable;
    private Label lblCountMessages;
    private Button btnSendMessage;
    private Button btnStopMessage;
}
