using MyTeletouch.Entities;
using MyTeletouch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTeletouch.Controllers
{
    public class ApplicationWebAPIController<TEnity> : ApiController where TEnity : BaseModel
    {
        protected Repository<TEnity> repository;

        public ApplicationWebAPIController(Repository<TEnity> repository)
        {
            this.repository = repository;
        }
    }
}
