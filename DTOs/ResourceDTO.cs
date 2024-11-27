using System;

namespace orb_api.DTOs;

public class ResourceDTO
{
  public int ResourceID { get; set; }
    public int StateID { get; set; }
    public int CountyID { get; set; }
    public string ResourceType { get; set; }
    public string ResourceURL { get; set; }
    public string ResourceUser { get; set; }
    public string ResourcePwd { get; set; }
}
