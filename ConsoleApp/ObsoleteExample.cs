namespace ConsoleApp;

/// <summary>
/// Obsolete attribute örnekleri için sınıf
/// </summary>
public class ObsoleteExample
{
    /// <summary>
    /// Bu metot sadece uyarı (warning) verecek şekilde işaretlenmiştir
    /// </summary>
    [Obsolete("Bu metot kullanımdan kaldırılmıştır. Lütfen YeniMetot() kullanın.", false)]
    public static void EskiMetot()
    {
        Console.WriteLine("Eski metot çalışıyor...");
    }

    /// <summary>
    /// Bu metot derleme hatası (error) verecek şekilde işaretlenmiştir
    /// Not: Bu satırı kullanmak için yorum satırından çıkarmanız gerekir
    /// </summary>
    // [Obsolete("Bu metot artık kullanılamaz! Derleme hatası verir.", true)]
    public static void CokEskiMetot()
    {
        Console.WriteLine("Çok eski metot çalışıyor...");
    }

    public static void YeniMetot()
    {
        Console.WriteLine("Yeni metot çalışıyor...");
    }
}

