using System;
using System.Collections.Generic;

namespace VMSCore.Integration.MasterDataEntities.Interfaces
{
    public interface IMasterDataEntitiesQueries
    {
        List<ProvinceModel> GetAllProvinces();
        ProvinceModel GetProvinceModelById(Guid provinceId);
        List<DistrictModel> GetAllDistricts();
        List<WardModel> GetAllWards();
        List<ProvinceModel> SearchProvince(string provinceName, bool isActive = true);
        List<DistrictViewModel> SearchDistrict(string provinceCode, string districtName, bool isActive = true);
        List<WardViewModel> SearchWard(string provinceCode, string districtCode, string wardName, bool isActive = true);

        DistrictModel GetDistrictModelById(Guid districtId);
    }
}
