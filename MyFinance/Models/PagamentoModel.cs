using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class PagamentoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a  forma de pagameto!")]
        //Tipo//
        public string Descricao { get; set; }

        public List<PagamentoModel> ListaPagamento()
        {
            List<PagamentoModel> lista = new List<PagamentoModel>();
            PagamentoModel item;

            string sql = $"SELECT ID,DESCRICAO FROM PAGAMENTO";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new PagamentoModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Descricao=dt.Rows[i]["DESCRICAO"].ToString();

                lista.Add(item);
            }
            return lista;
        }

        public void Insert()
        {
            string sql = $"INSERT INTO PAGAMENTO (DESCRICAO) VALUES('{Descricao}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
