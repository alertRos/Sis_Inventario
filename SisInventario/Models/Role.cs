namespace SisInventario.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<Usuario> usuarios { get; set; }
    }
}
