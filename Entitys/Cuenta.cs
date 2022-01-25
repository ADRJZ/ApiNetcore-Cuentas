namespace apiFinanciera.Entitys
{
    public class Cuenta : EntityBase
    {
        public String? NumeroCuenta { get; set; }
        public String? NombreCuenta { get; set; }
        public TipoCuenta? TipoCuenta { get; set; }
        public decimal Saldo { get; set; }

        // Laves Foraneas

        public int ClienteId { get; set; }

        // Propiedades de navegacion
        public virtual Cliente Cliente { get; set; }
        public virtual List<Movimiento>? Movimientos { get; set; }
    }

    public enum TipoCuenta
    {
        CORRIENTE = 1001,
        AHORRO = 2001,
        CREDITO = 3001
    }
}