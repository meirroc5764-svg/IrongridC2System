using System;
namespace IrongridC2SystemConsumer.Model
{
    public class MessageModel
    {
        public int AssetId {  get; set; }

        public string AssetType {  get; set; }

        public string RawValue {  get; set; }

        public DateTime Timestamp { get; set; }
    }
}
