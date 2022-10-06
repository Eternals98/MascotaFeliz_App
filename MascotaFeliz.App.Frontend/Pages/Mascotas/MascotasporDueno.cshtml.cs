using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class MascotasporDuenoModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota; 
        private readonly IRepositorioDueno _repoDueno;
        public IEnumerable<Mascota> listaMascotas {get;set;} 
        public IEnumerable<Dueno> listaDuenos { get; set; }
        public Mascota mascota { get; set; }
        public Veterinario veterinario { get; set; }
        public Dueno dueno { get; set; }
        public Historia historia { get; set; }
        public IEnumerable<Veterinario> listaVeterinarios { get; set; }


        public MascotasporDuenoModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        }
        

        public void OnGet(int filtro)
        {
            listaMascotas = _repoMascota.GetMascotasPorFiltroDueno(filtro);
            listaDuenos = _repoDueno.GetAllDuenos();
        }

    }
}
