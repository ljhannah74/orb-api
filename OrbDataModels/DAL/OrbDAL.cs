using System;
using OrbDataModels.DTOs;
using MySqlConnector;
using System.ComponentModel.Design;

namespace OrbDataModels.DAL;

public class OrbDAL
{
    private readonly string _connectionString;

    public OrbDAL(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<StateDTO> GetAllStates()
    {
        var states = new List<StateDTO>();

        using (MySqlConnection mySqlConn = new MySqlConnection(_connectionString))
        using (MySqlCommand mySqlCmd = new MySqlCommand("GetStates", mySqlConn))
        {
            mySqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

            mySqlCmd.Connection.Open();
            MySqlDataReader reader = mySqlCmd.ExecuteReader();

            while (reader.Read())
            {
                StateDTO state = new StateDTO
                {
                    StateID = (int)reader["StateID"],
                    StateName = reader["StateName"].ToString()
                };
                states.Add(state);
            }

            mySqlConn.Close();
        }

        return states;
    }

    public List<CountyDTO> GetCountiesByState(int StateID)
    {
        var counties = new List<CountyDTO>();

        using (MySqlConnection mySqlConn = new MySqlConnection(_connectionString))
        using (MySqlCommand mySqlCmd = new MySqlCommand("GetCountiesByState", mySqlConn))
        {
            mySqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            mySqlCmd.Parameters.AddWithValue("p_StateID", StateID);
            mySqlCmd.Connection.Open();
            MySqlDataReader reader = mySqlCmd.ExecuteReader();

            while (reader.Read())
            {
                CountyDTO county = new CountyDTO
                {
                    CountyID = (int)reader["CountyID"],
                    CountyName = reader["CountyName"].ToString()
                };
                counties.Add(county);
            }

            mySqlConn.Close();
        }

        return counties;
    }

    public OrbDTO GetOrbByStateCounty(int StateID, int CountyID)
    {
        using (MySqlConnection mySqlConn = new MySqlConnection(_connectionString))
        using (MySqlCommand mySqlCmd = new MySqlCommand("GetOrbsByStateCounty", mySqlConn))
        {
            mySqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            mySqlCmd.Parameters.AddWithValue("p_StateID", StateID);
            mySqlCmd.Parameters.AddWithValue("p_CountyID", CountyID);
            mySqlConn.Open();
            MySqlDataReader reader = mySqlCmd.ExecuteReader();

            if (reader.Read())
            {

                return new OrbDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    StateID = reader.GetInt32(reader.GetOrdinal("StateID")),
                    CountyID = reader.GetInt32(reader.GetOrdinal("CountyID")),
                    LastUpdate = reader.GetDateTime(reader.GetOrdinal("last_update")),
                    CountyHomepage = reader["county_homepage"] as string,
                    SubNeed = reader["sub_need"] as string,
                    WeSubscribe = reader["we_subscribe"] as string,
                    SubTerm = reader["sub_term"] as string,
                    SubFee = reader["subFee"] as string,
                    Tap = reader["tap"] as string,
                    Rv = reader["rv"] as string,
                    DtreeDesk = reader["dtree_desk"] as string,
                    Ins = reader["ins"] as string,
                    Props = reader["props"] as string,
                    Copy = reader["copy"] as string,
                    CopyPmtMethod = reader["copy_pmt_method"] as string,
                    CopyFeeAmt = reader["copyFeeAmt"] as string,
                    CopySource = reader["copy_source"] as string,
                    ImgDate = reader["img_date"] as string,
                    IndexDate = reader["index_date"] as string,
                    IndexSource = reader["index_source"] as string,
                    IndexPmtMethod = reader["index_pmt_method"] as string,
                    LandUrl = reader["land_url"] as string,
                    LoginReq = reader["login_req"] as string,
                    CountyUser = reader["county_user"] as string,
                    CountyPwd = reader["county_pwd"] as string,
                    LandUrl2 = reader["land_url2"] as string,
                    LandUser2 = reader["land_user2"] as string,
                    LandPwd2 = reader["land_pwd2"] as string,
                    AssessorUrl = reader["assessor_url"] as string,
                    AssessorUser = reader["assessor_user"] as string,
                    AssessorPwd = reader["assessor_pwd"] as string,
                    TaxUrl = reader["tax_url"] as string,
                    TaxUser = reader["tax_user"] as string,
                    TaxPwd = reader["tax_pwd"] as string,
                    Tax2Url = reader["tax2_url"] as string,
                    Tax2User = reader["tax2_user"] as string,
                    Tax2Pwd = reader["tax2_pwd"] as string,
                    DelinqTaxUrl = reader["delinq_tax_url"] as string,
                    Tax3User = reader["tax3_user"] as string,
                    Tax3Pwd = reader["tax3_pwd"] as string,
                    UccUrl = reader["ucc_url"] as string,
                    MuniCourtUrl = reader["muniCourt_url"] as string,
                    MuniUser = reader["muni_user"] as string,
                    MuniPwd = reader["muni_pwd"] as string,
                    ProthonUrl = reader["prothon_url"] as string,
                    ProUser = reader["pro_user"] as string,
                    ProPwd = reader["pro_pwd"] as string,
                    SheriffUrl = reader["sheriff_url"] as string,
                    CourtUrl = reader["court_url"] as string,
                    CourtUser = reader["court_user"] as string,
                    CourtPwd = reader["court_pwd"] as string,
                    CourtImgDt = reader["courtImgDt"] as string,
                    CourtIndexDt = reader["courtIndexDt"] as string,
                    ForeclosureUrl = reader["foreclosure_url"] as string,
                    ProbateUrl = reader["probate_url"] as string,
                    ProbateUser = reader["probate_user"] as string,
                    ProbatePwd = reader["probate_pwd"] as string,
                    MapUrl = reader["map_url"] as string,
                    PlatUrl = reader["plat_url"] as string,
                    OtherUrl = reader["other_url"] as string,
                    OtherUser = reader["other_user"] as string,
                    OtherPwd = reader["other_pwd"] as string,
                    Comments = reader["comments"] as string
                };
            }
            else
            {
                return null;
            }
        }
    }
}
