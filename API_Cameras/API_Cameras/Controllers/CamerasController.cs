using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Cameras.Models;

namespace API_Cameras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamerasController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CamerasController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Cameras
        [HttpGet]
        public List<Camera> GetCameras()
        {
            return  _context.Cameras.ToList();
        }

        // GET: api/Cameras/5
        [HttpGet("{id}")]
        public IActionResult GetCamera(int id)
        {
            var camera = _context.Cameras.Find(id);
            if (camera == null)
            {
                return NotFound();
            }
            return Ok(camera);
        }

        [HttpGet("name/{id}")]
        public List<Camera> GetCameraByName(string id)
        {
            List<Camera> cameras = _context.Cameras.Where(d => d.Description.Contains(id)).ToList();
            return cameras;
        }
    }
}
