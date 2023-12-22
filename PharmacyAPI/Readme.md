# Proyecto .NET Core Web API

Este proyecto es una API desarrollada en .NET Core que proporciona funciones para gestionar informaci�n sobre farmacias. Incluye la consulta de farmacias, la creaci�n de nuevas farmacias y la b�squeda de la farmacia m�s cercana en base a la geolocalizaci�n del cliente.

## Caracter�sticas

- Consulta de farmacias existentes.
- Creaci�n de nuevas farmacias.
- B�squeda de la farmacia m�s cercana basada en la geolocalizaci�n del cliente.

## Requisitos

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Configuraci�n y Uso

### Ejecuci�n con Docker Compose

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/tu-proyecto.git

2. Accede al directorio del proyecto
   
	cd tu-proyecto

3. Ejecuci�n de la aplicaci�n

	docker-compose up	

4. Acceder al a API (swagger y uso)

    http://localhost:puerto/swagger/index.html
    http://localhost:puerto/api/

### Base de datos y ejemplo

5. Base de datos

	Se incluye un script de creaci�n (script.sql) en la carpeta database para inicializar la base de datos con datos de ejemplo.

6. Endpoints

    GET /api/farmacias: Obtiene la lista de todas las farmacias.
    POST /api/farmacias: Crea una nueva farmacia.
    GET /api/farmacias/cercana?latitud=valor&longitud=valor: Obtiene la farmacia m�s cercana basada en la geolocalizaci�n del cliente.