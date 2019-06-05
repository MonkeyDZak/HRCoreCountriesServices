﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRCoreBordersModel;
using HRCoreBordersRepository.Interface;

namespace HRCoreBordersServices
{
    public class HRCoreBordersService : ICoreBordersService
    {
        private IHRCoreBordersRepository _bordersRepository = null;

        public HRCoreBordersService(IHRCoreBordersRepository service )
        {
            _bordersRepository = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="borderID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<HRBorder>> GetBorders(String borderID = null)
        {
            if(_bordersRepository != null)
            {
                Task<IEnumerable<HRBorder>> bordersTask = _bordersRepository.GetBorders(borderID);
                await bordersTask;
                return bordersTask.Result;
            }
            else
            {
                throw new MemberAccessException();
            }
        }
    }
}
