namespace ProductRegistration.Shared.Configs;

public class NotificationEventProductionConfig
{
    public string? ArnSnsRegistration { get; set; }
    public string? SubjectRegistration { get; set; }
    public string? ArnSnsUpdateProduct { get; set; }
    public string? SubjectUpdateProduct { get; set; }
    public string? ArnSnsDeleteProduct { get; set; }
    public string? SubjectDeleteProduct { get; set; }
}