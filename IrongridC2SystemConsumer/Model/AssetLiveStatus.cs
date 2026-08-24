using System;
using System.ComponentModel.DataAnnotations;
namespace IrongridC2SystemConsumer.Model
{
    public class AssetLiveStatus
    {
        [Key]
        public int AssetId {  get; set; }

        [AllowedValues("UAV", "PerimeterSensor")]
        public string AssetType {  get; set; }

        [Required]
        public string RawValue {  get; set; }

        public string ProcessedStatus {  get; set; }

        [Required]
        public bool IsVerified { get; set; }

        [Required]
        public DateTime LastUpdate {  get; set; }


    }
}





//AssetId int מזהה האמצעי
//AssetType string סוג האמצעי UAV / PerimeterSensor
//RawValue string הערך שהתקבל Required
//ProcessedStatus string תוצאה לאחר עיבוד Stable / Warning
//IsVerified bool האם הדיווח תקין Required
//LastUpdate DateTime זמן עדכון אחרון Required