using System;
using System.Collections.Generic;

namespace KidscryptoApi.Models;

public partial class CryptoFact
{
    public int IdCryptoFact { get; set; }

    public int? CryptoFactId { get; set; }

    public string Fact { get; set; } = null!;

    public virtual Crypto? CryptoFactNavigation { get; set; }
}
