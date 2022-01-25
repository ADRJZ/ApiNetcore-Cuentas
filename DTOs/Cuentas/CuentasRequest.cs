namespace apiFinanciera.DTOs.Cuentas
{
    public class CuentasRequest
    {
        public int idCliente { get; set; }
        public int Tipocuenta { get; set; }
        public decimal? Saldo { get; set; }
        public String? Nombrecuenta { get; set; }
    }
}