# Programa de consola hecho en `C#`

Este programa está hecho en `C#` y tiene la función de conectarse a una base de datos creada en MySQL para manipular los datos que están almacenados ahí. Dicha base de datos tiene información sencilla (estudiantes, correos, notas) y este programa pregunta si desea añadir estudiantes a esa base, listar los estudiantes, editar la información de los estudiantes o borrar la información si se desea. El archivo para crear la base de datos se llama `crear_taller_estudiantes.sql`.

Este programa fue hecho en .NET 5.0, así que si se está usando otra versión de .NET, sólo hay que cambiar un línea de código en el archivo `SolNotas.csproj` para que compile sin problemas. El contenido de este archivo es:

```C#
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

</Project>
```

Hay que cambiar la línea `<TargetFramework>net5.0</TargetFramework>` por la versión de .NET que quiera, por ejemplo, si es .NET 3.1 sería:

```C#
<TargetFramework>netcoreapp3.1</TargetFramework>
```

También se usan [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/get-started/overview/install) y [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) para hacer la conexión con la base de datos. Revise el archivo `SolNotas.csproj` para saber qué versión desea usar. Además deberá agregar el servidor, el nombre de la base de datos, el usuario y la contraseña en `Modelo/Taller_estudiantesContext.cs` para poder manipular la base de datos.
