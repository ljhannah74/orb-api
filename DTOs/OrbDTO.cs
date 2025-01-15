using System;
using orb_api.Models;

namespace orb_api.DTOs;

public class OrbDTO
{
    public int Id { get; set; }

    public string? State { get; set; }

    public string? County { get; set; }

    public List<ResourceInfo>? Resources { get; set; }
}
