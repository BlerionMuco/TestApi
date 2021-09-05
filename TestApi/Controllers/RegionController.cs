using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestApi.Contracts;
using TestApi.Entities;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepo;

        protected const string PHONE_NUMBER_NULL_VALUE = "The phone number should have a value.";
        protected const string PHONE_NUMBER_REQUIRED_LENGTH = "The length of phone number does not fulfill required length.";
        protected const string REGION_NOT_FOUND = "There is no region with this prefix.";

        public RegionController(IRegionRepository regionRepo)
        {
            _regionRepo = regionRepo;
        }

        //This method is for project launch purpose only
        [HttpGet]
        public IActionResult GetRegions([FromQuery] string phone)
        {
            var regions = _regionRepo.GetRegions();

            return Ok(regions);
        }

        [HttpGet]
        [Route("DetectCountryFor")]
        public IActionResult DetectCountryFor([FromQuery] string phone)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(phone))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, PHONE_NUMBER_NULL_VALUE);
                }

                if (phone.Length < 4 || phone.Length > 8)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, PHONE_NUMBER_REQUIRED_LENGTH);
                }

                var regions = _regionRepo.GetRegions();

                string regionPrefix = phone.Substring(0, 4);

                List<Region> response = new List<Region>();

                foreach (var region in regions)
                {
                    if (region.RegionPrefix == regionPrefix)
                    {
                        response.Add(new Region
                        {
                            Id = region.Id,
                            RegionPrefix = region.RegionPrefix,
                            RegionName = region.RegionName
                        });
                    }
                }

                if (response.Count < 1)
                {
                    return StatusCode(StatusCodes.Status404NotFound, REGION_NOT_FOUND);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}