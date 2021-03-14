# GraphQL with .NET 5

GraphQL with .NET 5 using [Hot Chocolate](https://github.com/ChilliCream/hotchocolate)

---

## Getting Started

Start a docker instance of SQL Server 2019

```sh
docker-compose up -d
```

Connect to the DB instance, through `SSMS` or `Azure Data Studio` & execute the script from `db/db.sql`

---

## Entity Framework

Check if `dotnet-ef` is installed

```sh
dotnet ef
```

If the output is an error message, install the tool globally

```sh
dotnet tool install --global dotnet-ef
```

**Add Migration**

```sh
dotnet ef migrations add AddPlatformToDB --project .\CommanderGQL\CommanderGQL.csproj
```

**Update Database**

```sh
dotnet ef database update --project .\CommanderGQL\CommanderGQL.csproj
```

---
