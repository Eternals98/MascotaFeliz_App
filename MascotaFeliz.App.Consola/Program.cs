using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;


namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Consola");

            //ListarDuenosFiltro();      
            //AddDueno();
            //BuscarDueno(1);
            
            //ListarDuenos();

            //ListarVeterinariosFiltro();
            AddVeterinario();
            //BuscarVeterinario(1);
            //BuscarMascota(1);

            //AddMascota();
            //AsignarVeterinario();
            //AsignarDueno();
            //AsignarHistoria();

            //ListarMascotas();
            //ListarHistorias();
            
            //AddHistoria();
            //AsignarVisitaPyP(2);
            //ListarMascotas();

        }
        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Pedro",
                Apellidos = "EL escamoso",
                Direccion = "Casa",
                Telefono = "515151515",
                Correo = "pedroescamoso@gmail.com"
            };
            dueno = _repoDueno.AddDueno(dueno);
          
        }
        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Andrea",
                Apellidos = "Ochoa",
                Direccion = "Casa 2",
                Telefono = "2222222222",
                TarjetaProfesional = "TP0002"
            };
            _repoVeterinario.AddVeterinario(veterinario);

        }
    }
}