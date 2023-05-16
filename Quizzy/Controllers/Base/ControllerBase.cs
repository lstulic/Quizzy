// <copyright file="ControllerBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.API.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// BaseController class.
    /// </summary>
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        #region attributes

        /// <summary>
        /// The service provider.
        /// </summary>
        protected IServiceProvider serviceProvider;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ControllerBase(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        #endregion

        #region methods

        /// <summary>
        /// Messages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        protected ActionResult Message(string message)
        {
            return this.StatusCode(200, message);
        }

        /// <summary>
        /// Internals the server error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>ActionResult.</returns>
        protected ActionResult InternalServerError(Exception? ex = null)
        {
            return this.StatusCode(500, ex?.Message ?? "INTERNAL_SERVER_ERROR");
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        protected ActionResult Error(string message)
        {
            return this.StatusCode(503, message);
        }
        #endregion
    }
}
