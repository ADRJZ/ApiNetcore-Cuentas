namespace apiFinanciera.DTOs.Movimientos
{
    public class RetirarCuentaRequest
    {
        public String NumeroCuenta { get; set; }
        public decimal Cantidad { get; set; }
        public String Concepto { get; set; }
        public String Usuario { get; set; }
        public int? IdCliente { get; set; }
        public int? IdCuenta { get; set; }
    }
}