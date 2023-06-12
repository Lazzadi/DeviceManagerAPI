﻿using AutoMapper;
using DeviceManagerAPI.DTO;
using DeviceManagerAPI.Interfaces;
using DeviceManagerAPI.Models;
using DeviceManagerAPI.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;


namespace DeviceManagerAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]

        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("{UserID}", Name = "GetUserByID")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByID(int UserID)
        {
            var users = _userRepository.GetUserByID(UserID);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        //Write a post request to add a new user
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] RegisterUserDTO user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email already exists
            var existingUser = _userRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", $"User with email '{user.Email}' already exists.");
                return Conflict(ModelState);
            }

            var userToCreate = _mapper.Map<User>(user);

            if (!_userRepository.CreateUser(userToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong saving the user " + $"{user.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("User was created");
        }

        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [EnableCors]
        public IActionResult LoginUser([FromBody] UserLoginDTO user)
        {
            

            if (user == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email exists
            var existingUser = _userRepository.GetUserByEmail(user.Email);

            if (existingUser == null)
            {
                ModelState.AddModelError("", $"User with email '{user.Email}' does not exist.");
                return NotFound(ModelState);
            }

            // Check if the password matches
            if (existingUser.Password != user.Password)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return BadRequest(ModelState);
            }

            // Authentication successful
            string json = JsonSerializer.Serialize(existingUser);
            return Ok(json);
            
        }



    }
}
