using Microsoft.AspNetCore.Mvc;
using PasswordManager.Dto.Password;
using PasswordManager.Entities;
using PasswordManager.Services;

namespace PasswordManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PasswordController(IPasswordDataService service) : ControllerBase
    {
        private readonly IPasswordDataService _passwordService = service;

        /// <summary>
        /// Adds a New Password/Account to the Database
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(int),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)] 
        public IActionResult AddNewPassword([FromBody] RequestAddPasswordDataDTO request){
            var id = _passwordService.AddPassword(request);

            return Created(string.Empty,id);
        }
        /// <summary>
        /// Get a list if all passwords stored in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PasswordData>),StatusCodes.Status200OK)]
        public IActionResult GetAllPasswords(){
            var list = _passwordService.GetListOfAllPasswords();
            return Ok(list);
        }

        /// <summary>
        /// Get a specific encrypted password details with their id.
        /// </summary>
        /// <param name="id">id of the password</param>
        /// <returns>A response with the PasswordData</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PasswordData),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public IActionResult GetEncryptedPassword([FromRoute] int id){
            if( id <= 0){
                return BadRequest("Invalid Id requested!");
            }
            var result = _passwordService.GetEncryptedPasswordData(id);
            if(result is null){
                return NotFound("Password not found!");
            }
            return Ok(result);
        }



        /// <summary>
        /// Get a specific decrypted password details with their id.
        /// </summary>
        /// <param name="id">id of the password</param>
        /// <returns>A response with the DecryptedPasswordData</returns>
        [HttpGet]
        [Route("Decrypt/{id}")]
        [ProducesResponseType(typeof(DecryptedPasswordData),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public IActionResult GetDecryptedPassword([FromRoute] int id){
            if( id <= 0){
                return BadRequest("Invalid Id requested!");
            }
            var result = _passwordService.GetDecryptedPasswordData(id);
            if(result is null){
                return NotFound("Password not found!");
            }
            return Ok(result);
        }

        /// <summary>
        /// Updates the content of a password
        /// </summary>
        /// <param name="id">id of the password</param>
        /// <param name="request"></param>
        /// <returns>returns the Updated PasswordData</returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(PasswordData),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePassword([FromRoute] int id, [FromBody] RequestAddPasswordDataDTO request){
            if( id <= 0){
                return BadRequest("Invalid Id requested!");
            }
            var result = _passwordService.UpdatePasswordData(id,request);
            if(result is null){
                return NotFound("Password not found!");
            }
            return Ok(result);
        }

        /// <summary>
        /// Deletes a password from the database
        /// </summary>
        /// <param name="id">id of the PasswordData</param>
        /// <returns>Returns a message if deleted successfully or not</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public IActionResult DeletePassword([FromRoute]int id) {
            if( id <= 0){
                return BadRequest("Invalid Id requested!");
            }
            var result = _passwordService.DeletePasswordDataEntry(id);

            if(!result){
                return NotFound("Password not found!");
            }
            return Ok("Deleted Successfully!");
        }
    }
    
}