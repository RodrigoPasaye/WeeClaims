# WeeClaims Backend

## DEV

1. Clonar el repositorio
2. Cambiar cadena de conexión en el archivo appsettings.json para conectarse con la BD de SQLServer. El ejemplo es utilizando SQL Server Authentication
   Si estas usando Windows Authentication usa el siguiente ejemplo para evitar problemas al conectarse
  ```
  Server=MyServer;Database=WeeClaims;Trusted_Connection=True;Encrypt=false;Trust Server Certificate=True
  ```
3. Iniciar migraciones (en caso de que no existan) ejecutar el siguiente comando con la consola de administrador de paquetes Nuget
  ```
  Add-Migration InitDB
  ```
4. Ejecutar Script para creación de BD
5. Creacion de tablas ejecutar el siguiente comando con la consola de administrador de paquetes Nuget
  ```
  Update-Database
  ```
8. Correr proyecto 
