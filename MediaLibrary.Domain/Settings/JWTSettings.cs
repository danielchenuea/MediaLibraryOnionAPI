﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Settings;

public record JWTSettings
{
    public string Key { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Authority { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public double DurationInMinutes {  get; init; }
}
