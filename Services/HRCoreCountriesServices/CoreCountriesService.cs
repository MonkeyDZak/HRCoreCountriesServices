﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HRCoreCountriesModel;
using HRCoreCountriesRepository;

namespace HRCoreCountriesServices
{
    public class CoreCountriesService : ICoreCountriesService
    {
        private ICountriesRepository _repository = null;
        //Hide default constructor as we must do DI with ICountriesRepository
        private CoreCountriesService()
        {
        }
        //1- Constructor injection of CountiresRepository
        public CoreCountriesService(ICountriesRepository repo)
        {
            //1-
            _repository = repo;
        }
        //1- If reposiory is available
        //  1.1- Launch asynchronous GetCountries on repository
        //  1.2- Give back thread availability waiting for result
        //  1.3- Get back result when wee get it.
        //2- Else, return basic Exception in this very first version.
        public async Task<IEnumerable<HRCountryModel>> GetCountriesAsync()
        {
            //1-
            if (_repository != null)
            {
                //1.1-
                Task<IEnumerable<HRCountryModel>> countriesTask = _repository.GetCountriesAsync();
                //1.2-
                IEnumerable<HRCountryModel> retour = await countriesTask;
                //1.3-
                return retour;
            }
            else
            {
                //2-
                throw new Exception("CoreCountriesService initialization failed..");
            }
        }
    }
}
