using EFCore.ValueObjects;

namespace EFCore.Domain
{
    public class Produit
    {
        public int Id { get; set; }
        public string Codebarre { get; set; }
        public string Description { get; set; }
        public decimal Valeur { get; set; }
        public TypeProduit TypeProduit { get; set; }
        public bool Active { get; set; }
    }
}