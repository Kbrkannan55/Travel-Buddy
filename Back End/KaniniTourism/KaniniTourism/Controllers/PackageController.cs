﻿using KaniniTourism.Models;
using KaniniTourism.Repository.PackageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaniniTourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageRepo _context;
        public PackageController(IPackageRepo context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Package>>> GetAllPackages()
        {
            try
            {
                return await _context.GetAllPackages();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

/*        [Authorize(Roles = "Agent")]*/
        [HttpPost]
        public async Task<ActionResult<List<Package>>> PostPackages(Package package)
        {
            try
            {
                return await _context.PostPackages(package);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("GetFilteredDetails")]
        public async Task<ActionResult<List<Package>>> GetFiltedPackages(string type, string desti,string transport)
        {
            try
            {
                return await _context.GetFiltedPackages(type,desti, transport);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
    }
}
