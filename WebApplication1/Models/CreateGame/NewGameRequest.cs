using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSV.Backend.Models;

namespace ContagiaDOS_API.Models.CreateGame
{
    public class NewGameRequest : ModelValidator
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public void ValidateModel()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new BadRequestException("El nombre del juego es requerido.");
            }
        }
    }
}
