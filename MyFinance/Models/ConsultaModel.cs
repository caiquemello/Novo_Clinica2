using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class ConsultaModel
    {
        public int Id { get; set; }


        public string Observacao { get; set; }

        [Required(ErrorMessage = "Informe a Hora da Consulta!")]
        public int Hora { get; set; }

        [Required(ErrorMessage = "Informe a Data da Consulta!")]
        public string Data_consulta { get; set; }

        public string DataFinal { get; set; } //Utilizado para Filtros

        [Required(ErrorMessage = "Informe o Nome do Serviço!")]
        public string Nome_servico { get; set; }

        [Required(ErrorMessage = "Informe o Tipo do Serviço!")]
        public string Tipo_servico { get; set; }

        [Required(ErrorMessage = "Informe o Valor Serviço!")]
        public double Valor_Servico { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Cliente!")]
        public string Nome_Cliente { get; set; }

        public string Forma_Pagamento { get; set; }

        public string Nome_Funcionario { get; set; }

        public string Nome_Usuario { get; set; }

        public int Id_servico { get; set; }

        public int Funcioario_Id { get; set; }

        public int Cliente_Id { get; set; }

        public int Pagamento_Id { get; set; }

        public int Usuario_Id { get; set; }

        public List<ConsultaModel> ListaConsulta()
        {
            List<ConsultaModel> lista = new List<ConsultaModel>();
            ConsultaModel item;

            //Utilizado pela View Extrato
            string filtro = "";

            if ((Data_consulta != null) && (DataFinal != null))
            {
                filtro += $" and C.DATA_CONSULTA >='{DateTime.Parse(Data_consulta).ToString("yyyy/MM/dd")}' and C.DATA_CONSULTA <='{DateTime.Parse(DataFinal).ToString("yyyy/MM/dd")}' ";
            }

            //if (Tipo != null)
            //{
            //    if (Tipo != "A")
            //    {
            //        filtro += $" and t.Tipo ='{Tipo}' ";
            //    }
            //}

            //if (Tipo_servico != null)
            //{
            //    filtro += $" and S.TIPO ='{Tipo_servico}' ";
            //}
            //Fim

            string sql = $"select C.ID,C.OBSEVARCOES,C.HORA_CONSULTA,C.DATA_CONSULTA,S.NOME,S.TIPO,S.VALOR,CL.NOME,P.DESCRICAO,F.NOME,U.NOME FROM CONSULTA " +
                               " AS C INNER JOIN SERVICO AS S " +
                               " ON C.SERVICO_ID = S.ID " +
                                "INNER JOIN CLIENTE AS CL ON C.CLIENTE_ID = S.ID " +
                                "INNER JOIN PAGAMENTO AS P ON C.PAGAMENTO_ID = P.ID " +
                                "INNER JOIN USUARIO AS U ON C.USUARIO_ID = U.ID " +
                                 "INNER JOIN FUNCINARIO AS F ON C.FUNCINARIO_ID = F.ID; ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ConsultaModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Observacao = dt.Rows[i]["OBSERVACAO"].ToString();
                item.Hora = int.Parse(dt.Rows[i]["HORA_CONSULTA"].ToString());
                item.Data_consulta = dt.Rows[i]["DATA_CONSULTA"].ToString();
                item.Nome_servico = dt.Rows[i]["NOME"].ToString();
                item.Tipo_servico = dt.Rows[i]["TIPO"].ToString();
                item.Valor_Servico = double.Parse(dt.Rows[i]["VALOR"].ToString());
                item.Nome_Cliente = dt.Rows[i]["NOME"].ToString();
                item.Forma_Pagamento = dt.Rows[i]["DESCRICAO"].ToString();
                item.Nome_Funcionario = dt.Rows[i]["Nome"].ToString();
                item.Nome_Usuario = dt.Rows[i]["NOME"].ToString();
                item.Id_servico = int.Parse(dt.Rows[i]["SERVICO_ID"].ToString());
                item.Funcioario_Id = int.Parse(dt.Rows[i]["FUNCINARIO_ID"].ToString());
                item.Cliente_Id = int.Parse(dt.Rows[i]["CLIENTE_ID"].ToString());
                item.Pagamento_Id = int.Parse(dt.Rows[i]["PAGAMENTO_ID"].ToString());
                item.Usuario_Id = int.Parse(dt.Rows[i]["USUARIO_ID"].ToString());

                lista.Add(item);
            }
            return lista;

        }
        public void Insert()
        {
            string sql = $"INSERT INTO CONSULTA (NOME,TIPO,NOME,DATA_CONSULTA,OBSERVACAO,NOME,DESCRICAO,SERVICO_ID,FUNCINARIO_ID,CLIENTE_ID,PAGAMENTO_ID,USUARIO_ID)" +
                $" VALUES('{Nome_Cliente}','{Tipo_servico}','{Nome_servico}','{DateTime.Parse(Data_consulta).ToString("yyyy/MM/dd")}','{Observacao}','{Nome_Funcionario}','{Forma_Pagamento}','{Id_servico}','{Funcioario_Id}','{Cliente_Id}','{Pagamento_Id}','{Usuario_Id}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}

