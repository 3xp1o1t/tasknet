# Tasknet

## Table of Contents

- [Tasknet](#tasknet)
  - [Table of Contents](#table-of-contents)
  - [About](#about)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
  - [Usage](#usage)
    - [Guía de EF incluyendo comandos de dotnet](#guía-de-ef-incluyendo-comandos-de-dotnet)

## About

Aplicación sencilla para gestionar tareas creada con ASP.Net 8 (Backend) y React (Frontend)

## Getting Started

TODO

### Prerequisites

TODO

```bash
TODO
```

## Usage

### Guía de EF incluyendo comandos de dotnet

Listar sdks instalados

```bash
dotnet --list-sdks
```

Crear proyecto de WebApi con controladores y https por default

```bash
dotnet new webapi -controllers -f net8.0
```

Iniciar proyecto con Swagger (usando run, por alguna razón no lo inicia)

```bash
dotnet watch --project .\TasknetBackend\TasknetBackend.csproj
```

[Comandos dotnet ef](https://www.learnentityframeworkcore.com/migrations/add-migration)

Cadena de conexión para instancias locales:

```json
"ConnectionStrings": {
  "TasknetConnection": "Server=JMDEV\\SQLEXPRESS;Database=Tasknet;User Id=<user>;Password=<password>;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
}
```

`Construir el proyecto para verificar errores`

```powershell
dotnet build
```

Ejemplo para ejecutar las migraciones desde el CLI de dotnet

```bash
# Initial es el nombre de la migración y project es la ruta del proyecto
dotnet ef migrations add Initial --project .\TasknetBackend\TasknetBackend.csproj
```

Revertir los cambios de la migración

```bash
# seguro que necesita la ruta del proyecto en algunos casos
dotnet ef migrations remove
```

Después de agregar la migración se envían los cambios al DBMS

```bash
dotnet ef database update --project .\TasknetBackend\TasknetBackend.csproj
```

`Cualquier cambio en un modelo requiere crear una migración nueva + actualizar la base de datos`
