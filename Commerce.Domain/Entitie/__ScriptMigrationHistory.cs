namespace Commerce.Domain.Entitie
{
    public class __ScriptMigrationHistory : Entity
    {
        public string FileName { get; set; }
        protected __ScriptMigrationHistory() { }
        public __ScriptMigrationHistory(string fileName)
        {
            FileName = fileName;
        }
    }
}