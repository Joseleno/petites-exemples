namespace EFCore.Domain
{
    public class ItenCommande
    {
        public int Id { get; set; }
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }
        public int ProduitId { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
        public decimal Valeur { get; set; }
        public decimal Remise { get; set; }
    }
}