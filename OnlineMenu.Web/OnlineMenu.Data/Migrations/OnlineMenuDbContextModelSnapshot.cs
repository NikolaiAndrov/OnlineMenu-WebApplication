﻿#nullable disable

namespace OnlineMenu.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using OnlineMenu.Data;

    [DbContext(typeof(OnlineMenuDbContext))]
    partial class OnlineMenuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("DrinkCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Milliliters")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DrinkCategoryId");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e8f3044-79df-45cf-bbe6-b924ba3adf03"),
                            Description = "Mineral Water",
                            DrinkCategoryId = 1,
                            ImageUrl = "https://uc9c1f4c47eb8fb60f3ae5a89363.previews.dropboxusercontent.com/p/thumb/ACJaC6ufDJAVZAPfJtER-yibPK-mpyQy2HOeScBIMBTsRXhrHooD_fFSaHL3xtQfMYxQdDk9Wk1Daj6eM3wKQBQ11LUsRbBooJQjgVZ2QHgYDSkIATWfKq6ZA0RzMiGv5GMvroXZReocAKigYZKrqI2prh_kzeCG7anbf1T3Z_IyH0epje20vtdbJl4sYJpzWC_8BqpYgQhgQWiBTK_IXzrdr7jyl06S6RdRr8JJoJoSXxLOETsxbvrr7zXU82lHhborywvKnd1PCzQCIbGi-y4PjX4oSV2-6GTW-W4adcp8t7R-JtP4THQPimu875-DliVcmkW2yv54nh3EasKyCKSHS_gPiTTH1GjpDjZz94eL03CH56W7kEmdN0ZDPtxMrMU/p.jpeg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Devin",
                            Price = 1.80m
                        },
                        new
                        {
                            Id = new Guid("4af27246-f76a-4ba3-bdc2-cdc7856b6008"),
                            Description = "Sparkling Water",
                            DrinkCategoryId = 1,
                            ImageUrl = "https://ucdc984860049a54c41353072bdc.previews.dropboxusercontent.com/p/thumb/ACL0y00Ij7lpIC_EugbufazeItPOP81YxcdC8twB1oKekJsEBxrc3lcrtFkOBnFiGrsG5qsR8DWpq2iiqXGkzKV22lgrBkkGwkyUFhQV8n21Y30vrGQn8Jtn0r3rKp8fwyFzDZXxKyJGsOyayVle-lZA07k-_c1DJB2BlhR_kJM6OaotAcRk4wrEa26f_0PIvPc3W6g0KoL7_vJE5TqseFJ11t6uIUvsZx9pkR4-OeioxpgYC4uQWz77kPlykjrf3SkPmCt3hOv6AwK8b7zEfjFnXlBmvrfCm2Ps0HPbW5ozVU3ILiuekANms9x9eGpModd2KXi2Jrbdke1HkBiuRWZdsKP3mdeqD6HrrGe6nH0fSlKVrcPX4_qq3Y4EHLIOa-0/p.jpeg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Devin",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("fb306f13-d430-4227-99f0-e01c508a7378"),
                            Description = "Classic or sugar free",
                            DrinkCategoryId = 2,
                            ImageUrl = "https://uc54479bad12631b2e5cbb0b9614.previews.dropboxusercontent.com/p/thumb/ACIWhg5bH06rqzrpXy6qKqQfm4NlqEr43RVuoghvkz662jmmma97EsO6fxw5igG2w5EwNsEOnX6SKgTg5f3TYmbS2vycwN2K8_vkTBLkUDDxZpWeJUnbvomi4NYL-89x3bZEY0lpoKCfUHU0JQ4bJ3dHYSBguzQ6LrEPn7OzuxznT7A86Mo17KgPoYHdanksCckLUxXMulAQPPOPW9D0AlI7BgEfAVZIjf7mi3FWNzKNcySTn2pZUHX9nCb0aXEO3VSD2R6SdVza81IC3ZrxKRbuludGu_vLH-nCVIofvDRiKaFgxBL0Hgp3fVm97-nr9QWdrK2A6qPT1BAXtujR6DdpeegKVCnKAAaVWIMltzj6U2MtL7EUuqOXWA1xzyTqLVI/p.jpeg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Coca Cola",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("5ddf2c51-51c8-4c33-96f6-5ed3f4db9cb2"),
                            Description = "Flavour by choice",
                            DrinkCategoryId = 2,
                            ImageUrl = "https://uc0ab3fef5c438477b9b1e8221c4.previews.dropboxusercontent.com/p/thumb/ACKESxEDKConRHA-XNEi8UC0TAEap8vQcfVm8Pb0cIfDI6hHuBVCfS4rcQXlj5i_0_obxjI1Z06__1rLTpoZGwAfqoL_0Bqk90DQszDiPPSw0WmFDpMwQI-580YZosaBKwQhaTazhmcENHQUK4ToRWJhSzZ3lLC-iPhb-Q0RxREhAdIFTbJSCwN2sL3iIKuZYYdLHRmchFpcQkDkCKMZZ1rk7dBOh809CtT2Ni3Px577aaijX7lGb-WjEuInKAS8wGmLMwOPmnaQOA62WsAKPc8EKK_mKYU1meJfE3SMD6Bw8e89WO_m96otutVuCuI4IXSlzw23_b8HnP--p06yktR9L4FRXDLnLdyvbR9BBU-wjrNcZ5KsdcoZ6T2g1F6W6uc/p.jpeg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Fanta",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("a35be3bc-427a-4cc2-847d-cc14884b8aaa"),
                            Description = "Flavour by choice",
                            DrinkCategoryId = 2,
                            ImageUrl = "https://ucaf6ca18eb28b99ab1ef4c40427.previews.dropboxusercontent.com/p/thumb/ACJLMhqW39J598aUMLJCA4nhzC0Ja7Otf_MSkttpdbpygql_Ht4MrZoKAq5yTS_OhKoIYeJ0vb-iU09CaUcqz_5DGEEf31TRr_gGaxIynSmH7_AtJYtmg1sYf117qKzF3Kp_h-bDoxFXAk_xpOSri9H1pCvPQq_fPArRKdD_etCAUBlbSbQXP_wKu2nuip5noj2GgaK0pWbO41FX0X4mTIOk1SC7wwO3T6n3bC4Zzt8nUe3--mlpL6ybAXHnOk4O5hliSpyvI_GFsEpRurVgyLTqpol_8ztKSxb1Wob4gv2lyvK50hv4BeC4M5kuruet6h_uIAISPaxyMoODgWgcP1X6f77Q1iCWQzf0yXkRQabDCq8bEMF4uJiW_Q9d3X2lGlE/p.jpeg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Pop Soda",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("48a6df9c-7572-48fa-a268-ef22bd6403c4"),
                            Description = "Espresso, Americano or Decaf",
                            DrinkCategoryId = 3,
                            ImageUrl = "https://uc749cab6b4ab1e2c345196c3e6c.previews.dropboxusercontent.com/p/thumb/ACJO6QKVQQHfAAX6cqWqhQyr4T21NwKj-fFODH-ZvEAHqWC_giud6dHTSyajQEL5td6fG6yNq0tVTdDouQrALJ4v0qtmVp1OKhfHJyk82h-LHbTS5FbI1OOjIiK7Q1d4nu18dHeqZPni7R9NHHnCHCWyAM_4xADlTHxk-lsORZzV3L14dtXuROlc2SF7ZIjBAE1lpMMEtSx2yeM6fPZzCfSGs87v2YLZSQS-8ueKDXLEmr2GMbcZ0VGasw9qoONWAI3v88PgrrTpSieBHW4GnMBHnE5TDYVB0jpCgYe3LlFG3NFdV3gFktYYPLeVz6LiJ_Pux4SupkkmFkWnkN__b9rXyfhzxzyhXBjKpQ_vL6e1XGCfKdyvglQgAvbkI8ayzHs/p.jpeg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Coffee",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("210f6cba-73ce-4feb-8f72-1373af57daa3"),
                            Description = "Cocoa powder by choice",
                            DrinkCategoryId = 3,
                            ImageUrl = "https://ucb742251efe5b0088da4e93bdd7.previews.dropboxusercontent.com/p/thumb/ACLF7lfOGSCsu2886mGZRBqax86Jt5vDrAmU4aGScFZIjA8nE-TFZoeQ8GuVZbhU6eC60iZNj1U-t_FnigboYm4EsaB35W361DobQcEzVYnhjS2LgDoj74cpozJO50QJgKGyXJ1kSO23XzJsnom5buMcW0oIdWRLnIO8X12aDQFcjeWbMLNXdZ3XKeo22eHAk-sN0CeQ0AWsbNu-fgFgThqxYdxqylYUM7oB3pRvsKQlYEkC7pcVW_hJEa8_GmRUY5DMLDfxO0Eku8IYzwBM6TLBHuKBK42tNj7QaASi7YAMJlP5LoSaPUyIEiP-g9zPsVZPP81wfaUzFFfZqztUvQhvWSm1wG_0xvCzaKzqs6u32nxs3x4sBVG2eYFuiCdWXvQ/p.jpeg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 80,
                            Name = "Cappuccino",
                            Price = 2.60m
                        },
                        new
                        {
                            Id = new Guid("10c34570-f3c0-4d1a-ad16-b9e15816706c"),
                            Description = "Herbs or Fruit flavour",
                            DrinkCategoryId = 3,
                            ImageUrl = "https://uc8cdb139bc670e7b9f0dbe2a698.previews.dropboxusercontent.com/p/thumb/ACLszdDfvT5U7V67vd-P9dUupDgFjWg3XANrHa6wZgy25PGFJ05AFwzWO1ai45OIgiRCbITTtNOJxjHqO_BzW2T4rWSpwAhTu-xrddRp17anwecSyiRjTcEIsozfR5n1Y7_ExPy-L-Ln_smMBueWjwDuCx8ra2X4jiCWFijDoAAvespz_DIa6x4ruAzTB7s36ovDImK8_ckMy1msW9tSmTS0-ZlbClRP-3gPxqlCAJ4gUfioS5w1KWF5Z66JYbE_T1iNa8PiUljMvcIjgGqOes1g2Y3dwBE80t5ebin1BBfTH4WgcVRgbP7Obh35_bdahf9x0L4pn13exM-70A5YVPlZLtqD7v9-P0e08msrjZLNe8wHoDdb9xG2ui55UAf74YE/p.png",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 80,
                            Name = "Tea",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("8301d3d7-374b-4b1a-9fb4-39a4dca3615b"),
                            Description = "Draught beer",
                            DrinkCategoryId = 4,
                            ImageUrl = "https://ucd905382607284558aff947bacb.previews.dropboxusercontent.com/p/thumb/ACLqgorO33Z0hf4EVIfw4BwGtfOcCuHiiuymbv4gElxsWLraL2UzlOpUVwleL96l7D0CWKjHU7QARYfUsHKGzg8MQzpca8g0mqHwVE96h25_kpQDoobmr1wDHMplVffAWSqLHh_K8J5CJcEmiXQnZrd4TxskjW7Ndl1fatRheOjBfDTuqst0fsLrI7cSwIwfQIT1koIxAebMMxpc8pvkvVAv1rL3_lCwLBMPYuXxM5E6m-4LN1A7o33UeHZXWffmHFLe9wqIS_7SuY-PUzHdRSAthqBRHH6oQtB_xpObkWzQRRMnoESp5bze5zhUPXEfCfflq_rGh85z-4JoEzHw4YR9JCtBuXp11ZUobySOGZ5ONfQLVYwIItLrmel0mi2p948/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Carlsberg",
                            Price = 3.00m
                        },
                        new
                        {
                            Id = new Guid("211e2eae-4acb-436b-b7ae-eee2b71dc453"),
                            Description = "Draught beer",
                            DrinkCategoryId = 4,
                            ImageUrl = "https://uc680f65cb2b7db5ea42b8036dcf.previews.dropboxusercontent.com/p/thumb/ACIDO-i_aDPCw3SWUFI4wItRFjYSogvGsrZPPUt7R19j0CkgRiWPtUj94bhzLUSemp7jDulVRYfx4r2LaJ5oJugM1D-3hFOWZE09Exd7I8a1Rc2G5vdkosyNhDOFWHv3UrJ2cQW_my8pUDfJbK329-9YsWfdOHWKgQop4ZFNMMIQiPai9tPwtqKTSVScqA7I1n8LRPPe1FNk9tP_j5P4khNzA6YxSAAwPvXHCBnQ7tqwV-fjDlLKQV75KimHwRv0TGBKRox304V8LaqV1j16680L0G4h8AjKSPEELCdYjvKcQ5MAIzYy2JH3e8L9efwdV4V1rJcWzPuVCk1MQ2pWeSVPFvjrTKWOJVklXUALmJzA2ljeeasXSEnsH7GGszXn2eQ/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 500,
                            Name = "Carlsberg",
                            Price = 4.50m
                        },
                        new
                        {
                            Id = new Guid("21aa59e5-2005-4617-a1e1-1acccf0798d0"),
                            Description = "12 years aged whisky",
                            DrinkCategoryId = 5,
                            ImageUrl = "https://uc8e1c87861fe68473f6f80ab22a.previews.dropboxusercontent.com/p/thumb/ACLh4Tc41GH3qBjM1EQAOvAviFfmFrRg6foYwsBnGAxmaCxRpIMXQUJx0mCBZyqPUCx-amTkcUFVbSQwwpEH-XUlPUW7Qv3qGT4uf5pMQcy0Pi0g6Nd8QgeG0Gaby8YSaG5TsDeY9v0YNKBzPdyjnDGHJB_rEZurgTghqmTlVXoBffNWvEj-6MogJmfjB_cgyhUndW3pq8hAIAR-zBfG0a7-E2dHtDqFY_QADHqG23zXmNEV6-PaRe3D_kMqO-5TeeV5lKOJNmedBxGc_zMcIByfGkcUmridPoBKAuP9lLCusa4zVzBll6qWFIWjkksVdKILMe05QFowqmBd1kx7lKRaqQd0Rx0uCE375gQqKTVfdGZiZVEQp34PaRcXg6Eh3vs/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Singleton",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = new Guid("c19a37dc-bd13-4b10-8fa3-e8e0d5941be8"),
                            Description = "15 years aged whisky",
                            DrinkCategoryId = 5,
                            ImageUrl = "https://uc6c575c198f45063a12931e19ea.previews.dropboxusercontent.com/p/thumb/ACJZzjVLBB00gouMFHlMc0IrR8NGvmN82u8qB1Tp9-upY0NEuVjpv_HCm5MXMCjKNnBs8TxwTN68qzDcuJyruOMshmMlCwMCtrJW_cg3ianPK_tThQsS0sVg5w-I6XvZyhtgiYpBpzQlL6hPRxVyI7gvv72lzWtewn05MFBL13QyQ-lV3YGWsHY6Iy5L7eUM4h8bl85WH1KgGSjdUDXSqUlrGaD0bUG5pIprGxbAMM0AT_pbhMOHARYoRBSWV67PEkugUJPI5xt8c9flgzwvcy52E_SFw3GYZl92Pz3x9fQxLarIbvCqczuz4MTaNb_2AogNCmt_UZHNxVmocYhT0O9LMGHVru2cQdD0_Ooh1QvGqHBgqXWDyU7gNIr0CAfQz6g/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Glenfiddich",
                            Price = 18.00m
                        },
                        new
                        {
                            Id = new Guid("54441a9d-a578-4d2f-8785-c0498af4c416"),
                            Description = "Scotch whisky",
                            DrinkCategoryId = 5,
                            ImageUrl = "https://uc776957d67d12eec3bb71543841.previews.dropboxusercontent.com/p/thumb/ACJylw6SYGdfahi0XdJsikmdNdlCgX5tM4F_tirs2w3jqERtLg3rdvxhzBpZQ2sesjxV7j346ipUjQ1IntJj8o_BkE1HZqfzWqelGFtMauoVxeXn6qYuzdoIr2jHiW_ZvcBxVtbdKwLXQL45SPedErZRJyaxqBDWOIXIwo-OYk2BRYh-wtEoKdFmoRRvqwdbqpoVseK8QIzRCjKzXa4tS9iu0Bj1ZskiYJpiGtdexzs0C0vHNSWTWJMZM35MjSKfFkQO2Qf_qNPHuJA0uHaVQ5KITH9RnaZn62IjjpXGIjIObP-RiPQoOSuZAFBdTdxECZizSSIZ9Oju_reOPRPjXMpqE6BCf4l2IKPj1GjXF0Rc_ZN0tBWoEh0Gd8OdWYhylPI/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "The Sassenach",
                            Price = 14.00m
                        },
                        new
                        {
                            Id = new Guid("55489743-d83c-4903-862d-4d567e4daaf6"),
                            Description = "Vodka with premium quality and smooth taste",
                            DrinkCategoryId = 6,
                            ImageUrl = "https://uc572e1c3d51ab7a39e8aa27b3b8.previews.dropboxusercontent.com/p/thumb/ACKq4lG-S8XyoO_6yOtUkSE0e-KKT5oU7ukhwO9kO4zaM4zFSX989aht80pGIcfpT6XcpjAj2iiiE4CTgtchfKsZyXyLKGRAdxB-Zi3MzCA_-M5VH4j5WDgeOjO9rbs3TyNNxbppVCBlYQYGBwuK1RF1zEhe0Si-V_L2cf6StNCln1OAPjd5asCDq8YMYINSsJn0afMA_P14aOXV8WECbspQeEhxquFm3CNev4-LtozJ3f4J6-njG8WxUAV3cBCLaNKjFkTirqdy_DQSxK_TemzCJljaJaIeQgawhZC34zm3xPTHvHv03xSlsWc9nU93cRyvG-ZTGAtVgvDjfafrDHR5kmgwW030bBZArE2Sf3MjT5VzVPMh7VWulsB3GgDYEwk/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Beluga",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = new Guid("6dc7a625-babd-4478-bf4f-6579ed34527c"),
                            Description = "Smoothness, subtle sweetness, and clean finish",
                            DrinkCategoryId = 6,
                            ImageUrl = "https://uc41f2bdb66479ee97f8ed425182.previews.dropboxusercontent.com/p/thumb/ACLtF0Tp51rD3BRGbmKnFPbMbRms1EmpLvVga4MWkLhJzZzjLR1_3oI60ORzjIRWx96xiQ-X9Y1n1nvPkgstUe5DSK2JCgh6kCrbOyN9ULOpedSBJg3o3jEWmppEUJI0TGu3e8dGcdu5gYdpy_vwd0YCp7x9ROSxh8Vf93D5qZvjy3ZgzGGZGngLkIcIls19Y502ULO2XErRlQlgvvSHq-bEyLQg_f56nTW17DjZQQbTNhn6eXlgmvoHRGwwQxjjC7DPgAUEN8lGH405h4JbQK3DSWXsGUno5REvliWo9LOwnccnZUMRYhJ57hAKg4EvWCfRn5zGOfnsa6jkNCf4-hzrE3_pjnesOOiHCzEZvalUqYErkkoaNhw5L1NYriqMpmg/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Belvedere",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = new Guid("a5bcb938-dc3a-4df6-824a-d7c2dd47275c"),
                            Description = "Smooth taste with subtle sweetness and a hint of almond",
                            DrinkCategoryId = 6,
                            ImageUrl = "https://uc21d4abd34231348924c82bc913.previews.dropboxusercontent.com/p/thumb/ACJf6rWEWN2smnu8aZey7THuCZ4QJ6Ml350oPh6SfpFlmjHw2nBk3Mq7Q7SeusPr5_kigLSAa11tNbvKO8OedAHz5vN3hd-Q3SgUudZEzPQBRRwJl_Ur5lRzBa-M0IiygLaffGQ7PolKEbcR0hrScmtF8py2Gd6H8uACXH7aqbRpAThFbP02lv4qegxWf3HqlEGU2I2lTZzMvzDBO5_YF9Qr0a6U_9hLLBDh3-LAirSe7IsYvF1SOAL9bwuC7LM8h-w37z12g6YSDn1xmO30ANN16PNvg4Pr7Cc1BqgybhliwNAPCl9yPSirnjmV5q3DbghGDFBenA9Nq1DfMK8Vm0-3uO14qLtbV_amogrJXeuYnKXkHB3Fts5FGkERCtLUB88/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Grey Goose",
                            Price = 18.00m
                        },
                        new
                        {
                            Id = new Guid("6d2d7228-abfc-49b0-83b7-d86efe9789be"),
                            Description = "London Dry Gin",
                            DrinkCategoryId = 7,
                            ImageUrl = "https://uc2ce24417d1794649b002ae263c.previews.dropboxusercontent.com/p/thumb/ACI-Il_Bs1w9CyA0vA2lP-9hqdJ9QPd9mQjwRpZq0_QWwUizUCFFzO5wqXB2UsxvfmfRXtRM47BlrCLN7yAYrLULq_CIN4SJ2qEXaZEVVCC0wzqrtAhwHmpOzBiXMWG0zKr-X7pMCMAJ7QQj3uLXXxN8VxSkJZQ8QoG1Y3z5A9tJ9AVPLggvDQshhvdsuEDtNfhtbgfaWo6zTffOXOtP4jHh8iHVE8YIit-mwzaYPYYgj86sJleJbwvpI_aGK1xvbEfRfjvrLxf-Zm75Kv-lPPa-FbM-hYjmf3d_ec-ZBzOuZWlzmzmbwurRmx0e88of8-Yc7-UA6Q_bl1gKNYv7XGDdk9JKxz8jCde6YWNZ94iUy_1LqJmHWXDyZCRTTX_X0qo/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Bombay Sapphire",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = new Guid("60cef764-4422-4bf2-a7af-718f144052b6"),
                            Description = "London Dry Gin",
                            DrinkCategoryId = 7,
                            ImageUrl = "https://uc7818dd26bb796b83b85db0e667.previews.dropboxusercontent.com/p/thumb/ACIFZt3FY8A5cJ56LcBS1QoNortYgL2707x0xYM3SOyw3q9ACAwJo8ek-2P4ldkb-5gNtPALkIZXcoqYbnMXtFJhUAK60qwQilank651aqxDn0yVna4_zcm4VeGRqmlcp-TEjYi7CvciObTy0EsYj7sKHQzElW_Ytc2y6iTSHckR-3mC6c1Uu8A1UhPbsz2BJZsXQrXLCc-aF_QX6rI_ZWwFMx8vBvTHm1n1iMzKptaPqtsFHmOimRCO_vJDvI9f9ai7xBVyDS0zWT-diYHPbXb14QAHHg2oJeDGgFcEiRwTFMso8aVT8moGRLHPpFubFpxD-USWsJmWergRBHi9hJDr8Imuj9X1nQs0Pm6Hp8aWcj8D5yqqzylv449k9c4580w/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Brokers",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = new Guid("7975c442-2ab7-4df6-922d-73ad6514621c"),
                            Description = "Red, White, or Rose",
                            DrinkCategoryId = 8,
                            ImageUrl = "https://uc0ba9d481b29cf257f254cdf22f.previews.dropboxusercontent.com/p/thumb/ACI-VtoOYwWYPMBJLTJK4reZmGtaivkyUqWkoIN20yIcV3jrbY1DT7gyHObd5cfdQuRTKqqXbzKase9TeIIn567QXTCQDYk6xP2ww2oXmpvslapDAeq28hRqc36WPsDZpPL-pAIN6urjYxOw74w6MqqYVUKdiFDYxr5JmxeX7iXxm4UmyvKjSfBBAywjZ_34_anrK1TzpVSYQIH2b1qZrNwqcw4cbMMBVhD-WL3zb5RrI6IqwlDvEF8GbgeHkMWxf_DVYQYvlIAYo_PruTBXJ_p87c0NrLn9GoIwqTdS5mJfICFEbs3AhLZhuWU4SH2rX7KwDTYyvkp6KsJwnR3KECjk93JcIdKB5V4J9ylE4P5jw7Tlt1dha8Zm180v_aw_rFQ/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 350,
                            Name = "Minkov Brothers Wine",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = new Guid("6cbe6697-c65c-4d06-8e0e-7a3c33fda9e4"),
                            Description = "Consists of equal parts of three main ingredients: gin, campari, and sweet vermouth",
                            DrinkCategoryId = 9,
                            ImageUrl = "https://uccb24e13742879d8339c67b6ca5.previews.dropboxusercontent.com/p/thumb/ACLCf7hUGr-KVucGQhKOodcsAZrZxJC-THm66oniQvw5DLZ6HTsZFRjIJ9akO76LTRqW6gNE3VMHcB29pQ8-ALdBfCupVVmmKyyE1LetpWwJaUy99ZMM7pC0_grMKMds0ZgVExF4OGW4QRuAwZQcKudI_45gnjPj1XtXBAsMqh0cA9GlHCzDqCAqznJPT8FIdwv3VPzAXRDqwRk-dzhQzx532NHQSPoxTyXvnFrr6AG400qinLXTsZLxCcgqZECCbLC_VWxpjzH7KPtEK-RV79WjUyyzsW-lIumYRLrXl4KPatbQGQ1GaJMPDUvbw5C60tlS-KkPXczLRJQ16EqLE59zYiukClCFRS2cbmEYnSAPUMmu3eXMO8CW6JOfJttDgUo/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 200,
                            Name = "Negroni",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = new Guid("36aff0cf-5a44-4fee-92da-838f173ddffe"),
                            Description = "Consists of aperol, prosecco, club soda, ice cubes, orange slice",
                            DrinkCategoryId = 9,
                            ImageUrl = "https://ucd101b79affd79bd3487a0b9195.previews.dropboxusercontent.com/p/thumb/ACIGGWwPIyXYO3vZuASYsOZXxRrtzRlQUaimIDnxVFLBd51UKJtG8KFZzzR7l7EgNK5EkHD8Y5sRlMNvl_R3WciJHAH7PEhju8ddQyO1445KaxsDIc-rS3C-5N0bJCp5yqM24In53_IeNMYKli8rSbBIjvtL7SBpWi4dsYw810dzu_ldVk0t2Q1M2Ex83UqPZDZIiKw0iWajiPuiPsTFCBorBUTE9-D8HJh1Ma8miKyfqxgSYStOdffUyB8hByzf-1apuKuAEsRGxzWRu1kV_SFJJ4KTZ1iwXPKggBeJBsQwXQL9OpNU8pZSsSUz5axz9a7dstDJhfiyEAkY7NePqZfXLvgMRpcDYaR--bt47WwjzgX_zwmGbrNBCRhLkexT98o/p.jpeg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 250,
                            Name = "Aperol Spritz",
                            Price = 8.00m
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.DrinkCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DrinksCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Water"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Soft Drinks"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Hot Drinks"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Beer"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Whisky"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Vodka"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Gin"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "Wine"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "Cocktails"
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("Food");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e8efcb5-db8e-4b9c-b51e-af8b43f1cb89"),
                            Description = "Romaine lettuce, croutons, parmesan cheese and a dressing consisting of olive oil, lemon juice, garlic, worcestershire sauce",
                            FoodCategoryId = 1,
                            ImageUrl = "https://uc775e92110dd8f77e45e799abeb.previews.dropboxusercontent.com/p/thumb/ACKXilzU-1r9SaT8i9nD0gK2TL9sKPr5bbpT6G1DeWHL2oHTd0e2zSm_YXQ4kA5hZnowfloBIcBz1cF6-pgGkiw-Z-45itMn5qLEaBf8y8g-ZjTPWFMPj3BgGzqktIGJ9QCOc9FXCTP36f8Dk1-zFP4ksgcRroj6oKczM7rQKqXO9J_uHHd5Ob_F5X5QZkX2I1a2eIm5YiocCFNNHIxTatGTR7j_k-Paw3tX_t1AZrYyozZr0C29ig_bfp_3kxOXoF40La-e7pyjEuvh6c0lmTGjsMmkDWv6fWc2I8Ym9heOyFMWUPiJoeHskAzSrMpjcdWpi205finZFWsmf2amzzvyQ92-gqk64QQJnCc1EkrucCuxr5EsWXLwtgF6vC-kuKs/p.jpeg",
                            IsDeleted = false,
                            Name = "Caesar Salad",
                            Price = 12.00m,
                            Weight = 400
                        },
                        new
                        {
                            Id = new Guid("547e89fc-8ac2-44ca-8d2b-1a672e3af93f"),
                            Description = "Tomatoes, mozzarella cheese, basil leaves, olive oil, pesto",
                            FoodCategoryId = 1,
                            ImageUrl = "https://uc98fca7cb525b23cc48839a8a65.previews.dropboxusercontent.com/p/thumb/ACL7PWJrq-_W_lFGYIN9XFwk9iG_I3SuZhMHV4yY8oABkHOiYdfckgz4SjDSB4kpQwBsA2w5Xzn6jqmdRudkpDeTLmURwejUStdqmcaBJx1RiNnhNEwVvxBWfsoCgHbCHClR8Yt5_F7jRTSrLmUP94NOauw-kBfeosu171BdKclx7aGB96MG98PgQ4cjcq3bdztJZ5D22HtQqludeChjPr1HhxjjMGoTLHY4e1NLsn88QxzrRIgmyD7Xpq205Crr44xemQ0XO8rARXkkeDAzkyVuXzDWzPlkWA80cy19dJbhnQoNywqJrMJty7_vEdu31BykfaoXAxfFVCOSKnKPOrPoO5am3srS-LV8lBQkiTmDWaDI_ohdY8-9SmH9c2-HqT0/p.jpeg",
                            IsDeleted = false,
                            Name = "Caprese Salad",
                            Price = 12.00m,
                            Weight = 450
                        },
                        new
                        {
                            Id = new Guid("c33fc162-db37-4cfe-8dc0-b8fc120fa9f5"),
                            Description = "With ketchup",
                            FoodCategoryId = 2,
                            ImageUrl = "https://uc66a2d97ebdf1b94051364a551e.previews.dropboxusercontent.com/p/thumb/ACK82mjZrDfVqtroHDwR27Ra5FgA1M9BUJFQpjXpYd8f5lCvTXuh843WyYyGzdVtRnw2Y6uDQgPlIqLzl6JC-LTH_DQ3qw2Qu00qjLfgPigmjQjpQueHhKajmSazf47a5NUz6PPQT-bzZsHyTls8NK5Gdoy4VBjVsKdxkuYRxLLFNThx8zYdKa3Pwz56qFPKoT6WK7XYUK-JiBhS81v4ParbQH92AWb0GWVwpSdZwkiEKOLjh0rsVWet0upBEKAGBKrkStUUey3gqaGECM2RGtui5RwA1ZHKkBqoRfkN5FpYrP72SeE_s1hA0I-Ghh9h_emy8xQJSKg0bj2wbIbLnqfgsBtDOLTTdES-tDH89GldvGp57tLHlz43FBAfZGMNbNY/p.jpeg",
                            IsDeleted = false,
                            Name = "French Fries",
                            Price = 6.50m,
                            Weight = 300
                        },
                        new
                        {
                            Id = new Guid("716f45b7-2c90-4141-a26f-50f88e91693b"),
                            Description = "With ketchup and yogurt sauce",
                            FoodCategoryId = 2,
                            ImageUrl = "https://uc761faec458f4568610483bedce.previews.dropboxusercontent.com/p/thumb/ACKinDviyI969HSGq_dWa2UnjCWJfk6sAkBtS6rRqOvdC8QhLVGAv4lipx4tX7UWod-DqzwmxyF61HoOYGIFMWVS8Vu9xGxFV9i3Ubo6cQaRjvZab8YkwIi2bTm77I8mDKAxuCpJzFZ0GFZjJBAmL5n58zI-9zJPHi6177axo5jmklfRbcSleOp7cSiBpTl_RgGIK16J1F7zY0-zXNyITrUPWvnDkENsExp9AJ53321zOShvmBfbW2PxKoN7pM78FRsI1puSqfbaPKHGrr3pdWfF2-ACr6DXxxPaEa6bQSTy2EiGy-uXAnD177HZNf-M5M7YlxUYyGeCrU4k2GZDUMY9t81S7bpBOcedZ49AUVPE7GLU0fNtqIbz28pnp0YNhQM/p.jpeg",
                            IsDeleted = false,
                            Name = "Chicken Nuggets",
                            Price = 8.00m,
                            Weight = 350
                        },
                        new
                        {
                            Id = new Guid("b729846a-32b9-45e6-b6e7-f726c7440355"),
                            Description = "With corn flakes and ketchup",
                            FoodCategoryId = 2,
                            ImageUrl = "https://uc81a59cd34e583620e972a365b6.previews.dropboxusercontent.com/p/thumb/ACLfyIxGUOhGj1ftp5Me4gs_zwe-fpSvyH7HA0exWojFM6pby79sadL3Ge2vbqVKtktga2qaPwznDNvqThIHkya_B1GAmgxnIR3gj2pC_ZMQM5bWV13My7Ytb309r3pPK2gth7hsZ_AMyfMMWRwR6CZAvNPm9SwQwCj-RP8XVEFVSr8lZuwgGUvs0mHJjKJ4-P-PfQVRyPPJq-58hm92gxxt9929seUAVW7r1TypuRaHWC2CXNze_0UWpeN8Bq-oE4_n_5_nUYvE-5PlAMUvVxfKIDZwEZ9asCsU5QpskNUxbuWccAU1uQIDvaCGQwv8HDTsyW7bJIgsMzfWRHmfl2Evyj9n_Y92sq-hO0p0Dl-XOi3hFhO0J9oMzMIBWmoq_Pk/p.jpeg",
                            IsDeleted = false,
                            Name = "Crusted Chicken Strips",
                            Price = 10.00m,
                            Weight = 350
                        },
                        new
                        {
                            Id = new Guid("2437d03c-bc28-4448-bc32-1be08a43f985"),
                            Description = "Grilled chicken breasts topped with mozzarella cheese, tomato slices, fresh basil leaves, pesto",
                            FoodCategoryId = 3,
                            ImageUrl = "https://uce26c50df0e8a99fa5d29bd7d83.previews.dropboxusercontent.com/p/thumb/ACKD5hL3A_ybKXH_a5PjUEbKyE_kAihuQQeUjRKvfKMVy_MFzs8pQ176Kgp8eGXZL5TQM3LyL3t60DuUWSAByCjV2Rr3BU6qV1o6CiNkLkxZ7kr2dUG7u5YJic2kaZZ8BBwUkfJXBQQGDni_en2kzEP7pzUCuDz7NAhZGMxsWBkuVh9M-dxGSc0OHVy68wJHL7CKsnKecq-0f-5xmmhJm0S2zwCCO9ZaXs_gRqCcR0G973OQ-bhZ7DMMyoLFI5YECwidPyI8ozIbU3-FVoUijZFphABhJxfj9BwaGRDyJ4pTlbIrB8l-Mz4ya1K51JHdVHYf2r6i2Swyyrdrdu56uvMZvPSOFfUJ0odLaOHnaD4hAIPChIdLfKafoCfrilImnoM/p.jpeg",
                            IsDeleted = false,
                            Name = "Chicken Caprese",
                            Price = 11.50m,
                            Weight = 400
                        },
                        new
                        {
                            Id = new Guid("aacdfc09-c378-44c3-9b16-b2ebb36086bd"),
                            Description = "Traditional Austrian dish made with a thinly pounded and breaded veal cutlet, french fries, yogurt sauce",
                            FoodCategoryId = 3,
                            ImageUrl = "https://uc1693f94ae231c00d3173f97282.previews.dropboxusercontent.com/p/thumb/ACJQdrIO44OpTUgkgEBQTQsLDv8B1QvoICteGV0-ab6d5-xQbr4BMMI9fPnRIkrascHMdmWTmBeVazhC8_ZUz8j_v6krW9nfN5EG6wcG-VaVs3SvHd9hua-477ifkZ6uHfSOWZPFlbb6invwacCEWUgZ1XVZzBo5Z-Vmw77qbCa-i9RuHFXZus9WyfNyBjMPuwLEiTo77R7rWWAGKcCP4dVZBFrEEnI1M_ykAamBwx707Phx1A4KSm1m492YNZp06fqMIRauev7wW1s2pFQk4xQQT3jABRpOnEWMtGQjXrWWh7QI1EoMRgqrFqUsdl-0lHENN0x4SeerTjRcEneCn30_6gf1zwku65q3rfFebfXqz6AT_xHLz3ZEhhF2uVINWBM/p.png",
                            IsDeleted = false,
                            Name = "Viennese Schnitzel",
                            Price = 15.00m,
                            Weight = 500
                        },
                        new
                        {
                            Id = new Guid("761fabde-fb3d-4d22-aed7-f97570ba0848"),
                            Description = "Side dish - fresh mushrooms, mushrooms sauce, french fries, carrot and broccoli",
                            FoodCategoryId = 3,
                            ImageUrl = "https://uc095ab4106b5ecdbc05b493f43a.previews.dropboxusercontent.com/p/thumb/ACJ7UfdyAXEEwgVubrmuPvJDDGBXW4R0a9aJE2YaHYXzIYi1h_pt8M5yN9l1lEXvYm-yEf47JFPiEePlUXX5lI-RIPATFQmOr_T9UPNmCUkVeCW1quzi9QifUdJoEWlNBPjOlUtUaeB2SGgDV-yDGQCU0hVigR8WinXbwZN9L8-ldD0_BgtGrv9BAsLoMF0DwSxi2EzFHfGGSycCTigN9GUIn7N75ycO6J1tE_dZdVpkQP2U08R0Zt5_hCdJDYKjrDWoQIc3UDqbG7KNhpgnSCJGLnPyV4i-JJoT2XSaqL3vZVFRUbCrL1uO5wntvNFVpDjhAwp4d8dgPkeFO-mlppHlGDEpZZeVZEipoa5NLKaoOf87P8rznnVEcwE6g3g1W3E/p.jpeg",
                            IsDeleted = false,
                            Name = "Beef Steak",
                            Price = 29.99m,
                            Weight = 650
                        },
                        new
                        {
                            Id = new Guid("21b8a7a9-9b88-43a0-ada2-248a6795eb31"),
                            Description = "Fresh buffalo mozzarella cheese, tomato sauce, basil leaves",
                            FoodCategoryId = 4,
                            ImageUrl = "https://uc920bd6fa91ae5b5cbfd65d5ff0.previews.dropboxusercontent.com/p/thumb/ACJW9W1fiUuTU42zrmY53XnCI_GJ9ngyRr_IE05GEdCtOsgJPBmfdZPMJf7uQs9laxHj76vbeNdETPAnAcnJF1OIcuy3FrNxrhZvGRmtzh9xEekKHweXj0jUC83btqdAXayK6SYSueO2XEWF74BYZRIC603FcHzvgiaSUrtyi-b07sVRBdsHYuo1V4OFBVIZCrnNSA44bkG5IEqzVN8-3nPlkLSyVbu2bS-spIiZwg0t75ctE-p_7mbg-R1XTtYISedFEIAC08k3bUy2SD-tLYTjXSRKhrDlTOQqMlf9Wwztar7TOMqf0BHsB8rJabvED_JL2JnGUWrBEDSCGWkZnKMEY8LNH2JiW3a-jDHeiVX-KQEo1nsyo4UgR2Pr7bpJdxs/p.jpeg",
                            IsDeleted = false,
                            Name = "Pizza Bufala",
                            Price = 14.99m,
                            Weight = 550
                        },
                        new
                        {
                            Id = new Guid("011682b2-74d2-4273-a798-8ab46006efd2"),
                            Description = "Mozzarella cheese, tomato sauce, spicy cured Italian sausage",
                            FoodCategoryId = 4,
                            ImageUrl = "https://uc3ae55f1d1d3c4cd134aec3f942.previews.dropboxusercontent.com/p/thumb/ACIeGX9Bdm5MdUVFM8R2Qlm7duuc-_nftLJpST9Z_WW5bLmmwo9fzrpE3uKXj7SfQw-UCRcoyH2B8WUEEuuuChZm5-iCjQ5j11IjWmhSjNKRKb_jS8FccuYzHYpAYv1HDRkeko0zRgi_Fc9JVetRu6LVyv8VmJVKBDOpIfTwe3m48bIsHQ3VaRsESin1NVeYKYsq3Ox5RF9IaxEmI9J0ub8mE2O5-PT7a-P0yvarfoiznNpfqZOn-vwpBgZU8MdlejTYtO-fIBwpHvk3CpN4OjJpvrlxZER906rJ_-1K5_XAs8La5rS7c6L9K5iWdI5iAG8lhgZg5QxWN83p2jG6OT2qmYtNmWDixfFEPadSXkV0SmSKYPDVxDwJ94FTuaxDFhQ/p.jpeg",
                            IsDeleted = false,
                            Name = "Pizza Pepperoni",
                            Price = 14.99m,
                            Weight = 550
                        },
                        new
                        {
                            Id = new Guid("14419c44-db4e-466d-a86d-24927f10dc9b"),
                            Description = "Spaghetti noodles topped with a meat-based sauce ragù alla bolognese",
                            FoodCategoryId = 5,
                            ImageUrl = "https://ucda61a488517f5eafa06aa480eb.previews.dropboxusercontent.com/p/thumb/ACKT6-Ti1Z3jF6qbVx45PyE_maOhhGfSjLZSm7G0vY-B5ocWXbbxbGo1mJYdG8BoSQibbHRXE6xp2EPvZbZ633W9pOkhCAiPJgVA7w83W0XfWZnpN4qwXbUCMc8j7N54CZ6k2ZbJLkzWnbNTMoMLue62FSRlk45Q84MYteCtiaS_rs_ys9CuRiDr0P8T0YfeWSMgksvcUJfZEkQ46extfPuuQVFt8RcgYpNWHxmWQQ00k7PFXXb8NxsiVPZAHeN9zYZdxcqEkzD8FDLfK8OAO5LXJz2Xeqkerbyd_XCwZ8SzChNzN1nEl-LP8SPMwmgrx3ps8Heyg-N1OPbSmfL2zY5gnqkvpK-sMWkaLMf_I2SDD3k52PlGJlMzPMdGoBC-Vws/p.jpeg",
                            IsDeleted = false,
                            Name = "Spaghetti Bolognese",
                            Price = 12.00m,
                            Weight = 440
                        },
                        new
                        {
                            Id = new Guid("12951791-71bd-43b7-b3cf-f2ee89007550"),
                            Description = "Spaghetti pasta, eggs, pecorino romano cheese, guanciale (cured pork cheek), black pepper",
                            FoodCategoryId = 5,
                            ImageUrl = "https://uc4ca54fb7ca40986e8b8f88c451.previews.dropboxusercontent.com/p/thumb/ACKgeCFtl152AJ2k9XtJQGtRAHEqRIfM7jo0KanbiupMn0uczxYwhj2lVFgQywNMx2M_-_fF5CYIGoerNj_4Ku0VtuEOA1IFDsDR-yWljzrvGRl_Gbq1g54LysAU7AQo6jo8DLEXkF-l_Y5YEoR6ckKjKdthDdAXs5Skc3gFz43GK6wKtrxh1oRydZmVxNpSlZkizHtdXLlu_mtyE5wiwq1fw38aI40-T-SNiPv16DAzzZ3CNwGeYQr4ydkTnmZE1CBWJPnFpvLHp4BFYi5ZqEPAL65Yjuk1aNGNfHVSDVC13y5Yjxrxwm0iCKoTxyEKFwlMPMuYCt7LU91_JxS5KNV9Z_pddhluzPDVYW9djlcge7Ildagt989vdQ5KIVfIKpM/p.jpeg",
                            IsDeleted = false,
                            Name = "Spaghetti Carbonara",
                            Price = 11.00m,
                            Weight = 440
                        },
                        new
                        {
                            Id = new Guid("0d945b3a-347a-41e9-a1c7-9467e9893c77"),
                            Description = "Beef burger with french fries, fresh salad, cheddar",
                            FoodCategoryId = 6,
                            ImageUrl = "https://uc17220967bf29f23b6c13b38b5d.previews.dropboxusercontent.com/p/thumb/ACL5M1i2-xQIBUoh8OjDfV61k3frcehTBdsNnCd7PdfI5j7G0hLZk7ikBn5QWSd6ffCZ6S5P-Uf_N_Ly--KoGcF9KMX9Xzza2FRmtZcWGoSszCjpxuy-vkAj-szuuM21juCdxWGO8ySs_VYeKL8ehnr0EtQPwtg94fSSv7gIt9RmSnb6__rw0E_No2807gohxY4fDMlSSNw0Ws46eNnGRzhbGFLI8RUEoljDYJuMBEY3OGe5PiobUz-ZJRPvcqsJ5pKtMjMg0KXHrbU5m6KXmyviWu7v3_6RLV50BiF4O4d9gYUtGiSRw3ivFvqLRIA6OarRh5VARN_VexvQL2l4QfxhmRgmUfUnX-OOhzrkDrfLmRqxgcPP-sA0K3Npmf7g-uw/p.jpeg",
                            IsDeleted = false,
                            Name = "Beef Burger",
                            Price = 18.00m,
                            Weight = 480
                        },
                        new
                        {
                            Id = new Guid("1b13851e-d03b-4ed3-95aa-027f7a94f657"),
                            Description = "Pork burger with fresh salad and cheddar",
                            FoodCategoryId = 6,
                            ImageUrl = "https://uc00118cfd0f097611e1a69be5b8.previews.dropboxusercontent.com/p/thumb/ACIol-2h3GRxD4q7LduTyOiUVKUdr0ojliXmlnDHy8LMnfrWjW9lzx8JK6RBkYc9rLnIiiwvKIAYA9evVo6hNSEdVoxtrP2bCQYCZvZhMGm3pS1Ujfl5TFvsMbIpSaCGz4wUOutqPzBgaMUesukkE2hxofeI34xe21v5K0PD5LuH9BuoriPbyeo18uyk9oY8v6anJ5J87tPm6dRkZwEMYbeNR5k5suN06LZZaVhHogOCkaADzcGSyWheuzqZCcyGSwAger5z9jWgCjQwmsL8ZfGmeh2UDaPuBLi9AJg_7HzqB-FrFsyOnbfKp5baoI7pwJpWcyo3zgQ6vQcZDgsVrsqzUNg3X1pdTEP9rnk0krKYqfeern8stsG-4uykUyf7crs/p.jpeg",
                            IsDeleted = false,
                            Name = "Pork Burger",
                            Price = 14.00m,
                            Weight = 430
                        },
                        new
                        {
                            Id = new Guid("24232452-6ed8-4e4a-9d09-3089181e37d5"),
                            Description = "Chocolate souffle with vanilla ice cream",
                            FoodCategoryId = 7,
                            ImageUrl = "https://uc31c341bac4c8dff3b1f6e7579c.previews.dropboxusercontent.com/p/thumb/ACJe_LLzgMDglq82shvZPrtv7ZWG6fSqYWhvFvmMLUhnmGGSTpOXcEPgURMerFzseILhJyfLZ_WCUkOZx4STKJFnnMlLyPbWW4hhyHNvuHDIiZ5Dzlfd9BjyYTe2S5dxKm6WKurVUc7F-cDMI448cxBdbbS3iZcT6zVI0IN3VXJQ84dGwNXVc68lv2NeAhB2JC9rGSt4AKEQ3JCqp-WGNO0ptYy11J0-Gh8P2DK5Ey0pmPDSuWXV8PgHC1c7V57E9bnQokXs36FJvT2ajcfdqdKL1WCP3UfqMkegnHZZ5FS78eP9GsYU8_DJ9mbO5fJlK5b9lLpb93I_H77rBeXBfJuJ4FT1QYkNMIT_SNFEGmZVxJGAmya56wO8c0b7kVdNQOM/p.jpeg",
                            IsDeleted = false,
                            Name = "Souffle",
                            Price = 6.50m,
                            Weight = 250
                        },
                        new
                        {
                            Id = new Guid("95ddaea0-1ac3-4e4a-aa1b-f7265cdb7af6"),
                            Description = "Consists of layers of coffee-soaked ladyfinger biscuits, a creamy mixture made with mascarpone cheese, flavored with a hint of liqueur, and dusted with cocoa powder on top",
                            FoodCategoryId = 7,
                            ImageUrl = "https://uc5ad448d6936c53529c16e9879d.previews.dropboxusercontent.com/p/thumb/ACKhdiZLzFFfXVMBrcH799jpf4e_anEbvZA7CCbGZsmM_xblbYTf2QNGTRj5Xxpq6QbmuVjRK-2lHQNaOQLH65Tl6HLWRwEqT5UUw7pnQpOhOx0uKsp2Lgn10Stmt7dUSI61AJomOPjjH4ilYlrpYxQWq-bU3qaN7Wmw5YgIdy7ptoCds7JSSQKrBqKONtmiUPJvsw5dtAgTank0XIaCYmJ5VJMsL-9yKDGixmt7UTzAvGt19XlqtDNnfz_x0wJPE4xYRAPvSWlCGqpSD1qETUBeyNeXYsZz1sRX-u37B4TPyhAkLMz_NU1gqEbQ-QxBAYT25-_KYgOCcRZycyGCFD-s-SKFztWUZSIXlhW8MY0lSbVxt5htivuH3lSLh35NWlE/p.jpeg",
                            IsDeleted = false,
                            Name = "Tiramisu",
                            Price = 6.90m,
                            Weight = 300
                        },
                        new
                        {
                            Id = new Guid("e43e7bea-39aa-443d-9227-93ce1e721240"),
                            Description = "Cake with intense chocolate flavor and smooth, creamy texture",
                            FoodCategoryId = 7,
                            ImageUrl = "https://uca877bca878e5176ff6310a93ab.previews.dropboxusercontent.com/p/thumb/ACKzy2SwRzAVQ1fkwtO9BzwBMISMJiGH4LSWuSbukVJAkFt0E3E1vFBboo1jJe6mkF6p2wWqL8XlTiA_xQ43-eviL_631m1FP8Wz-nGwVfL-GHHZqbP8sMMT68FdZc6Gc4I8GuuGc2i8igODZhkqAKwf5_RkUEyjIQZFEoF0R6l3Yo4PIoKnvNz8UK8H3Wx2KZuFsS60cq-f31sTqXJGAIMd4xLjJaULroq5AoySXiklsO-9uB3U8KsPJ0VLXDpFSNzvjnP5jWik48UeJ5A5Day8lIGJkjFFWRLxkYoMG31KSFGYpzrohlfFfcoTyc-4GoUXxtQhz0QG3iGsK96bivNRbJQxnwVOMhQb4vJZBL_2irx8WBSONziRlfhW0frg7DE/p.jpeg",
                            IsDeleted = false,
                            Name = "Garash",
                            Price = 5.90m,
                            Weight = 200
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("FoodCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Salads"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Starters"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Main Dishes"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Spaghetti"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Burgers"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Desserts"
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserDrink", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DrinkId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "DrinkId");

                    b.HasIndex("DrinkId");

                    b.ToTable("UsersDrinks");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserFood", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("UsersFood");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Drink", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.DrinkCategory", "DrinkCategory")
                        .WithMany("Drinks")
                        .HasForeignKey("DrinkCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DrinkCategory");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Food", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.FoodCategory", "Category")
                        .WithMany("Food")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Manager", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserDrink", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", "User")
                        .WithMany("FavouriteDrinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserFood", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", "User")
                        .WithMany("FavourtiteFood")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("FavouriteDrinks");

                    b.Navigation("FavourtiteFood");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.DrinkCategory", b =>
                {
                    b.Navigation("Drinks");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.FoodCategory", b =>
                {
                    b.Navigation("Food");
                });
#pragma warning restore 612, 618
        }
    }
}
