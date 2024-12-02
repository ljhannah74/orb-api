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
                    StateID = (int)reader["StateID"],
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

    public bool UpdateOrb(OrbDTO orbDto)
    {
        using (var connection = new MySqlConnection(_connectionString))
        using (var command = new MySqlCommand("UpdateORB", connection))
        {
            command.Parameters.AddWithValue("@StateID", orbDto.StateID);
            command.Parameters.AddWithValue("@CountyID", orbDto.CountyID);
            command.Parameters.AddWithValue("@LastUpdate", orbDto.LastUpdate);
            command.Parameters.AddWithValue("@CountyHomepage", (object)orbDto.CountyHomepage ?? DBNull.Value);
            command.Parameters.AddWithValue("@SubNeed", (object)orbDto.SubNeed ?? DBNull.Value);
            command.Parameters.AddWithValue("@WeSubscribe", (object)orbDto.WeSubscribe ?? DBNull.Value);
            command.Parameters.AddWithValue("@SubTerm", (object)orbDto.SubTerm ?? DBNull.Value);
            command.Parameters.AddWithValue("@SubFee", (object)orbDto.SubFee ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tap", (object)orbDto.Tap ?? DBNull.Value);
            command.Parameters.AddWithValue("@Rv", (object)orbDto.Rv ?? DBNull.Value);
            command.Parameters.AddWithValue("@DtreeDesk", (object)orbDto.DtreeDesk ?? DBNull.Value);
            command.Parameters.AddWithValue("@Ins", (object)orbDto.Ins ?? DBNull.Value);
            command.Parameters.AddWithValue("@Props", (object)orbDto.Props ?? DBNull.Value);
            command.Parameters.AddWithValue("@Copy", (object)orbDto.Copy ?? DBNull.Value);
            command.Parameters.AddWithValue("@CopyPmtMethod", (object)orbDto.CopyPmtMethod ?? DBNull.Value);
            command.Parameters.AddWithValue("@CopyFeeAmt", (object)orbDto.CopyFeeAmt ?? DBNull.Value);
            command.Parameters.AddWithValue("@CopySource", (object)orbDto.CopySource ?? DBNull.Value);
            command.Parameters.AddWithValue("@ImgDate", (object)orbDto.ImgDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@IndexDate", (object)orbDto.IndexDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@IndexSource", (object)orbDto.IndexSource ?? DBNull.Value);
            command.Parameters.AddWithValue("@IndexPmtMethod", (object)orbDto.IndexPmtMethod ?? DBNull.Value);
            command.Parameters.AddWithValue("@LandUrl", (object)orbDto.LandUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@LoginReq", (object)orbDto.LoginReq ?? DBNull.Value);
            command.Parameters.AddWithValue("@CountyUser", (object)orbDto.CountyUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@CountyPwd", (object)orbDto.CountyPwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@LandUrl2", (object)orbDto.LandUrl2 ?? DBNull.Value);
            command.Parameters.AddWithValue("@LandUser2", (object)orbDto.LandUser2 ?? DBNull.Value);
            command.Parameters.AddWithValue("@LandPwd2", (object)orbDto.LandPwd2 ?? DBNull.Value);
            command.Parameters.AddWithValue("@AssessorUrl", (object)orbDto.AssessorUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@AssessorUser", (object)orbDto.AssessorUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@AssessorPwd", (object)orbDto.AssessorPwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@TaxUrl", (object)orbDto.TaxUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@TaxUser", (object)orbDto.TaxUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@TaxPwd", (object)orbDto.TaxPwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tax2Url", (object)orbDto.Tax2Url ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tax2User", (object)orbDto.Tax2User ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tax2Pwd", (object)orbDto.Tax2Pwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@DelinqTaxUrl", (object)orbDto.DelinqTaxUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tax3User", (object)orbDto.Tax3User ?? DBNull.Value);
            command.Parameters.AddWithValue("@Tax3Pwd", (object)orbDto.Tax3Pwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@UccUrl", (object)orbDto.UccUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@MuniCourtUrl", (object)orbDto.MuniCourtUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@MuniUser", (object)orbDto.MuniUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@MuniPwd", (object)orbDto.MuniPwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProthonUrl", (object)orbDto.ProthonUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProUser", (object)orbDto.ProUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProPwd", (object)orbDto.ProPwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@SheriffUrl", (object)orbDto.SheriffUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@CourtUrl", (object)orbDto.CourtUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@CourtUser", (object)orbDto.CourtUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@CourtPwd", (object)orbDto.CourtPwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@CourtImgDt", (object)orbDto.CourtImgDt ?? DBNull.Value);
            command.Parameters.AddWithValue("@CourtIndexDt", (object)orbDto.CourtIndexDt ?? DBNull.Value);
            command.Parameters.AddWithValue("@ForeclosureUrl", (object)orbDto.ForeclosureUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProbateUrl", (object)orbDto.ProbateUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProbateUser", (object)orbDto.ProbateUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@ProbatePwd", (object)orbDto.ProbatePwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@MapUrl", (object)orbDto.MapUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@PlatUrl", (object)orbDto.PlatUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@OtherUrl", (object)orbDto.OtherUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@OtherUser", (object)orbDto.OtherUser ?? DBNull.Value);
            command.Parameters.AddWithValue("@OtherPwd", (object)orbDto.OtherPwd ?? DBNull.Value);
            command.Parameters.AddWithValue("@Comments", (object)orbDto.Comments ?? DBNull.Value);

            connection.Open();
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
