using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PersonaClass : ClaseMaestra
    {
        ConexionDB Conexion = new ConexionDB();
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }
        public List<PersonasTelefonos> Detalle { get; set; }

        public PersonaClass()
        {
            this.PersonaId = 0;
            this.Nombres = "";
            this.Sexo = "";
            this.TipoTelefono = "";
            this.Telefono = "";
            this.Detalle = new List<PersonasTelefonos>();
        }

        public PersonaClass(int personaid)
        {
            PersonaId = personaid;
        }

        public void AgregarTelefonos(string TipoTelefono, string Telefono)
        {
            this.Detalle.Add(new PersonasTelefonos(TipoTelefono, Telefono));
        }

        public override bool Insertar()
        {
            int Retorno = 0;
            object Identity;
            try
            {
                Identity = Conexion.ObtenerValor(String.Format("Insert Into Personas(Nombres, Sexo) values('{0}', '{1}') select @@IDENTITY", this.Nombres, this.Sexo));
                int.TryParse(Identity.ToString(), out Retorno);
                this.PersonaId = Retorno;
                if (Retorno > 0)
                {
                    foreach (PersonasTelefonos NumeroDatos in Detalle)
                    {
                        Conexion.Ejecutar(String.Format("Insert into PersonasTelefonos(PersonaId, TipoTelefono, Telefono) Values ({0}, '{1}', '{2}')", Retorno, NumeroDatos.TipoTelefono, NumeroDatos.Telefono));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno > 0;
        }

        public override bool Editar()
        {
            bool Retorno = false;
            try
            {
                Retorno = Conexion.Ejecutar(String.Format("Update Personas set Nombres='{0}', Sexo='{1}' where PersonaId= {2}", this.Nombres, this.Sexo, this.PersonaId));
                if (Retorno)
                {
                    Conexion.Ejecutar(String.Format("Delete from PersonasTelefonos Where PersonaId= {0}", this.PersonaId));
                    foreach (PersonasTelefonos Numero in this.Detalle)
                    {
                        Conexion.Ejecutar(string.Format("Insert into PersonasTelefonos(PersonaId, TipoTelefono, Telefono) Values ({0},'{1}','{2}')", this.PersonaId, Numero.TipoTelefono, Numero.Telefono));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno;
        }
        
        public override bool Eliminar()
        {
            bool Retorno = false;
            try
            {
                Retorno = Conexion.Ejecutar(String.Format("Delete from PersonasTelefonos Where PersonaId= {0};" + "Delete from Personas where PersonaId= {0}", this.PersonaId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dtEventDetalle = new DataTable();
            try
            {
                dt = Conexion.ObtenerDatos(String.Format("select * from Personas where PersonaId=" + IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.PersonaId = (int)dt.Rows[0]["PersonaId"];
                    this.Nombres = dt.Rows[0]["Nombres"].ToString();
                    this.Sexo = dt.Rows[0]["Sexo"].ToString(); ;
                    dtEventDetalle = Conexion.ObtenerDatos(String.Format("select * from PersonasTelefonos where PersonaId=" + IdBuscado));
                   
                    foreach (DataRow row in dtEventDetalle.Rows)
                    {
                        AgregarTelefonos(row["TipoTelefono"].ToString(), row["Telefono"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Orden by  " + Orden;
            return Conexion.ObtenerDatos("Select " + Campos + " From Eventos Where " + Condicion + Orden);
        }
    }
}
