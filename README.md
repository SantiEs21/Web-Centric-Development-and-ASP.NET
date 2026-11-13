# Web-Centric-Development-and-ASP.NET

API REST de tareas (Todo) hecha con C# y ASP.NET Core (`TodoApi`). Usa una base de datos en memoria, así que **no necesitas instalar ninguna base de datos**.

## Requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (el proyecto usa `net10.0`)
- Git
- Un editor (opcional): VS Code con la extensión C# Dev Kit, o Visual Studio 2022+

Verifica la instalación:

```bash
dotnet --version   # debe mostrar 10.x
git --version
```

## Instalación

```bash
# 1. Clonar el repositorio
git clone <URL-DEL-REPOSITORIO>
cd Web-Centric-Development-and-ASP.NET

# 2. Restaurar herramientas locales (CSharpier, opcional) y paquetes NuGet
dotnet tool restore
dotnet restore

# 3. (Opcional) Confiar en el certificado HTTPS de desarrollo
dotnet dev-certs https --trust
```

## Ejecutar el proyecto

```bash
dotnet run --launch-profile https
```

O solo HTTP:

```bash
dotnet run --launch-profile http
```

URLs:

| Perfil | URL                    |
| ------ | ---------------------- |
| http   | http://localhost:5088  |
| https  | https://localhost:7216 |

Para detener la aplicación presiona `Ctrl + C`.

## Probar la API

- Swagger UI (solo en Development): http://localhost:5088/swagger
- Documento OpenAPI: http://localhost:5088/openapi/v1.json
- Archivo `TodoApi.http` para probar desde VS Code / Visual Studio.

Endpoints principales:

| Método | Ruta                  | Descripción             |
| ------ | --------------------- | ----------------------- |
| GET    | `/api/TodoItems`      | Listar tareas           |
| GET    | `/api/TodoItems/{id}` | Obtener una tarea       |
| POST   | `/api/TodoItems`      | Crear una tarea         |
| PUT    | `/api/TodoItems/{id}` | Actualizar una tarea    |
| DELETE | `/api/TodoItems/{id}` | Eliminar una tarea      |
| GET    | `/weatherforecast`    | Ejemplo de la plantilla |

Ejemplo:

```bash
curl -X POST http://localhost:5088/api/TodoItems \
  -H "Content-Type: application/json" \
  -d '{"name":"Mi primera tarea","isComplete":false}'
```

## Comandos útiles

```bash
dotnet build           # compilar
dotnet watch run       # ejecutar con recarga automática
dotnet csharpier .     # formatear el código
```

> Nota: los datos viven en memoria; se pierden al detener la aplicación.
