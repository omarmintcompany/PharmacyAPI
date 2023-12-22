# Proyecto .NET Core Web API

Este proyecto es una API desarrollada en .NET Core que proporciona funciones para gestionar información sobre farmacias. Incluye la consulta de farmacias, la creación de nuevas farmacias y la búsqueda de la farmacia más cercana en base a la geolocalización del cliente.

## Características

- Consulta de farmacias existentes.
- Creación de nuevas farmacias.
- Búsqueda de la farmacia más cercana basada en la geolocalización del cliente.

## Requisitos

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Configuración y Uso

### Ejecución con Docker Compose

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/tu-proyecto.git

2. Accede al directorio del proyecto
   
	cd tu-proyecto

3. Ejecución de la aplicación

	docker-compose up	

4. Acceder al a API (swagger y uso)

    http://localhost:puerto/swagger/index.html
    http://localhost:puerto/api/

### Base de datos y ejemplo

5. Base de datos

	Se incluye un script de creación (script.sql) en la carpeta database para inicializar la base de datos con datos de ejemplo.

6. Endpoints

    GET /api/farmacias: Obtiene la lista de todas las farmacias.
    POST /api/farmacias: Crea una nueva farmacia.
    GET /api/farmacias/cercana?latitud=valor&longitud=valor: Obtiene la farmacia más cercana basada en la geolocalización del cliente.