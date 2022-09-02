using System.Text.Json;

namespace SmartBodyDiaryDomain;

public class JsonPersistence
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions()
    {
        // TODO: Culture handling
        WriteIndented = true,
    };

    static JsonPersistence()
    {
        _options.Converters.Add(new DateOnlyConverter());
    }

    public string Serialize(DiaryWeight[] weightsToBeUsed)
        => JsonSerializer.Serialize(weightsToBeUsed, _options);

    public DiaryWeight[] Deserialize(string serializedJson)
        => JsonSerializer.Deserialize<DiaryWeight[]>(serializedJson, _options);
}