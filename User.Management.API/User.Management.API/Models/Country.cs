namespace User.Management.API.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<State> States { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<City> Cities { get; set; }
    }
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
