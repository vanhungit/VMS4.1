using System;
using System.Collections.Generic;
using VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Implementations;
using VMSCore.Integration.MasterDataEntities.Interfaces;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Integration.MasterDataEntities
{
    public class MasterDataEntitiesQueries : IMasterDataEntitiesQueries
    {
        private readonly ProvinceRepository _provinceRepository = new ProvinceRepository();
        private readonly DistrictRepository _districtRepository = new DistrictRepository();
        private readonly WardRepository _wardRepository = new WardRepository();

        public List<ProvinceModel> GetAllProvinces()
        {
            var provinces = _provinceRepository.GetAll();
            return provinces;
        }

        public ProvinceModel GetProvinceModelById(Guid provinceId)
        {
            var province = _provinceRepository.GetById(provinceId);
            return province;
        }

        public DistrictModel GetDistrictModelById(Guid districtId)
        {
            var district = _districtRepository.GetById(districtId);
            return district;
        }

        public WardModel GetWardModelById(Guid wardId)
        {
            var district = _wardRepository.GetById(wardId);
            return district;
        }

        public List<DistrictModel> GetAllDistricts()
        {
            var districts = _districtRepository.GetAll();
            return districts;
        }

        public List<WardModel> GetAllWards()
        {
            var wards = _wardRepository.GetAll();
            return wards;
        }

        #region Search
        public List<ProvinceModel> SearchProvince(string provinceName, bool isActive = true)
        {
            var searchModel = new ProvinceSearchViewModel()
            {
                Actived = isActive,
                ProvinceName = provinceName
            };
            var provinces = _provinceRepository.Search(searchModel);
            return provinces;
        }

        public List<DistrictViewModel> SearchDistrict(string provinceCode, string districtName, bool isActive = true)
        {
            var searchModel = new DistrictSearchViewModel()
            {
                Actived = isActive,
                DistrictName = districtName,
                ProvinceId = Guid.Parse(provinceCode)
            };

            var districts = _districtRepository.Search(searchModel);
            return districts;
        }

        public List<WardViewModel> SearchWard(string provinceCode, string districtCode, string wardName, bool isActive = true)
        {
            var searchModel = new WardSearchViewModel()
            {
                Actived = isActive,
                ProvinceCode = Guid.Parse(provinceCode),
                DistrictCode = Guid.Parse(districtCode),
            };

            var wards = _wardRepository.Search(searchModel);
            return wards;
        }

        #endregion
    }
}
