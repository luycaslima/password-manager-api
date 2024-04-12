using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Dto.Password;
using PasswordManager.Entities;
using PasswordManager.Services;

namespace PasswordManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController(IPasswordDataService service) : ControllerBase
    {
        private readonly IPasswordDataService _passwordService = service;


        [HttpPost]
        [ProducesResponseType(typeof(int),StatusCodes.Status201Created)]
        public IActionResult AddNewPassword([FromBody] RequestAddPasswordDataDTO request){
            var id = _passwordService.AddPassword(request);

            return Created(string.Empty,id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PasswordData>),StatusCodes.Status200OK)]
        public IActionResult GetAllPasswords(){
            var list = _passwordService.GetListOfAllPasswords();
            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PasswordData),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public IActionResult GetEncryptedPassword([FromRoute] int id){
            var result = _passwordService.GetEncryptedPasswordData(id);
            if(result is null){
                return NotFound("Password not found!");
            }
            return Ok(result);
        }



        [HttpGet]
        [Route("Decrypt/{id}")]
        [ProducesResponseType(typeof(DecryptedPasswordData),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public IActionResult GetDecryptedPassword([FromRoute] int id){
            var result = _passwordService.GetDecryptedPasswordData(id);
            if(result is null){
                return NotFound("Password not found!");
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(PasswordData),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public IActionResult UpdatePassword([FromRoute] int id, [FromBody] RequestAddPasswordDataDTO request){
            var result = _passwordService.UpdatePasswordData(id,request);
            if(result is null){
                return NotFound("Password not found!");
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public IActionResult DeletePassword([FromRoute]int id) {
            var result = _passwordService.DeletePasswordDataEntry(id);

            if(!result){
                return NotFound("Password not found!");
            }
            return Ok("Deleted Successfully!");
        }
    }
    
}