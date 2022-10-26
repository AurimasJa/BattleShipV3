
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleShipV3.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? EloFrom { get; set; }
        public double? EloTo { get; set; }
        public DateTime CreationDate { get; set; }
        public User PlayerOne { get; set; }
        public User? PlayerTwo { get; set; }
    }
}
