namespace NeftchiLLC.Domain.Models.Entities
{
    public class Translation
    {
        public int Id { get; set; }
        public string Key { get; set; }         
        public string Language { get; set; }    
        public string Value { get; set; }
    }
}
