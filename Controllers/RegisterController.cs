using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Org.Data;
using System.Linq;
using System;
using System.Threading.Tasks;
using Org.DTOs;
using AutoMapper;
using Org.Helpers;

namespace Org.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private ApplicationDBContext _context;
        private readonly IMapper mapper;

        public RegisterController(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;

        }

        [HttpGet]
      
        public async Task<ActionResult<List<RegisterDTO>>> Get()
        {
            try
            {
                var Registers = await _context.Registers.AsNoTracking().ToListAsync();
                var registerDTOs = mapper.Map<List<RegisterDTO>>(Registers);

                return registerDTOs;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RegisterDTO>> Get(int id)
        {
            var register = await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);
            if (register == null)
            {
                return NotFound();
            }
            var registersDTOs = mapper.Map<RegisterDTO>(register);
            return registersDTOs;
        }
        [HttpPost]

        public async Task<ActionResult> Post([FromBody] RegisterCreationDTOs registerCreation)
        {
                
                var register = mapper.Map<Register>(registerCreation);
                await _context.AddAsync(register);
                await _context.SaveChangesAsync();
                var registerDTOs = mapper.Map<RegisterDTO>(register);
                return new CreatedAtRouteResult(new { registerDTOs.Id }, registerDTOs);
           
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RegisterCreationDTOs registerCreation)
        {
            var register = mapper.Map<Register>(registerCreation);
            register.Id = id;
            _context.Entry(register).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok("Organization Updated");

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _context.Registers.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            _context.Remove(new Register() { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
    
}