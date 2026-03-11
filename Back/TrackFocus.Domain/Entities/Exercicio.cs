using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TrackFocus.Domain.Entities
{
    [Table("Exercicio")]
    public class Exercicio
    {
        [Column("cd_id", TypeName = "int")]
        public int Id { get; set; }
        [Column("nm_exercicio", TypeName = "varchar(100)")]
        public string Nome { get; set; } = string.Empty;
        [Column("cd_tipo_exercico", TypeName = "int")]
        public int Tipo_ExercicioId { get; set; }
        [ForeignKey(nameof(Tipo_ExercicioId))]
        public Tipo_Exercicio Tipo_Exercicio { get; set; }
        [Column("cd_treino")]
        public int TreinoId { get; set; }
        [ForeignKey(nameof(TreinoId))]
        [JsonIgnore]
        public Treino Treino { get; set; }
        [JsonIgnore]
        public ICollection<Cardio>? ExerciciosCardio { get; set; }
        [JsonIgnore]
        public ICollection<Serie_Musculacao>? ExerciciosMusculacao { get; set; }        
    }
}