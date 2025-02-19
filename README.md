# Proyecto ASP.NET Core Web API

## Descripción 

API desarrollada en ASP.NET Core que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) al modelo User con una conexión a una base de datos PostgreSQL.

## Instalación 
```
git clone https://github.com/dcastrog111/AztroWebApplication.git
```

## Instalar dependencias
```
dotnet restore
```
## Configurar conexión a BBDD
```
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=tu_base_de_datos;Username=tu_usuario;Password=tu_contraseña"
}
```
## Modelo de datos 
```
public class User {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
}
```

## Ejecutar el proyecto

```
dotnet watch run --hot-reload
```

## Endpoints 

### Puerto : http://localhost:5163

| Método | Ruta           | Descripción                     |
|--------|----------------|---------------------------------|
| GET    | /api/User      | Obtiene todos los usuarios      |
| GET    | /api/User/{id} | Obtiene un usuario de acuerdo al id|
| POST   | /api/User      | Crea un nuevo usuario           |
| PUT    | /api/User/{id} | Actualiza un usuario existente de acuerdo al id |
| DELETE | /api/User/{id} | Elimina el usuario de acuerdo al id |





