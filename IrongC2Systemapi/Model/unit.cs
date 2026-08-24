using System;
namespace IrongC2Systemapi.Model
{
    public class Unit
    {
        public int Id { get; set; }

        public string UnitName {  get; set; }

        public string Sector {  get; set; }
        
        public Assets Assets { get; set; }
    }
}