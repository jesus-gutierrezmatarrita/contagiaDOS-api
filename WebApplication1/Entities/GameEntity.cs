using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Redes.Entities
{
    [Table("games")]
    public class GameEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("gameId", Order = 1)]
        [Key]
        public string GameId { get; set; }

        [Required(ErrorMessage = "El nombre del juego es requerido.")]
        [MaxLength(50, ErrorMessage = "El nombre no debe ser mayor a 50 caracteres.")]
        [Column("name", Order = 2)]
        public string Name { get; set; }

        [Column("owner", Order = 3)]
        public string Owner { get; set; }

        [MinLength(8, ErrorMessage = "La contraseña debe contener al menos 8 caracteres.")]
        [Column("password", Order = 4)]
        public string Password { get; set; }

        [Column("status", Order = 5)]
        public string Status { get; set; }

    }
}
