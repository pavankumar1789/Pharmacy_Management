using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management1.Models;
using Pharmacy_Management1.Dto;
using Pharmacy_Management1.Helper;
using Pharmacy_Management1.Repository;
using System;

namespace Pharmacy_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _userRepository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new UserDetail
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Contact = dto.Contact,
                UserAddress = dto.UserAddress,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(dto.UserPassword)
            };

            var newUser = _userRepository.Create(user);
            return Created("Sucess", newUser);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userRepository.GetByEmail(dto.Email);
            if (user == null)
                return BadRequest(new { message = "Invalid Credentials" });
            if (!BCrypt.Net.BCrypt.Verify(dto.UserPassword, user.UserPassword))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }
            var jwtstring = _jwtService.Generate(user.UserId);
            Response.Cookies.Append("jwt", jwtstring, new CookieOptions
            {
                HttpOnly = true,
            });
            return Ok(new
            {
                message = "sucess"

            });
        }
        [HttpGet("User")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.GetById(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }

        }
        [HttpGet("UserAll")]
        public IActionResult UserAll()
        {
            var user = _userRepository.GetAll();
            return new OkObjectResult(user);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "sucess"
            });
        }
    }
}