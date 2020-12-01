using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    public class Tractor
    {
        public Guid ID { get; set; }

        /// <summary>
        /// Este es el número económico o placas del tractor 
        /// </summary>
        public string Noeconomico { get; set; }
    }
}
