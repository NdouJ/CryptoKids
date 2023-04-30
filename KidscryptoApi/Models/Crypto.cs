using System;
using System.Collections.Generic;

namespace KidscryptoApi.Models;

public partial class Crypto
{
    public int IdCrypto { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CryptoFact> CryptoFacts { get; set; } = new List<CryptoFact>();
}
