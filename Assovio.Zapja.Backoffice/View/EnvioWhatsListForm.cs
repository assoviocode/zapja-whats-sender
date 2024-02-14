using Assovio.Zapja.Core.DTO;
using Assovio.Zapja.Core.DTO.Enum;
using Assovio.Zapja.Core.DTO.Simple;
using Assovio.Zapja.Core.ServiceHttp;
using Assovio.Zapja.WhatsApp;
using Backoffice.View;
using EnvioWhatsApp.View.Tables;

namespace EnvioWhatsApp.View
{
    public partial class EnvioWhatsListForm : Form
    {
        private DataTableEnvioWhats _dtEnvioWhats = new DataTableEnvioWhats();
        private EnvioWhatsHttpService _envioWhatsHttpService;
        private EnvioWhatsDTO? _envioWhatsDTO;

        private IList<EnvioWhatsSimpleDTO>? _envioWhatsSimpleList;

        private WhatsAppSender? _whatsAppSender;

        public EnvioWhatsListForm()
        {
            this._envioWhatsHttpService = new EnvioWhatsHttpService();

            InitializeComponent();
        }

        private void EnvioWhatsListForm_Load(object sender, EventArgs e)
        {
            this.LoadDados(sender, e);
        }

        public async void LoadDados(object sender, EventArgs e)
        {

            await this.GetEnviosWhats();

            if (this._envioWhatsSimpleList != null)
            {
                this.InitParameters();
            }
            else
            {
                this._dtEnvioWhats.Reset();
                MessageBox.Show("Não há protocolos disponíveis para edição!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        public void InitParameters()
        {
            if (this._envioWhatsSimpleList != null)
            {
                this.AtualizaItensTabela(this._envioWhatsSimpleList);

                // parametros tabela

                this.dgvEnvioWhats.Columns[0].Visible = false;

                this.dgvEnvioWhats.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEnvioWhats.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvEnvioWhats.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvEnvioWhats.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEnvioWhats.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvEnvioWhats.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvEnvioWhats.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEnvioWhats.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvEnvioWhats.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvEnvioWhats.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEnvioWhats.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvEnvioWhats.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                this.dgvEnvioWhats.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvEnvioWhats.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvEnvioWhats.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                foreach (DataGridViewRow row in this.dgvEnvioWhats.Rows)
                {
                    int IdItem = Convert.ToInt32(row.Cells[0].Value);

                    var demonstrativo = _dtEnvioWhats.GetItemById(IdItem);

                    if (demonstrativo != null)
                    {
                        switch (demonstrativo.Status)
                        {
                            case EnumStatusEnvioWhats.NA_FILA:
                                row.DefaultCellStyle.BackColor = Color.White;
                                break;
                            case EnumStatusEnvioWhats.EM_ANDAMENTO:
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                                break;
                            case EnumStatusEnvioWhats.ENVIADO:
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                                break;
                            case EnumStatusEnvioWhats.CANCELADO:
                                row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                                row.DefaultCellStyle.ForeColor = Color.White;
                                break;
                            default:
                                break;
                        }
                    }
                }

                this.dgvEnvioWhats.Refresh();
            }

        }

        private void AtualizaItensTabela(IList<EnvioWhatsSimpleDTO>? simpleList)
        {
            if (simpleList != null)
            {
                this._dtEnvioWhats.SetItens(simpleList);
                this.dgvEnvioWhats.DataSource = this._dtEnvioWhats;
                this.dgvEnvioWhats.Refresh();
                this.lblCountEnvioWhats.Text = $"Quantidade de Registros: {simpleList.Count()}";
            }
            else
            {
                this.lblCountEnvioWhats.Text = $"Quantidade de Registros: 0";
                MessageBox.Show("Sem resultado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task GetEnviosWhats()
        {

            this._envioWhatsSimpleList = new List<EnvioWhatsSimpleDTO>();

            Dictionary<string, object> mapFilters = this.GetFilter();

            LoadingService.LoadingShow();

            var envioWhatsPageDTO = await this._envioWhatsHttpService.Index(mapFilters);

            this._envioWhatsSimpleList = envioWhatsPageDTO.Content;

            LoadingService.LoadingClose();

            if (this._envioWhatsSimpleList != null && this._envioWhatsSimpleList.Count() > 0)
            {
                this.InitParameters();
            }
            else
            {
                MessageBox.Show("Não há envios disponíveis!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.LimparLista();
            }
        }

        private Dictionary<string, object> GetFilter()
        {
            var mapFilters = new Dictionary<string, object>();
            mapFilters.Add("data_prevista", DateTime.Now.ToString("yyyy/MM/dd"));
            mapFilters.Add("status", EnumStatusEnvioWhats.NA_FILA);
            return mapFilters;
        }

        private void LimparLista()
        {
            this._envioWhatsSimpleList = new List<EnvioWhatsSimpleDTO>();

            this.AtualizaItensTabela(this._envioWhatsSimpleList);

        }

        private async void btnIniciarEnvio_Click(object sender, EventArgs e)
        {
            this.btnIniciarEnvio.Enabled = false;
            this.btnPararEnvio.Enabled = true;

            this._whatsAppSender = new WhatsAppSender();

            while (true)
            {

                EnvioWhatsDTO? envioWhatsDTO = await this._envioWhatsHttpService.ShowProximo();

                if (envioWhatsDTO != null)
                {
                    this.AtualizarEnvioEmAndamento(envioWhatsDTO);

                    await this._whatsAppSender.Send(envioWhatsDTO);

                    this._envioWhatsSimpleList = this._envioWhatsSimpleList?.Where(ew => ew.Id != envioWhatsDTO.Id).ToList();

                    this.AtualizaItensTabela(this._envioWhatsSimpleList);
                }
                else
                {
                    //Thread.Sleep(1000);
                    break;
                }
            }

            this.btnPararEnvio.Enabled = false;
            this.btnIniciarEnvio.Enabled = true;
        }

        private void AtualizarEnvioEmAndamento(EnvioWhatsDTO envioWhatsDTO)
        {
            foreach (DataGridViewRow row in this.dgvEnvioWhats.Rows)
            {
                int IdItem = Convert.ToInt32(row.Cells[0].Value);

                if (IdItem == envioWhatsDTO.Id)
                {
                    var entity = _dtEnvioWhats.GetItemById(IdItem);

                    if (entity != null)
                    {
                        row.Cells["Status"].Value = EnumStatusEnvioWhats.EM_ANDAMENTO.ToString().Replace("_", " ");
                        row.DefaultCellStyle.BackColor = Color.LightCyan;
                        this.dgvEnvioWhats.Refresh();
                    }
                }


            }
        }

        private void btnPararEnvio_Click(object sender, EventArgs e)
        {
            this.btnIniciarEnvio.Enabled = true;
            this.btnPararEnvio.Enabled = false;

            this._whatsAppSender.StopMessages();
        }
    }
}
