﻿namespace IpTracker
{
    public class IPInfo
    {
        public string ip { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string org { get; set; }
        public string postal { get; set; }
        public string timezone { get; set; }
        public string locOnMap { get; set; }

        public override string ToString()
        {
            return
                "IP Information:\n" +
                "----------------------\n" +
                $"IP Address   : {ip}\n" +
                $"Country      : {country}\n" +
                $"Region       : {region}\n" +
                $"City         : {city}\n" +
                $"Postal Code  : {postal}\n" +
                $"Timezone     : {timezone}\n" +
                $"Location     : {loc} (Map: {locOnMap})\n" +
                $"Organization : {org}\n";
        }

    }
}
