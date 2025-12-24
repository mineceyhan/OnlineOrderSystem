public class UserProcessor
{
    public void ProcessUser(string username, string email, string password)
    {
        // 1. Doğrulama Mantığı (Validation)
        if (string.IsNullOrEmpty(username) || !email.Contains("@"))
        {
            throw new Exception("Geçersiz kullanıcı bilgileri.");
        }

        // 2. İş Mantığı / Veri Hazırlama
        string hashedPassword = "SHA256_" + password; // Basitçe şifreleme simülasyonu

        // 3. Veritabanı İşlemi (Bağımlılık içeride oluşturulmuş - Dependency Inversion ihlali)
        var connection = new SqlConnection("Server=myServer;Database=myDB;");
        connection.Open();
        var command = new SqlCommand($"INSERT INTO Users (Name, Email, Pwd) VALUES ('{username}', '{email}', '{hashedPassword}')", connection);
        command.ExecuteNonQuery();

        // 4. Günlükleme (Logging)
        System.IO.File.WriteAllText("log.txt", $"{username} sisteme kaydedildi.");
    }
}