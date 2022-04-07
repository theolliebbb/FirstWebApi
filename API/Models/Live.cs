using System;
using SQLite;
namespace API.Models
{
    public class Live
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Band { get; set; }
        public string Date { get; set; }
        public string Venue { get; set; }
        public string Image { get; set; }
        public string MapLocation { get; set; }

    
    public Live()
		{
		}
	}
}

