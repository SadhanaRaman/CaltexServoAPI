using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CaltexCustomerAPI.Models;
using CaltexCustomerAPI.Contract;
using CaltexCustomerAPI.Services;

namespace CaltexCustomerAPI.Controllers
{
    [ApiController]
    [Route("store")]
    //swagger json - https://localhost:44317/swagger/CaltexPISpec/swagger.json
    public class StoreController : ControllerBase
    {

        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        //private IStoreService storeService = new StoreService();

        [HttpPost]

        public PurchaseResponse StoreData( [FromBody] PurchaseRequest purchaseRequest)
        {
            return _storeService.ServoData(purchaseRequest);
        }
    }
}
