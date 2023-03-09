using System.Text.Json;

namespace SmartBodyDiaryDomain;

public interface IJsonPersistence
{
    PersistenceContainer? Deserialize(string serializedJson);
    string Serialize(PersistenceContainer dataToBeSerialized);
}

public sealed class JsonPersistence : IJsonPersistence
{
    private static readonly JsonSerializerOptions _options = new();

    static JsonPersistence()
    {
        _options.Converters.Add(new DateOnlyConverter());
    }

    public static bool WriteIndented
    {
        get => _options.WriteIndented;
        set => _options.WriteIndented = value;
    }

    public string Serialize(PersistenceContainer dataToBeSerialized)
        => JsonSerializer.Serialize(dataToBeSerialized, _options);

    public PersistenceContainer? Deserialize(string serializedJson)
        => JsonSerializer.Deserialize<PersistenceContainer>(serializedJson, _options);
}