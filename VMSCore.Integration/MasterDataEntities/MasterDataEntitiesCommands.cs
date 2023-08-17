using System;
using VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Implementations;
using VMSCore.Integration.MasterDataEntities.Interfaces;

namespace VMSCore.Integration.MasterDataEntities
{
    public class MasterDataEntitiesCommands : IMasterDataEntitiesCommands
    {
        private readonly ProvinceRepository _provinceRepository = new ProvinceRepository();
        private readonly DistrictRepository _districtRepository = new DistrictRepository();
        private readonly WardRepository _wardRepository = new WardRepository();


        #region Province
        public ProvinceModel AddProvinceModel(ProvinceModel newProvince)
        {
            return _provinceRepository.Add(newProvince);
        }

        public ProvinceModel UpdateProvinceModel(ProvinceModel updateProvince)
        {
            if (updateProvince == null || updateProvince.ProvinceId.Equals(Guid.Empty)) return null;
            var provinceInDb = _provinceRepository.GetById(updateProvince.ProvinceId);

            // TODO: Using Auto mapper
            provinceInDb.ProvinceCode = updateProvince.ProvinceCode;
            provinceInDb.Actived = updateProvince.Actived;
            provinceInDb.ProvinceName = updateProvince.ProvinceName;
            provinceInDb.Area = updateProvince.Area;
            provinceInDb.OrderIndex = updateProvince.OrderIndex;
            provinceInDb.ConfigPriceCode = updateProvince.ConfigPriceCode;
            provinceInDb.IsHasLicensePrice = updateProvince.IsHasLicensePrice;

            _provinceRepository.Update(provinceInDb);
            return provinceInDb;

        }

        public string DeleteProvinceModelById(string provinceId)
        {
            if (string.IsNullOrWhiteSpace(provinceId)) return string.Empty;

            var provinceInDb = _provinceRepository.GetById(Guid.Parse(provinceId));
            if (provinceInDb == null) return string.Empty;

            _provinceRepository.Delete(provinceInDb);
            return provinceId;
        }
        #endregion

        #region District
        public DistrictModel AddDistrictModel(DistrictModel newDistrict)
        {
            return _districtRepository.Add(newDistrict);
        }

        public DistrictModel UpdateDistrictModel(DistrictModel updateDistrict)
        {
            if (updateDistrict == null || updateDistrict.ProvinceId.Equals(Guid.Empty)) return null;
            var districtInDb = _districtRepository.GetById(updateDistrict.DistrictId);

            // TODO: Using Auto mapper
            districtInDb.Actived = updateDistrict.Actived;
            districtInDb.ProvinceId = updateDistrict.ProvinceId;
            districtInDb.Appellation = updateDistrict.Appellation;
            districtInDb.DistrictCode = updateDistrict.DistrictCode;
            districtInDb.RegisterVAT = updateDistrict.RegisterVAT;
            districtInDb.VehicleRegistrationSignature = updateDistrict.VehicleRegistrationSignature;
            districtInDb.OrderIndex = updateDistrict.OrderIndex;
            districtInDb.DistrictName = updateDistrict.DistrictName;

            _districtRepository.Update(districtInDb);
            return districtInDb;
        }

        public string DeleteDistrictModelById(string districtId)
        {
            if (string.IsNullOrWhiteSpace(districtId)) return string.Empty;

            var districtInDb = _districtRepository.GetById(Guid.Parse(districtId));
            if (districtInDb == null) return string.Empty;

            _districtRepository.Delete(districtInDb);
            return districtId;
        }
        #endregion

        #region Ward
        public WardModel AddWardModel(WardModel newWard)
        {
            return _wardRepository.Add(newWard);
        }

        public WardModel UpdateWardModel(WardModel updateWard)
        {
            if (updateWard == null || updateWard.WardId.Equals(Guid.Empty)) return null;
            var wardInDb = _wardRepository.GetById(updateWard.WardId);

            // TODO: Using Auto mapper
            wardInDb.WardCode = updateWard.WardCode;
            wardInDb.Appellation = updateWard.Appellation;
            wardInDb.DistrictId = updateWard.DistrictId;
            wardInDb.OrderIndex = updateWard.OrderIndex;

            _wardRepository.Update(wardInDb);
            return wardInDb;
        }

        public string DeleteWardModelById(string wardId)
        {
            if (string.IsNullOrWhiteSpace(wardId)) return string.Empty;
            var wardInDb = _wardRepository.GetById(Guid.Parse(wardId));
            if (wardInDb == null) return string.Empty;
            _wardRepository.Delete(wardInDb);
            return wardId;
        }
        #endregion

    }
}
