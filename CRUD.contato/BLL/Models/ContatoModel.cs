using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRUD.contato.Models
{
    public class ContatoModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public string telefone { get; set; }
        public string mensagem { get; set; }

        public ContatoModel(){ }

        /*******************************************/
        /*Retornando todos os cadastros do Contatos*/
        /*********************************************/
        public async Task<List<ContatoModel>> ListarContatos(int? id)
        {
            List<ContatoModel> lista = await Task.Run(() => new List<ContatoModel>());
            ContatoModel item;
            DAL.DAL objDAL = await Task.Run(() => new DAL.DAL());

            /**************************/
            /*Excluindo os usuarios*/
            /************************/
            if (id != null)
            {
                /*Deletando os usuarios*/
                string sqlDelete = $"delete from CRUD.dbo.contato where id = '{id}'";
                await Task.Run(() => objDAL.RetDataTable(sqlDelete)); // abre a conexão
                mensagem = "Excluido";

            }

            /*********************/
            /*SAlvando usuarios*/
            /*********************/
            if(nome != null && telefone != null)
            {
                /*Deletando os usuarios*/
                string sqlInsert = $"insert into CRUD.dbo.contato (nome, celular, telefone) values ('{nome}','{celular}','{telefone}')";
                await Task.Run(() => objDAL.RetDataTable(sqlInsert)); // abre a conexão
                mensagem = "Salvo";
            }

            /************************/
            /*Carregando os usuarios*/
            /************************/
            string sql = $"select * from CRUD.dbo.contato order by id desc";           
            DataTable dt = await Task.Run(() => objDAL.RetDataTable(sql)); // abre a conexão

            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = await Task.Run(() => new ContatoModel());

                    item.id = int.Parse(dt.Rows[i]["id"].ToString());
                    item.nome = dt.Rows[i]["nome"].ToString();
                    item.celular = dt.Rows[i]["celular"].ToString();
                    item.telefone = dt.Rows[i]["telefone"].ToString();

                    await Task.Run(() => lista.Add(item));
                }
            }


            return await Task.Run(() => lista);

        }

    }

    }

