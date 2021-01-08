using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CL.Modelo
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmpleadoId { get; set; }
        public string Token { get; set; }
        public string Jwt { get; set; }
        public Empleado Empleado { get; set; }

    }
}
