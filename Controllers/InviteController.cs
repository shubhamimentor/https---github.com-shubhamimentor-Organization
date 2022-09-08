using Microsoft.AspNetCore.Mvc;
using Org.Data;
using AutoMapper;
using System.Threading.Tasks;
using Org.DTOs;
using Org.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;

namespace Org.Controllers
{   
    [ApiController]
    [Route("api/Invite")]
    public class InviteController : Controller
    {
        private readonly IMapper mapper;   
        private readonly ApplicationDBContext _context;
        
        public InviteController(ApplicationDBContext context,IMapper mapper)
        {
            _context = context;
            this.mapper=mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InviteCreationDTO inviteCreation)
        {
            var invite = mapper.Map<Invite>(inviteCreation);
            await _context.AddAsync(invite);
            await _context.SaveChangesAsync();
            var inviteDTOs = mapper.Map<InviteDTO>(invite);
            return Ok( inviteDTOs);
        }
        [HttpPost]
        [Route("myinvitations")]
        public async Task<ActionResult> Post([FromBody] ActOnInvitationDTO actOnInvitationDTO)
        { 
                if (Guid.Empty == (actOnInvitationDTO.Id))
                {
                    return BadRequest();
                }

                if (actOnInvitationDTO.Response == InvitationAction.Approved)
                {
                    string connectionString = "Data Source=DESKTOP-JEERM1G\\SQLEXPRESS;Initial Catalog=OrgAPIs;Integrated Security=True";

                    string commandText = $"Update Invites Set Status = '{actOnInvitationDTO.Response}',Username = '{actOnInvitationDTO.Username}' WHERE Id = '{actOnInvitationDTO.Id}' ";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        conn.Open();
                        var result =
                           cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                }
                else
                {
                    string connectionString = "Data Source=DESKTOP-JEERM1G\\SQLEXPRESS;Initial Catalog=OrgAPIs;Integrated Security=True";

                    string commandText = $"Update Invites Set Status = 'Rejected:{actOnInvitationDTO.Remark}',Username = '{actOnInvitationDTO.Username}' WHERE Id = '{actOnInvitationDTO.Id}'";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        conn.Open();
                        var result = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                return Ok("success");
            
        }

        [HttpGet]
        [Route("myinvitations")]
        public async Task<ActionResult<List<InviteDTO>>> Get()
        {
            var invite = await _context.Invites.AsNoTracking().ToListAsync();
            var inviteDTO = mapper.Map<List<InviteDTO>>(invite);

            return inviteDTO;
        }
        [HttpGet]
        [Route("SentInvite")]
        public async Task<ActionResult<List<SentInviteDTO>>> SentInvite( int fromOrgId, string status)
        {
                var invite = await _context.Invites.FromSqlRaw($"Select * From Invites where FromOrgId ={fromOrgId} AND Status = '{status}'").AsNoTracking().ToListAsync();
                var sentinviteDTO = mapper.Map<List<SentInviteDTO>>(invite);
                return sentinviteDTO;

        }
    }
}