using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleApp;

public partial class MainForm : Form
{
    private TabControl tabControl = null!;
    private RichTextBox outputTextBox = null!;
    private TextBox number1TextBox = null!;
    private TextBox number2TextBox = null!;
    private Label resultLabel = null!;

    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "C# Temelleri ve Reflection Örnekleri";
        this.Size = new System.Drawing.Size(900, 700);
        this.StartPosition = FormStartPosition.CenterScreen;

        // TabControl oluştur
        tabControl = new TabControl
        {
            Dock = DockStyle.Fill,
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        // Tab 1: Struct ve Değer Tipleri
        CreateStructTab();

        // Tab 2: Exception Handling
        CreateExceptionTab();

        // Tab 3: Obsolete Attribute
        CreateObsoleteTab();

        // Tab 4: Reflection Raporu
        CreateReflectionTab();

        this.Controls.Add(tabControl);
    }

    private void CreateStructTab()
    {
        var tab = new TabPage("1. Struct ve Değer Tipleri");
        
        var label = new Label
        {
            Text = "Öğrenci Listesi (Struct Örneği)",
            Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
            Location = new System.Drawing.Point(20, 20),
            AutoSize = true
        };

        var listBox = new ListBox
        {
            Location = new System.Drawing.Point(20, 60),
            Size = new System.Drawing.Size(800, 300),
            Font = new System.Drawing.Font("Consolas", 10F)
        };

        var btnShow = new Button
        {
            Text = "Öğrencileri Göster",
            Location = new System.Drawing.Point(20, 380),
            Size = new System.Drawing.Size(200, 40),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        var infoLabel = new Label
        {
            Text = "Not: Struct'lar değer tipi (value type) olduğu için,\nher öğrenci bağımsız bir kopya olarak saklanır.",
            Location = new System.Drawing.Point(20, 440),
            Size = new System.Drawing.Size(800, 50),
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic),
            ForeColor = System.Drawing.Color.DarkBlue
        };

        btnShow.Click += (s, e) =>
        {
            listBox.Items.Clear();
            
            Student student1 = new Student(1, "Ali Veli", 3.75);
            Student student2 = new Student(2, "Ayşe Yılmaz", 3.92);
            Student student3 = new Student(3, "Mehmet Demir", 2.85);

            List<Student> students = new List<Student> { student1, student2, student3 };

            listBox.Items.Add("=== ÖĞRENCİ LİSTESİ ===");
            listBox.Items.Add("");
            foreach (var student in students)
            {
                listBox.Items.Add(student.ToString());
            }
        };

        tab.Controls.AddRange(new Control[] { label, listBox, btnShow, infoLabel });
        tabControl.TabPages.Add(tab);
    }

