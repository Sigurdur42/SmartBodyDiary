using System.Text.Json;

namespace SmartBodyDiaryDomain;

public class JsonPersistence
{
    private static readonly JsonSerializerOptions _options = new ();

    static JsonPersistence()
    {
        _options.Converters.Add(new DateOnlyConverter());
    }

    public bool WriteIndented
    {
        get => _options.WriteIndented;
        set => _options.WriteIndented = value;
    }

    public string Serialize(JsonPersistenceContainer dataToBeSerialized)
        => JsonSerializer.Serialize(dataToBeSerialized, _options);

    public JsonPersistenceContainer? Deserialize(string serializedJson)
        => JsonSerializer.Deserialize<JsonPersistenceContainer>(serializedJson, _options);
}