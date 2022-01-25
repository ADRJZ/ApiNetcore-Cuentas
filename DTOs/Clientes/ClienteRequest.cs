namespace apiFinanciera.DTOs.Clientes
{
    public class ClienteRequest
    {
        public String Nombre { get; set; } 
        public String ApellidoPaterno { get; set; }   
        public String ApellidoMaterno { get; set; }
        public String Identificacion { get; set; }
    }
}