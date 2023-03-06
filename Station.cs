namespace Radio
{
    public class Station
    {
        public Station(string name, string url)
        {
            Name = name;
            URL = url;
        }

        public string Name { get; private set; }
        public string URL { get; private set; }
    }
}
