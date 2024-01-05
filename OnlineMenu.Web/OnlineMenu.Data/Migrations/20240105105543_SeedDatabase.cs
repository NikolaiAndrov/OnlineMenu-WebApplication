#nullable disable

namespace OnlineMenu.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DrinksCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Water" },
                    { 2, false, "Soft Drinks" },
                    { 3, false, "Hot Drinks" },
                    { 4, false, "Beer" },
                    { 5, false, "Whisky" },
                    { 6, false, "Vodka" },
                    { 7, false, "Gin" },
                    { 8, false, "Wine" },
                    { 9, false, "Cocktails" }
                });

            migrationBuilder.InsertData(
                table: "FoodCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Salads" },
                    { 2, false, "Starters" },
                    { 3, false, "Main Dishes" },
                    { 4, false, "Pizza" },
                    { 5, false, "Spaghetti" },
                    { 6, false, "Burgers" },
                    { 7, false, "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Description", "DrinkCategoryId", "ImageUrl", "IsAlcoholic", "IsDeleted", "Milliliters", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0e8f3044-79df-45cf-bbe6-b924ba3adf03"), "Mineral Water", 1, "https://uc9c1f4c47eb8fb60f3ae5a89363.previews.dropboxusercontent.com/p/thumb/ACJaC6ufDJAVZAPfJtER-yibPK-mpyQy2HOeScBIMBTsRXhrHooD_fFSaHL3xtQfMYxQdDk9Wk1Daj6eM3wKQBQ11LUsRbBooJQjgVZ2QHgYDSkIATWfKq6ZA0RzMiGv5GMvroXZReocAKigYZKrqI2prh_kzeCG7anbf1T3Z_IyH0epje20vtdbJl4sYJpzWC_8BqpYgQhgQWiBTK_IXzrdr7jyl06S6RdRr8JJoJoSXxLOETsxbvrr7zXU82lHhborywvKnd1PCzQCIbGi-y4PjX4oSV2-6GTW-W4adcp8t7R-JtP4THQPimu875-DliVcmkW2yv54nh3EasKyCKSHS_gPiTTH1GjpDjZz94eL03CH56W7kEmdN0ZDPtxMrMU/p.jpeg", false, false, 330, "Devin", 1.80m },
                    { new Guid("10c34570-f3c0-4d1a-ad16-b9e15816706c"), "Herbs or Fruit flavour", 3, "https://uc8cdb139bc670e7b9f0dbe2a698.previews.dropboxusercontent.com/p/thumb/ACLszdDfvT5U7V67vd-P9dUupDgFjWg3XANrHa6wZgy25PGFJ05AFwzWO1ai45OIgiRCbITTtNOJxjHqO_BzW2T4rWSpwAhTu-xrddRp17anwecSyiRjTcEIsozfR5n1Y7_ExPy-L-Ln_smMBueWjwDuCx8ra2X4jiCWFijDoAAvespz_DIa6x4ruAzTB7s36ovDImK8_ckMy1msW9tSmTS0-ZlbClRP-3gPxqlCAJ4gUfioS5w1KWF5Z66JYbE_T1iNa8PiUljMvcIjgGqOes1g2Y3dwBE80t5ebin1BBfTH4WgcVRgbP7Obh35_bdahf9x0L4pn13exM-70A5YVPlZLtqD7v9-P0e08msrjZLNe8wHoDdb9xG2ui55UAf74YE/p.png", false, false, 80, "Tea", 2.00m },
                    { new Guid("210f6cba-73ce-4feb-8f72-1373af57daa3"), "Cocoa powder by choice", 3, "https://ucb742251efe5b0088da4e93bdd7.previews.dropboxusercontent.com/p/thumb/ACLF7lfOGSCsu2886mGZRBqax86Jt5vDrAmU4aGScFZIjA8nE-TFZoeQ8GuVZbhU6eC60iZNj1U-t_FnigboYm4EsaB35W361DobQcEzVYnhjS2LgDoj74cpozJO50QJgKGyXJ1kSO23XzJsnom5buMcW0oIdWRLnIO8X12aDQFcjeWbMLNXdZ3XKeo22eHAk-sN0CeQ0AWsbNu-fgFgThqxYdxqylYUM7oB3pRvsKQlYEkC7pcVW_hJEa8_GmRUY5DMLDfxO0Eku8IYzwBM6TLBHuKBK42tNj7QaASi7YAMJlP5LoSaPUyIEiP-g9zPsVZPP81wfaUzFFfZqztUvQhvWSm1wG_0xvCzaKzqs6u32nxs3x4sBVG2eYFuiCdWXvQ/p.jpeg", false, false, 80, "Cappuccino", 2.60m },
                    { new Guid("211e2eae-4acb-436b-b7ae-eee2b71dc453"), "Draught beer", 4, "https://uc680f65cb2b7db5ea42b8036dcf.previews.dropboxusercontent.com/p/thumb/ACIDO-i_aDPCw3SWUFI4wItRFjYSogvGsrZPPUt7R19j0CkgRiWPtUj94bhzLUSemp7jDulVRYfx4r2LaJ5oJugM1D-3hFOWZE09Exd7I8a1Rc2G5vdkosyNhDOFWHv3UrJ2cQW_my8pUDfJbK329-9YsWfdOHWKgQop4ZFNMMIQiPai9tPwtqKTSVScqA7I1n8LRPPe1FNk9tP_j5P4khNzA6YxSAAwPvXHCBnQ7tqwV-fjDlLKQV75KimHwRv0TGBKRox304V8LaqV1j16680L0G4h8AjKSPEELCdYjvKcQ5MAIzYy2JH3e8L9efwdV4V1rJcWzPuVCk1MQ2pWeSVPFvjrTKWOJVklXUALmJzA2ljeeasXSEnsH7GGszXn2eQ/p.jpeg", true, false, 500, "Carlsberg", 4.50m },
                    { new Guid("21aa59e5-2005-4617-a1e1-1acccf0798d0"), "12 years aged whisky", 5, "https://uc8e1c87861fe68473f6f80ab22a.previews.dropboxusercontent.com/p/thumb/ACLh4Tc41GH3qBjM1EQAOvAviFfmFrRg6foYwsBnGAxmaCxRpIMXQUJx0mCBZyqPUCx-amTkcUFVbSQwwpEH-XUlPUW7Qv3qGT4uf5pMQcy0Pi0g6Nd8QgeG0Gaby8YSaG5TsDeY9v0YNKBzPdyjnDGHJB_rEZurgTghqmTlVXoBffNWvEj-6MogJmfjB_cgyhUndW3pq8hAIAR-zBfG0a7-E2dHtDqFY_QADHqG23zXmNEV6-PaRe3D_kMqO-5TeeV5lKOJNmedBxGc_zMcIByfGkcUmridPoBKAuP9lLCusa4zVzBll6qWFIWjkksVdKILMe05QFowqmBd1kx7lKRaqQd0Rx0uCE375gQqKTVfdGZiZVEQp34PaRcXg6Eh3vs/p.jpeg", true, false, 50, "Singleton", 15.00m },
                    { new Guid("36aff0cf-5a44-4fee-92da-838f173ddffe"), "Consists of aperol, prosecco, club soda, ice cubes, orange slice", 9, "https://ucd101b79affd79bd3487a0b9195.previews.dropboxusercontent.com/p/thumb/ACIGGWwPIyXYO3vZuASYsOZXxRrtzRlQUaimIDnxVFLBd51UKJtG8KFZzzR7l7EgNK5EkHD8Y5sRlMNvl_R3WciJHAH7PEhju8ddQyO1445KaxsDIc-rS3C-5N0bJCp5yqM24In53_IeNMYKli8rSbBIjvtL7SBpWi4dsYw810dzu_ldVk0t2Q1M2Ex83UqPZDZIiKw0iWajiPuiPsTFCBorBUTE9-D8HJh1Ma8miKyfqxgSYStOdffUyB8hByzf-1apuKuAEsRGxzWRu1kV_SFJJ4KTZ1iwXPKggBeJBsQwXQL9OpNU8pZSsSUz5axz9a7dstDJhfiyEAkY7NePqZfXLvgMRpcDYaR--bt47WwjzgX_zwmGbrNBCRhLkexT98o/p.jpeg", true, false, 250, "Aperol Spritz", 8.00m },
                    { new Guid("48a6df9c-7572-48fa-a268-ef22bd6403c4"), "Espresso, Americano or Decaf", 3, "https://uc749cab6b4ab1e2c345196c3e6c.previews.dropboxusercontent.com/p/thumb/ACJO6QKVQQHfAAX6cqWqhQyr4T21NwKj-fFODH-ZvEAHqWC_giud6dHTSyajQEL5td6fG6yNq0tVTdDouQrALJ4v0qtmVp1OKhfHJyk82h-LHbTS5FbI1OOjIiK7Q1d4nu18dHeqZPni7R9NHHnCHCWyAM_4xADlTHxk-lsORZzV3L14dtXuROlc2SF7ZIjBAE1lpMMEtSx2yeM6fPZzCfSGs87v2YLZSQS-8ueKDXLEmr2GMbcZ0VGasw9qoONWAI3v88PgrrTpSieBHW4GnMBHnE5TDYVB0jpCgYe3LlFG3NFdV3gFktYYPLeVz6LiJ_Pux4SupkkmFkWnkN__b9rXyfhzxzyhXBjKpQ_vL6e1XGCfKdyvglQgAvbkI8ayzHs/p.jpeg", false, false, 50, "Coffee", 2.00m },
                    { new Guid("4af27246-f76a-4ba3-bdc2-cdc7856b6008"), "Sparkling Water", 1, "https://ucdc984860049a54c41353072bdc.previews.dropboxusercontent.com/p/thumb/ACL0y00Ij7lpIC_EugbufazeItPOP81YxcdC8twB1oKekJsEBxrc3lcrtFkOBnFiGrsG5qsR8DWpq2iiqXGkzKV22lgrBkkGwkyUFhQV8n21Y30vrGQn8Jtn0r3rKp8fwyFzDZXxKyJGsOyayVle-lZA07k-_c1DJB2BlhR_kJM6OaotAcRk4wrEa26f_0PIvPc3W6g0KoL7_vJE5TqseFJ11t6uIUvsZx9pkR4-OeioxpgYC4uQWz77kPlykjrf3SkPmCt3hOv6AwK8b7zEfjFnXlBmvrfCm2Ps0HPbW5ozVU3ILiuekANms9x9eGpModd2KXi2Jrbdke1HkBiuRWZdsKP3mdeqD6HrrGe6nH0fSlKVrcPX4_qq3Y4EHLIOa-0/p.jpeg", false, false, 330, "Devin", 2.00m },
                    { new Guid("54441a9d-a578-4d2f-8785-c0498af4c416"), "Scotch whisky", 5, "https://uc776957d67d12eec3bb71543841.previews.dropboxusercontent.com/p/thumb/ACJylw6SYGdfahi0XdJsikmdNdlCgX5tM4F_tirs2w3jqERtLg3rdvxhzBpZQ2sesjxV7j346ipUjQ1IntJj8o_BkE1HZqfzWqelGFtMauoVxeXn6qYuzdoIr2jHiW_ZvcBxVtbdKwLXQL45SPedErZRJyaxqBDWOIXIwo-OYk2BRYh-wtEoKdFmoRRvqwdbqpoVseK8QIzRCjKzXa4tS9iu0Bj1ZskiYJpiGtdexzs0C0vHNSWTWJMZM35MjSKfFkQO2Qf_qNPHuJA0uHaVQ5KITH9RnaZn62IjjpXGIjIObP-RiPQoOSuZAFBdTdxECZizSSIZ9Oju_reOPRPjXMpqE6BCf4l2IKPj1GjXF0Rc_ZN0tBWoEh0Gd8OdWYhylPI/p.jpeg", true, false, 50, "The Sassenach", 14.00m },
                    { new Guid("55489743-d83c-4903-862d-4d567e4daaf6"), "Vodka with premium quality and smooth taste", 6, "https://uc572e1c3d51ab7a39e8aa27b3b8.previews.dropboxusercontent.com/p/thumb/ACKq4lG-S8XyoO_6yOtUkSE0e-KKT5oU7ukhwO9kO4zaM4zFSX989aht80pGIcfpT6XcpjAj2iiiE4CTgtchfKsZyXyLKGRAdxB-Zi3MzCA_-M5VH4j5WDgeOjO9rbs3TyNNxbppVCBlYQYGBwuK1RF1zEhe0Si-V_L2cf6StNCln1OAPjd5asCDq8YMYINSsJn0afMA_P14aOXV8WECbspQeEhxquFm3CNev4-LtozJ3f4J6-njG8WxUAV3cBCLaNKjFkTirqdy_DQSxK_TemzCJljaJaIeQgawhZC34zm3xPTHvHv03xSlsWc9nU93cRyvG-ZTGAtVgvDjfafrDHR5kmgwW030bBZArE2Sf3MjT5VzVPMh7VWulsB3GgDYEwk/p.jpeg", true, false, 50, "Beluga", 15.00m },
                    { new Guid("5ddf2c51-51c8-4c33-96f6-5ed3f4db9cb2"), "Flavour by choice", 2, "https://uc0ab3fef5c438477b9b1e8221c4.previews.dropboxusercontent.com/p/thumb/ACKESxEDKConRHA-XNEi8UC0TAEap8vQcfVm8Pb0cIfDI6hHuBVCfS4rcQXlj5i_0_obxjI1Z06__1rLTpoZGwAfqoL_0Bqk90DQszDiPPSw0WmFDpMwQI-580YZosaBKwQhaTazhmcENHQUK4ToRWJhSzZ3lLC-iPhb-Q0RxREhAdIFTbJSCwN2sL3iIKuZYYdLHRmchFpcQkDkCKMZZ1rk7dBOh809CtT2Ni3Px577aaijX7lGb-WjEuInKAS8wGmLMwOPmnaQOA62WsAKPc8EKK_mKYU1meJfE3SMD6Bw8e89WO_m96otutVuCuI4IXSlzw23_b8HnP--p06yktR9L4FRXDLnLdyvbR9BBU-wjrNcZ5KsdcoZ6T2g1F6W6uc/p.jpeg", false, false, 330, "Fanta", 2.50m },
                    { new Guid("60cef764-4422-4bf2-a7af-718f144052b6"), "London Dry Gin", 7, "https://uc7818dd26bb796b83b85db0e667.previews.dropboxusercontent.com/p/thumb/ACIFZt3FY8A5cJ56LcBS1QoNortYgL2707x0xYM3SOyw3q9ACAwJo8ek-2P4ldkb-5gNtPALkIZXcoqYbnMXtFJhUAK60qwQilank651aqxDn0yVna4_zcm4VeGRqmlcp-TEjYi7CvciObTy0EsYj7sKHQzElW_Ytc2y6iTSHckR-3mC6c1Uu8A1UhPbsz2BJZsXQrXLCc-aF_QX6rI_ZWwFMx8vBvTHm1n1iMzKptaPqtsFHmOimRCO_vJDvI9f9ai7xBVyDS0zWT-diYHPbXb14QAHHg2oJeDGgFcEiRwTFMso8aVT8moGRLHPpFubFpxD-USWsJmWergRBHi9hJDr8Imuj9X1nQs0Pm6Hp8aWcj8D5yqqzylv449k9c4580w/p.jpeg", true, false, 50, "Brokers", 8.00m },
                    { new Guid("6cbe6697-c65c-4d06-8e0e-7a3c33fda9e4"), "Consists of equal parts of three main ingredients: gin, campari, and sweet vermouth", 9, "https://uccb24e13742879d8339c67b6ca5.previews.dropboxusercontent.com/p/thumb/ACLCf7hUGr-KVucGQhKOodcsAZrZxJC-THm66oniQvw5DLZ6HTsZFRjIJ9akO76LTRqW6gNE3VMHcB29pQ8-ALdBfCupVVmmKyyE1LetpWwJaUy99ZMM7pC0_grMKMds0ZgVExF4OGW4QRuAwZQcKudI_45gnjPj1XtXBAsMqh0cA9GlHCzDqCAqznJPT8FIdwv3VPzAXRDqwRk-dzhQzx532NHQSPoxTyXvnFrr6AG400qinLXTsZLxCcgqZECCbLC_VWxpjzH7KPtEK-RV79WjUyyzsW-lIumYRLrXl4KPatbQGQ1GaJMPDUvbw5C60tlS-KkPXczLRJQ16EqLE59zYiukClCFRS2cbmEYnSAPUMmu3eXMO8CW6JOfJttDgUo/p.jpeg", true, false, 200, "Negroni", 8.00m },
                    { new Guid("6d2d7228-abfc-49b0-83b7-d86efe9789be"), "London Dry Gin", 7, "https://uc2ce24417d1794649b002ae263c.previews.dropboxusercontent.com/p/thumb/ACI-Il_Bs1w9CyA0vA2lP-9hqdJ9QPd9mQjwRpZq0_QWwUizUCFFzO5wqXB2UsxvfmfRXtRM47BlrCLN7yAYrLULq_CIN4SJ2qEXaZEVVCC0wzqrtAhwHmpOzBiXMWG0zKr-X7pMCMAJ7QQj3uLXXxN8VxSkJZQ8QoG1Y3z5A9tJ9AVPLggvDQshhvdsuEDtNfhtbgfaWo6zTffOXOtP4jHh8iHVE8YIit-mwzaYPYYgj86sJleJbwvpI_aGK1xvbEfRfjvrLxf-Zm75Kv-lPPa-FbM-hYjmf3d_ec-ZBzOuZWlzmzmbwurRmx0e88of8-Yc7-UA6Q_bl1gKNYv7XGDdk9JKxz8jCde6YWNZ94iUy_1LqJmHWXDyZCRTTX_X0qo/p.jpeg", true, false, 50, "Bombay Sapphire", 8.00m },
                    { new Guid("6dc7a625-babd-4478-bf4f-6579ed34527c"), "Smoothness, subtle sweetness, and clean finish", 6, "https://uc41f2bdb66479ee97f8ed425182.previews.dropboxusercontent.com/p/thumb/ACLtF0Tp51rD3BRGbmKnFPbMbRms1EmpLvVga4MWkLhJzZzjLR1_3oI60ORzjIRWx96xiQ-X9Y1n1nvPkgstUe5DSK2JCgh6kCrbOyN9ULOpedSBJg3o3jEWmppEUJI0TGu3e8dGcdu5gYdpy_vwd0YCp7x9ROSxh8Vf93D5qZvjy3ZgzGGZGngLkIcIls19Y502ULO2XErRlQlgvvSHq-bEyLQg_f56nTW17DjZQQbTNhn6eXlgmvoHRGwwQxjjC7DPgAUEN8lGH405h4JbQK3DSWXsGUno5REvliWo9LOwnccnZUMRYhJ57hAKg4EvWCfRn5zGOfnsa6jkNCf4-hzrE3_pjnesOOiHCzEZvalUqYErkkoaNhw5L1NYriqMpmg/p.jpeg", true, false, 50, "Belvedere", 15.00m },
                    { new Guid("7975c442-2ab7-4df6-922d-73ad6514621c"), "Red, White, or Rose", 8, "https://uc0ba9d481b29cf257f254cdf22f.previews.dropboxusercontent.com/p/thumb/ACI-VtoOYwWYPMBJLTJK4reZmGtaivkyUqWkoIN20yIcV3jrbY1DT7gyHObd5cfdQuRTKqqXbzKase9TeIIn567QXTCQDYk6xP2ww2oXmpvslapDAeq28hRqc36WPsDZpPL-pAIN6urjYxOw74w6MqqYVUKdiFDYxr5JmxeX7iXxm4UmyvKjSfBBAywjZ_34_anrK1TzpVSYQIH2b1qZrNwqcw4cbMMBVhD-WL3zb5RrI6IqwlDvEF8GbgeHkMWxf_DVYQYvlIAYo_PruTBXJ_p87c0NrLn9GoIwqTdS5mJfICFEbs3AhLZhuWU4SH2rX7KwDTYyvkp6KsJwnR3KECjk93JcIdKB5V4J9ylE4P5jw7Tlt1dha8Zm180v_aw_rFQ/p.jpeg", true, false, 350, "Minkov Brothers Wine", 6.00m },
                    { new Guid("8301d3d7-374b-4b1a-9fb4-39a4dca3615b"), "Draught beer", 4, "https://ucd905382607284558aff947bacb.previews.dropboxusercontent.com/p/thumb/ACLqgorO33Z0hf4EVIfw4BwGtfOcCuHiiuymbv4gElxsWLraL2UzlOpUVwleL96l7D0CWKjHU7QARYfUsHKGzg8MQzpca8g0mqHwVE96h25_kpQDoobmr1wDHMplVffAWSqLHh_K8J5CJcEmiXQnZrd4TxskjW7Ndl1fatRheOjBfDTuqst0fsLrI7cSwIwfQIT1koIxAebMMxpc8pvkvVAv1rL3_lCwLBMPYuXxM5E6m-4LN1A7o33UeHZXWffmHFLe9wqIS_7SuY-PUzHdRSAthqBRHH6oQtB_xpObkWzQRRMnoESp5bze5zhUPXEfCfflq_rGh85z-4JoEzHw4YR9JCtBuXp11ZUobySOGZ5ONfQLVYwIItLrmel0mi2p948/p.jpeg", true, false, 330, "Carlsberg", 3.00m },
                    { new Guid("a35be3bc-427a-4cc2-847d-cc14884b8aaa"), "Flavour by choice", 2, "https://ucaf6ca18eb28b99ab1ef4c40427.previews.dropboxusercontent.com/p/thumb/ACJLMhqW39J598aUMLJCA4nhzC0Ja7Otf_MSkttpdbpygql_Ht4MrZoKAq5yTS_OhKoIYeJ0vb-iU09CaUcqz_5DGEEf31TRr_gGaxIynSmH7_AtJYtmg1sYf117qKzF3Kp_h-bDoxFXAk_xpOSri9H1pCvPQq_fPArRKdD_etCAUBlbSbQXP_wKu2nuip5noj2GgaK0pWbO41FX0X4mTIOk1SC7wwO3T6n3bC4Zzt8nUe3--mlpL6ybAXHnOk4O5hliSpyvI_GFsEpRurVgyLTqpol_8ztKSxb1Wob4gv2lyvK50hv4BeC4M5kuruet6h_uIAISPaxyMoODgWgcP1X6f77Q1iCWQzf0yXkRQabDCq8bEMF4uJiW_Q9d3X2lGlE/p.jpeg", false, false, 330, "Pop Soda", 2.50m },
                    { new Guid("a5bcb938-dc3a-4df6-824a-d7c2dd47275c"), "Smooth taste with subtle sweetness and a hint of almond", 6, "https://uc21d4abd34231348924c82bc913.previews.dropboxusercontent.com/p/thumb/ACJf6rWEWN2smnu8aZey7THuCZ4QJ6Ml350oPh6SfpFlmjHw2nBk3Mq7Q7SeusPr5_kigLSAa11tNbvKO8OedAHz5vN3hd-Q3SgUudZEzPQBRRwJl_Ur5lRzBa-M0IiygLaffGQ7PolKEbcR0hrScmtF8py2Gd6H8uACXH7aqbRpAThFbP02lv4qegxWf3HqlEGU2I2lTZzMvzDBO5_YF9Qr0a6U_9hLLBDh3-LAirSe7IsYvF1SOAL9bwuC7LM8h-w37z12g6YSDn1xmO30ANN16PNvg4Pr7Cc1BqgybhliwNAPCl9yPSirnjmV5q3DbghGDFBenA9Nq1DfMK8Vm0-3uO14qLtbV_amogrJXeuYnKXkHB3Fts5FGkERCtLUB88/p.jpeg", true, false, 50, "Grey Goose", 18.00m },
                    { new Guid("c19a37dc-bd13-4b10-8fa3-e8e0d5941be8"), "15 years aged whisky", 5, "https://uc6c575c198f45063a12931e19ea.previews.dropboxusercontent.com/p/thumb/ACJZzjVLBB00gouMFHlMc0IrR8NGvmN82u8qB1Tp9-upY0NEuVjpv_HCm5MXMCjKNnBs8TxwTN68qzDcuJyruOMshmMlCwMCtrJW_cg3ianPK_tThQsS0sVg5w-I6XvZyhtgiYpBpzQlL6hPRxVyI7gvv72lzWtewn05MFBL13QyQ-lV3YGWsHY6Iy5L7eUM4h8bl85WH1KgGSjdUDXSqUlrGaD0bUG5pIprGxbAMM0AT_pbhMOHARYoRBSWV67PEkugUJPI5xt8c9flgzwvcy52E_SFw3GYZl92Pz3x9fQxLarIbvCqczuz4MTaNb_2AogNCmt_UZHNxVmocYhT0O9LMGHVru2cQdD0_Ooh1QvGqHBgqXWDyU7gNIr0CAfQz6g/p.jpeg", true, false, 50, "Glenfiddich", 18.00m },
                    { new Guid("fb306f13-d430-4227-99f0-e01c508a7378"), "Classic or sugar free", 2, "https://uc54479bad12631b2e5cbb0b9614.previews.dropboxusercontent.com/p/thumb/ACIWhg5bH06rqzrpXy6qKqQfm4NlqEr43RVuoghvkz662jmmma97EsO6fxw5igG2w5EwNsEOnX6SKgTg5f3TYmbS2vycwN2K8_vkTBLkUDDxZpWeJUnbvomi4NYL-89x3bZEY0lpoKCfUHU0JQ4bJ3dHYSBguzQ6LrEPn7OzuxznT7A86Mo17KgPoYHdanksCckLUxXMulAQPPOPW9D0AlI7BgEfAVZIjf7mi3FWNzKNcySTn2pZUHX9nCb0aXEO3VSD2R6SdVza81IC3ZrxKRbuludGu_vLH-nCVIofvDRiKaFgxBL0Hgp3fVm97-nr9QWdrK2A6qPT1BAXtujR6DdpeegKVCnKAAaVWIMltzj6U2MtL7EUuqOXWA1xzyTqLVI/p.jpeg", false, false, 330, "Coca Cola", 2.50m }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Description", "FoodCategoryId", "ImageUrl", "IsDeleted", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("011682b2-74d2-4273-a798-8ab46006efd2"), "Mozzarella cheese, tomato sauce, spicy cured Italian sausage", 4, "https://uc3ae55f1d1d3c4cd134aec3f942.previews.dropboxusercontent.com/p/thumb/ACIeGX9Bdm5MdUVFM8R2Qlm7duuc-_nftLJpST9Z_WW5bLmmwo9fzrpE3uKXj7SfQw-UCRcoyH2B8WUEEuuuChZm5-iCjQ5j11IjWmhSjNKRKb_jS8FccuYzHYpAYv1HDRkeko0zRgi_Fc9JVetRu6LVyv8VmJVKBDOpIfTwe3m48bIsHQ3VaRsESin1NVeYKYsq3Ox5RF9IaxEmI9J0ub8mE2O5-PT7a-P0yvarfoiznNpfqZOn-vwpBgZU8MdlejTYtO-fIBwpHvk3CpN4OjJpvrlxZER906rJ_-1K5_XAs8La5rS7c6L9K5iWdI5iAG8lhgZg5QxWN83p2jG6OT2qmYtNmWDixfFEPadSXkV0SmSKYPDVxDwJ94FTuaxDFhQ/p.jpeg", false, "Pizza Pepperoni", 14.99m, 550 },
                    { new Guid("0d945b3a-347a-41e9-a1c7-9467e9893c77"), "Beef burger with french fries, fresh salad, cheddar", 6, "https://uc17220967bf29f23b6c13b38b5d.previews.dropboxusercontent.com/p/thumb/ACL5M1i2-xQIBUoh8OjDfV61k3frcehTBdsNnCd7PdfI5j7G0hLZk7ikBn5QWSd6ffCZ6S5P-Uf_N_Ly--KoGcF9KMX9Xzza2FRmtZcWGoSszCjpxuy-vkAj-szuuM21juCdxWGO8ySs_VYeKL8ehnr0EtQPwtg94fSSv7gIt9RmSnb6__rw0E_No2807gohxY4fDMlSSNw0Ws46eNnGRzhbGFLI8RUEoljDYJuMBEY3OGe5PiobUz-ZJRPvcqsJ5pKtMjMg0KXHrbU5m6KXmyviWu7v3_6RLV50BiF4O4d9gYUtGiSRw3ivFvqLRIA6OarRh5VARN_VexvQL2l4QfxhmRgmUfUnX-OOhzrkDrfLmRqxgcPP-sA0K3Npmf7g-uw/p.jpeg", false, "Beef Burger", 18.00m, 480 },
                    { new Guid("12951791-71bd-43b7-b3cf-f2ee89007550"), "Spaghetti pasta, eggs, pecorino romano cheese, guanciale (cured pork cheek), black pepper", 5, "https://uc4ca54fb7ca40986e8b8f88c451.previews.dropboxusercontent.com/p/thumb/ACKgeCFtl152AJ2k9XtJQGtRAHEqRIfM7jo0KanbiupMn0uczxYwhj2lVFgQywNMx2M_-_fF5CYIGoerNj_4Ku0VtuEOA1IFDsDR-yWljzrvGRl_Gbq1g54LysAU7AQo6jo8DLEXkF-l_Y5YEoR6ckKjKdthDdAXs5Skc3gFz43GK6wKtrxh1oRydZmVxNpSlZkizHtdXLlu_mtyE5wiwq1fw38aI40-T-SNiPv16DAzzZ3CNwGeYQr4ydkTnmZE1CBWJPnFpvLHp4BFYi5ZqEPAL65Yjuk1aNGNfHVSDVC13y5Yjxrxwm0iCKoTxyEKFwlMPMuYCt7LU91_JxS5KNV9Z_pddhluzPDVYW9djlcge7Ildagt989vdQ5KIVfIKpM/p.jpeg", false, "Spaghetti Carbonara", 11.00m, 440 },
                    { new Guid("14419c44-db4e-466d-a86d-24927f10dc9b"), "Spaghetti noodles topped with a meat-based sauce ragù alla bolognese", 5, "https://ucda61a488517f5eafa06aa480eb.previews.dropboxusercontent.com/p/thumb/ACKT6-Ti1Z3jF6qbVx45PyE_maOhhGfSjLZSm7G0vY-B5ocWXbbxbGo1mJYdG8BoSQibbHRXE6xp2EPvZbZ633W9pOkhCAiPJgVA7w83W0XfWZnpN4qwXbUCMc8j7N54CZ6k2ZbJLkzWnbNTMoMLue62FSRlk45Q84MYteCtiaS_rs_ys9CuRiDr0P8T0YfeWSMgksvcUJfZEkQ46extfPuuQVFt8RcgYpNWHxmWQQ00k7PFXXb8NxsiVPZAHeN9zYZdxcqEkzD8FDLfK8OAO5LXJz2Xeqkerbyd_XCwZ8SzChNzN1nEl-LP8SPMwmgrx3ps8Heyg-N1OPbSmfL2zY5gnqkvpK-sMWkaLMf_I2SDD3k52PlGJlMzPMdGoBC-Vws/p.jpeg", false, "Spaghetti Bolognese", 12.00m, 440 },
                    { new Guid("1b13851e-d03b-4ed3-95aa-027f7a94f657"), "Pork burger with fresh salad and cheddar", 6, "https://uc00118cfd0f097611e1a69be5b8.previews.dropboxusercontent.com/p/thumb/ACIol-2h3GRxD4q7LduTyOiUVKUdr0ojliXmlnDHy8LMnfrWjW9lzx8JK6RBkYc9rLnIiiwvKIAYA9evVo6hNSEdVoxtrP2bCQYCZvZhMGm3pS1Ujfl5TFvsMbIpSaCGz4wUOutqPzBgaMUesukkE2hxofeI34xe21v5K0PD5LuH9BuoriPbyeo18uyk9oY8v6anJ5J87tPm6dRkZwEMYbeNR5k5suN06LZZaVhHogOCkaADzcGSyWheuzqZCcyGSwAger5z9jWgCjQwmsL8ZfGmeh2UDaPuBLi9AJg_7HzqB-FrFsyOnbfKp5baoI7pwJpWcyo3zgQ6vQcZDgsVrsqzUNg3X1pdTEP9rnk0krKYqfeern8stsG-4uykUyf7crs/p.jpeg", false, "Pork Burger", 14.00m, 430 },
                    { new Guid("1e8efcb5-db8e-4b9c-b51e-af8b43f1cb89"), "Romaine lettuce, croutons, parmesan cheese and a dressing consisting of olive oil, lemon juice, garlic, worcestershire sauce", 1, "https://uc775e92110dd8f77e45e799abeb.previews.dropboxusercontent.com/p/thumb/ACKXilzU-1r9SaT8i9nD0gK2TL9sKPr5bbpT6G1DeWHL2oHTd0e2zSm_YXQ4kA5hZnowfloBIcBz1cF6-pgGkiw-Z-45itMn5qLEaBf8y8g-ZjTPWFMPj3BgGzqktIGJ9QCOc9FXCTP36f8Dk1-zFP4ksgcRroj6oKczM7rQKqXO9J_uHHd5Ob_F5X5QZkX2I1a2eIm5YiocCFNNHIxTatGTR7j_k-Paw3tX_t1AZrYyozZr0C29ig_bfp_3kxOXoF40La-e7pyjEuvh6c0lmTGjsMmkDWv6fWc2I8Ym9heOyFMWUPiJoeHskAzSrMpjcdWpi205finZFWsmf2amzzvyQ92-gqk64QQJnCc1EkrucCuxr5EsWXLwtgF6vC-kuKs/p.jpeg", false, "Caesar Salad", 12.00m, 400 },
                    { new Guid("21b8a7a9-9b88-43a0-ada2-248a6795eb31"), "Fresh buffalo mozzarella cheese, tomato sauce, basil leaves", 4, "https://uc920bd6fa91ae5b5cbfd65d5ff0.previews.dropboxusercontent.com/p/thumb/ACJW9W1fiUuTU42zrmY53XnCI_GJ9ngyRr_IE05GEdCtOsgJPBmfdZPMJf7uQs9laxHj76vbeNdETPAnAcnJF1OIcuy3FrNxrhZvGRmtzh9xEekKHweXj0jUC83btqdAXayK6SYSueO2XEWF74BYZRIC603FcHzvgiaSUrtyi-b07sVRBdsHYuo1V4OFBVIZCrnNSA44bkG5IEqzVN8-3nPlkLSyVbu2bS-spIiZwg0t75ctE-p_7mbg-R1XTtYISedFEIAC08k3bUy2SD-tLYTjXSRKhrDlTOQqMlf9Wwztar7TOMqf0BHsB8rJabvED_JL2JnGUWrBEDSCGWkZnKMEY8LNH2JiW3a-jDHeiVX-KQEo1nsyo4UgR2Pr7bpJdxs/p.jpeg", false, "Pizza Bufala", 14.99m, 550 },
                    { new Guid("24232452-6ed8-4e4a-9d09-3089181e37d5"), "Chocolate souffle with vanilla ice cream", 7, "https://uc31c341bac4c8dff3b1f6e7579c.previews.dropboxusercontent.com/p/thumb/ACJe_LLzgMDglq82shvZPrtv7ZWG6fSqYWhvFvmMLUhnmGGSTpOXcEPgURMerFzseILhJyfLZ_WCUkOZx4STKJFnnMlLyPbWW4hhyHNvuHDIiZ5Dzlfd9BjyYTe2S5dxKm6WKurVUc7F-cDMI448cxBdbbS3iZcT6zVI0IN3VXJQ84dGwNXVc68lv2NeAhB2JC9rGSt4AKEQ3JCqp-WGNO0ptYy11J0-Gh8P2DK5Ey0pmPDSuWXV8PgHC1c7V57E9bnQokXs36FJvT2ajcfdqdKL1WCP3UfqMkegnHZZ5FS78eP9GsYU8_DJ9mbO5fJlK5b9lLpb93I_H77rBeXBfJuJ4FT1QYkNMIT_SNFEGmZVxJGAmya56wO8c0b7kVdNQOM/p.jpeg", false, "Souffle", 6.50m, 250 },
                    { new Guid("2437d03c-bc28-4448-bc32-1be08a43f985"), "Grilled chicken breasts topped with mozzarella cheese, tomato slices, fresh basil leaves, pesto", 3, "https://uce26c50df0e8a99fa5d29bd7d83.previews.dropboxusercontent.com/p/thumb/ACKD5hL3A_ybKXH_a5PjUEbKyE_kAihuQQeUjRKvfKMVy_MFzs8pQ176Kgp8eGXZL5TQM3LyL3t60DuUWSAByCjV2Rr3BU6qV1o6CiNkLkxZ7kr2dUG7u5YJic2kaZZ8BBwUkfJXBQQGDni_en2kzEP7pzUCuDz7NAhZGMxsWBkuVh9M-dxGSc0OHVy68wJHL7CKsnKecq-0f-5xmmhJm0S2zwCCO9ZaXs_gRqCcR0G973OQ-bhZ7DMMyoLFI5YECwidPyI8ozIbU3-FVoUijZFphABhJxfj9BwaGRDyJ4pTlbIrB8l-Mz4ya1K51JHdVHYf2r6i2Swyyrdrdu56uvMZvPSOFfUJ0odLaOHnaD4hAIPChIdLfKafoCfrilImnoM/p.jpeg", false, "Chicken Caprese", 11.50m, 400 },
                    { new Guid("547e89fc-8ac2-44ca-8d2b-1a672e3af93f"), "Tomatoes, mozzarella cheese, basil leaves, olive oil, pesto", 1, "https://uc98fca7cb525b23cc48839a8a65.previews.dropboxusercontent.com/p/thumb/ACL7PWJrq-_W_lFGYIN9XFwk9iG_I3SuZhMHV4yY8oABkHOiYdfckgz4SjDSB4kpQwBsA2w5Xzn6jqmdRudkpDeTLmURwejUStdqmcaBJx1RiNnhNEwVvxBWfsoCgHbCHClR8Yt5_F7jRTSrLmUP94NOauw-kBfeosu171BdKclx7aGB96MG98PgQ4cjcq3bdztJZ5D22HtQqludeChjPr1HhxjjMGoTLHY4e1NLsn88QxzrRIgmyD7Xpq205Crr44xemQ0XO8rARXkkeDAzkyVuXzDWzPlkWA80cy19dJbhnQoNywqJrMJty7_vEdu31BykfaoXAxfFVCOSKnKPOrPoO5am3srS-LV8lBQkiTmDWaDI_ohdY8-9SmH9c2-HqT0/p.jpeg", false, "Caprese Salad", 12.00m, 450 },
                    { new Guid("716f45b7-2c90-4141-a26f-50f88e91693b"), "With ketchup and yogurt sauce", 2, "https://uc761faec458f4568610483bedce.previews.dropboxusercontent.com/p/thumb/ACKinDviyI969HSGq_dWa2UnjCWJfk6sAkBtS6rRqOvdC8QhLVGAv4lipx4tX7UWod-DqzwmxyF61HoOYGIFMWVS8Vu9xGxFV9i3Ubo6cQaRjvZab8YkwIi2bTm77I8mDKAxuCpJzFZ0GFZjJBAmL5n58zI-9zJPHi6177axo5jmklfRbcSleOp7cSiBpTl_RgGIK16J1F7zY0-zXNyITrUPWvnDkENsExp9AJ53321zOShvmBfbW2PxKoN7pM78FRsI1puSqfbaPKHGrr3pdWfF2-ACr6DXxxPaEa6bQSTy2EiGy-uXAnD177HZNf-M5M7YlxUYyGeCrU4k2GZDUMY9t81S7bpBOcedZ49AUVPE7GLU0fNtqIbz28pnp0YNhQM/p.jpeg", false, "Chicken Nuggets", 8.00m, 350 },
                    { new Guid("761fabde-fb3d-4d22-aed7-f97570ba0848"), "Side dish - fresh mushrooms, mushrooms sauce, french fries, carrot and broccoli", 3, "https://uc095ab4106b5ecdbc05b493f43a.previews.dropboxusercontent.com/p/thumb/ACJ7UfdyAXEEwgVubrmuPvJDDGBXW4R0a9aJE2YaHYXzIYi1h_pt8M5yN9l1lEXvYm-yEf47JFPiEePlUXX5lI-RIPATFQmOr_T9UPNmCUkVeCW1quzi9QifUdJoEWlNBPjOlUtUaeB2SGgDV-yDGQCU0hVigR8WinXbwZN9L8-ldD0_BgtGrv9BAsLoMF0DwSxi2EzFHfGGSycCTigN9GUIn7N75ycO6J1tE_dZdVpkQP2U08R0Zt5_hCdJDYKjrDWoQIc3UDqbG7KNhpgnSCJGLnPyV4i-JJoT2XSaqL3vZVFRUbCrL1uO5wntvNFVpDjhAwp4d8dgPkeFO-mlppHlGDEpZZeVZEipoa5NLKaoOf87P8rznnVEcwE6g3g1W3E/p.jpeg", false, "Beef Steak", 29.99m, 650 },
                    { new Guid("95ddaea0-1ac3-4e4a-aa1b-f7265cdb7af6"), "Consists of layers of coffee-soaked ladyfinger biscuits, a creamy mixture made with mascarpone cheese, flavored with a hint of liqueur, and dusted with cocoa powder on top", 7, "https://uc5ad448d6936c53529c16e9879d.previews.dropboxusercontent.com/p/thumb/ACKhdiZLzFFfXVMBrcH799jpf4e_anEbvZA7CCbGZsmM_xblbYTf2QNGTRj5Xxpq6QbmuVjRK-2lHQNaOQLH65Tl6HLWRwEqT5UUw7pnQpOhOx0uKsp2Lgn10Stmt7dUSI61AJomOPjjH4ilYlrpYxQWq-bU3qaN7Wmw5YgIdy7ptoCds7JSSQKrBqKONtmiUPJvsw5dtAgTank0XIaCYmJ5VJMsL-9yKDGixmt7UTzAvGt19XlqtDNnfz_x0wJPE4xYRAPvSWlCGqpSD1qETUBeyNeXYsZz1sRX-u37B4TPyhAkLMz_NU1gqEbQ-QxBAYT25-_KYgOCcRZycyGCFD-s-SKFztWUZSIXlhW8MY0lSbVxt5htivuH3lSLh35NWlE/p.jpeg", false, "Tiramisu", 6.90m, 300 },
                    { new Guid("aacdfc09-c378-44c3-9b16-b2ebb36086bd"), "Traditional Austrian dish made with a thinly pounded and breaded veal cutlet, french fries, yogurt sauce", 3, "https://uc1693f94ae231c00d3173f97282.previews.dropboxusercontent.com/p/thumb/ACJQdrIO44OpTUgkgEBQTQsLDv8B1QvoICteGV0-ab6d5-xQbr4BMMI9fPnRIkrascHMdmWTmBeVazhC8_ZUz8j_v6krW9nfN5EG6wcG-VaVs3SvHd9hua-477ifkZ6uHfSOWZPFlbb6invwacCEWUgZ1XVZzBo5Z-Vmw77qbCa-i9RuHFXZus9WyfNyBjMPuwLEiTo77R7rWWAGKcCP4dVZBFrEEnI1M_ykAamBwx707Phx1A4KSm1m492YNZp06fqMIRauev7wW1s2pFQk4xQQT3jABRpOnEWMtGQjXrWWh7QI1EoMRgqrFqUsdl-0lHENN0x4SeerTjRcEneCn30_6gf1zwku65q3rfFebfXqz6AT_xHLz3ZEhhF2uVINWBM/p.png", false, "Viennese Schnitzel", 15.00m, 500 },
                    { new Guid("b729846a-32b9-45e6-b6e7-f726c7440355"), "With corn flakes and ketchup", 2, "https://uc81a59cd34e583620e972a365b6.previews.dropboxusercontent.com/p/thumb/ACLfyIxGUOhGj1ftp5Me4gs_zwe-fpSvyH7HA0exWojFM6pby79sadL3Ge2vbqVKtktga2qaPwznDNvqThIHkya_B1GAmgxnIR3gj2pC_ZMQM5bWV13My7Ytb309r3pPK2gth7hsZ_AMyfMMWRwR6CZAvNPm9SwQwCj-RP8XVEFVSr8lZuwgGUvs0mHJjKJ4-P-PfQVRyPPJq-58hm92gxxt9929seUAVW7r1TypuRaHWC2CXNze_0UWpeN8Bq-oE4_n_5_nUYvE-5PlAMUvVxfKIDZwEZ9asCsU5QpskNUxbuWccAU1uQIDvaCGQwv8HDTsyW7bJIgsMzfWRHmfl2Evyj9n_Y92sq-hO0p0Dl-XOi3hFhO0J9oMzMIBWmoq_Pk/p.jpeg", false, "Crusted Chicken Strips", 10.00m, 350 },
                    { new Guid("c33fc162-db37-4cfe-8dc0-b8fc120fa9f5"), "With ketchup", 2, "https://uc66a2d97ebdf1b94051364a551e.previews.dropboxusercontent.com/p/thumb/ACK82mjZrDfVqtroHDwR27Ra5FgA1M9BUJFQpjXpYd8f5lCvTXuh843WyYyGzdVtRnw2Y6uDQgPlIqLzl6JC-LTH_DQ3qw2Qu00qjLfgPigmjQjpQueHhKajmSazf47a5NUz6PPQT-bzZsHyTls8NK5Gdoy4VBjVsKdxkuYRxLLFNThx8zYdKa3Pwz56qFPKoT6WK7XYUK-JiBhS81v4ParbQH92AWb0GWVwpSdZwkiEKOLjh0rsVWet0upBEKAGBKrkStUUey3gqaGECM2RGtui5RwA1ZHKkBqoRfkN5FpYrP72SeE_s1hA0I-Ghh9h_emy8xQJSKg0bj2wbIbLnqfgsBtDOLTTdES-tDH89GldvGp57tLHlz43FBAfZGMNbNY/p.jpeg", false, "French Fries", 6.50m, 300 },
                    { new Guid("e43e7bea-39aa-443d-9227-93ce1e721240"), "Cake with intense chocolate flavor and smooth, creamy texture", 7, "https://uca877bca878e5176ff6310a93ab.previews.dropboxusercontent.com/p/thumb/ACKzy2SwRzAVQ1fkwtO9BzwBMISMJiGH4LSWuSbukVJAkFt0E3E1vFBboo1jJe6mkF6p2wWqL8XlTiA_xQ43-eviL_631m1FP8Wz-nGwVfL-GHHZqbP8sMMT68FdZc6Gc4I8GuuGc2i8igODZhkqAKwf5_RkUEyjIQZFEoF0R6l3Yo4PIoKnvNz8UK8H3Wx2KZuFsS60cq-f31sTqXJGAIMd4xLjJaULroq5AoySXiklsO-9uB3U8KsPJ0VLXDpFSNzvjnP5jWik48UeJ5A5Day8lIGJkjFFWRLxkYoMG31KSFGYpzrohlfFfcoTyc-4GoUXxtQhz0QG3iGsK96bivNRbJQxnwVOMhQb4vJZBL_2irx8WBSONziRlfhW0frg7DE/p.jpeg", false, "Garash", 5.90m, 200 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("0e8f3044-79df-45cf-bbe6-b924ba3adf03"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("10c34570-f3c0-4d1a-ad16-b9e15816706c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("210f6cba-73ce-4feb-8f72-1373af57daa3"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("211e2eae-4acb-436b-b7ae-eee2b71dc453"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("21aa59e5-2005-4617-a1e1-1acccf0798d0"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("36aff0cf-5a44-4fee-92da-838f173ddffe"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("48a6df9c-7572-48fa-a268-ef22bd6403c4"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("4af27246-f76a-4ba3-bdc2-cdc7856b6008"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("54441a9d-a578-4d2f-8785-c0498af4c416"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("55489743-d83c-4903-862d-4d567e4daaf6"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("5ddf2c51-51c8-4c33-96f6-5ed3f4db9cb2"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("60cef764-4422-4bf2-a7af-718f144052b6"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("6cbe6697-c65c-4d06-8e0e-7a3c33fda9e4"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("6d2d7228-abfc-49b0-83b7-d86efe9789be"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("6dc7a625-babd-4478-bf4f-6579ed34527c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("7975c442-2ab7-4df6-922d-73ad6514621c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("8301d3d7-374b-4b1a-9fb4-39a4dca3615b"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("a35be3bc-427a-4cc2-847d-cc14884b8aaa"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("a5bcb938-dc3a-4df6-824a-d7c2dd47275c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("c19a37dc-bd13-4b10-8fa3-e8e0d5941be8"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("fb306f13-d430-4227-99f0-e01c508a7378"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("011682b2-74d2-4273-a798-8ab46006efd2"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("0d945b3a-347a-41e9-a1c7-9467e9893c77"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("12951791-71bd-43b7-b3cf-f2ee89007550"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("14419c44-db4e-466d-a86d-24927f10dc9b"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("1b13851e-d03b-4ed3-95aa-027f7a94f657"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("1e8efcb5-db8e-4b9c-b51e-af8b43f1cb89"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("21b8a7a9-9b88-43a0-ada2-248a6795eb31"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("24232452-6ed8-4e4a-9d09-3089181e37d5"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("2437d03c-bc28-4448-bc32-1be08a43f985"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("547e89fc-8ac2-44ca-8d2b-1a672e3af93f"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("716f45b7-2c90-4141-a26f-50f88e91693b"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("761fabde-fb3d-4d22-aed7-f97570ba0848"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("95ddaea0-1ac3-4e4a-aa1b-f7265cdb7af6"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("aacdfc09-c378-44c3-9b16-b2ebb36086bd"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("b729846a-32b9-45e6-b6e7-f726c7440355"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("c33fc162-db37-4cfe-8dc0-b8fc120fa9f5"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("e43e7bea-39aa-443d-9227-93ce1e721240"));

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DrinksCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodCategories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
