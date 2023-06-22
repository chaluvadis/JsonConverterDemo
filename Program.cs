using System.Text.Json;
using ExamTypes;
using CustomConverter;

var examp = new ExamBatch
{
    Id = 1,
    Name = "Exam Batch 1",
    Employees = null,
    Exams = null,
    NextExamBatch = new NextExamBatch
    {
        Employees = null,
        Exams = null
    }
};

var options = new JsonSerializerOptions
{
    Converters =
    {
        new NullToListConverter()
    }
};
// Serialize the object with the custom converter
string json = JsonSerializer.Serialize(examp, options);
Console.WriteLine(json);