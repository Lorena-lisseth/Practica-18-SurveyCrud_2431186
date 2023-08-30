using SQLite;

namespace Practica17_2431186.Models
{
    public class TodoItem
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string FavoriteTeam { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Done { get; set; }
    }
}
