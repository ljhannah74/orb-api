using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace orb_api.Models;

public partial class OrbDbContext : DbContext
{
    public OrbDbContext()
    {
    }

    public OrbDbContext(DbContextOptions<OrbDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Orb> Orbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=orb_db;user=lewisjhannah;password=precious5", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.6-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Orb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ORB");

            entity.Property(e => e.Id).HasColumnType("int(6)");
            entity.Property(e => e.AssessorPwd)
                .HasMaxLength(9)
                .HasColumnName("assessor_pwd");
            entity.Property(e => e.AssessorUrl)
                .HasMaxLength(154)
                .HasColumnName("assessor_url");
            entity.Property(e => e.AssessorUser)
                .HasMaxLength(28)
                .HasColumnName("assessor_user");
            entity.Property(e => e.Comments)
                .HasColumnType("text")
                .HasColumnName("comments");
            entity.Property(e => e.Copy)
                .HasMaxLength(3)
                .HasColumnName("copy");
            entity.Property(e => e.CopyFeeAmt)
                .HasMaxLength(0)
                .HasColumnName("copyFeeAmt");
            entity.Property(e => e.CopyPmtMethod)
                .HasMaxLength(0)
                .HasColumnName("copy_pmt_method");
            entity.Property(e => e.CopySource)
                .HasMaxLength(10)
                .HasColumnName("copy_source");
            entity.Property(e => e.County)
                .HasMaxLength(32)
                .HasColumnName("county");
            entity.Property(e => e.CountyHomepage)
                .HasMaxLength(202)
                .HasColumnName("county_homepage");
            entity.Property(e => e.CountyPwd)
                .HasMaxLength(24)
                .HasColumnName("county_pwd");
            entity.Property(e => e.CountyUser)
                .HasMaxLength(35)
                .HasColumnName("county_user");
            entity.Property(e => e.CourtImgDt)
                .HasMaxLength(0)
                .HasColumnName("courtImgDt");
            entity.Property(e => e.CourtIndexDt)
                .HasMaxLength(0)
                .HasColumnName("courtIndexDt");
            entity.Property(e => e.CourtPwd)
                .HasMaxLength(11)
                .HasColumnName("court_pwd");
            entity.Property(e => e.CourtUrl)
                .HasMaxLength(135)
                .HasColumnName("court_url");
            entity.Property(e => e.CourtUser)
                .HasMaxLength(15)
                .HasColumnName("court_user");
            entity.Property(e => e.DelinqTaxUrl)
                .HasMaxLength(96)
                .HasColumnName("delinq_tax_url");
            entity.Property(e => e.DtreeDesk)
                .HasMaxLength(3)
                .HasColumnName("dtree_desk");
            entity.Property(e => e.ForeclosureUrl)
                .HasMaxLength(146)
                .HasColumnName("foreclosure_url");
            entity.Property(e => e.ImgDate)
                .HasMaxLength(9)
                .HasColumnName("img_date");
            entity.Property(e => e.IndexDate)
                .HasMaxLength(8)
                .HasColumnName("index_date");
            entity.Property(e => e.IndexPmtMethod)
                .HasMaxLength(0)
                .HasColumnName("index_pmt_method");
            entity.Property(e => e.IndexSource)
                .HasMaxLength(10)
                .HasColumnName("index_source");
            entity.Property(e => e.Ins)
                .HasMaxLength(3)
                .HasColumnName("ins");
            entity.Property(e => e.LandPwd2)
                .HasMaxLength(13)
                .HasColumnName("land_pwd2");
            entity.Property(e => e.LandUrl)
                .HasMaxLength(202)
                .HasColumnName("land_url");
            entity.Property(e => e.LandUrl2)
                .HasMaxLength(109)
                .HasColumnName("land_url2");
            entity.Property(e => e.LandUser2)
                .HasMaxLength(28)
                .HasColumnName("land_user2");
            entity.Property(e => e.LastUpdate)
                .HasMaxLength(10)
                .HasColumnName("last_update");
            entity.Property(e => e.LoginReq)
                .HasMaxLength(5)
                .HasColumnName("login_req");
            entity.Property(e => e.MapUrl)
                .HasColumnType("text")
                .HasColumnName("map_url");
            entity.Property(e => e.MuniCourtUrl)
                .HasMaxLength(87)
                .HasColumnName("muniCourt_url");
            entity.Property(e => e.MuniPwd)
                .HasMaxLength(8)
                .HasColumnName("muni_pwd");
            entity.Property(e => e.MuniUser)
                .HasMaxLength(17)
                .HasColumnName("muni_user");
            entity.Property(e => e.OtherPwd)
                .HasMaxLength(14)
                .HasColumnName("other_pwd");
            entity.Property(e => e.OtherUrl)
                .HasColumnType("text")
                .HasColumnName("other_url");
            entity.Property(e => e.OtherUser)
                .HasMaxLength(36)
                .HasColumnName("other_user");
            entity.Property(e => e.PlatUrl)
                .HasMaxLength(78)
                .HasColumnName("plat_url");
            entity.Property(e => e.ProPwd)
                .HasMaxLength(6)
                .HasColumnName("pro_pwd");
            entity.Property(e => e.ProUser)
                .HasMaxLength(13)
                .HasColumnName("pro_user");
            entity.Property(e => e.ProbatePwd)
                .HasMaxLength(10)
                .HasColumnName("probate_pwd");
            entity.Property(e => e.ProbateUrl)
                .HasMaxLength(83)
                .HasColumnName("probate_url");
            entity.Property(e => e.ProbateUser)
                .HasMaxLength(22)
                .HasColumnName("probate_user");
            entity.Property(e => e.Props)
                .HasMaxLength(3)
                .HasColumnName("props");
            entity.Property(e => e.ProthonUrl)
                .HasMaxLength(153)
                .HasColumnName("prothon_url");
            entity.Property(e => e.Rv)
                .HasMaxLength(3)
                .HasColumnName("rv");
            entity.Property(e => e.SheriffUrl)
                .HasMaxLength(133)
                .HasColumnName("sheriff_url");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .HasColumnName("state");
            entity.Property(e => e.SubFee)
                .HasMaxLength(3)
                .HasColumnName("subFee");
            entity.Property(e => e.SubNeed)
                .HasMaxLength(3)
                .HasColumnName("sub_need");
            entity.Property(e => e.SubTerm)
                .HasMaxLength(6)
                .HasColumnName("sub_term");
            entity.Property(e => e.Tap)
                .HasMaxLength(2)
                .HasColumnName("tap");
            entity.Property(e => e.Tax2Pwd)
                .HasMaxLength(8)
                .HasColumnName("tax2_pwd");
            entity.Property(e => e.Tax2Url)
                .HasMaxLength(103)
                .HasColumnName("tax2_url");
            entity.Property(e => e.Tax2User)
                .HasMaxLength(9)
                .HasColumnName("tax2_user");
            entity.Property(e => e.Tax3Pwd)
                .HasMaxLength(6)
                .HasColumnName("tax3_pwd");
            entity.Property(e => e.Tax3User)
                .HasMaxLength(14)
                .HasColumnName("tax3_user");
            entity.Property(e => e.TaxPwd)
                .HasMaxLength(15)
                .HasColumnName("tax_pwd");
            entity.Property(e => e.TaxUrl)
                .HasMaxLength(151)
                .HasColumnName("tax_url");
            entity.Property(e => e.TaxUser)
                .HasMaxLength(22)
                .HasColumnName("tax_user");
            entity.Property(e => e.UccUrl)
                .HasMaxLength(137)
                .HasColumnName("ucc_url");
            entity.Property(e => e.WeSubscribe)
                .HasMaxLength(2)
                .HasColumnName("we_subscribe");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
