namespace Dto.Plants;

public class SettingsResponseDto
{
    public bool status { get; set; } = false;
    
    private Dictionary<string, string> _data;
    public Dictionary<string, string> data { get { return this._data; } }

    private Dictionary<string, string> _errors;
    public Dictionary<string, string> errors { get { return this._errors; } }

    public SettingsResponseDto(bool status)
    {
        this.status = status;
        this._errors = new Dictionary<string, string>();
        this._data = new Dictionary<string, string>();
    }
}