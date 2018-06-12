using AdonaiApi.Data;
using AdonaiApi.Models;
using AdonaiApi.Models.Enums;
using AdonaiApi.ViewModels;
using AdonaiApi.ViewModels.LeadViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdonaiApi.Controllers
{
    public class LeadController : Controller
    {
        private readonly AdonaiDataContext _context;

        public LeadController(AdonaiDataContext context)
        {
            _context = context;
        }

        [Route("lead/register")]
        [HttpPost]
        public ResultViewModel Create([FromBody]CreateLeadViewModel model)
        {
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Data = model.Notifications
                };
            }

            var consorcio = (ConsorcioEnum)model.Consorcio;

            _context.Lead.Add(new Lead
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Consorcio = consorcio.ToString(),
                CreateDate = DateTime.Now
            });

            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Data = "Lead created success!"
            };
        }

        [Route("Lead")]
        [HttpGet]
        public ResultViewModel Get()
        {

            var tst = _context.Lead.ToList();

            var lead = new Lead();
            lead.Id = 1;
            lead.Name = "Filipe";
            lead.Email = "filipemateussilva@gmail.com";
            lead.PhoneNumber = "12345";
            lead.Consorcio = "Imóvel";
            lead.CreateDate = DateTime.Now;

            return new ResultViewModel
            {
                Success = true,
                Data = lead
            };
        }
    }
}