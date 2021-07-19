using ContagiaDOS_API.Models.CreateGame;
using ContagiaDOS_API.Models.GetAllGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContagiaDOS_API.Services
{
    public interface ISetUpService
    {
        GameHeader Games();

        NewGameResponse Create(NewGameRequest request);
    }
}
