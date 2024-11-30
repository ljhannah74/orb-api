using System;
using System.Data.Common;
using OrbDataModels.DAL;
using OrbDataModels.DTOs;

namespace OrbDataModels.BLL;

public class OrbBLL
{
    private readonly OrbDAL _resourceDAL;
    public OrbBLL(string connectionString)
    {
        _resourceDAL = new OrbDAL(connectionString);
    }
    public List<StateDTO> GetAllStates() => _resourceDAL.GetAllStates();

    public List<CountyDTO> GetCountiesByState(int StateID) => _resourceDAL.GetCountiesByState(StateID);

    public OrbDTO GetOrbsByStateCounty(int StateID, int CountyID) => _resourceDAL.GetOrbByStateCounty(StateID, CountyID);
}
