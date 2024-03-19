using System.Text;
using Commerce.Domain.Entitie;
using Commerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Commerce.API.Configuration
{
    public static class DataBaseConfig
    {
        public static void MigrateScripts(this CommerceContext context, string pathScript)
        {
            if (Directory.Exists(pathScript))
            {
                var arquivos = Directory.GetFiles(pathScript).OrderBy(t => t);
                foreach (var arquivo in arquivos)
                {
                    var fileInfo = new FileInfo(arquivo);
                    if (fileInfo.Extension.ToLower() != ".sql")
                        continue;
                    if (context.__ScriptMigrationHistory.Any(t => t.FileName == arquivo.Replace("/", "\\")))
                        continue;

                    var sql = File.ReadAllText(arquivo, Encoding.UTF8);

                    try
                    {
                        if (sql != "")
                            context.Database.ExecuteSqlRaw(sql);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(arquivo, ex);
                    }
                    context.__ScriptMigrationHistory.Add(new __ScriptMigrationHistory(arquivo.Replace("/", "\\")));
                    context.SaveChanges();
                }
            }
        }
    }
}