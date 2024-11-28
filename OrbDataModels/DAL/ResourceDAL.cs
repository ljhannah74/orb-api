using System;
using OrbDataModels.DTOs;
using MySqlConnector;

namespace OrbDataModels.DAL;

public class ResourceDAL
{
    private readonly string _connectionString;

    public ResourceDAL(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<StateDTO> GetAllStates()
    {
        var states = new List<StateDTO>();

        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            string query = "SELECT StateID, StateName FROM State";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                states.Add(new StateDTO
                {
                    StateID = (int)reader["StateID"],
                    StateName = reader["StateName"].ToString()
                });
            }

            conn.Close();
        }

        return states;
    }

}
