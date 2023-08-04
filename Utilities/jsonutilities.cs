using Newtonsoft.Json;

namespace POM_Basic.Utilities
{
    public static class JsonUtility
{
    public static dynamic ReadAndDeserialize(string username, string password)
    {
        string filePath = (@"../../../") + "/payload.json";
        string jsonContent = System.IO.File.ReadAllText(filePath);
        return JsonConvert.DeserializeAnonymousType(jsonContent, new
        {
            username = "",
            password = ""
        })!;
    }

    public static void SerializeAndWrite(string value){
         string fileName = (@"../../../") + "/quantity.json"; 
         string jsonString = System.Text.Json.JsonSerializer.Serialize("Quantity");
         string jsonString2 = System.Text.Json.JsonSerializer.Serialize(value);
        File.WriteAllText(fileName, "{"+jsonString+": " +jsonString2+"}");
         
    }
}
}