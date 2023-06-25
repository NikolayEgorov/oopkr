namespace Models;

using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Log: Base
{
    public enum Type
    {
        info,
        log,
        debug,
        warning,
        error
    }

    private static string _typeInfo =  "info";
    private static string _typeLog =  "log";
    private static string _typeDebug =  "debug";
    private static string _typeWarning =  "warning";
    private static string _typeError =  "error";

    [NotMapped]
    public Type typeEnum { get; set; } = Type.log;
    public string type { get; set; } = _typeLog;
    [Column(TypeName = "text")]
    public string message { get; set; } = String.Empty;
    [Column(TypeName="datetime")]
    public DateTime date { get; set; } = DateTime.Now;

    public void setType(Type type)
    {
        switch(type) {
            case Type.info:
                this.type = _typeInfo;
                break;
            case Type.debug:
                this.type = _typeDebug;
                break;
            case Type.warning:
                this.type = _typeWarning;
                break;
            case Type.error:
                this.type = _typeError;
                break;
            default:
                this.type = _typeLog;
                break;
        }
    }
}