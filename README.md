# Instrucciones para Ejecutar la API

## Requisitos previos

Antes de ejecutar la API, asegúrate de tener las siguientes herramientas instaladas:

1. **.NET SDK**: Asegúrate de tener instalado el SDK de .NET 6.0 o superior. Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download).

2. **dotnet ef**: Las herramientas de **Entity Framework Core** son necesarias para gestionar las migraciones de la base de datos. Si no tienes **dotnet ef** instalado, ejecuta el siguiente comando en la terminal para instalarlo globalmente:

    ```bash
    dotnet tool install --global dotnet-ef
    ```

## Pasos para ejecutar la API

Sigue estos pasos para ejecutar la API correctamente:

1. **Actualizar la base de datos**: 
   
   Antes de arrancar la API, debes asegurarte de que la base de datos esté actualizada. Ejecuta el siguiente comando en la raíz del proyecto, donde se encuentra la solución (el archivo `.sln`):

   ```bash
   dotnet ef database update --project "Core/Infraestructure/Syac.Orders.Core.Infraestructure.Persistence/Syac.Orders.Core.Infraestructure.Persistence.csproj" --startup-project "Web/Syac.Orders.Web.Api/Syac.Orders.Web.Api.csproj"
