using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFocus.Domain.Entities
{
    public class Cardio
    {
        [Column("cd_id", TypeName = "int")]
        public int Id { get; set; }
        [Column("qt_distancia", TypeName = "int")]
        public int? Distancia { get; set; }
        [Column("qt_calorias", TypeName = "int")]
        public int? Calorias { get; set; }    
        [Column("cd_exercicioId")]
        public int ExercicioId { get; set; }
        [ForeignKey(nameof(ExercicioId))]
        public Exercicio Exercicio { get; set; }
    }
}