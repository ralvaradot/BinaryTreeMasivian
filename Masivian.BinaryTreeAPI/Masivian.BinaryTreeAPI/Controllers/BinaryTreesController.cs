using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Masivian.BinaryTreeAPI.Models;
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

        [HttpGet]
        public IActionResult CreateTree(int nodes)
        {
            if (nodes == 0)
                return BadRequest("Numero de Nodos invalido");

            return Ok(new BinaryTree() { });
        }
    }
}