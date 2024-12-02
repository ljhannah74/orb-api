using System;
using System.Data.Common;
using OrbDataModels.DAL;
using OrbDataModels.DTOs;

namespace OrbDataModels.BLL;

public class OrbBLL
{
    private readonly OrbDAL _orbDAL;
    public OrbBLL(string connectionString)
    {
        _orbDAL = new OrbDAL(connectionString);
    }
    public List<StateDTO> GetAllStates() => _orbDAL.GetAllStates();

    public List<CountyDTO> GetCountiesByState(int StateID) => _orbDAL.GetCountiesByState(StateID);

    public OrbDTO GetOrbsByStateCounty(int StateID, int CountyID) => _orbDAL.GetOrbByStateCounty(StateID, CountyID);

    public bool UpdateOrb(OrbDTO orbDto) => _orbDAL.UpdateOrb(orbDto);
}
