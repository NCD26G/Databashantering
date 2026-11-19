# Lektion 9
Idag ska vi gå igenom hur vi kan skydda vår anslutningssträng med hjälp av dotnet's inbyggda _secrets_

### Följande steg behöver genomföras för att kunna använda dotnet user-secrets

1. Installera Microsoft.Extensions.Hosting

2. I terminalen kör följande kommando dotnet user-secrets init

3. Kör följande kommmando i terminalen dotnet user-secrets set ConnectionStrings:pgsql **"<Vår anslutningssträng till postgres databasen>"**

4. Lägg till följande kod i _app.axaml.cs_

    ```
	var builder = Host.CreateApplicationBuilder();
    builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

    var connectionString = builder.Configuration.GetConnectionString("pgsql");
    collection.AddDbContext<RunStoreDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
        options.LogTo(Console.WriteLine, LogLevel.Information);
    });
   ``` 

5.	Uppdatera RunStoreDbContext med en _constructor_ i detta fall en **primary constructor**
	`public class RunStoreDbContext(DbContextOptions options) : DbContext(options)`

6.	Ta bort **OnConfiguring** metoden

7.	Ta bort i _ServiceCollectionExtensions_ collection.`AddDbContext<RunStoreDbContext>();`

8.	Testkör applikationen och den bör fungera som vanligt

9.	Gör en test migrering och se felet som uppstår

10.	Skapa en ny klass i Factories katalogen 
```public class DatabaseDesignTimeFactory:IDesignTimeDbContextFactory<RunStoreDbContext>```

