using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Tipo de Serviço!")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Nome do serviço!")]

        public string Tipo { get; set; }
        [Required(ErrorMessage = "Informe o Valor!")]
        public double Valor { get; set; }

        public string Observacao { get; set; }

        [Required(ErrorMessage = "Informe o Data Do Serviço!")]
        public string Data_Servico { get; set; }
        
        public int Hora { get; set; }
       

        public List<ServicoModel> ListaServico()
        {
            List<ServicoModel> lista = new List<ServicoModel>();
            ServicoModel item;

            string sql = $"SELECT ID,NOME,TIPO,OBSERVACAO,DATA_SERVICO,VALOR FROM SERVICO";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ServicoModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.Tipo = dt.Rows[i]["TIPO"].ToString();
                item.Observacao = dt.Rows[i]["OBSERVACAO"].ToString();
                item.Data_Servico = dt.Rows[i]["DATA_SERVICO"].ToString();
                //item.Hora = int.Parse(dt.Rows[i]["HORA"].ToString());
                item.Valor = double.Parse(dt.Rows[i]["VALOR"].ToString());
                lista.Add(item);
            }
            return lista;
        }
            public void Insert()
            {

                string sql = $"INSERT INTO SERVICO (NOME,TIPO,OBSERVACAO,DATA_SERVICO,VALOR) VALUES('{Nome}','{Tipo}','{Observacao}','{Data_Servico}','{Valor}')";
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
            }
        
    }
}
