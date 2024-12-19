using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Infrastructure.DbUtility
{
    public static class DbExtensions
    {
        // Consider using: Task<bool> 
        public static async Task ExecuteSqlCommand(this System.Data.Common.DbConnection conn, string cmd)
        {
            try
            {
                await using (var command = conn.CreateCommand())
                {
                    command.CommandText = cmd;
                    var rowsAffected = await command.ExecuteNonQueryAsync();

                    Debug.WriteLine($"{cmd}  -  Rows affected: {rowsAffected}");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"EXCEPTION: {e.Message} \n {e.InnerException} \n {e.StackTrace}");
            }
        }
    }
}
