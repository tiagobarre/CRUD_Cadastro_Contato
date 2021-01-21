using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CRUD.contato.DAL
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string DataBase = "CRUD";
        private static string User = "tbarreto";
        private static string Password = "171186tsb";
        public string redirecionar { get; set; }      
        
        private string db = $"Server={Server};DataBase={DataBase};User Id={User};Password={Password}";

        private SqlConnection connection;

        public DAL() // Construtor da classe
        {
            connection = new SqlConnection(db);
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (SqlException ex)
            {

                redirecionar = $"{ex.Message}";

            }



        }

        // Retornar Dados do Banco
        public async Task<DataTable> RetDataTable(string sql)
        {
            DataTable Dados = await Task.Run(() => new DataTable());

            try
            {
                await Task.Run(() => connection.Open());
                SqlCommand command = await Task.Run(() => new SqlCommand(sql, connection));
                SqlDataAdapter DataAdapter = await Task.Run(() => new SqlDataAdapter(command));
                await Task.Run(() => DataAdapter.Fill(Dados));
                await Task.Run(() => connection.Close());
            }
            catch (SqlException ex)
            {
                redirecionar = $"{ex.Message}";
            }



            return await Task.Run(() => Dados);

        }

        // Executa INSERT,UPDATE,DELETE
        public async void ExecutarComandoSQL(string sql)
        {
            try
            {
                await Task.Run(() => connection.Open());
                SqlCommand command = await Task.Run(() => new SqlCommand(sql, connection));
                await Task.Run(() => command.ExecuteNonQuery());
                await Task.Run(() => connection.Close());
            }
            catch (SqlException ex)
            {
                redirecionar = $"{ex.Message}";
            }

        }

    }
}
