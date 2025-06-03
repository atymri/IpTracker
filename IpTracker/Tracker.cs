using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using Newtonsoft.Json;


namespace IpTracker
{
    public static class Tracker
    {
        public static async Task<IPInfo?> Track(string ip)
        {
            IPInfo response = new IPInfo();
            string endpoint = $"https://www.ipinfo.io/{ip}/json";
            using (HttpClient http = new HttpClient())
            {
                try
                {
                    string json = await http.GetStringAsync(endpoint);
                    response = JsonConvert.DeserializeObject<IPInfo>(json);
                    response.locOnMap = $"https://www.google.com/maps/dir/{response.loc}/";
                }catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"something went wrong.\n{e.Message}");
                    Console.ResetColor();
                }
                return response;
            }
        }

        public static bool IsValid(string ip)
        {
            string[] octets = ip.Split('.');
            if (octets.Length < 4)
                return false;
            foreach(string octet in octets)
            {
                if (int.Parse(octet) > 255 || int.Parse(octet) < 0)
                    return false;
            }
            return true;
        }

    }
}
