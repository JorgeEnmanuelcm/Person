using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class PersonasTelefonos
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }

        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }

        public PersonasTelefonos()
        {
            this.Id = 0;
            this.PersonaId = 0;
            this.TipoTelefono = "";
            this.Telefono = "";
        }

        public PersonasTelefonos(string tipotelefono, string telefono)
        {
            this.TipoTelefono = tipotelefono;
            this.Telefono = telefono;
        }
    }
}
