using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Infome seu CPF!")]
        public int Cpf { get; set; }

        [Required(ErrorMessage = "Infome seu RG!")]
        public int Rg { get; set; }

        [Required(ErrorMessage = "Infome seu Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Infome seu Email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua Senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe sua Data de Nascimento!")]
        public string Data_Nascimento { get; set; }

        [Required(ErrorMessage = "Informe o Seu Telefone!")]
        public int Telefone { get; set; }

        public FuncionarioModel()
        {

        }

        public List<FuncionarioModel> ListaFuncionarioModel()
        {
            List<FuncionarioModel> lista = new List<FuncionarioModel>();
            FuncionarioModel item;

            string sql = $"SELECT ID,CPF,RG,NOME, EMAIL,SENHA,DATA_NASCIMENTO,TELEFONE FROM FUNCINARIO ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new FuncionarioModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Cpf = int.Parse(dt.Rows[i]["CPF"].ToString());
                item.Rg = int.Parse(dt.Rows[i]["RG"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.Email = dt.Rows[i]["EMAIL"].ToString();
                item.Data_Nascimento = dt.Rows[i]["DATA_NASCIMENTO"].ToString();
                item.Telefone = int.Parse(dt.Rows[i]["TELEFONE"].ToString());


                lista.Add(item);
            }
            return lista;
        }
        public void Insert()
        {
            string sql = $"INSERT INTO FUNCINARIO (CPF,RG,NOME,EMAIL,DATA_NASCIMENTO,TELEFONE ) VALUES('{Cpf}','{Rg}','{Nome}','{Email}','{Data_Nascimento}','{Telefone}')";
            DAL objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id_Funcionario)
        {
            new DAL().ExecutarComandoSQL("DELETE FROM CONTA WHERE ID = " + id_Funcionario);
        }
    }
}
