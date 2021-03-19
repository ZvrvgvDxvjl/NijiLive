using Newtonsoft.Json;
namespace NijiLive.classes
{
    public class Channel
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public string Agency { get; set; }
        public string Region { get; set; }
        public string Generation { get; set; }
        [JsonIgnore]
        public bool Live { get; set; }
        public Channel(string _URL, string _Name, string _Agency, string _Region, string _Generation)
        {
            URL = _URL;
            Name = _Name;
            Agency = _Agency;
            Region = _Region;
            Generation = _Generation;
        }
        //channel list double click, remove & edit channel rely on this
        public override string ToString()
        {
            string retVal = Name + " (" + Agency + " " + Region;
            if (Generation != string.Empty)
            {
                retVal += " " + Generation + " Gen)";
            }
            else
            {
                retVal += ")";
            }
            return retVal;
        }
    }
}