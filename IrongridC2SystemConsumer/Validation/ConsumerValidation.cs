using IrongridC2SystemConsumer.Model;
using System;
using System.ComponentModel.DataAnnotations;
namespace IrongridC2SystemConsumer.Validation
{
    public class Consumervalidation
    {
        public AssetLiveStatus checkStatus(MessageModel message)
        {
            if(message.AssetType == "UAV")
            {
               var assetLiveStatusUAv = new AssetLiveStatus()
                {
                    AssetId = message.AssetId,
                    AssetType = message.AssetType,
                    RawValue = message.RawValue,
                    ProcessedStatus = ProcessedStatusUAV(message.RawValue),
                    IsVerified = IsVerifiedUAV(message.RawValue),
                    LastUpdate = message.Timestamp

                };
                return assetLiveStatusUAv;
            }


            var assetLiveStatus = new AssetLiveStatus()
            {
                AssetId = message.AssetId,
                AssetType = message.AssetType,
                RawValue = message.RawValue,
                ProcessedStatus = ProcessedStatusUAV(message.RawValue),
                IsVerified = IsVerifiedUAV(message.RawValue),
                LastUpdate = message.Timestamp
            };
            return assetLiveStatus;
        }


        private bool CheckRAWValue(string RawValue)
        {
            if(int.TryParse(RawValue, out int result))
            {
                return true;
            }
            return false;
        }

        private string ProcessedStatusUAV(string RawValue)
        {
            if(!CheckRAWValue(RawValue))
            {
                return "Warning";
            }
            int result = int.Parse(RawValue);

            if(result < 20 || result >= 100)
            {
                return "Warning";
            }

            if (result > 19 || result >= 100)
            {
                return "Stable";
            }

            return "Warning";
        }

        private bool IsVerifiedUAV(string RawValue)
        {
            if (!CheckRAWValue(RawValue))
            {
                return false;
            }
            int result = int.Parse(RawValue);

            if (result < 20 && result >= 100)
            {
                return true;
            }

            if (result > 19 && result >= 100)
            {
                return true;
            }
            return false;
        }

    }
}