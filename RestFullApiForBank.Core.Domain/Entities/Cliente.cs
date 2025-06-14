using RestFullApiForBank.Core.Domain.Common;

namespace RestFullApiForBank.Core.Domain.Entities
{
    public class Cliente : AuditableBaseEntity
    {
        private int _edad;
        public required string Nombre { get; set; }
        public required string LastName { get; set; }
        public DateTime FechaDeNacimineto { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public string? Direccion { get; set; }
        public int Edad
        {
            get {
                if (this._edad <= 0)
                    this._edad = new DateTime(DateTime.Now.Subtract(this.FechaDeNacimineto).Ticks).Year - 1;
                return this._edad;
            }
        }
    }
}
