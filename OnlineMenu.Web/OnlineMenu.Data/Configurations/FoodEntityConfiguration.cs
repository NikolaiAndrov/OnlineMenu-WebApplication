namespace OnlineMenu.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data.Models;

    public class FoodEntityConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasOne(f => f.Category)
                .WithMany(fc => fc.Food)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.CreateFood());
        }

        private Food[] CreateFood()
        {
            ICollection<Food> foodCollection = new HashSet<Food>();

            Food food;

            food = new Food
            {
                Name = "Caesar Salad",
                Weight = 400,
                Price = 12.00m,
                Description = "Romaine lettuce, croutons, parmesan cheese and a dressing consisting of olive oil, lemon juice, garlic, worcestershire sauce",
                IsDeleted = false,
                ImageUrl = "https://uc775e92110dd8f77e45e799abeb.previews.dropboxusercontent.com/p/thumb/ACKXilzU-1r9SaT8i9nD0gK2TL9sKPr5bbpT6G1DeWHL2oHTd0e2zSm_YXQ4kA5hZnowfloBIcBz1cF6-pgGkiw-Z-45itMn5qLEaBf8y8g-ZjTPWFMPj3BgGzqktIGJ9QCOc9FXCTP36f8Dk1-zFP4ksgcRroj6oKczM7rQKqXO9J_uHHd5Ob_F5X5QZkX2I1a2eIm5YiocCFNNHIxTatGTR7j_k-Paw3tX_t1AZrYyozZr0C29ig_bfp_3kxOXoF40La-e7pyjEuvh6c0lmTGjsMmkDWv6fWc2I8Ym9heOyFMWUPiJoeHskAzSrMpjcdWpi205finZFWsmf2amzzvyQ92-gqk64QQJnCc1EkrucCuxr5EsWXLwtgF6vC-kuKs/p.jpeg",
                FoodCategoryId = 1
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Caprese Salad",
                Weight = 450,
                Price = 12.00m,
                Description = "Tomatoes, mozzarella cheese, basil leaves, olive oil, pesto",
                IsDeleted = false,
                ImageUrl = "https://uc98fca7cb525b23cc48839a8a65.previews.dropboxusercontent.com/p/thumb/ACL7PWJrq-_W_lFGYIN9XFwk9iG_I3SuZhMHV4yY8oABkHOiYdfckgz4SjDSB4kpQwBsA2w5Xzn6jqmdRudkpDeTLmURwejUStdqmcaBJx1RiNnhNEwVvxBWfsoCgHbCHClR8Yt5_F7jRTSrLmUP94NOauw-kBfeosu171BdKclx7aGB96MG98PgQ4cjcq3bdztJZ5D22HtQqludeChjPr1HhxjjMGoTLHY4e1NLsn88QxzrRIgmyD7Xpq205Crr44xemQ0XO8rARXkkeDAzkyVuXzDWzPlkWA80cy19dJbhnQoNywqJrMJty7_vEdu31BykfaoXAxfFVCOSKnKPOrPoO5am3srS-LV8lBQkiTmDWaDI_ohdY8-9SmH9c2-HqT0/p.jpeg",
                FoodCategoryId = 1
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "French Fries",
                Weight = 300,
                Price = 6.50m,
                Description = "With ketchup",
                IsDeleted = false,
                ImageUrl = "https://uc66a2d97ebdf1b94051364a551e.previews.dropboxusercontent.com/p/thumb/ACK82mjZrDfVqtroHDwR27Ra5FgA1M9BUJFQpjXpYd8f5lCvTXuh843WyYyGzdVtRnw2Y6uDQgPlIqLzl6JC-LTH_DQ3qw2Qu00qjLfgPigmjQjpQueHhKajmSazf47a5NUz6PPQT-bzZsHyTls8NK5Gdoy4VBjVsKdxkuYRxLLFNThx8zYdKa3Pwz56qFPKoT6WK7XYUK-JiBhS81v4ParbQH92AWb0GWVwpSdZwkiEKOLjh0rsVWet0upBEKAGBKrkStUUey3gqaGECM2RGtui5RwA1ZHKkBqoRfkN5FpYrP72SeE_s1hA0I-Ghh9h_emy8xQJSKg0bj2wbIbLnqfgsBtDOLTTdES-tDH89GldvGp57tLHlz43FBAfZGMNbNY/p.jpeg",
                FoodCategoryId = 2
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Chicken Nuggets",
                Weight = 350,
                Price = 8.00m,
                Description = "With ketchup and yogurt sauce",
                IsDeleted = false,
                ImageUrl = "https://uc761faec458f4568610483bedce.previews.dropboxusercontent.com/p/thumb/ACKinDviyI969HSGq_dWa2UnjCWJfk6sAkBtS6rRqOvdC8QhLVGAv4lipx4tX7UWod-DqzwmxyF61HoOYGIFMWVS8Vu9xGxFV9i3Ubo6cQaRjvZab8YkwIi2bTm77I8mDKAxuCpJzFZ0GFZjJBAmL5n58zI-9zJPHi6177axo5jmklfRbcSleOp7cSiBpTl_RgGIK16J1F7zY0-zXNyITrUPWvnDkENsExp9AJ53321zOShvmBfbW2PxKoN7pM78FRsI1puSqfbaPKHGrr3pdWfF2-ACr6DXxxPaEa6bQSTy2EiGy-uXAnD177HZNf-M5M7YlxUYyGeCrU4k2GZDUMY9t81S7bpBOcedZ49AUVPE7GLU0fNtqIbz28pnp0YNhQM/p.jpeg",
                FoodCategoryId = 2
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Crusted Chicken Strips",
                Weight = 350,
                Price = 10.00m,
                Description = "With corn flakes and ketchup",
                IsDeleted = false,
                ImageUrl = "https://uc81a59cd34e583620e972a365b6.previews.dropboxusercontent.com/p/thumb/ACLfyIxGUOhGj1ftp5Me4gs_zwe-fpSvyH7HA0exWojFM6pby79sadL3Ge2vbqVKtktga2qaPwznDNvqThIHkya_B1GAmgxnIR3gj2pC_ZMQM5bWV13My7Ytb309r3pPK2gth7hsZ_AMyfMMWRwR6CZAvNPm9SwQwCj-RP8XVEFVSr8lZuwgGUvs0mHJjKJ4-P-PfQVRyPPJq-58hm92gxxt9929seUAVW7r1TypuRaHWC2CXNze_0UWpeN8Bq-oE4_n_5_nUYvE-5PlAMUvVxfKIDZwEZ9asCsU5QpskNUxbuWccAU1uQIDvaCGQwv8HDTsyW7bJIgsMzfWRHmfl2Evyj9n_Y92sq-hO0p0Dl-XOi3hFhO0J9oMzMIBWmoq_Pk/p.jpeg",
                FoodCategoryId = 2
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Chicken Caprese",
                Weight = 400,
                Price = 11.50m,
                Description = "Grilled chicken breasts topped with mozzarella cheese, tomato slices, fresh basil leaves, pesto",
                IsDeleted = false,
                ImageUrl = "https://uce26c50df0e8a99fa5d29bd7d83.previews.dropboxusercontent.com/p/thumb/ACKD5hL3A_ybKXH_a5PjUEbKyE_kAihuQQeUjRKvfKMVy_MFzs8pQ176Kgp8eGXZL5TQM3LyL3t60DuUWSAByCjV2Rr3BU6qV1o6CiNkLkxZ7kr2dUG7u5YJic2kaZZ8BBwUkfJXBQQGDni_en2kzEP7pzUCuDz7NAhZGMxsWBkuVh9M-dxGSc0OHVy68wJHL7CKsnKecq-0f-5xmmhJm0S2zwCCO9ZaXs_gRqCcR0G973OQ-bhZ7DMMyoLFI5YECwidPyI8ozIbU3-FVoUijZFphABhJxfj9BwaGRDyJ4pTlbIrB8l-Mz4ya1K51JHdVHYf2r6i2Swyyrdrdu56uvMZvPSOFfUJ0odLaOHnaD4hAIPChIdLfKafoCfrilImnoM/p.jpeg",
                FoodCategoryId = 3
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Viennese Schnitzel",
                Weight = 500,
                Price = 15.00m,
                Description = "Traditional Austrian dish made with a thinly pounded and breaded veal cutlet, french fries, yogurt sauce",
                IsDeleted = false,
                ImageUrl = "https://uc1693f94ae231c00d3173f97282.previews.dropboxusercontent.com/p/thumb/ACJQdrIO44OpTUgkgEBQTQsLDv8B1QvoICteGV0-ab6d5-xQbr4BMMI9fPnRIkrascHMdmWTmBeVazhC8_ZUz8j_v6krW9nfN5EG6wcG-VaVs3SvHd9hua-477ifkZ6uHfSOWZPFlbb6invwacCEWUgZ1XVZzBo5Z-Vmw77qbCa-i9RuHFXZus9WyfNyBjMPuwLEiTo77R7rWWAGKcCP4dVZBFrEEnI1M_ykAamBwx707Phx1A4KSm1m492YNZp06fqMIRauev7wW1s2pFQk4xQQT3jABRpOnEWMtGQjXrWWh7QI1EoMRgqrFqUsdl-0lHENN0x4SeerTjRcEneCn30_6gf1zwku65q3rfFebfXqz6AT_xHLz3ZEhhF2uVINWBM/p.png",
                FoodCategoryId = 3
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Beef Steak",
                Weight = 650,
                Price = 29.99m,
                Description = "Side dish - fresh mushrooms, mushrooms sauce, french fries, carrot and broccoli",
                IsDeleted = false,
                ImageUrl = "https://uc095ab4106b5ecdbc05b493f43a.previews.dropboxusercontent.com/p/thumb/ACJ7UfdyAXEEwgVubrmuPvJDDGBXW4R0a9aJE2YaHYXzIYi1h_pt8M5yN9l1lEXvYm-yEf47JFPiEePlUXX5lI-RIPATFQmOr_T9UPNmCUkVeCW1quzi9QifUdJoEWlNBPjOlUtUaeB2SGgDV-yDGQCU0hVigR8WinXbwZN9L8-ldD0_BgtGrv9BAsLoMF0DwSxi2EzFHfGGSycCTigN9GUIn7N75ycO6J1tE_dZdVpkQP2U08R0Zt5_hCdJDYKjrDWoQIc3UDqbG7KNhpgnSCJGLnPyV4i-JJoT2XSaqL3vZVFRUbCrL1uO5wntvNFVpDjhAwp4d8dgPkeFO-mlppHlGDEpZZeVZEipoa5NLKaoOf87P8rznnVEcwE6g3g1W3E/p.jpeg",
                FoodCategoryId = 3
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Pizza Bufala",
                Weight = 550,
                Price = 14.99m,
                Description = "Fresh buffalo mozzarella cheese, tomato sauce, basil leaves",
                IsDeleted = false,
                ImageUrl = "https://uc920bd6fa91ae5b5cbfd65d5ff0.previews.dropboxusercontent.com/p/thumb/ACJW9W1fiUuTU42zrmY53XnCI_GJ9ngyRr_IE05GEdCtOsgJPBmfdZPMJf7uQs9laxHj76vbeNdETPAnAcnJF1OIcuy3FrNxrhZvGRmtzh9xEekKHweXj0jUC83btqdAXayK6SYSueO2XEWF74BYZRIC603FcHzvgiaSUrtyi-b07sVRBdsHYuo1V4OFBVIZCrnNSA44bkG5IEqzVN8-3nPlkLSyVbu2bS-spIiZwg0t75ctE-p_7mbg-R1XTtYISedFEIAC08k3bUy2SD-tLYTjXSRKhrDlTOQqMlf9Wwztar7TOMqf0BHsB8rJabvED_JL2JnGUWrBEDSCGWkZnKMEY8LNH2JiW3a-jDHeiVX-KQEo1nsyo4UgR2Pr7bpJdxs/p.jpeg",
                FoodCategoryId = 4
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Pizza Pepperoni",
                Weight = 550,
                Price = 14.99m,
                Description = "Mozzarella cheese, tomato sauce, spicy cured Italian sausage",
                IsDeleted = false,
                ImageUrl = "https://uc3ae55f1d1d3c4cd134aec3f942.previews.dropboxusercontent.com/p/thumb/ACIeGX9Bdm5MdUVFM8R2Qlm7duuc-_nftLJpST9Z_WW5bLmmwo9fzrpE3uKXj7SfQw-UCRcoyH2B8WUEEuuuChZm5-iCjQ5j11IjWmhSjNKRKb_jS8FccuYzHYpAYv1HDRkeko0zRgi_Fc9JVetRu6LVyv8VmJVKBDOpIfTwe3m48bIsHQ3VaRsESin1NVeYKYsq3Ox5RF9IaxEmI9J0ub8mE2O5-PT7a-P0yvarfoiznNpfqZOn-vwpBgZU8MdlejTYtO-fIBwpHvk3CpN4OjJpvrlxZER906rJ_-1K5_XAs8La5rS7c6L9K5iWdI5iAG8lhgZg5QxWN83p2jG6OT2qmYtNmWDixfFEPadSXkV0SmSKYPDVxDwJ94FTuaxDFhQ/p.jpeg",
                FoodCategoryId = 4
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Spaghetti Bolognese",
                Weight = 440,
                Price = 12.00m,
                Description = "Spaghetti noodles topped with a meat-based sauce ragù alla bolognese",
                IsDeleted = false,
                ImageUrl = "https://ucda61a488517f5eafa06aa480eb.previews.dropboxusercontent.com/p/thumb/ACKT6-Ti1Z3jF6qbVx45PyE_maOhhGfSjLZSm7G0vY-B5ocWXbbxbGo1mJYdG8BoSQibbHRXE6xp2EPvZbZ633W9pOkhCAiPJgVA7w83W0XfWZnpN4qwXbUCMc8j7N54CZ6k2ZbJLkzWnbNTMoMLue62FSRlk45Q84MYteCtiaS_rs_ys9CuRiDr0P8T0YfeWSMgksvcUJfZEkQ46extfPuuQVFt8RcgYpNWHxmWQQ00k7PFXXb8NxsiVPZAHeN9zYZdxcqEkzD8FDLfK8OAO5LXJz2Xeqkerbyd_XCwZ8SzChNzN1nEl-LP8SPMwmgrx3ps8Heyg-N1OPbSmfL2zY5gnqkvpK-sMWkaLMf_I2SDD3k52PlGJlMzPMdGoBC-Vws/p.jpeg",
                FoodCategoryId = 5
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Spaghetti Carbonara",
                Weight = 440,
                Price = 11.00m,
                Description = "Spaghetti pasta, eggs, pecorino romano cheese, guanciale (cured pork cheek), black pepper",
                IsDeleted = false,
                ImageUrl = "https://uc4ca54fb7ca40986e8b8f88c451.previews.dropboxusercontent.com/p/thumb/ACKgeCFtl152AJ2k9XtJQGtRAHEqRIfM7jo0KanbiupMn0uczxYwhj2lVFgQywNMx2M_-_fF5CYIGoerNj_4Ku0VtuEOA1IFDsDR-yWljzrvGRl_Gbq1g54LysAU7AQo6jo8DLEXkF-l_Y5YEoR6ckKjKdthDdAXs5Skc3gFz43GK6wKtrxh1oRydZmVxNpSlZkizHtdXLlu_mtyE5wiwq1fw38aI40-T-SNiPv16DAzzZ3CNwGeYQr4ydkTnmZE1CBWJPnFpvLHp4BFYi5ZqEPAL65Yjuk1aNGNfHVSDVC13y5Yjxrxwm0iCKoTxyEKFwlMPMuYCt7LU91_JxS5KNV9Z_pddhluzPDVYW9djlcge7Ildagt989vdQ5KIVfIKpM/p.jpeg",
                FoodCategoryId = 5
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Beef Burger",
                Weight = 480,
                Price = 18.00m,
                Description = "Beef burger with french fries, fresh salad, cheddar",
                IsDeleted = false,
                ImageUrl = "https://uc17220967bf29f23b6c13b38b5d.previews.dropboxusercontent.com/p/thumb/ACL5M1i2-xQIBUoh8OjDfV61k3frcehTBdsNnCd7PdfI5j7G0hLZk7ikBn5QWSd6ffCZ6S5P-Uf_N_Ly--KoGcF9KMX9Xzza2FRmtZcWGoSszCjpxuy-vkAj-szuuM21juCdxWGO8ySs_VYeKL8ehnr0EtQPwtg94fSSv7gIt9RmSnb6__rw0E_No2807gohxY4fDMlSSNw0Ws46eNnGRzhbGFLI8RUEoljDYJuMBEY3OGe5PiobUz-ZJRPvcqsJ5pKtMjMg0KXHrbU5m6KXmyviWu7v3_6RLV50BiF4O4d9gYUtGiSRw3ivFvqLRIA6OarRh5VARN_VexvQL2l4QfxhmRgmUfUnX-OOhzrkDrfLmRqxgcPP-sA0K3Npmf7g-uw/p.jpeg",
                FoodCategoryId = 6
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Pork Burger",
                Weight = 430,
                Price = 14.00m,
                Description = "Pork burger with fresh salad and cheddar",
                IsDeleted = false,
                ImageUrl = "https://uc00118cfd0f097611e1a69be5b8.previews.dropboxusercontent.com/p/thumb/ACIol-2h3GRxD4q7LduTyOiUVKUdr0ojliXmlnDHy8LMnfrWjW9lzx8JK6RBkYc9rLnIiiwvKIAYA9evVo6hNSEdVoxtrP2bCQYCZvZhMGm3pS1Ujfl5TFvsMbIpSaCGz4wUOutqPzBgaMUesukkE2hxofeI34xe21v5K0PD5LuH9BuoriPbyeo18uyk9oY8v6anJ5J87tPm6dRkZwEMYbeNR5k5suN06LZZaVhHogOCkaADzcGSyWheuzqZCcyGSwAger5z9jWgCjQwmsL8ZfGmeh2UDaPuBLi9AJg_7HzqB-FrFsyOnbfKp5baoI7pwJpWcyo3zgQ6vQcZDgsVrsqzUNg3X1pdTEP9rnk0krKYqfeern8stsG-4uykUyf7crs/p.jpeg",
                FoodCategoryId = 6
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Souffle",
                Weight = 250,
                Price = 6.50m,
                Description = "Chocolate souffle with vanilla ice cream",
                IsDeleted = false,
                ImageUrl = "https://uc31c341bac4c8dff3b1f6e7579c.previews.dropboxusercontent.com/p/thumb/ACJe_LLzgMDglq82shvZPrtv7ZWG6fSqYWhvFvmMLUhnmGGSTpOXcEPgURMerFzseILhJyfLZ_WCUkOZx4STKJFnnMlLyPbWW4hhyHNvuHDIiZ5Dzlfd9BjyYTe2S5dxKm6WKurVUc7F-cDMI448cxBdbbS3iZcT6zVI0IN3VXJQ84dGwNXVc68lv2NeAhB2JC9rGSt4AKEQ3JCqp-WGNO0ptYy11J0-Gh8P2DK5Ey0pmPDSuWXV8PgHC1c7V57E9bnQokXs36FJvT2ajcfdqdKL1WCP3UfqMkegnHZZ5FS78eP9GsYU8_DJ9mbO5fJlK5b9lLpb93I_H77rBeXBfJuJ4FT1QYkNMIT_SNFEGmZVxJGAmya56wO8c0b7kVdNQOM/p.jpeg",
                FoodCategoryId = 7
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Tiramisu",
                Weight = 300,
                Price = 6.90m,
                Description = "Consists of layers of coffee-soaked ladyfinger biscuits, a creamy mixture made with mascarpone cheese, flavored with a hint of liqueur, and dusted with cocoa powder on top",
                IsDeleted = false,
                ImageUrl = "https://uc5ad448d6936c53529c16e9879d.previews.dropboxusercontent.com/p/thumb/ACKhdiZLzFFfXVMBrcH799jpf4e_anEbvZA7CCbGZsmM_xblbYTf2QNGTRj5Xxpq6QbmuVjRK-2lHQNaOQLH65Tl6HLWRwEqT5UUw7pnQpOhOx0uKsp2Lgn10Stmt7dUSI61AJomOPjjH4ilYlrpYxQWq-bU3qaN7Wmw5YgIdy7ptoCds7JSSQKrBqKONtmiUPJvsw5dtAgTank0XIaCYmJ5VJMsL-9yKDGixmt7UTzAvGt19XlqtDNnfz_x0wJPE4xYRAPvSWlCGqpSD1qETUBeyNeXYsZz1sRX-u37B4TPyhAkLMz_NU1gqEbQ-QxBAYT25-_KYgOCcRZycyGCFD-s-SKFztWUZSIXlhW8MY0lSbVxt5htivuH3lSLh35NWlE/p.jpeg",
                FoodCategoryId = 7
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Garash",
                Weight = 200,
                Price = 5.90m,
                Description = "Cake with intense chocolate flavor and smooth, creamy texture",
                IsDeleted = false,
                ImageUrl = "https://uca877bca878e5176ff6310a93ab.previews.dropboxusercontent.com/p/thumb/ACKzy2SwRzAVQ1fkwtO9BzwBMISMJiGH4LSWuSbukVJAkFt0E3E1vFBboo1jJe6mkF6p2wWqL8XlTiA_xQ43-eviL_631m1FP8Wz-nGwVfL-GHHZqbP8sMMT68FdZc6Gc4I8GuuGc2i8igODZhkqAKwf5_RkUEyjIQZFEoF0R6l3Yo4PIoKnvNz8UK8H3Wx2KZuFsS60cq-f31sTqXJGAIMd4xLjJaULroq5AoySXiklsO-9uB3U8KsPJ0VLXDpFSNzvjnP5jWik48UeJ5A5Day8lIGJkjFFWRLxkYoMG31KSFGYpzrohlfFfcoTyc-4GoUXxtQhz0QG3iGsK96bivNRbJQxnwVOMhQb4vJZBL_2irx8WBSONziRlfhW0frg7DE/p.jpeg",
                FoodCategoryId = 7
            };
            foodCollection.Add(food);

            return foodCollection.ToArray();
        }
    }
}
