using Microsoft.Extensions.Primitives;

public static class Helpers
{
    public static KeyValuePair<string, StringValues> GetFormData(IFormCollection data, string key)
    {
        foreach(KeyValuePair<string, StringValues> datum in data.ToList()) {
            if(datum.Key.Equals(key)) {
                return datum;
            }
        }

        return new KeyValuePair<string, StringValues>(key, "");
    }

    public static List<string> ParseMultipleSelectValue(IFormCollection data, string key)
    {
        string? value = GetFormData(data, key).Value;
        
        List<string> values = new List<string>();
        if(value == null || value.Length == 0) return values;
        
        foreach(string val in value.Split(",")) {
            values.Add(val);
        }

        return values;
    }
}