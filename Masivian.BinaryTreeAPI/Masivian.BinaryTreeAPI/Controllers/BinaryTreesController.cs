using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Masivian.BinaryTreeAPI.Models;
using Masivian.BinaryTreeAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Masivian.BinaryTreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinaryTreesController : ControllerBase
    {
        private readonly IServiceBinTree _service;
            public BinaryTreesController(IServiceBinTree service)
        {
            _service = service;
        }

        [HttpGet("{nodes}")]
        public IActionResult CreateTree(int nodes)
        {
            if (nodes == 0 || nodes <= 3)
                return BadRequest("Numero de Nodos invalido");

            return Ok(_service.CreateTree(nodes));
        }
    }
}