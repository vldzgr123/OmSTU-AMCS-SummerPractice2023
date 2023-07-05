using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


string path_input = args[0];
string path_output = args[1];
string file_input = File.ReadAllText(path_input);
dynamic file_input_json = JsonConvert.DeserializeObject(file_input) ?? new JObject();
List<Cadet> cadets = file_input_json.data.ToObject<List<Cadet>>();
string task_name = file_input_json.taskName;
List<dynamic> result;
switch (task_name)
{
    case "GetStudentsWithHighestGPA":
        result = GetStudentsWithHighestGPA(cadets);
        break;
    case "CalculateGPAByDiscipline":
        result = CalculateGPAByDiscipline(cadets);
        break;
    case "GetBestGroupsByDiscipline":
        result = GetBestGroupsByDiscipline(cadets);
        break;
    default:
        throw new Exception();
}
string output_file_json = JsonConvert.SerializeObject(new { Response = result }, Formatting.Indented);
File.WriteAllText(path_output, output_file_json);


static List<dynamic> GetStudentsWithHighestGPA(List<Cadet> cadets)
{
    var cadet_marks = cadets.GroupBy(x => x.Name).Select(y => new
    {
        Name = y.Key,
        Mark = y.Select(y => y.Mark).ToArray()
    });
    double max_average_mark = cadet_marks.Max(x => x.Mark.Average());
    var cadet_marks_max_average = cadet_marks.Where(x => x.Mark.Average() == max_average_mark)
    .Select(x => new
    {
        Name = x.Name,
        Mark = Math.Round(x.Mark.Average(), 2)
    });
    List<dynamic> result = cadet_marks_max_average.ToList<dynamic>();
    return result;
}
static List<dynamic> CalculateGPAByDiscipline(List<Cadet> cadets)
{
    var discipline_average_mark = cadets.GroupBy(x => x.Discipline)
    .Select(y => new Dictionary<string, double> { [y.Key] = y.Average(y => y.Mark) });
    List<dynamic> result = discipline_average_mark.ToList<dynamic>();
    return result;
}
static List<dynamic> GetBestGroupsByDiscipline(List<Cadet> cadets)
{
    var group_discipline_mark = cadets.GroupBy(x => new { x.Discipline, x.Group })
    .Select(y => new
    {
        Discipline = y.Key.Discipline,
        Group = y.Key.Group,
        GPA = y.Average(m => m.Mark)
    }).GroupBy(d => d.Discipline)
    .Select(d => new
    {
        Discipline = d.Key,
        Group = d.OrderByDescending(dd => dd.GPA).FirstOrDefault()?.Group,
        GPA = d.Max(d => d.GPA)
    });
    List<dynamic> result = group_discipline_mark.ToList<dynamic>();
    return result;
}


class Cadet
{
    public string Name = "";
    public string Group = "";
    public string Discipline = "";
    public int Mark;
}



