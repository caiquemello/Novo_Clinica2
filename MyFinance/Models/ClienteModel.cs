using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Infome seu Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Infome seu CPF!")]
        public int Cpf { get; set; }

        [Required(ErrorMessage = "Infome seu CPF!")]
        public int Rg { get; set; }

        [Required(ErrorMessage = "Informe sua Data de Nascimento!")]
        public string Data_Nascimento { get; set; }

        [Required(ErrorMessage = "Informe seu Endereço!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe seu Bairro!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe sua Ciadade!")]
        public string Cidade { get; set; }

        //[Required(ErrorMessage = "Informe o Seu Telefone!")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Informe o Numero do seu Celualar!")]
        public int Celular { get; set; }

        [Required(ErrorMessage = "Informe uma Numero do seu Descricão!")]
        public string Descricao { get; set; }

        public string Profissao { get; set; }



        public List<ClienteModel> ListaCliente()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;

            string sql = $"SELECT ID,NOME,CPF,RG,DATA_NASCIMENTO,ENDERECO,BAIRRO,CIDADE,CELULAR,TELEFONE,DESCRICAO,PROFISSAO FROM CLIENTE;";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.Cpf = int.Parse(dt.Rows[i]["CPF"].ToString());
                item.Rg = int.Parse(dt.Rows[i]["RG"].ToString());
                item.Data_Nascimento = dt.Rows[i]["DATA_NASCIMENTO"].ToString();
                item.Endereco = dt.Rows[i]["ENDERECO"].ToString();
                item.Bairro = dt.Rows[i]["BAIRRO"].ToString();
                item.Cidade = dt.Rows[i]["CIDADE"].ToString();
                item.Celular = int.Parse(dt.Rows[i]["CELULAR"].ToString());
                //item.Telefone = int.Parse(dt.Rows[i]["TELEFONE"].ToString());
                item.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                item.Profissao= dt.Rows[i]["PROFISSAO"].ToString();

                lista.Add(item);
            }
            return lista;

        }
        public void Insert()
        {
            string sql = $"INSERT INTO CLIENTE (NOME,CPF,RG,DATA_NASCIMENTO,ENDERECO,BAIRRO,CIDADE,CELULAR,TELEFONE,DESCRICAO,PROFISSAO)" +
                $" VALUES('{Nome}','{Cpf}','{Rg}','{Data_Nascimento}','{Endereco}','{Bairro}','{Cidade}','{Celular}','{Telefone}','{Descricao}','{Profissao}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id_conta)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM CLIENTE WHERE ID = " + id_conta);
        }

    }   
}