    private void CreateExceptionTab()
    {
        var tab = new TabPage("2. Exception Handling");
        
        var label = new Label
        {
            Text = "Matematiksel İşlem (Exception Handling)",
            Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
            Location = new System.Drawing.Point(20, 20),
            AutoSize = true
        };

        var label1 = new Label
        {
            Text = "Birinci Sayı:",
            Location = new System.Drawing.Point(20, 70),
            Size = new System.Drawing.Size(120, 30),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        number1TextBox = new TextBox
        {
            Location = new System.Drawing.Point(150, 70),
            Size = new System.Drawing.Size(200, 30),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        var label2 = new Label
        {
            Text = "İkinci Sayı:",
            Location = new System.Drawing.Point(20, 120),
            Size = new System.Drawing.Size(120, 30),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        number2TextBox = new TextBox
        {
            Location = new System.Drawing.Point(150, 120),
            Size = new System.Drawing.Size(200, 30),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        var btnCalculate = new Button
        {
            Text = "Bölme İşlemi Yap",
            Location = new System.Drawing.Point(20, 170),
            Size = new System.Drawing.Size(200, 40),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        resultLabel = new Label
        {
            Location = new System.Drawing.Point(20, 230),
            Size = new System.Drawing.Size(800, 100),
            Font = new System.Drawing.Font("Segoe UI", 10F),
            AutoSize = false
        };

        var finallyLabel = new Label
        {
            Text = "",
            Location = new System.Drawing.Point(20, 340),
            Size = new System.Drawing.Size(800, 30),
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic),
            ForeColor = System.Drawing.Color.Green
        };

        btnCalculate.Click += (s, e) =>
        {
            resultLabel.Text = "";
            finallyLabel.Text = "";

            try
            {
                int sayi1 = int.Parse(number1TextBox.Text);
                int sayi2 = int.Parse(number2TextBox.Text);
                int sonuc = sayi1 / sayi2;
                resultLabel.Text = $"✓ Sonuç: {sayi1} / {sayi2} = {sonuc}";
                resultLabel.ForeColor = System.Drawing.Color.Green;
            }
            catch (DivideByZeroException ex)
            {
                resultLabel.Text = $"✗ HATA: Sıfıra bölme hatası!\n{ex.Message}";
                resultLabel.ForeColor = System.Drawing.Color.Red;
            }
            catch (FormatException ex)
            {
                resultLabel.Text = $"✗ HATA: Geçersiz format! Lütfen sayı giriniz.\n{ex.Message}";
                resultLabel.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                resultLabel.Text = $"✗ Beklenmeyen hata: {ex.Message}";
                resultLabel.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                finallyLabel.Text = ">>> Finally bloğu çalıştı! (Her durumda çalışır)";
            }
        };

        tab.Controls.AddRange(new Control[] { 
            label, label1, number1TextBox, label2, number2TextBox, 
            btnCalculate, resultLabel, finallyLabel 
        });
        tabControl.TabPages.Add(tab);
    }

    private void CreateObsoleteTab()
    {
        var tab = new TabPage("3. Obsolete Attribute");
        
        var label = new Label
        {
            Text = "Obsolete Attribute Örnekleri",
            Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
            Location = new System.Drawing.Point(20, 20),
            AutoSize = true
        };

        var outputBox = new RichTextBox
        {
            Location = new System.Drawing.Point(20, 70),
            Size = new System.Drawing.Size(800, 300),
            Font = new System.Drawing.Font("Consolas", 10F),
            ReadOnly = true
        };

        var btnOldMethod = new Button
        {
            Text = "Eski Metot (Uyarı Verir)",
            Location = new System.Drawing.Point(20, 390),
            Size = new System.Drawing.Size(200, 40),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        var btnNewMethod = new Button
        {
            Text = "Yeni Metot",
            Location = new System.Drawing.Point(240, 390),
            Size = new System.Drawing.Size(200, 40),
            Font = new System.Drawing.Font("Segoe UI", 10F)
        };

        var infoLabel = new Label
        {
            Text = "Not: EskiMetot() [Obsolete(..., false)] ile işaretlenmiştir - sadece uyarı verir.\n" +
                   "CokEskiMetot() [Obsolete(..., true)] ile işaretlenmiştir - derleme hatası verir (yorum satırında).",
            Location = new System.Drawing.Point(20, 450),
            Size = new System.Drawing.Size(800, 50),
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic),
            ForeColor = System.Drawing.Color.DarkBlue
        };

        btnOldMethod.Click += (s, e) =>
        {
            outputBox.Clear();
            outputBox.AppendText("Eski metot çağrılıyor (sadece uyarı verir):\n");
            outputBox.AppendText(">>> ");
            ObsoleteExample.EskiMetot();
            outputBox.AppendText("\n\n(Bu metot derleme sırasında uyarı verecek ama çalışacak)");
        };

        btnNewMethod.Click += (s, e) =>
        {
            outputBox.Clear();
            outputBox.AppendText("Yeni metot çağrılıyor:\n");
            outputBox.AppendText(">>> ");
            ObsoleteExample.YeniMetot();
        };

        tab.Controls.AddRange(new Control[] { 
            label, outputBox, btnOldMethod, btnNewMethod, infoLabel 
        });
        tabControl.TabPages.Add(tab);
    }

    private void CreateReflectionTab()
    {
        var tab = new TabPage("4. Reflection Raporu");
        
        var label = new Label
        {
            Text = "Custom Attribute ve Reflection Raporu",
            Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
            Location = new System.Drawing.Point(20, 20),
            AutoSize = true
        };

        outputTextBox = new RichTextBox
        {
            Location = new System.Drawing.Point(20, 70),
            Size = new System.Drawing.Size(800, 400),
            Font = new System.Drawing.Font("Consolas", 9F),
            ReadOnly = true
        };

        var btnGenerate = new Button
        {
            Text = "Reflection Raporu Oluştur",
            Location = new System.Drawing.Point(20, 490),
            Size = new System.Drawing.Size(250, 40),
            Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold)
        };

        btnGenerate.Click += (s, e) => GenerateReflectionReport();

        tab.Controls.AddRange(new Control[] { label, outputTextBox, btnGenerate });
        tabControl.TabPages.Add(tab);
    }

    private void GenerateReflectionReport()
    {
        outputTextBox.Clear();
        
        Type type = typeof(ExampleClass);

        outputTextBox.AppendText("=== CUSTOM ATTRIBUTE VE REFLECTION RAPORU ===\n\n");
        outputTextBox.AppendText("SINIF BİLGİLERİ\n");
        outputTextBox.AppendText("---------------\n");
        outputTextBox.AppendText($"Sınıf Adı: {type.Name}\n");
        outputTextBox.AppendText($"Tam Adı: {type.FullName}\n");
        outputTextBox.AppendText($"Namespace: {type.Namespace}\n");
        outputTextBox.AppendText($"Tip: {type.GetType().Name}\n\n");

        // Sınıf üzerindeki attribute'ları kontrol et
        var classAttributes = type.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);
        if (classAttributes.Length > 0)
        {
            outputTextBox.AppendText("Sınıf Attribute Bilgileri:\n");
            foreach (DeveloperInfoAttribute attr in classAttributes)
            {
                outputTextBox.AppendText($"  - Geliştirici: {attr.DeveloperName}\n");
                outputTextBox.AppendText($"  - Versiyon: {attr.Version}\n");
                outputTextBox.AppendText($"  - Açıklama: {attr.Description}\n");
                outputTextBox.AppendText($"  - Oluşturulma Tarihi: {attr.CreatedDate:yyyy-MM-dd HH:mm:ss}\n\n");
            }
        }
        else
        {
            outputTextBox.AppendText("Sınıf üzerinde DeveloperInfo attribute'u bulunamadı.\n\n");
        }

        // Metotları al
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        outputTextBox.AppendText("\nMETOT BİLGİLERİ\n");
        outputTextBox.AppendText("---------------\n");
        outputTextBox.AppendText($"Toplam Metot Sayısı: {methods.Length}\n\n");

        int methodNumber = 1;
        foreach (MethodInfo method in methods)
        {
            outputTextBox.AppendText($"{methodNumber}. Metot: {method.Name}\n");
            outputTextBox.AppendText($"   Dönüş Tipi: {method.ReturnType.Name}\n");
            outputTextBox.AppendText($"   Parametreler: {string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"))}\n");

            // Metot üzerindeki attribute'ları kontrol et
            var methodAttributes = method.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);
            if (methodAttributes.Length > 0)
            {
                outputTextBox.AppendText("   Attribute Bilgileri:\n");
                foreach (DeveloperInfoAttribute attr in methodAttributes)
                {
                    outputTextBox.AppendText($"     - Geliştirici: {attr.DeveloperName}\n");
                    outputTextBox.AppendText($"     - Versiyon: {attr.Version}\n");
                    outputTextBox.AppendText($"     - Açıklama: {attr.Description}\n");
                    outputTextBox.AppendText($"     - Oluşturulma Tarihi: {attr.CreatedDate:yyyy-MM-dd HH:mm:ss}\n");
                }
            }
            else
            {
                outputTextBox.AppendText("   Attribute: Bu metotta DeveloperInfo attribute'u yok.\n");
            }

            outputTextBox.AppendText("\n");
            methodNumber++;
        }

        outputTextBox.AppendText("\n=== REFLECTION RAPORU TAMAMLANDI ===\n");
    }
}

