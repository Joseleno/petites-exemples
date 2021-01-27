namespace EFCore.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string CEP { get; set; }
        public string Province { get; set; }
        public string Ville { get; set; }
    }
}