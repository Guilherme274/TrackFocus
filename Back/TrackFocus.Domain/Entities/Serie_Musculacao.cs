using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFocus.Domain.Entities
{
    public class Serie_Musculacao
    {
        [Column("cd_id", TypeName = "int")]
        public int Id { get; set; }
        [Column("qt_repeticoes", TypeName = "int")]
        public int? NumRepeticoes { get; set; }        
        [Column("qt_peso")]
        public int Peso { get; set; }
        [Column("cd_exercicioId")]
        public int ExercicioId { get; set; }
        [ForeignKey(nameof(ExercicioId))]
        public Exercicio Exercicio { get; set; }
        
    }
}