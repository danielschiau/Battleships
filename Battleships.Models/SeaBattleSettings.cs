using System.Collections.Generic;

namespace Battleships.Models
{
    public class SeaBattleSettings
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
