using System;
using System.IO;
using System.Text.Json;

namespace OnlineOrderSystem.Services;


    public class Test3
    {
        // ❌ Hard-coded secret (CRITICAL)
        private const string ApiKey = "NOVA-SECRET-API-KEY-123456";

        // ❌ User input directly used as file path (Path Traversal)
        public string M1(string fileNameFromUser)
        {
            string content =
                "<html><head></head><body><h1>NOVA-commit-5</h1></body></html>";

            // ❌ Path Traversal vulnerability
            var fullPath = "C:\\temp\\" + fileNameFromUser;

            File.WriteAllText(fullPath, content);

            // ❌ Sensitive data exposure
            return JsonSerializer.Serialize(new
            {
                success = true,
                apiKey = ApiKey, // ❌ secret response body içinde
                savedPath = fullPath
            });
        }

        // ❌ Information disclosure
        public string CodeAnt0()
        {
            return Environment.UserName + "@" + Environment.MachineName;
        }

        // ❌ Exception leak (stack trace disclosure)
        public string CodeAnt1()
        {
            try
            {
                throw new Exception("Database connection failed: password=1234");
            }
            catch (Exception ex)
            {
                return ex.ToString(); // ❌ internal details dışarı sızıyor
            }
        }
    }

