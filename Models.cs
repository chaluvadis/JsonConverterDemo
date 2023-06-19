namespace ExamTypes;
public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }
}

public class Exam
{
    public string Name { get; set; }
    public int Score { get; set; }
    public string Subject { get; set; }
}

public class ExamBatch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Exam> Exams { get; set; }
    public NextExamBatch NextExamBatch { get; set; }
    public string Remarks { get; set; }
}

public class NextExamBatch
{
    public List<Employee> Employees { get; set; }
    public List<Exam> Exams { get; set; }
}

