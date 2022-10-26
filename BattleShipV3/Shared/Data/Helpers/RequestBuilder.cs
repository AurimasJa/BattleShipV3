
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BattleShipV3.Shared.Data.Helpers
{
    public class RequestHelper
    {
        public static StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
