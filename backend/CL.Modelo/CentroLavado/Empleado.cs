using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace CL.Modelo
{
    [Table("Empleado")]
   public class Empleado
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200), MinLength(5)]
        public string Nombre { get; set; }

        
        [Required]
        [DefaultValue(false)]
        public bool UsuarioSistema { get; set; }

        /// <summary>
        ///  Este campo es opciona, para el crud si el valode UsuarioSistema es True
        ///  entonces este campo es requerido
        /// </summary>
        [MaxLength(100)]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// NO DEBE LLENARSE EN EL CRUD
        /// </summary>
        [MaxLength(500)]
        public string Hash { get; set; }

        /// <summary>
        /// NO DEBE LLENARSE EN EL CRUD
        /// </summary>
        [MaxLength(50)]
        public string Salt { get; set; }
        
        /// <summary>
        /// Especifica si un usuario de sistema se encuentra activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Indica cuando fue la última vez que el usuario hizo login, el singo ? significa que este valor puede ser nulo
        /// NO DEBE LLENARSE EN EL CRUD, se llenará con el proceso de login
        /// </summary>
        public DateTimeKind? UltimoAcceso { get; set; }

        /// <summary>
        /// Lista de los empleados asociados al centro de lavado
        /// </summary>
        public ICollection<EmpleadoCentroLavado> CentrosLavado { get; set; }

    }
}
