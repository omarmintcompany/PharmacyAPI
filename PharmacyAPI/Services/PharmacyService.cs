using PharmacyAPI.Models.Repositories;
using PharmacyAPI.Models.Responses;
using PharmacyAPI.Models.Services;
using PharmacyAPI.Persistence;
using PharmacyAPI.Repositories;
using PharmacyAPI.Resources;
using PharmacyAPI.Resources.Query;
using System.Security.Cryptography.Xml;

namespace PharmacyAPI.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PharmacyService(IPharmacyRepository pharmacyRepository, IUnitOfWork unitOfWork)
        {
            _pharmacyRepository = pharmacyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PharmacyResponse> GetPharmacy(int pharmacyId)
        {
            try
            {
                Task<Pharmacys> reservationTask = _pharmacyRepository.GetPharmacy(pharmacyId);

                Pharmacys pharmacysData = await reservationTask;

                if (pharmacysData != null)
                {
                    return new PharmacyResponse(new PharmacyResource()
                    {
                        Id = pharmacysData.Id,
                        Name = pharmacysData.PharmacyName,
                        Address = pharmacysData.Address,
                        Latitude = pharmacysData.Latitude,
                        Longitude = pharmacysData.Longitude
                    });
                }
                else
                    return new PharmacyResponse("Farmacia inexistente");

            }
            catch (Exception ex)
            {
                return new PharmacyResponse("No se ha encontrado la farmacia indicada : " + ex.Message);
            }
        }

        public async Task<PharmacyResponse> CreatePharmacy(PharmacyResource pharmacyData)
        {

            _unitOfWork.BeginTransaction();
            try
            {
                // Comprobamos los datos minimos para la creación de la farmacia
                if (pharmacyData.Name == "")
                    throw new Exception("No se puede dar de alta una farmacia sin el nombre.");

                // Comprobamos que la farmacia no exista ya en el sistema basandonos en su nombre y geolocalización
                Pharmacys? checkPharmacy = _pharmacyRepository.checkPharmacy(pharmacyData);
                if (checkPharmacy != null)
                    throw new Exception("Ya existe la farmacia indicada.");

                // En caso de no existir, la creamos
                Pharmacys newPharmacy = new Pharmacys();

                newPharmacy.PharmacyName = pharmacyData.Name;
                newPharmacy.Address = pharmacyData.Address;
                newPharmacy.Latitude = pharmacyData.Latitude;
                newPharmacy.Longitude = pharmacyData.Longitude;

                await _pharmacyRepository.Add(newPharmacy);

                await _unitOfWork.CompleteAsync();
                _unitOfWork.Commit();

                return new PharmacyResponse(pharmacyData);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return new PharmacyResponse("No se ha podido dar de alta la farmacia : " + ex.Message);

            }

        }
        
        public async Task<PharmacyResponse> GetNearestPharmacy(PharmacyListQuery pharmacyListQuery)
        {
            Pharmacys nearestPharmacy = null;
            double distanciaMinima = double.MaxValue;

            List<Pharmacys> phamacysList = await _pharmacyRepository.GetPharmacysList();

            foreach (Pharmacys pharmacy in phamacysList)
            {
                double distancia = CalculateDistance(pharmacyListQuery.Latitude, pharmacyListQuery.Longitude, pharmacy.Latitude, pharmacy.Longitude);

                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    nearestPharmacy = pharmacy;
                }
            }

            if (nearestPharmacy != null)
            {
                return new PharmacyResponse(new PharmacyResource()
                {
                    Id = nearestPharmacy.Id,
                    Name = nearestPharmacy.PharmacyName,
                    Address = nearestPharmacy.Address,
                    Latitude = nearestPharmacy.Latitude,
                    Longitude = nearestPharmacy.Longitude
                });
            }
            else
                return new PharmacyResponse("No hay farmacias disponibles");
            
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double earthRadius = 6371.0;

            var dLat = (lat2 - lat1) * (Math.PI / 180.0);
            var dLon = (lon2 - lon1) * (Math.PI / 180.0);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * (Math.PI / 180.0)) * Math.Cos(lat2 * (Math.PI / 180.0)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = earthRadius * c;
            return distance;
        }
    }
}
