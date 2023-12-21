using PharmacyAPI.Models.Repositories;
using PharmacyAPI.Models.Responses;
using PharmacyAPI.Models.Services;
using PharmacyAPI.Persistence;
using PharmacyAPI.Repositories;
using PharmacyAPI.Resources;
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

     /*   public async Task<PharmacyResponse> GetPharmacy(int pharmacyId)
        {
            try
            {
                Pharmacys? pharmacyData = await _pharmacyRepository.GetPharmacy(pharmacyId);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return new PharmacyResponse("No se ha encontrado la farmacia indicada : " + ex.Message);

            }
        }*/

        public async Task<PharmacyResponse> CreatePharmacy(PharmacyResource pharmacyData)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                // Comprobamos que la farmacia no exista ya en el sistema basandonos en su nombre y geolocalización
                Pharmacys? checkPharmacy = _pharmacyRepository.checkPharmacy(pharmacyData);
                if (checkPharmacy != null)
                    return new PharmacyResponse("Ya existe la farmacia indicada.");

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
        /*
        public async Task<PharmacyResource> GetNearestPharmacy(int latitude, int longitude)
        {

        }*/
    }
}
