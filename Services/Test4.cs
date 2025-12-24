public class UserProcessor
{
    public void ProcessUser(string username, string email, string password)
    {
        // 1. Doğrulama Mantığı (Validation)
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty.", nameof(username));

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be empty.", nameof(password));

        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
        {
            throw new ArgumentException("Invalid email format.", nameof(email));
        }
        string hashedPassword = HashPassword(password);
        using var connection = new SqlConnection("Server=myServer;Database=myDB;");
        connection.Open();

        using var command = new SqlCommand(
            "INSERT INTO Users (Name, Email, Pwd) VALUES (@username, @email, @password)",
            connection);

        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", hashedPassword);

        command.ExecuteNonQuery();

        // 4. Günlükleme (Logging)
        System.IO.File.WriteAllText("log.txt", $"{username} sisteme kaydedildi.");
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            // 4. Günlükleme (Logging)
            var logMessage = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {username} sisteme kaydedildi.{Environment.NewLine}";
            System.IO.File.AppendAllText("log.txt", logMessage); return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    // 2. İş Mantığı / Veri Hazırlama

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var saltedPassword = password + "YourSaltHere"; // Use a unique salt per user in production
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        return Convert.ToBase64String(bytes);
    }

    // 3. Veritabanı İşlemi
}