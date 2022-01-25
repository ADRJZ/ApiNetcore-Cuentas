namespace apiFinanciera.DTOs
{
    public class Response
    {
        public int status { get; set; }
        public object content { get; set; }
        public bool success { get; set; }
        public Response()
        {
            
            this.status = 500;
            this.content = null;
            this.success = false;
        }
    }
}