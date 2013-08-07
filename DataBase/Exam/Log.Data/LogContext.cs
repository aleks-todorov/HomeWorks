using System.Data.Entity;
using Log.Models;

public class LogContext : DbContext
{
    public LogContext()
        : base("LogsDb")
    {

    }
    public DbSet<CustomLogs> Logs { get; set; }
}
