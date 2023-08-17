namespace VMSCore.Integration.MasterDataEntities.Interfaces
{
    public interface IMasterDataEntitiesCommands
    {
        ProvinceModel AddProvinceModel(ProvinceModel newProvince);
        ProvinceModel UpdateProvinceModel(ProvinceModel updateProvince);
        string DeleteProvinceModelById(string provinceId);


    }
}
