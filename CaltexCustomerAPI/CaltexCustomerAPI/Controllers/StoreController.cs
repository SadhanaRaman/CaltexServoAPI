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
    [Route("[controller]")]
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

        /*Sample Request*/
        /*{ 
           "CustomerId":"8e4e8991-aaee-495b-9f24-52d5d0e509c5",
           "LoyaltyCard":"CTX0000001",
           "TransactionDate":"2020-04-03T00:00:00.000Z",
           "BasketData":
            [
              {"ProductId":"PRD01","Quantity":"3","UnitPrice": "1.2"}
            ]
        }*/
    }
}
