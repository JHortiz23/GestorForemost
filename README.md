
# GestorForemost

**GestorForemost** es un software creado para la gestión de cobros, el cual se alimenta automáticamente con facturas generadas desde el punto de ventas. Está diseñado para facilitar el control de cobros pendientes y pagos realizados, ofreciendo herramientas para la asignación de cuentas a gestores de cobro y la visualización de información clave de clientes y facturas.

## Funcionalidades principales

### Módulo de Inicio
Menú principal de la aplicación.
    <img width="960" alt="Captura de pantalla 2024-10-04 094815" src="https://github.com/user-attachments/assets/f01b4549-c438-4733-aef9-aa3008254fff">


### Módulo de Facturas
1. **Ver facturas pendientes**: Generadas desde el punto de venta por agentes de ventas.
    <img width="960" alt="Captura de pantalla 2024-10-04 094840" src="https://github.com/user-attachments/assets/8a6eb195-020e-40dc-ba6e-13f593304e86">



3. **Histórico de facturas pagadas**: Facturas que ya han sido pagadas y están fuera del proceso de cobro.
     <img width="960" alt="Captura de pantalla 2024-10-04 094902" src="https://github.com/user-attachments/assets/f70811fb-7306-41ea-9b3e-986a4491fc06">


### Módulo de Clientes
1. **Lista de clientes**: Permite ver la lista completa de los clientes de la empresa junto con su información detallada, facilitando la labor de los gestores de cobro.
     <img width="960" alt="Captura de pantalla 2024-10-04 094927" src="https://github.com/user-attachments/assets/72a0dae9-24d9-4421-9355-7c7a9ddb3716">
     <img width="960" alt="Captura de pantalla 2024-10-04 094948" src="https://github.com/user-attachments/assets/19255d05-0838-403f-9036-046478c589b6">


   

### Módulo de Cobros
1. **Gestión de Cobros**: Módulo para asignar cuentas con saldos pendientes a los gestores de cobro. La asignación puede realizarse por día o turno y se puede redistribuir las cuentas que aún están pendientes.
<img width="959" alt="Captura de pantalla 2024-10-04 095426" src="https://github.com/user-attachments/assets/f8d546b8-f495-4382-af4f-114a403a47ec">
<img width="960" alt="Captura de pantalla 2024-10-04 105426" src="https://github.com/user-attachments/assets/ec7d5973-0045-4393-ac61-737d9ce4e81f">



## Instalación

Para descargar e instalar GestorForemost desde Git, sigue los siguientes pasos:

1. Clona el repositorio a tu máquina local:
    \`\`\`bash
    git clone https://github.com/JHortiz23/GestorForemost.git
    \`\`\`
   

## Conexión a la base de datos

La base de datos que utiliza este proyecto se llama **GestorForemost**. Se incluye una copia de la base de datos junto con el proyecto para simplificar la configuración inicial.

### Configuración en `appsettings.json`

La conexión a la base de datos se establece en el archivo `appsettings.json`. A continuación, se muestra un ejemplo de la cadena de conexión que debes configurar:

\`\`\`json
"ConnectionStrings": {
  "Conexion": "server="nombre servidor"; database=GestorForemost; User Id=sa; Password=password;"
}
\`\`\`

### Pasos para establecer la conexión:

1. Abre el archivo `appsettings.json` ubicado en el directorio raíz del proyecto.
2. Asegúrate de que la cadena de conexión esté correctamente configurada con los datos del servidor SQL donde se encuentra la base de datos.
3. Si es necesario, actualiza los valores de `server`, `User Id` y `Password` según tu configuración local de SQL Server.

Una vez configurada la conexión, el proyecto estará listo para ejecutarse y comenzar a interactuar con la base de datos **GestorForemost**.

Esto iniciará la aplicación y permitirá acceder a las funcionalidades de gestión de facturas, clientes y cobros a través de la interfaz web.

---

Si tienes alguna duda o problema con la instalación, no dudes en revisar la documentación oficial de .NET
