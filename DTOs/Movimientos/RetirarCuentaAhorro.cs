namespace apiFinanciera.DTOs.Movimientos
{
    public class RetirarCuentaAhorro
    {
        public String NumeroCuenta { get; set; }
        public decimal Cantidad { get; set; }
        public String? Concepto { get; set; }
        public int IdCliente { get; set; }
    }


}