using contagiaDOS.Entities;
using ContagiaDOS_API.Models.Common;
using ContagiaDOS_API.Models.CreateGame;
using ContagiaDOS_API.Models.GetAllGames;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Redes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSV.Backend.Models;

namespace ContagiaDOS_API.Services
{
    public class SetUpService : ISetUpService
    {
        private readonly DBContext _dBContext;

        public SetUpService(DBContext dBContext)
        {
            this._dBContext = dBContext;
        }
        /// <summary>
        /// Adds a new game
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NewGameResponse Create(NewGameRequest request)
        {
            try
            {
                request.ValidateModel();

                NewGameResponse response = null;

                GameEntity newGame = new GameEntity
                {
                    Name = request.Name,
                    Password = request.Password
                };
                this._dBContext.Games.Add(newGame);
                this._dBContext.SaveChanges();

                response = new NewGameResponse
                {
                    Name = newGame.Name,
                    Password = newGame.Password
                };
                return response;
            }
            catch(BadRequestException badRequest)
            {
                throw badRequest;
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Ha ocurrido un error interno. Por favor, inténtelo de nuevo.");
            }
        }

        /// <summary>
        /// Gets all the games
        /// </summary>
        /// <returns></returns>
        public GameHeader Games()
        {
            try
            {
                GameHeader response = new GameHeader();
                response.Games = new List<GameModel>();

                List<GameEntity> gamesEntities = this._dBContext.Games.ToList();

                if (gamesEntities == null)
                {
                    return null;
                }
                else
                {
                    GameModel model = null;
                    foreach (var game in gamesEntities)
                    {
                        model = new GameModel
                        {
                            GameId = game.GameId,
                            Name = game.Name,
                            Owner = game.Owner,
                            Password = game.Password,
                            Status = game.Status
                        };
                        response.Games.Add(model);
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new InternalServerException(ex.Message, "Error interno en el servidor. Intente más tarde.");
            }
        }
        /*
        public JoinResponse Join(JoinRequest request)
        {
            throw new NotImplementedException();
        }*/
    }
}