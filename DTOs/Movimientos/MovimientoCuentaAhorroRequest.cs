namespace apiFinanciera.DTOs.Movimientos
{
    public class MovimientoCuentaAhorroRequest
    {
        public String NumeroCuentaAbono{ get; set; }
        public int? IdcuentaOrigen { get; set; }
        public decimal Cantidad { get; set; }
        public String Concepto { get; set; }
        public String Usuario { get; set; }
        public int? IdCliente { get; set; }
    }
}