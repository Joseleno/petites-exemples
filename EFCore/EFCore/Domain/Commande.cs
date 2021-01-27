using System;
using System.Collections.Generic;
using EFCore.ValueObjects;

namespace EFCore.Domain
{
    public class Commande
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public TypeLivraison TypeLivraison { get; set; }
        public StatutCommande StatutCommande { get; set; }
        public string Remarque { get; set; }
        public ICollection<ItenCommande> ItensCommandes { get; set; }
    }
}