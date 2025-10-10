# Microservicio de Inventario

Requisitos:
- Visual Studio Code (o Visual Studio 2022)
- .NET 8 SDK
- PostgreSQL

Instrucciones para ejecutar con Visual Studio Code (Windows / PowerShell)

1. Abrir el proyecto en VS Code

- Abre Visual Studio Code y selecciona "File → Open Folder...". Elige la carpeta raíz del repositorio (donde está `Inventory.sln`).

2. Restaurar paquetes y compilar

- Abre una terminal integrada en VS Code (PowerShell es la predeterminada en Windows) y ejecuta:

```powershell
dotnet restore Inventory.sln
dotnet build Inventory.sln -c Debug
```

3. Configurar la base de datos (PostgreSQL)

- Asegúrate de tener PostgreSQL en ejecución y crea la base de datos que usa la aplicación.
- Edita las cadenas de conexión en `src/Inventory.WebApi/appsettings.json` o en `appsettings.Development.json` según corresponda. Por ejemplo:

```json
// ... en appsettings.json
"ConnectionStrings": {
	"DefaultConnection": "Host=localhost;Port=5432;Database=inventory_db;Username=postgres;Password=changeme"
}
```

Nota: Si aún no tienes la herramienta de EF CLI instalada globalmente, instala el paquete de herramientas:

```powershell
dotnet tool restore
dotnet tool install --global dotnet-ef --version 8.*
```

4. Ejecutar la API desde VS Code

- Opción A - Usar la terminal:

```powershell
dotnet run --project src/Inventory.WebApi/Inventory.WebApi.csproj
```

- Opción B - Usar Run and Debug (F5):
	1. Abre la carpeta `src/Inventory.WebApi` en el explorador de proyectos.
	2. Abre `src/Inventory.WebApi/Properties/launchSettings.json` para revisar los perfiles disponibles.
	3. Abre la vista Run and Debug (Ctrl+Shift+D), crea o selecciona una configuración `.NET Launch (web)` apuntando a `src/Inventory.WebApi/Inventory.WebApi.csproj` y presiona F5.

5. Ejecutar y depurar múltiples proyectos (si necesitas servicios adicionales)

- Para ejecutar varios proyectos simultáneamente (por ejemplo API y un worker), abre varias terminales y ejecuta `dotnet run --project <ruta>` para cada proyecto.
- Alternativamente, crea una configuración de lanzamiento compuesta en `.vscode/launch.json` que inicie varios proyectos a la vez.

6. Comprobaciones rápidas y troubleshooting

- Verifica que el puerto en `launchSettings.json` no esté en uso.
- Revisa la salida de la terminal y el panel "Problems" de VS Code para errores de compilación.
- Si faltan paquetes NuGet, ejecuta `dotnet restore` de nuevo.


Instrucciones para ejecutar con Visual Studio 2022 (Windows)

1. Abrir la solución

- Abre Visual Studio 2022 y selecciona File → Open → Project/Solution. Elige la solución `Inventory.sln` en la raíz del repositorio.

2. Restaurar paquetes y compilar

- Visual Studio normalmente restaurará los paquetes NuGet al abrir la solución. Para forzar la restauración: desde el menú selecciona "Tools → NuGet Package Manager → Package Manager Console" y ejecuta `Update-Package -reinstall`, o usa "Build → Restore NuGet Packages".
- Compila la solución con Build → Build Solution (Ctrl+Shift+B).

3. Configurar la cadena de conexión (PostgreSQL)

- Edita `src/Inventory.WebApi/appsettings.json` o `appsettings.Development.json` para ajustar la cadena de conexión. También puedes usar secretos de usuario o variables de entorno desde Visual Studio (Properties → Debug → Environment variables) si no quieres cambiar los archivos en el repositorio.


4. Ejecutar y depurar desde Visual Studio

- En el Explorador de soluciones, haz clic derecho en `src/Inventory.WebApi` y selecciona "Set as Startup Project".
- Si necesitas iniciar varios proyectos al mismo tiempo, haz clic derecho en la solución → Properties → Startup Project → selecciona "Multiple startup projects" y para cada proyecto elige la acción "Start" o "Start without debugging".
- Selecciona el perfil de ejecución (IIS Express o el proyecto) desde la barra superior y presiona F5 para ejecutar con depuración o Ctrl+F5 para ejecutar sin depuración.

5. Consejos y troubleshooting específicos de Visual Studio

- Si Visual Studio no encuentra el SDK, instala el workload ".NET desktop development" y/o "ASP.NET and web development" desde el Visual Studio Installer y confirma que el SDK .NET 8 está instalado en el sistema.
- Revisa la ventana "Output" (Show output) y la "Error List" para diagnósticos claros cuando la compilación o la ejecución fallen.




