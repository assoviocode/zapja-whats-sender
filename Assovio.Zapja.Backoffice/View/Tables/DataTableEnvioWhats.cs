using Assovio.Zapja.Core.DTO.Simple;
using System.Data;

namespace EnvioWhatsApp.View.Tables
{
    public partial class DataTableEnvioWhats : DataTable
    {
        private IList<EnvioWhatsSimpleDTO> itens = new List<EnvioWhatsSimpleDTO>();

        public DataTableEnvioWhats()
        {
            DefineColumns();
        }

        private void DefineColumns()
        {
            Columns.Add("Id");
            Columns.Add("Status");
            Columns.Add("N° Remetente").DefaultValue = "-";
            Columns.Add("Nome Contato").DefaultValue = "-";
            Columns.Add("N° WhatsApp").DefaultValue = "-";
            Columns.Add("Data Envio").DefaultValue = "-";
        }

        public void AddItens(IList<EnvioWhatsSimpleDTO> list)
        {
            foreach (EnvioWhatsSimpleDTO item in list)
                itens.Add(item);

            UpdateList();
        }

        public void SetItens(IList<EnvioWhatsSimpleDTO> list)
        {
            itens = list;
            UpdateList();
        }

        public void UpdateList()
        {
            Rows.Clear();

            foreach (EnvioWhatsSimpleDTO item in itens)
            {
                if (item != null)
                {
                    Rows.Add(new object[] {
                        item.Id.ToString(),
                        item.Status.ToString().Replace("_", " ").Trim(),
                        !String.IsNullOrEmpty(item.NumeroOrigem) ? item.NumeroOrigem : "-",
                        !String.IsNullOrEmpty(item.NomeContato) ? item.NomeContato : "-",
                        !String.IsNullOrEmpty(item.NumeroWhats) ? item.NumeroWhats : "-",
                        item.DataEnvio.ToString("dd/MM/yyyy") ?? "-",
                    });
                }
            }
        }

        public EnvioWhatsSimpleDTO GetItemSelected(int rowSelected)
        {
            return itens[rowSelected];
        }

        public int GetSize()
        {
            return Rows.Count;
        }

        public EnvioWhatsSimpleDTO? GetItemById(int value)
        {
            return itens.Where(i => i.Id == value).FirstOrDefault();
        }
    }
}
