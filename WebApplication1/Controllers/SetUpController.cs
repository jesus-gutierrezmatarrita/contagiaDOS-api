using contagiaDOS.Entities;
using ContagiaDOS_API.Models.Common;
using ContagiaDOS_API.Models.CreateGame;
using ContagiaDOS_API.Models.GetAllGames;
using ContagiaDOS_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TSV.Backend.Models;

namespace Proyecto_Redes.Controllers
{
    [Route("/game/")]
    [ApiController]

    public class SetUpController : Controller
    {
        public readonly ISetUpService _setUpService;

        #region Constructors
        public SetUpController(ISetUpService setUpService)
        {
            this._setUpService = setUpService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method gets all the games.
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns>A game response model</returns>
        [HttpGet("/game/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GameHeader> GetAll()
        {
            try
            {
                GameHeader response = this._setUpService.Games();

                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.clientMessage);
            }
        }
        /// <summary>
        /// This method add a new game
        /// </summary>
        /// <param name="name"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public ActionResult<GameModel> Create([FromHeader, Required] string name, [FromBody, Required] NewGameRequest request)
        {
            try
            {
                NewGameResponse response = this._setUpService.Create(request: request);

                if (response == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(response);
            }
            catch (BadRequestException badRequest)
            {
                return new BadRequestObjectResult(badRequest.Message);
            }
            catch (InternalServerException internalError)
            {
                return StatusCode(500, internalError.Message);
            }
        }
        #endregion

    }
}
