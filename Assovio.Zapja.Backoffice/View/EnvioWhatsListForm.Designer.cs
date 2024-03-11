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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvioWhatsListForm));
        gbxMessages = new GroupBox();
        dgvEnvioWhats = new DataGridView();
        lblCountEnvioWhats = new Label();
        btnIniciarEnvio = new Button();
        btnPararEnvio = new Button();
        gbxMessages.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEnvioWhats).BeginInit();
        SuspendLayout();
        // 
        // gbxMessages
        // 
        gbxMessages.Controls.Add(dgvEnvioWhats);
        gbxMessages.Controls.Add(lblCountEnvioWhats);
        gbxMessages.Location = new Point(14, 16);
        gbxMessages.Margin = new Padding(3, 4, 3, 4);
        gbxMessages.Name = "gbxMessages";
        gbxMessages.Padding = new Padding(3, 4, 3, 4);
        gbxMessages.Size = new Size(1142, 631);
        gbxMessages.TabIndex = 1;
        gbxMessages.TabStop = false;
        gbxMessages.Text = "Mensagens Na Fila";
        // 
        // dgvEnvioWhats
        // 
        dgvEnvioWhats.AllowUserToAddRows = false;
        dgvEnvioWhats.AllowUserToDeleteRows = false;
        dgvEnvioWhats.AllowUserToResizeRows = false;
        dgvEnvioWhats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvEnvioWhats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvEnvioWhats.BackgroundColor = SystemColors.Window;
        dgvEnvioWhats.ColumnHeadersHeight = 29;
        dgvEnvioWhats.ImeMode = ImeMode.NoControl;
        dgvEnvioWhats.Location = new Point(21, 29);
        dgvEnvioWhats.MultiSelect = false;
        dgvEnvioWhats.Name = "dgvEnvioWhats";
        dgvEnvioWhats.ReadOnly = true;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Tahoma", 9F);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvEnvioWhats.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvEnvioWhats.RowHeadersWidth = 51;
        dgvEnvioWhats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvEnvioWhats.Size = new Size(1101, 551);
        dgvEnvioWhats.TabIndex = 53;
        dgvEnvioWhats.TabStop = false;
        // 
        // lblCountEnvioWhats
        // 
        lblCountEnvioWhats.AutoSize = true;
        lblCountEnvioWhats.Location = new Point(21, 595);
        lblCountEnvioWhats.Name = "lblCountEnvioWhats";
        lblCountEnvioWhats.Size = new Size(188, 20);
        lblCountEnvioWhats.TabIndex = 2;
        lblCountEnvioWhats.Text = "Quantidade de Registros: 0";
        // 
        // btnIniciarEnvio
        // 
        btnIniciarEnvio.Cursor = Cursors.Hand;
        btnIniciarEnvio.Image = (Image)resources.GetObject("btnIniciarEnvio.Image");
        btnIniciarEnvio.Location = new Point(351, 677);
        btnIniciarEnvio.Margin = new Padding(3, 4, 3, 4);
        btnIniciarEnvio.Name = "btnIniciarEnvio";
        btnIniciarEnvio.Size = new Size(127, 35);
        btnIniciarEnvio.TabIndex = 2;
        btnIniciarEnvio.Text = "Iniciar Envio";
        btnIniciarEnvio.TextAlign = ContentAlignment.MiddleRight;
        btnIniciarEnvio.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnIniciarEnvio.UseVisualStyleBackColor = true;
        btnIniciarEnvio.Click += btnIniciarEnvio_Click;
        // 
        // btnPararEnvio
        // 
        btnPararEnvio.Cursor = Cursors.Hand;
        btnPararEnvio.Enabled = false;
        btnPararEnvio.Image = (Image)resources.GetObject("btnPararEnvio.Image");
        btnPararEnvio.Location = new Point(689, 677);
        btnPararEnvio.Margin = new Padding(3, 4, 3, 4);
        btnPararEnvio.Name = "btnPararEnvio";
        btnPararEnvio.Size = new Size(127, 35);
        btnPararEnvio.TabIndex = 3;
        btnPararEnvio.Text = "Parar Envio";
        btnPararEnvio.TextAlign = ContentAlignment.MiddleRight;
        btnPararEnvio.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnPararEnvio.UseVisualStyleBackColor = true;
        btnPararEnvio.Click += btnPararEnvio_Click;
        // 
        // EnvioWhatsListForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1169, 789);
        Controls.Add(btnPararEnvio);
        Controls.Add(btnIniciarEnvio);
        Controls.Add(gbxMessages);
        Margin = new Padding(3, 4, 3, 4);
        Name = "EnvioWhatsListForm";
        Text = "Envio de Mensagens ";
        Load += EnvioWhatsListForm_Load;
        gbxMessages.ResumeLayout(false);
        gbxMessages.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEnvioWhats).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox gbxMessages;
    private Label lblCountEnvioWhats;
    private Button btnIniciarEnvio;
    private Button btnPararEnvio;
    private DataGridView dgvEnvioWhats;
}
