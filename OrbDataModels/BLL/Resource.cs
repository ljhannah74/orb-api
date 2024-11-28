using System;
using System.Data.Common;
using OrbDataModels.DAL;
using OrbDataModels.DTOs;

namespace OrbDataModels.BLL;

public class ResourceBLL
{
    private readonly ResourceDAL _resourceDAL;
    public ResourceBLL(string connectionString)
    {
        _resourceDAL = new ResourceDAL(connectionString);
    }
    public List<StateDTO> GetAllStates() {
        return _resourceDAL.GetAllStates();
    }
}
