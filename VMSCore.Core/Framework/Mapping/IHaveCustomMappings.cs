using AutoMapper;

namespace VMSCore.Core.Framework.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
