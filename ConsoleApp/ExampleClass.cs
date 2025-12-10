namespace ConsoleApp;

/// <summary>
/// Reflection örneği için kullanılan örnek sınıf
/// </summary>
[DeveloperInfo("Ahmet Yılmaz", "1.0.0", "Bu sınıf reflection örneği için oluşturulmuştur")]
public class ExampleClass
{
    [DeveloperInfo("Ahmet Yılmaz", "1.0.0", "Toplama işlemi yapan metot")]
    public int Topla(int a, int b)
    {
        return a + b;
    }

    [DeveloperInfo("Mehmet Demir", "1.1.0", "Çarpma işlemi yapan metot")]
    public int Carp(int a, int b)
    {
        return a * b;
    }

    [DeveloperInfo("Ayşe Kaya", "1.2.0", "String birleştirme işlemi yapan metot")]
    public string Birlestir(string str1, string str2)
    {
        return str1 + str2;
    }

    // Attribute olmayan metot
    public void AttributeOlmayanMetot()
    {
        Console.WriteLine("Bu metotta attribute yok");
    }
}

