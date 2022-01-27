
using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _1._Initial_Setup
{
    public class StartUp
    {
       static async Task Main(string[] args)
       {
            SqlConnection sqlConnection = new SqlConnection(Configuration.CONNECTION_STRING);

            await sqlConnection.OpenAsync();

            await using (sqlConnection)
            {
                await PrintVillainsWithMoreThan3Minions(sqlConnection);
            }
       }

       private static async Task PrintVillainsWithMoreThan3Minions(SqlConnection sqlConnection)
       {
           SqlCommand sqlCommand = new SqlCommand(Queries.VILLAIN_NAMES, sqlConnection);

           SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

           await using (sqlDataReader)
           {
               while (await sqlDataReader.ReadAsync())
               {
                   string villainName = sqlDataReader.GetString(0);
                   int minionsCount = sqlDataReader.GetInt32(1);
                   Console.WriteLine($"{villainName} - {minionsCount}");
               }
           }
       }
    }
}
