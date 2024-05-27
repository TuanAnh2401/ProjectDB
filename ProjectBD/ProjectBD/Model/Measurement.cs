using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectBD.Model
{
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int id { get; set; }
        public int kg { get; set; }
        public int mm { get; set; }
    }
}
