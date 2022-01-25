using System.ComponentModel.DataAnnotations;


namespace apiFinanciera.Entitys
{
    public class Cliente : EntityBase
    {
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String NombreCompleto { get; set; }
        public String NumeroIdentificacion { get; set; }

        public virtual List<Cuenta> ? Cuentas { get; set; }
    }
}
