# ASP.NET-UZDUOTIS


1. atidarykite failą "Uzduoties aplankas"/WebApplication1/appsettings.json
2. trečioje eilutėje pakeiskite connection string ir duomenu bazes pavadinimą 
"DefaultConnection": "Server=localhost;Database=test4;Trusted_Connection=True;"

3.atsidare projektą isijunkite "package manager console" ir įvesti dvi komandas:
  1. add-migration InitialCreate
  2. update-database
  
4. paleisti programą.
