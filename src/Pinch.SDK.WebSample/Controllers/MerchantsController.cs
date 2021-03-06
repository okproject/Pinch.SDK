﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pinch.SDK.WebSample.Helpers;
using Pinch.SDK.WebSample.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinch.SDK.WebSample.Controllers
{
    public class MerchantsController : BaseController
    {
        public MerchantsController(IOptions<PinchSettings> settings) : base(settings)
        {            
        }

        public async Task<IActionResult> Index()
        {
            var model = new MerchantsVm()
            {
                MyMerchant = await GetApi().Merchant.GetMerchant(),
                ManagedMerchants = await GetApi().Merchant.GetAllManagedMerchants()
            };

            return View(model);
        }
    }
}
