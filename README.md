<div style="text-align:center;">
<img src="wwwroot/Images/logo.png">
</div>
# VNPage

**VNPage** es una aplicación web desarrollada en **ASP.NET Core 8** diseñada para la gestión, exploración y reseña de novelas visuales. El proyecto permite a los usuarios ver un catálogo de novelas, leer reseñas y permite a los administradores gestionar el contenido.

## 🚀 Características

* **Catálogo de Novelas Visuales:** Visualización de títulos con detalles como desarrollador, género, etiquetas, fecha de lanzamiento y puntaje.
* **Sistema de Usuarios:** Autenticación y autorización robusta mediante **ASP.NET Core Identity**.
* **Roles y Permisos:** Sistema de roles diferenciados (Admin y usuarios estándar).
* **Panel de Administración:** Funcionalidades para crear, editar y eliminar novelas visuales.
* **Reseñas y Comentarios:** Estructura de datos preparada para la interacción de la comunidad.
* **Seed de Datos Automático:** El sistema verifica y crea automáticamente un usuario administrador y el rol correspondiente al iniciar la aplicación si no existen.

## 🛠️ Tecnologías Utilizadas

* **Framework:** .NET 8.0 (ASP.NET Core Razor Pages).
* **Base de Datos:** SQLite.
* **ORM:** Entity Framework Core 8.0.
* **Seguridad:** Microsoft.AspNetCore.Identity para gestión de usuarios y BCrypt.Net-Next para utilidades criptográficas.

## 📋 Requisitos Previos

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.

## ⚙️ Instalación y Ejecución

1.  **Clonar el repositorio:**
    ```bash
    git clone <url-del-repositorio>
    cd vnpage
    ```

2.  **Restaurar dependencias:**
    ```bash
    dotnet restore
    ```

3.  **Configurar la Base de Datos:**
    El proyecto utiliza SQLite. Ejecuta las migraciones para generar el archivo `VNpage.db`:
    ```bash
    dotnet ef database update
    ```

4.  **Ejecutar la aplicación:**
    ```bash
    dotnet run
    ```

5.  **Acceder a la web:**
    Abre tu navegador y ve a `https://localhost:7148` (o el puerto que indique tu consola).

## 🔐 Credenciales de Administrador (Seed Inicial)

Al ejecutar la aplicación por primera vez, se creará automáticamente un usuario con permisos administrativos para facilitar el desarrollo.

* **Usuario:** `admin`
* **Contraseña:** `Admin123!`

> ⚠️ **Nota de Seguridad:** Estas credenciales son generadas automáticamente en el archivo `Program.cs` para entornos de desarrollo. Se recomienda cambiar la contraseña y ajustar la configuración de seguridad (`options.Password`) antes de desplegar en producción.

## 📂 Estructura del Proyecto

* **Data/**: Contiene el `ApplicationDbContext` y la configuración de EF Core.
* **Models/**: Modelos de dominio como `NovelaVisual`, `Resena` y `ApplicationUser`.
* **Pages/**:
    * **Public/**: Vistas accesibles para todos los usuarios (Catálogo, Detalles).
    * **Admin/**: Vistas protegidas para la gestión del sitio.
    * **Account/**: Login, Registro y Logout.

---
*Este proyecto fue desarrollado con fines educativos y de demostración.*
