namespace OnlineMenu.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineMenu.Data.Models;

    public class DrinkEntityConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasOne(d => d.DrinkCategory)
                .WithMany(dc => dc.Drinks)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.CreateDrinks());
        }

        private Drink[] CreateDrinks()
        {
            ICollection<Drink> drinks = new HashSet<Drink>();

            Drink drink;

            drink = new Drink
            {
                Name = "Devin",
                Milliliters = 330,
                Price = 1.80m,
                Description = "Mineral Water",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://uc9c1f4c47eb8fb60f3ae5a89363.previews.dropboxusercontent.com/p/thumb/ACJaC6ufDJAVZAPfJtER-yibPK-mpyQy2HOeScBIMBTsRXhrHooD_fFSaHL3xtQfMYxQdDk9Wk1Daj6eM3wKQBQ11LUsRbBooJQjgVZ2QHgYDSkIATWfKq6ZA0RzMiGv5GMvroXZReocAKigYZKrqI2prh_kzeCG7anbf1T3Z_IyH0epje20vtdbJl4sYJpzWC_8BqpYgQhgQWiBTK_IXzrdr7jyl06S6RdRr8JJoJoSXxLOETsxbvrr7zXU82lHhborywvKnd1PCzQCIbGi-y4PjX4oSV2-6GTW-W4adcp8t7R-JtP4THQPimu875-DliVcmkW2yv54nh3EasKyCKSHS_gPiTTH1GjpDjZz94eL03CH56W7kEmdN0ZDPtxMrMU/p.jpeg",
                DrinkCategoryId = 1
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Devin",
                Milliliters = 330,
                Price = 2.00m,
                Description = "Sparkling Water",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://ucdc984860049a54c41353072bdc.previews.dropboxusercontent.com/p/thumb/ACL0y00Ij7lpIC_EugbufazeItPOP81YxcdC8twB1oKekJsEBxrc3lcrtFkOBnFiGrsG5qsR8DWpq2iiqXGkzKV22lgrBkkGwkyUFhQV8n21Y30vrGQn8Jtn0r3rKp8fwyFzDZXxKyJGsOyayVle-lZA07k-_c1DJB2BlhR_kJM6OaotAcRk4wrEa26f_0PIvPc3W6g0KoL7_vJE5TqseFJ11t6uIUvsZx9pkR4-OeioxpgYC4uQWz77kPlykjrf3SkPmCt3hOv6AwK8b7zEfjFnXlBmvrfCm2Ps0HPbW5ozVU3ILiuekANms9x9eGpModd2KXi2Jrbdke1HkBiuRWZdsKP3mdeqD6HrrGe6nH0fSlKVrcPX4_qq3Y4EHLIOa-0/p.jpeg",
                DrinkCategoryId = 1
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Coca Cola",
                Milliliters = 330,
                Price = 2.50m,
                Description = "Classic or sugar free",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://uc54479bad12631b2e5cbb0b9614.previews.dropboxusercontent.com/p/thumb/ACIWhg5bH06rqzrpXy6qKqQfm4NlqEr43RVuoghvkz662jmmma97EsO6fxw5igG2w5EwNsEOnX6SKgTg5f3TYmbS2vycwN2K8_vkTBLkUDDxZpWeJUnbvomi4NYL-89x3bZEY0lpoKCfUHU0JQ4bJ3dHYSBguzQ6LrEPn7OzuxznT7A86Mo17KgPoYHdanksCckLUxXMulAQPPOPW9D0AlI7BgEfAVZIjf7mi3FWNzKNcySTn2pZUHX9nCb0aXEO3VSD2R6SdVza81IC3ZrxKRbuludGu_vLH-nCVIofvDRiKaFgxBL0Hgp3fVm97-nr9QWdrK2A6qPT1BAXtujR6DdpeegKVCnKAAaVWIMltzj6U2MtL7EUuqOXWA1xzyTqLVI/p.jpeg",
                DrinkCategoryId = 2
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Fanta",
                Milliliters = 330,
                Price = 2.50m,
                Description = "Flavour by choice",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://uc0ab3fef5c438477b9b1e8221c4.previews.dropboxusercontent.com/p/thumb/ACKESxEDKConRHA-XNEi8UC0TAEap8vQcfVm8Pb0cIfDI6hHuBVCfS4rcQXlj5i_0_obxjI1Z06__1rLTpoZGwAfqoL_0Bqk90DQszDiPPSw0WmFDpMwQI-580YZosaBKwQhaTazhmcENHQUK4ToRWJhSzZ3lLC-iPhb-Q0RxREhAdIFTbJSCwN2sL3iIKuZYYdLHRmchFpcQkDkCKMZZ1rk7dBOh809CtT2Ni3Px577aaijX7lGb-WjEuInKAS8wGmLMwOPmnaQOA62WsAKPc8EKK_mKYU1meJfE3SMD6Bw8e89WO_m96otutVuCuI4IXSlzw23_b8HnP--p06yktR9L4FRXDLnLdyvbR9BBU-wjrNcZ5KsdcoZ6T2g1F6W6uc/p.jpeg",
                DrinkCategoryId = 2
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Pop Soda",
                Milliliters = 330,
                Price = 2.50m,
                Description = "Flavour by choice",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://ucaf6ca18eb28b99ab1ef4c40427.previews.dropboxusercontent.com/p/thumb/ACJLMhqW39J598aUMLJCA4nhzC0Ja7Otf_MSkttpdbpygql_Ht4MrZoKAq5yTS_OhKoIYeJ0vb-iU09CaUcqz_5DGEEf31TRr_gGaxIynSmH7_AtJYtmg1sYf117qKzF3Kp_h-bDoxFXAk_xpOSri9H1pCvPQq_fPArRKdD_etCAUBlbSbQXP_wKu2nuip5noj2GgaK0pWbO41FX0X4mTIOk1SC7wwO3T6n3bC4Zzt8nUe3--mlpL6ybAXHnOk4O5hliSpyvI_GFsEpRurVgyLTqpol_8ztKSxb1Wob4gv2lyvK50hv4BeC4M5kuruet6h_uIAISPaxyMoODgWgcP1X6f77Q1iCWQzf0yXkRQabDCq8bEMF4uJiW_Q9d3X2lGlE/p.jpeg",
                DrinkCategoryId = 2
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Coffee",
                Milliliters = 50,
                Price = 2.00m,
                Description = "Espresso, Americano or Decaf",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://uc749cab6b4ab1e2c345196c3e6c.previews.dropboxusercontent.com/p/thumb/ACJO6QKVQQHfAAX6cqWqhQyr4T21NwKj-fFODH-ZvEAHqWC_giud6dHTSyajQEL5td6fG6yNq0tVTdDouQrALJ4v0qtmVp1OKhfHJyk82h-LHbTS5FbI1OOjIiK7Q1d4nu18dHeqZPni7R9NHHnCHCWyAM_4xADlTHxk-lsORZzV3L14dtXuROlc2SF7ZIjBAE1lpMMEtSx2yeM6fPZzCfSGs87v2YLZSQS-8ueKDXLEmr2GMbcZ0VGasw9qoONWAI3v88PgrrTpSieBHW4GnMBHnE5TDYVB0jpCgYe3LlFG3NFdV3gFktYYPLeVz6LiJ_Pux4SupkkmFkWnkN__b9rXyfhzxzyhXBjKpQ_vL6e1XGCfKdyvglQgAvbkI8ayzHs/p.jpeg",
                DrinkCategoryId = 3
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Cappuccino",
                Milliliters = 80,
                Price = 2.60m,
                Description = "Cocoa powder by choice",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://ucb742251efe5b0088da4e93bdd7.previews.dropboxusercontent.com/p/thumb/ACLF7lfOGSCsu2886mGZRBqax86Jt5vDrAmU4aGScFZIjA8nE-TFZoeQ8GuVZbhU6eC60iZNj1U-t_FnigboYm4EsaB35W361DobQcEzVYnhjS2LgDoj74cpozJO50QJgKGyXJ1kSO23XzJsnom5buMcW0oIdWRLnIO8X12aDQFcjeWbMLNXdZ3XKeo22eHAk-sN0CeQ0AWsbNu-fgFgThqxYdxqylYUM7oB3pRvsKQlYEkC7pcVW_hJEa8_GmRUY5DMLDfxO0Eku8IYzwBM6TLBHuKBK42tNj7QaASi7YAMJlP5LoSaPUyIEiP-g9zPsVZPP81wfaUzFFfZqztUvQhvWSm1wG_0xvCzaKzqs6u32nxs3x4sBVG2eYFuiCdWXvQ/p.jpeg",
                DrinkCategoryId = 3
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Tea",
                Milliliters = 80,
                Price = 2.00m,
                Description = "Herbs or Fruit flavour",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "https://uc8cdb139bc670e7b9f0dbe2a698.previews.dropboxusercontent.com/p/thumb/ACLszdDfvT5U7V67vd-P9dUupDgFjWg3XANrHa6wZgy25PGFJ05AFwzWO1ai45OIgiRCbITTtNOJxjHqO_BzW2T4rWSpwAhTu-xrddRp17anwecSyiRjTcEIsozfR5n1Y7_ExPy-L-Ln_smMBueWjwDuCx8ra2X4jiCWFijDoAAvespz_DIa6x4ruAzTB7s36ovDImK8_ckMy1msW9tSmTS0-ZlbClRP-3gPxqlCAJ4gUfioS5w1KWF5Z66JYbE_T1iNa8PiUljMvcIjgGqOes1g2Y3dwBE80t5ebin1BBfTH4WgcVRgbP7Obh35_bdahf9x0L4pn13exM-70A5YVPlZLtqD7v9-P0e08msrjZLNe8wHoDdb9xG2ui55UAf74YE/p.png",
                DrinkCategoryId = 3
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Carlsberg",
                Milliliters = 330,
                Price = 3.00m,
                Description = "Draught beer",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://ucd905382607284558aff947bacb.previews.dropboxusercontent.com/p/thumb/ACLqgorO33Z0hf4EVIfw4BwGtfOcCuHiiuymbv4gElxsWLraL2UzlOpUVwleL96l7D0CWKjHU7QARYfUsHKGzg8MQzpca8g0mqHwVE96h25_kpQDoobmr1wDHMplVffAWSqLHh_K8J5CJcEmiXQnZrd4TxskjW7Ndl1fatRheOjBfDTuqst0fsLrI7cSwIwfQIT1koIxAebMMxpc8pvkvVAv1rL3_lCwLBMPYuXxM5E6m-4LN1A7o33UeHZXWffmHFLe9wqIS_7SuY-PUzHdRSAthqBRHH6oQtB_xpObkWzQRRMnoESp5bze5zhUPXEfCfflq_rGh85z-4JoEzHw4YR9JCtBuXp11ZUobySOGZ5ONfQLVYwIItLrmel0mi2p948/p.jpeg",
                DrinkCategoryId = 4
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Carlsberg",
                Milliliters = 500,
                Price = 4.50m,
                Description = "Draught beer",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc680f65cb2b7db5ea42b8036dcf.previews.dropboxusercontent.com/p/thumb/ACIDO-i_aDPCw3SWUFI4wItRFjYSogvGsrZPPUt7R19j0CkgRiWPtUj94bhzLUSemp7jDulVRYfx4r2LaJ5oJugM1D-3hFOWZE09Exd7I8a1Rc2G5vdkosyNhDOFWHv3UrJ2cQW_my8pUDfJbK329-9YsWfdOHWKgQop4ZFNMMIQiPai9tPwtqKTSVScqA7I1n8LRPPe1FNk9tP_j5P4khNzA6YxSAAwPvXHCBnQ7tqwV-fjDlLKQV75KimHwRv0TGBKRox304V8LaqV1j16680L0G4h8AjKSPEELCdYjvKcQ5MAIzYy2JH3e8L9efwdV4V1rJcWzPuVCk1MQ2pWeSVPFvjrTKWOJVklXUALmJzA2ljeeasXSEnsH7GGszXn2eQ/p.jpeg",
                DrinkCategoryId = 4
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Singleton",
                Milliliters = 50,
                Price = 15.00m,
                Description = "12 years aged whisky",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc8e1c87861fe68473f6f80ab22a.previews.dropboxusercontent.com/p/thumb/ACLh4Tc41GH3qBjM1EQAOvAviFfmFrRg6foYwsBnGAxmaCxRpIMXQUJx0mCBZyqPUCx-amTkcUFVbSQwwpEH-XUlPUW7Qv3qGT4uf5pMQcy0Pi0g6Nd8QgeG0Gaby8YSaG5TsDeY9v0YNKBzPdyjnDGHJB_rEZurgTghqmTlVXoBffNWvEj-6MogJmfjB_cgyhUndW3pq8hAIAR-zBfG0a7-E2dHtDqFY_QADHqG23zXmNEV6-PaRe3D_kMqO-5TeeV5lKOJNmedBxGc_zMcIByfGkcUmridPoBKAuP9lLCusa4zVzBll6qWFIWjkksVdKILMe05QFowqmBd1kx7lKRaqQd0Rx0uCE375gQqKTVfdGZiZVEQp34PaRcXg6Eh3vs/p.jpeg",
                DrinkCategoryId = 5
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Glenfiddich",
                Milliliters = 50,
                Price = 18.00m,
                Description = "15 years aged whisky",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc6c575c198f45063a12931e19ea.previews.dropboxusercontent.com/p/thumb/ACJZzjVLBB00gouMFHlMc0IrR8NGvmN82u8qB1Tp9-upY0NEuVjpv_HCm5MXMCjKNnBs8TxwTN68qzDcuJyruOMshmMlCwMCtrJW_cg3ianPK_tThQsS0sVg5w-I6XvZyhtgiYpBpzQlL6hPRxVyI7gvv72lzWtewn05MFBL13QyQ-lV3YGWsHY6Iy5L7eUM4h8bl85WH1KgGSjdUDXSqUlrGaD0bUG5pIprGxbAMM0AT_pbhMOHARYoRBSWV67PEkugUJPI5xt8c9flgzwvcy52E_SFw3GYZl92Pz3x9fQxLarIbvCqczuz4MTaNb_2AogNCmt_UZHNxVmocYhT0O9LMGHVru2cQdD0_Ooh1QvGqHBgqXWDyU7gNIr0CAfQz6g/p.jpeg",
                DrinkCategoryId = 5
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "The Sassenach",
                Milliliters = 50,
                Price = 14.00m,
                Description = "Scotch whisky",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc776957d67d12eec3bb71543841.previews.dropboxusercontent.com/p/thumb/ACJylw6SYGdfahi0XdJsikmdNdlCgX5tM4F_tirs2w3jqERtLg3rdvxhzBpZQ2sesjxV7j346ipUjQ1IntJj8o_BkE1HZqfzWqelGFtMauoVxeXn6qYuzdoIr2jHiW_ZvcBxVtbdKwLXQL45SPedErZRJyaxqBDWOIXIwo-OYk2BRYh-wtEoKdFmoRRvqwdbqpoVseK8QIzRCjKzXa4tS9iu0Bj1ZskiYJpiGtdexzs0C0vHNSWTWJMZM35MjSKfFkQO2Qf_qNPHuJA0uHaVQ5KITH9RnaZn62IjjpXGIjIObP-RiPQoOSuZAFBdTdxECZizSSIZ9Oju_reOPRPjXMpqE6BCf4l2IKPj1GjXF0Rc_ZN0tBWoEh0Gd8OdWYhylPI/p.jpeg",
                DrinkCategoryId = 5
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Beluga",
                Milliliters = 50,
                Price = 15.00m,
                Description = "Vodka with premium quality and smooth taste",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc572e1c3d51ab7a39e8aa27b3b8.previews.dropboxusercontent.com/p/thumb/ACKq4lG-S8XyoO_6yOtUkSE0e-KKT5oU7ukhwO9kO4zaM4zFSX989aht80pGIcfpT6XcpjAj2iiiE4CTgtchfKsZyXyLKGRAdxB-Zi3MzCA_-M5VH4j5WDgeOjO9rbs3TyNNxbppVCBlYQYGBwuK1RF1zEhe0Si-V_L2cf6StNCln1OAPjd5asCDq8YMYINSsJn0afMA_P14aOXV8WECbspQeEhxquFm3CNev4-LtozJ3f4J6-njG8WxUAV3cBCLaNKjFkTirqdy_DQSxK_TemzCJljaJaIeQgawhZC34zm3xPTHvHv03xSlsWc9nU93cRyvG-ZTGAtVgvDjfafrDHR5kmgwW030bBZArE2Sf3MjT5VzVPMh7VWulsB3GgDYEwk/p.jpeg",
                DrinkCategoryId = 6
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Belvedere",
                Milliliters = 50,
                Price = 15.00m,
                Description = "Smoothness, subtle sweetness, and clean finish",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc41f2bdb66479ee97f8ed425182.previews.dropboxusercontent.com/p/thumb/ACLtF0Tp51rD3BRGbmKnFPbMbRms1EmpLvVga4MWkLhJzZzjLR1_3oI60ORzjIRWx96xiQ-X9Y1n1nvPkgstUe5DSK2JCgh6kCrbOyN9ULOpedSBJg3o3jEWmppEUJI0TGu3e8dGcdu5gYdpy_vwd0YCp7x9ROSxh8Vf93D5qZvjy3ZgzGGZGngLkIcIls19Y502ULO2XErRlQlgvvSHq-bEyLQg_f56nTW17DjZQQbTNhn6eXlgmvoHRGwwQxjjC7DPgAUEN8lGH405h4JbQK3DSWXsGUno5REvliWo9LOwnccnZUMRYhJ57hAKg4EvWCfRn5zGOfnsa6jkNCf4-hzrE3_pjnesOOiHCzEZvalUqYErkkoaNhw5L1NYriqMpmg/p.jpeg",
                DrinkCategoryId = 6
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Grey Goose",
                Milliliters = 50,
                Price = 18.00m,
                Description = "Smooth taste with subtle sweetness and a hint of almond",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc21d4abd34231348924c82bc913.previews.dropboxusercontent.com/p/thumb/ACJf6rWEWN2smnu8aZey7THuCZ4QJ6Ml350oPh6SfpFlmjHw2nBk3Mq7Q7SeusPr5_kigLSAa11tNbvKO8OedAHz5vN3hd-Q3SgUudZEzPQBRRwJl_Ur5lRzBa-M0IiygLaffGQ7PolKEbcR0hrScmtF8py2Gd6H8uACXH7aqbRpAThFbP02lv4qegxWf3HqlEGU2I2lTZzMvzDBO5_YF9Qr0a6U_9hLLBDh3-LAirSe7IsYvF1SOAL9bwuC7LM8h-w37z12g6YSDn1xmO30ANN16PNvg4Pr7Cc1BqgybhliwNAPCl9yPSirnjmV5q3DbghGDFBenA9Nq1DfMK8Vm0-3uO14qLtbV_amogrJXeuYnKXkHB3Fts5FGkERCtLUB88/p.jpeg",
                DrinkCategoryId = 6
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Bombay Sapphire",
                Milliliters = 50,
                Price = 8.00m,
                Description = "London Dry Gin",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc2ce24417d1794649b002ae263c.previews.dropboxusercontent.com/p/thumb/ACI-Il_Bs1w9CyA0vA2lP-9hqdJ9QPd9mQjwRpZq0_QWwUizUCFFzO5wqXB2UsxvfmfRXtRM47BlrCLN7yAYrLULq_CIN4SJ2qEXaZEVVCC0wzqrtAhwHmpOzBiXMWG0zKr-X7pMCMAJ7QQj3uLXXxN8VxSkJZQ8QoG1Y3z5A9tJ9AVPLggvDQshhvdsuEDtNfhtbgfaWo6zTffOXOtP4jHh8iHVE8YIit-mwzaYPYYgj86sJleJbwvpI_aGK1xvbEfRfjvrLxf-Zm75Kv-lPPa-FbM-hYjmf3d_ec-ZBzOuZWlzmzmbwurRmx0e88of8-Yc7-UA6Q_bl1gKNYv7XGDdk9JKxz8jCde6YWNZ94iUy_1LqJmHWXDyZCRTTX_X0qo/p.jpeg",
                DrinkCategoryId = 7
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Brokers",
                Milliliters = 50,
                Price = 8.00m,
                Description = "London Dry Gin",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc7818dd26bb796b83b85db0e667.previews.dropboxusercontent.com/p/thumb/ACIFZt3FY8A5cJ56LcBS1QoNortYgL2707x0xYM3SOyw3q9ACAwJo8ek-2P4ldkb-5gNtPALkIZXcoqYbnMXtFJhUAK60qwQilank651aqxDn0yVna4_zcm4VeGRqmlcp-TEjYi7CvciObTy0EsYj7sKHQzElW_Ytc2y6iTSHckR-3mC6c1Uu8A1UhPbsz2BJZsXQrXLCc-aF_QX6rI_ZWwFMx8vBvTHm1n1iMzKptaPqtsFHmOimRCO_vJDvI9f9ai7xBVyDS0zWT-diYHPbXb14QAHHg2oJeDGgFcEiRwTFMso8aVT8moGRLHPpFubFpxD-USWsJmWergRBHi9hJDr8Imuj9X1nQs0Pm6Hp8aWcj8D5yqqzylv449k9c4580w/p.jpeg",
                DrinkCategoryId = 7
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Minkov Brothers Wine",
                Milliliters = 350,
                Price = 6.00m,
                Description = "Red, White, or Rose",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uc0ba9d481b29cf257f254cdf22f.previews.dropboxusercontent.com/p/thumb/ACI-VtoOYwWYPMBJLTJK4reZmGtaivkyUqWkoIN20yIcV3jrbY1DT7gyHObd5cfdQuRTKqqXbzKase9TeIIn567QXTCQDYk6xP2ww2oXmpvslapDAeq28hRqc36WPsDZpPL-pAIN6urjYxOw74w6MqqYVUKdiFDYxr5JmxeX7iXxm4UmyvKjSfBBAywjZ_34_anrK1TzpVSYQIH2b1qZrNwqcw4cbMMBVhD-WL3zb5RrI6IqwlDvEF8GbgeHkMWxf_DVYQYvlIAYo_PruTBXJ_p87c0NrLn9GoIwqTdS5mJfICFEbs3AhLZhuWU4SH2rX7KwDTYyvkp6KsJwnR3KECjk93JcIdKB5V4J9ylE4P5jw7Tlt1dha8Zm180v_aw_rFQ/p.jpeg",
                DrinkCategoryId = 8
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Negroni",
                Milliliters = 200,
                Price = 8.00m,
                Description = "Consists of equal parts of three main ingredients: gin, campari, and sweet vermouth",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://uccb24e13742879d8339c67b6ca5.previews.dropboxusercontent.com/p/thumb/ACLCf7hUGr-KVucGQhKOodcsAZrZxJC-THm66oniQvw5DLZ6HTsZFRjIJ9akO76LTRqW6gNE3VMHcB29pQ8-ALdBfCupVVmmKyyE1LetpWwJaUy99ZMM7pC0_grMKMds0ZgVExF4OGW4QRuAwZQcKudI_45gnjPj1XtXBAsMqh0cA9GlHCzDqCAqznJPT8FIdwv3VPzAXRDqwRk-dzhQzx532NHQSPoxTyXvnFrr6AG400qinLXTsZLxCcgqZECCbLC_VWxpjzH7KPtEK-RV79WjUyyzsW-lIumYRLrXl4KPatbQGQ1GaJMPDUvbw5C60tlS-KkPXczLRJQ16EqLE59zYiukClCFRS2cbmEYnSAPUMmu3eXMO8CW6JOfJttDgUo/p.jpeg",
                DrinkCategoryId = 9
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Aperol Spritz",
                Milliliters = 250,
                Price = 8.00m,
                Description = "Consists of aperol, prosecco, club soda, ice cubes, orange slice",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "https://ucd101b79affd79bd3487a0b9195.previews.dropboxusercontent.com/p/thumb/ACIGGWwPIyXYO3vZuASYsOZXxRrtzRlQUaimIDnxVFLBd51UKJtG8KFZzzR7l7EgNK5EkHD8Y5sRlMNvl_R3WciJHAH7PEhju8ddQyO1445KaxsDIc-rS3C-5N0bJCp5yqM24In53_IeNMYKli8rSbBIjvtL7SBpWi4dsYw810dzu_ldVk0t2Q1M2Ex83UqPZDZIiKw0iWajiPuiPsTFCBorBUTE9-D8HJh1Ma8miKyfqxgSYStOdffUyB8hByzf-1apuKuAEsRGxzWRu1kV_SFJJ4KTZ1iwXPKggBeJBsQwXQL9OpNU8pZSsSUz5axz9a7dstDJhfiyEAkY7NePqZfXLvgMRpcDYaR--bt47WwjzgX_zwmGbrNBCRhLkexT98o/p.jpeg",
                DrinkCategoryId = 9
            };
            drinks.Add(drink);

            return drinks.ToArray();
        }
    }
}
