using System;
using System.Collections.Generic;

namespace Komit.CompanionApp.Model.Entities;

public partial class Logadgang
{
    public string Program { get; set; } = null!;

    public string Bruger { get; set; } = null!;

    public short? Adgang1 { get; set; }

    public short? Adgang2 { get; set; }

    public byte[]? Kode { get; set; }

    public DateTime? Fradato { get; set; }

    public DateTime? Tildato { get; set; }

    public DateTime? Rettedato { get; set; }
}
