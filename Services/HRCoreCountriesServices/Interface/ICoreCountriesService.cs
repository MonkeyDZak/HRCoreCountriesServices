using HRCommon.Interface;
using HRCommonModel;
using HRCommonModels;
using QuickType;
using System;
using System.Threading.Tasks;

namespace HRCoreCountriesServices
{
    public interface ICoreCountriesService : ISortable, IPaginable
    {
        Task<HRCountry> GetCountryAsync(String id);
        Task<PagingParameterOutModel<HRCountry>> GetCountriesAsync(PagingParameterInModel pageModel, HRSortingParamModel orderBy);
    }
}