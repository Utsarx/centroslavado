using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    public static class DatosDemo
    {

        public static List<ConfiguracionVentaeCentroLavado> CentrosDemo()
        {
            List<ConfiguracionVentaeCentroLavado> l = new List<ConfiguracionVentaeCentroLavado>();
            for(int i = 0; i < 3; i++)
            {
                l.Add(ObtieneDatos(Guid.Parse($"A0000000-0000-0000-0000-00000000000{i}"), $"Centro {i}"));
            }
            

            return l;
        }

        public static ConfiguracionVentaeCentroLavado ObtieneDatos(Guid id, string name)
        {
            ConfiguracionVentaeCentroLavado c = new ConfiguracionVentaeCentroLavado();

            c.Centro = new CentroLavado() { Nombre = name, Id = id };
            c.Empleados = new List<Empleado>()
            {
                new Empleado() { Nombre = "Empelado 01", Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Activo = true },
                new Empleado() { Nombre = "Empelado 02", Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Activo = true },
                new Empleado() { Nombre = "Empelado 03", Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Activo = true }
            };

            c.Categorias = new List<Categoria>()
            {
                 new Categoria() { Id =Guid.Parse("00000000-0000-0000-0000-000000000001") , Nombre="Categoría 1"},
                 new Categoria() { Id =Guid.Parse("00000000-0000-0000-0000-000000000002") , Nombre="Categoría 2"},
                 new Categoria() { Id =Guid.Parse("00000000-0000-0000-0000-000000000003") , Nombre="Categoría 3"}
            };


            for (int i = 0; i < 3; i++)
            {
                c.Categorias[i].Servicios = new List<Servicio>();
                for (int j = 0; j < 3; j++)
                {
                    c.Categorias[i].Servicios.Add(
                        new Servicio()
                                {
                                    Clave = $"Clave {j + 1}",
                                    Nombre = $"Servicio {j + 1}",
                                    Id = Guid.Parse($"00000000-0000-0000-0000-00000000000{j + 1}"),
                                    CategoriaId = Guid.Parse($"00000000-0000-0000-0000-00000000000{i + 1}"),
                                     Precios = new List<Precio> ()
                                     {
                                         new Precio() { Descripcion ="Precio", Id = Guid.Parse( $"{i}000000{j}-0000-0000-0000-000000000001"), Moneda = Moneda.PesoMexicano, Monto = 50, EsDefault =true, ServicioId = Guid.Parse($"00000000-0000-0000-0000-00000000000{j + 1}") },
                                         new Precio() { Descripcion ="Precio", Id = Guid.Parse( $"{i}000000{j}-0000-0000-0000-000000000002"), Moneda = Moneda.PesoMexicano, Monto = 100, EsDefault =false, ServicioId = Guid.Parse($"00000000-0000-0000-0000-00000000000{j + 1}" )},
                                     }
                                }
                   );
                }
            }



            return c;
        }

    }
}
