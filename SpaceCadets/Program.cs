using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var Cadets=new List<Cadet>();
string pathInp = args[0];
string pathOut = args[1];
JObject readFile = JObject.Parse(File.ReadAllText(pathInp));

class Cadet
{
    public string Name {get; set;} = "Undefined";
    public string Group {get; set;} = "Undefined";
    public string Discipline {get; set;} = "Undefined";
    public int Mark {get; set;}
}
