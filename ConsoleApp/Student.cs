namespace ConsoleApp;

/// <summary>
/// Öğrenci bilgilerini temsil eden struct (değer tipi)
/// </summary>
public struct Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Gpa { get; set; }

    public Student(int id, string name, double gpa)
    {
        Id = id;
        Name = name;
        Gpa = gpa;
    }

    public override string ToString()
    {
        return $"ID: {Id}, İsim: {Name}, Not Ortalaması: {Gpa:F2}";
    }
}

