using System.ComponentModel.DataAnnotations.Schema;

namespace ElsaZone.Data.Entities;
[Table("SystemLogs")]
public class SystemLog
{
    public int LogId { set; get; }
    public int AdminId { set; get; }
    public string LogDescription { set; get; }
    public DateTime LogDate { set; get; }
    
}