public class Test1

{
    public string M1()

    {

        string json = "{\"Name\": \"Ahmet\", \"Age\": 30}";

        try

        {

            var p = JsonHelper.Deserialize<Person>(json);

            Console.WriteLine($"JSON Parse Başarılı: Name={p.Name}, Age={p.Age}");

        }

        catch (Exception ex)

        {

            Console.WriteLine($"Hata: {ex.Message}");

        }

        return json;

    }

}

 