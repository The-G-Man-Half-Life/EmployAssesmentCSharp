Aquí tienes todo el contenido dentro de un archivo Markdown:

# Project Name: EmployAssesmentCSharp

## Description
Este proyecto es un sistema para gestionar citas médicas. Permite a los usuarios (pacientes y doctores) crear y gestionar citas, visualizar enfermedades y tipos de cita, y administrar los datos de los pacientes, doctores y citas en una base de datos.

## Features
- **Gestión de pacientes:** Creación y almacenamiento de pacientes con sus datos personales.
- **Gestión de doctores:** Información sobre los doctores, especialidades y horarios de trabajo.
- **Gestión de citas:** Programación de citas médicas entre pacientes y doctores, con detalles sobre la enfermedad y tipo de cita.
- **Base de datos:** Utiliza Entity Framework Core para interactuar con la base de datos y manejar la persistencia de datos.

## Technologies Used
- **C#**: Lenguaje de programación principal.
- **ASP.NET Core**: Framework para la creación de la API.
- **Entity Framework Core**: ORM para interactuar con la base de datos.
- **SQL Server**: Base de datos utilizada para almacenar los datos.
- **Bogus**: Librería para la generación de datos falsos (seeders).

## Setup

### Prerequisites
- **.NET 8 SDK**: Asegúrate de tener el SDK de .NET 8 instalado en tu máquina. Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download).
- **SQL Server**: Necesitarás SQL Server para ejecutar la base de datos localmente. Si no lo tienes instalado, puedes obtenerlo [aquí](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

### Clonar el repositorio
```bash
git clone https://github.com/tu_usuario/EmployAssesmentCSharp.git
cd EmployAssesmentCSharp

Instalación de dependencias

Instala las dependencias necesarias con el siguiente comando:

dotnet restore

Configuración de la base de datos

    Asegúrate de que tu conexión a la base de datos esté correctamente configurada en el archivo appsettings.json. Aquí puedes definir la cadena de conexión a tu base de datos SQL Server.

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EmployAssesmentDB;Trusted_Connection=True;"
}

Aplica las migraciones para crear las tablas en la base de datos:

    dotnet ef database update

Seed de la base de datos

Los seeders de datos se ejecutan automáticamente durante el inicio de la aplicación. Si deseas ejecutar los seeders manualmente para poblar la base de datos con datos de prueba (como doctores, pacientes, citas, etc.), puedes llamar a los métodos correspondientes desde el ApplicationDbContext.

Los seeders disponibles son:

    DoctorSeeder: Inserta doctores de prueba en la base de datos.
    PatientSeeder: Inserta pacientes de prueba.
    AppointmentSeeder: Inserta citas médicas de prueba.
    DiseasSeeder: Inserta enfermedades de prueba.
    AppointmentTypeSeeder: Inserta tipos de citas de prueba.

API Documentation

La documentación de la API está disponible en Swagger, una herramienta de interfaz interactiva que te permite probar los endpoints directamente desde el navegador.

Para acceder a Swagger, inicia el proyecto y abre el siguiente enlace en tu navegador:

http://localhost:5000/swagger

Diagramas

Para los diagramas del sistema se utilizaron las siguientes herramientas:

    Draw.io: Herramienta para crear diagramas de flujo, estructuras de base de datos y diagramas de casos de uso.
    Miro: Herramienta colaborativa para la creación de diagramas interactivos.
    Visual Paradigm Online: Herramienta para diagramas UML, como diagramas de clases y secuencias.