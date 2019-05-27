# ASP.NET-UZDUOTIS


1. Atidarykite failą "Užduoties aplankas"/WebApplication1/appsettings.json
2. Trečioje eilutėje pakeiskite "connection string" ir duomenų bazės pavadinimą 
"DefaultConnection": "Server=localhost;Database=test4;Trusted_Connection=True;"

3.Atsidarykite projektą įsijunkite "package manager console" ir įvesti dvi komandas:
  1. add-migration InitialCreate
  2. update-database
  
4. paleisti programą.
