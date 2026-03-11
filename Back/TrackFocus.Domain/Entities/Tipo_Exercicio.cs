using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFocus.Domain.Entities
{
    public class Tipo_Exercicio
    {
        [Column("cd_id", TypeName = "int")]
        public int Id { get; set; }
        [Column("nm_tipo", TypeName = "varchar(30)")]
        public string Nome { get; set; } = string.Empty;
        public ICollection<Exercicio> Exercicios { get; set; } = new List<Exercicio>();
    }
}