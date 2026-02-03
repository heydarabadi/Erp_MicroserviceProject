namespace WarehouseService.Api.Infrastructure.ApplicationOptions;

public sealed class WarehouseOption
{
    public Logging Logging { get; set; }
    public Database Database { get; set; }
    public string AllowedHosts { get; set; }
    
}


public sealed class Logging
{
    public LogLevel LogLevel { get; set; }
}

public sealed class LogLevel
{
    public string Default { get; set; }
    public string Microsoft_AspNetCore { get; set; }
}

public sealed class Database
{
    public string ConnectionStrings { get; set; }
    public int MaxRetryCount { get; set; }
    public  int MaxRetryDelay { get; set; }
    public  int TimeOut { get; set; }
    
}


