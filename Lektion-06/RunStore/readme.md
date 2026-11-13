# Dagens lektion
Vi ska idag byta ut ADO.NET till EntityFrameworkCore i vår RunStore applikation.

### Instruktioner för att använda EF Core
1. Gå till [neon.com](https://neon.com/) och skapa ett nytt projekt
2. Skapa en ny databas och radera _neon.db_
3. Hämta starter projektet ifrån GitHub _RunStore-starter_
4. Installera följande nuget paket
    1. Microsoft.EntityFrameworkCore
    2. Microsoft.EntityFrameworkCore.Design
    3. Npgsql.EntityFrameworkCore.PostgreSQL


### Implementering av EF Core
#### DbContext
Skapa en katalog som heter _Data_. I katalogen en klass _RunStoreDbContext_
Ärv ifrån DbContext och åsidosätt *OnConfiguring* metoden
I metoden skriv följande kod ```optionsBuilder.UseNpgsql("Anslutningssträngen till postgress databasen");```.
Lägg även till raden ```optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);```. Detta ger oss en utskrift i terminalfönstret så vi ser vad som händer.

#### Skapa första migreringen
