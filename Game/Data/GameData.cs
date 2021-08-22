using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Data
{
    public class GameData
    {
        public int Id { get; set; }
        public int Answer { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string ImgUrl { get; set; }
    }
}
