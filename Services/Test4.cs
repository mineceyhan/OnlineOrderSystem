namespace OnlineOrderSystem.Services;

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
  // Connection string should come from configuration
     using var connection = new SqlConnection(_connectionString); // Inject via constructor
        connection.Open();

        using var command = new SqlCommand(
            "INSERT INTO Users (Name, Email, Pwd) VALUES (@username, @email, @password)",
            connection);

        command.Parameters.Add("@username", SqlDbType.NVarChar, 255).Value = username;
        command.Parameters.Add("@email", SqlDbType.NVarChar, 255).Value = email;
        command.Parameters.Add("@password", SqlDbType.NVarChar, 255).Value = hashedPassword;

        command.ExecuteNonQuery();

        // 4. Günlükleme (Logging)
        System.IO.File.AppendAllText("log.txt", $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {username} sisteme kaydedildi.{Environment.NewLine}");
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    // 2. İş Mantığı / Veri Hazırlama

 private string HashPassword(string password)
   {
       // BCrypt automatically generates a unique salt per hash
      return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
}

    // 3. Veritabanı İşlemi
}