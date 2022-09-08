using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Org.Data;
using System.Threading.Tasks;
using Org.DTOs;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Org.Models;
using Microsoft.Data.SqlClient;

namespace Org.Controllers
{
    public class ViewConnectionController : ControllerBase
    {
        private ApplicationDBContext _context;
        private readonly IMapper mapper;

        public ViewConnectionController (ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("Connection")]
        public async Task<ActionResult<List<ViewConnectionDTO>>> View(string status, string relationship_type )
        {

            var invites = await _context.Invites.FromSqlRaw($"select * from Invites where Status = '{status}' AND Relationship_type = '{relationship_type}'").AsNoTracking().ToListAsync();
            var viewConnectionDTOs = mapper.Map<List<ViewConnectionDTO>>(invites);
            return viewConnectionDTOs;

        }
        [HttpPost]
        [Route("Connection")]
        public async Task<ActionResult> Post ([FromBody] CancelInvitationDTO cancelInvitationDTO)
        {
            if (cancelInvitationDTO.Response == IsCancelled.Cancelled)
            {
                string connectionString = "Data Source=DESKTOP-JEERM1G\\SQLEXPRESS;Initial Catalog=OrgAPIs;Integrated Security=True";

                string commandText = $"Update Invites Set Status = '{cancelInvitationDTO.Response}' WHERE Status = 'Pending' ";

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

    }
}
