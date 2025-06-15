namespace RestFullApiForBank.Core.Application.DTOs.ClienteDtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string LastName { get; set; }
        public DateTime FechaDeNacimineto { get; set; }
        public int Edad { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public string? Direccion { get; set; }
    }
}