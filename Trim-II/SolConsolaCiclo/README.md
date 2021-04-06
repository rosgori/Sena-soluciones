# Programa de consola hecho en `C#`

Este programa está hecho en `C#` y tiene la función de mostrar ciertos menús, además de agregar nombres y listar integrantes de un grupo.

Este programa fue hecho en .NET 5.0, así que si se está usando otra versión de .NET, sólo hay que cambiar una línea de código en el archivo `SolConsolaCiclo.csproj` para que compile sin problemas. El contenido de este archivo es:

```C#
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

</Project>
```

Hay que cambiar la línea `<TargetFramework>net5.0</TargetFramework>` por la versión de .NET que quiera, por ejemplo, si es .NET 3.1 sería:

```
<TargetFramework>netcoreapp3.1</TargetFramework>
```

