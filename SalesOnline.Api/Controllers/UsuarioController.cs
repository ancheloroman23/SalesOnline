﻿using Microsoft.AspNetCore.Mvc;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Dtos.Usuario;


namespace SalesOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            var result = this.usuarioService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            var result = this.usuarioService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPost("SaveUsuario")]
        public IActionResult Post([FromBody] UsuarioDtoAdd usuarioAdd)
        {
            var result = this.usuarioService.Save(usuarioAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        // POST api/<UsuarioController>
        [HttpPost("UpdateUsuario")]
        public IActionResult Put([FromBody] UsuarioDtoUpdate usuarioUpdate)
        {
            var result = this.usuarioService.Update(usuarioUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("RemoveUsuario")]
        public IActionResult Remove([FromBody] UsuarioDtoRemove usuarioDtoRemove)
        {

            var result = this.usuarioService.Remove(usuarioDtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }



}
