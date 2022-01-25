namespace apiFinanciera.Entitys
{
    public class Movimiento : EntityBase
    {
        public decimal Cantidad { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public String Concepto { get; set; }
        public String Usuario { get; set; }
        public int? Cliente { get; set; }

        // Llaves foraneas
        public int CuentaId { get; set; }

        // Propiedades de navegacion
        public virtual Cuenta Cuenta { get; set; }

    }

    public enum TipoMovimiento
    {
        ABONO,
        CARGO,
    }
}