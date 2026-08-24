using System;
namespace IrongC2Systemapi.Model
{
    public class Assets
    {
        public int Id {  get; set; }

        public int UnitId {  get; set; }

        public string AssetSerial {  get; set; }
        
        public string Type {  get; set; }

        public Unit Unit { get; set; }
    }
}