# CleanStore

Ett ASP.NET Core Web API för produkter och kategorier, byggt med
Clean Architecture, CQRS, MediatR och Repository Pattern.

## Teknik

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MediatR
- Swagger

## Projektstruktur

- **CleanStore.Domain** – entiteterna Product och Category.
- **CleanStore.Application** – repository-interface, commands, queries och handlers.
- **CleanStore.Infrastructure** – DbContext, repository och migrations.
- **CleanStore.Api** – controllers och registrering av beroenden.

En kategori kan ha flera produkter. Controllers använder MediatR
för att skicka requests till handlers i Application-lagret.

## Kom igång

1. Installera .NET 9 SDK och SQL Server eller SQL Server LocalDB.
2. Klona repot och öppna projektets rotmapp.
3. Anpassa `ConnectionStrings:DefaultConnection` i
   `CleanStore.Api/appsettings.json` till din SQL Server.
4. Kör:

```powershell
dotnet restore
dotnet build
dotnet run --project CleanStore.Api
```

Databasen skapas och migrations appliceras automatiskt vid start.
SQL Server måste vara tillgänglig och anslutningen måste ha
behörighet att skapa och uppdatera databasen.

Kategorin Electronics med Id 1 läggs in via migration.

Öppna `/swagger` på adressen som terminalen visar.
Vid lokal utveckling har API:t körts på:

http://localhost:5057/swagger

Swagger är aktiverat i Development-miljön.

## Endpoints

| Metod | Endpoint | Funktion |
|-------|----------|----------|
| GET | /api/Product | Hämta alla produkter |
| POST | /api/Product | Skapa en produkt |
| PUT | /api/Product/{id} | Uppdatera en produkt |
| DELETE | /api/Product/{id} | Ta bort en produkt |

## Skapa en produkt

POST `/api/Product`:

```json
{
  "name": "Laptop",
  "description": "Gaming laptop",
  "price": 9999,
  "categoryId": 1
}
```

CategoryId måste referera till en befintlig kategori.

## Uppdatera en produkt

PUT `/api/Product/{id}`:

```json
{
  "id": 3,
  "name": "Laptop",
  "description": "Uppdaterad gaming laptop",
  "price": 8999,
  "categoryId": 1
}
```

Ersätt 3 med produktens faktiska Id i både adressen och JSON-kroppen.

## Testning

API:t testas manuellt via Swagger:

1. Skapa en produkt med POST.
2. Hämta listan med GET och kontrollera produkten.
3. Uppdatera produkten med PUT.
4. Kör GET och kontrollera ändringen.
5. Ta bort produkten med DELETE.
6. Kör GET och kontrollera att produkten är borta.

PUT och DELETE returnerar 204 vid framgång och 404 om produkten
saknas. PUT returnerar 400 om adressens Id och kroppens Id skiljer sig.

## Git-arbetsflöde

Ändringar görs på feature branches och förs in i main via Pull Requests.