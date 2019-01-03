using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerAPI.Models;
using TrackerDB;

namespace TrackerAPI.Controllers
{
    public class TrackerControllerBase : ControllerBase
    {
        ITrackerRepository _repo;
        ModelFactory _modelFactory;

        public TrackerControllerBase(ITrackerRepository repo)
        {
            _repo = repo;
        }

        public ITrackerRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }

        public ModelFactory TheModelFactory { get
            {
                if(_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.ControllerContext, TheRepository);
                }
                return _modelFactory;
            } }
    }
}
