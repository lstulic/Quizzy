// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using DTO = Quizzy.Dto;

    /// <summary>
    /// UsersController class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : API.Controllers.Base.ControllerBase
    {
        #region attributes
        private Core.Services.IUserService userService;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public UsersController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.userService = serviceProvider.GetRequiredService<Core.Services.IUserService>();
        }
        #endregion

        #region methods

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List of UserUpdate.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Returns all users
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTO.UserUpdate?>?>> GetUsers()
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.userService.GetUsers();

                if (result == null)
                {
                    return this.Error("Error occured while getting users");
                }

                var mappedResults = mapper.Map<IEnumerable<Core.Models.User>, IEnumerable<DTO.UserUpdate>>(result!);

                return this.Ok(mappedResults);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>UserUpdate.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTO.UserUpdate?>> GetUser(Guid id)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.userService.GetUser(id);

                if (result == null)
                {
                    return this.Error("Error occured while getting user");
                }

                var mappedResults = mapper.Map<Core.Models.User, DTO.UserUpdate>(result);

                return mappedResults;
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Posts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>UserUpdate.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Add User
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<DTO.UserUpdate?>> PostUser(DTO.UserUpdate user)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var mappingResult = mapper.Map<DTO.UserUpdate, Core.Models.User>(user);

                var result = await this.userService.PostUser(mappingResult);

                if (result == null)
                {
                    return this.Error("Error occured while posting user");
                }

                return this.CreatedAtAction("GetUser", new { id = result.Id }, user);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>UserLoginResponse.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Login
        // POST: api/Users/login
        [HttpPost("login")]
        public async Task<ActionResult<DTO.UserLoginResponse?>> LoginUser([FromBody]DTO.UserLogin login)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.userService.LoginUser(login.Username!, login.Password!);

                if (result == null)
                {
                    return this.Error("Error occured while logging in");
                }

                var mappedResult = mapper.Map<Core.Models.User, DTO.UserLoginResponse>(result);

                return mappedResult;
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>IActionResult.</returns>
        // Update user
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, DTO.UserUpdate user)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var mappedResult = mapper.Map<DTO.UserUpdate, Core.Models.User>(user);

                await this.userService.PutUser(id, mappedResult);

                return this.Message("User updated");
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await this.userService.DeleteUser(id);

                return this.Message("User deleted");
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Searches the users.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>List of UserUpdate.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Search
        // GET: api/Users/search/text
        [HttpGet("search/{text}")]
        public async Task<ActionResult<IEnumerable<DTO.UserUpdate?>?>> SearchUsers(string text)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.userService.SearchUsers(text);

                if (result == null)
                {
                    return this.Error("Error occured while searching for users");
                }

                var mappedResults = mapper.Map<IEnumerable<Core.Models.User>, IEnumerable<DTO.UserUpdate>>(result!);

                return this.Ok(mappedResults);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
        #endregion
    }
}
