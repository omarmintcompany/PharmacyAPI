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

	docker-compose up --build

4. Acceder al a API (swagger y uso)

    http://localhost:8080/swagger/index.html

### Base de datos y ejemplo

5. Base de datos

	Se incluye un script de creaci�n (script.sql) en la carpeta database para inicializar la base de datos con datos de ejemplo.

6. Endpoints

    GET /api/farmacias: Obtiene la lista de todas las farmacias.
    POST /api/farmacias: Crea una nueva farmacia.
    GET /api/farmacias/cercana?latitud=valor&longitud=valor: Obtiene la farmacia m�s cercana basada en la geolocalizaci�n del cliente.


### Test Unitarios

GetNearestPharmacy:
    Verifica que la solicitud GET a /api/farmacia con coordenadas de latitud 27.212 y longitud 15.121 devuelve un c�digo de estado 200.
    Analiza el cuerpo de la respuesta JSON y verifica propiedades espec�ficas como el nombre de la farmacia y su ID.

GetPharmacysError:
    Verifica que la solicitud GET a /api/farmacia/ver/10 (farmacia inexistente) devuelve un c�digo de estado 400.
    Verifica que el cuerpo de la respuesta es "Farmacia inexistente".

GetPharmacysOk:
    Verifica que la solicitud GET a /api/farmacia/ver/3 (farmacia existente) devuelve un c�digo de estado 200.
    Analiza el cuerpo de la respuesta JSON y verifica propiedades espec�ficas como el nombre, el ID y las coordenadas de la farmacia.

AddPharmacyOk:
        Verifica que la solicitud POST a /api/farmacia/agregar con datos v�lidos devuelve un c�digo de estado 200.
        Analiza el cuerpo de la respuesta JSON y verifica que el nombre de la farmacia creada sea "Farmacia Nueva para test unitario".

AdPharmacyError:
    Verifica que la solicitud POST a /api/farmacia/agregar con datos inv�lidos (nombre vac�o) devuelve un c�digo de estado 400.
    Verifica que el cuerpo de la respuesta es "No se ha podido dar de alta la farmacia: No se puede dar de alta una farmacia sin el nombre".