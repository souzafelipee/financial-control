using CommandLine;

namespace FinancialControl.Infra.DbMigrator.Runner;

public class Options
{
    [Option('c', "connection", Required = false, HelpText = "The connection string itself to the server and database you want to execute your migrations against.")]
    public string ConnectionString { get; set; }

}
