using AmKart.Services.Product.Queries;
using AmKart.Services.Products.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AmKart.Services.Product.Seed
{
    public static class ProductsSeeder
    {
        public async static void SeedProductsAsync(this IApplicationBuilder app)
        {
            var productsRepository = app.ApplicationServices.GetRequiredService<IProductsRepository>();

            var existingProducts = productsRepository.BrowseAsync(new BrowseProducts() {
                Category = "female"
            });

            if (existingProducts.Result.IsEmpty)
            {
                foreach (var product in GetProducts())
                {
                    await productsRepository.AddAsync(product);
                }
            }
        }

        static IEnumerable<Products.DomainEntities.Product> GetProducts()
        {
            return new List<Products.DomainEntities.Product>()
            {
                new Products.DomainEntities.Product(
                    new System.Guid("3c44a13b-b00f-47e6-85d4-ccd42f60a650"),
                    "The Womens Responsible Flannel",
                    "Cloud nine soft. Our signature brushed organic and recycled blend is a fall staple you won't want to take off. 59% organic cotton, 39% recycled polyester, 2% spandex. Machine wash. 6.8oz brushed flannel, Point collar with full front corozo button placket, Long sleeves with adjustable button cuffs, Double chest pockets",
                    899,
                    "female",
                    new string[] { @"/Images/Female/Cardigan_Brown.jpg", @"/Images/Female/Cardigan_Grey.jpg", @"/Images/Female/Cardigan_Blue.jpg" },
                    new string[] { "#D2A8B0", "#55552E", "#6A95C1" }),

                new Products.DomainEntities.Product(
                    new System.Guid("90fcc119-5038-4cd1-994f-5cd216951ca1"),
                    "Organic Cotton Crew Sweater",
                    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signuture Eco-Fleece, this pant features tailored pockets and a tapered leg opening.",
                    1499,
                    "female",
                    new string[] { @"/Images/Female/Trouser_Black.jpg", @"/Images/Female/Trouser_Grey.jpg"},
                    new string[] { "#2D2C33", "#868588" }),

                new Products.DomainEntities.Product(
                    new System.Guid("6cac50c2-7e31-43e2-a4fd-98238a6820ad"),
                    "Recycled Cotton Cardigan",
                    "A cozy, perfectly-oversized cardigan that's made for lounging around or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    599,
                    "female",
                    new string[] { @"/Images/Female/Cardigan_White.jpg", @"/Images/Female/Cardigan_Black.jpg"},
                    new string[] { "#2D2C33", "#868588" }),

                new Products.DomainEntities.Product(
                    new System.Guid("b2f06079-4004-4959-964d-e8839fc9162c"),
                    "The Women's Bison Ultralight",
                    "A cozy, perfectly-oversized cardigan that's for lounging around or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    1899,
                    "female",
                    new string[] { @"/Images/Female/Jacket_Red.jpg", @"/Images/Female/Jacket_Grey.jpg"},
                    new string[] { "#E40B27", "#C29681" }),

                new Products.DomainEntities.Product(
                    new System.Guid("6429a58c-c45a-4dec-9f66-bf388f8637a8"),
                    "Women's Organic Cotton Crew Sweater",
                    "A cozy, perfectly-oversized cardigan that's made for lounging or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    1999,
                    "female",
                    new string[] { @"/Images/Female/Hoodie_Brown.jpg", @"/Images/Female/Hoodie_Black.jpg", @"/Images/Female/Hoodie_Red.jpg"},
                    new string[] { "#FFF", "black", "#85333A" }),

                new Products.DomainEntities.Product(
                    new System.Guid("0ebcfbc8-1bf9-433a-8191-8cace32af36c"),
                    "Women's Recycled Rain Shell",
                    "Cloud nine soft. Our signature brushed organic and recycled blend is a fall staple won't want to take off. 59% organic cotton, 39% recycled polyester, 2% spandex. Machine wash. 6.8oz brushed flannel, Point collar with full front corozo button placket, Long sleeves with adjustable button cuffs, Double chest pockets",
                    1299,
                    "female",
                    new string[] { @"/Images/Female/Shawl_Green.jpg", @"/Images/Female/Jacket_Blue.jpg"},
                    new string[] { "#D2A8B0", "#55552E" }),

                new Products.DomainEntities.Product(
                    new System.Guid("001b0bcc-18c5-4fcd-91dc-ec787215aeee"),
                    "Women's Eco-Fleece Joggers",
                    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signature Eco-Fleece, this pant features tailored pockets.",
                    1699,
                    "female",
                    new string[] { @"/Images/Female/Shawl_Multicolor.jpg", @"/Images/Female/Jacket_Maroon.jpg"},
                    new string[] { "#2D2C33", "#868588" }),

                //new Products.DomainEntities.Product(
                //    new System.Guid("b6665d4d-5692-48e5-b65c-010ee05cfede"),
                //    "Women's Eco-Fleece Jogger Pants",
                //    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signature Eco-Fleece, this pant features tailored pockets and a tapered leg opening.",
                //    499,
                //    "female",
                //    new string[] { @"/Images/Sweater_Green.jpg", @"/Images/Sweater_White.jpg"},
                //    new string[] { "#E40B27", "#C29681" }),

                new Products.DomainEntities.Product(
                    new System.Guid("be143681-5563-46ed-9623-1b6a45e8898c"),
                    "Men's EcoKnit™ Striped Pocket Tee",
                    "Cloud nine soft. Our signature brushed organic and recycled blend is a fall staple you won't want to take off. 59% organic cotton, 39% recycled polyester, 2% spandex. Machine wash. 6.8oz brushed flannel, Point collar with full front corozo button placket, Long sleeves with adjustable button cuffs, Double chest pockets",
                    699,
                    "male",
                    new string[] { @"/Images/Male/Cardigan_White.jpg", @"/Images/Male/TShirt_Blue.jpg", "" },
                    new string[] { "#D2A8B0", "#55552E" }),

                new Products.DomainEntities.Product(
                    new System.Guid("fd94220b-b12c-4eb7-8eb2-951496420830"),
                    "Men's EcoKnit™ Pocket Tee",
                    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signuture Eco-Fleece, this pant features tailored pockets and a tapered leg opening.",
                    1899,
                    "male",
                    new string[] { @"/Images/Male/Shirt_Blue.jpg", @"/Images/Male/Shirt_White.jpg" },
                    new string[] { "#2D2C33", "#868588" }),

                new Products.DomainEntities.Product(
                    new System.Guid("9dea70cc-c678-4dfe-86d0-0f90ee478c21"),
                    "Recycled Cotton Cardigan",
                    "A cozy, perfectly-oversized cardigan that's made for lounging around or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    1199,
                    "male",
                    new string[] { @"/Images/Male/Overcoat_Blue.jpg", @"/Images/Male/Overcoat_Red.jpg", @"/Images/Male/Shirt_BlackWhite.jpg" },
                    new string[] { "#FFF", "black", "#85333A" }),

                new Products.DomainEntities.Product(
                    new System.Guid("8af3ef70-2bf8-41be-ae96-0fd908b15e98"),
                    "The Men's Bison Ultralight",
                    "A cozy, perfectly-oversized cardigan that's for lounging around or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    1999,
                    "male",
                    new string[] { @"/Images/Male/Shirt_BlueCheck.jpg", @"/Images/Male/Cardigan_Green.jpg" },
                    new string[] { "#D2A8B0", "#55552E" }),

                new Products.DomainEntities.Product(
                    new System.Guid("afd2d45d-d224-487e-af22-ed64534de258"),
                    "The Men's Responsible Flannel",
                    "A cozy, perfectly-oversized cardigan that's made for lounging or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    2199,
                    "male",
                    new string[] { @"/Images/Male/Jeans_Green.jpg", @"/Images/Male/Jacket_Black.jpg" },
                    new string[] { "#2D2C33", "#868588" }),

                new Products.DomainEntities.Product(
                    new System.Guid("ad23f3aa-77ca-4ffb-b377-97667a9b5ac4"),
                    "Organic Plaid Button Down",
                    "Cloud nine soft. Our signature brushed organic and recycled blend is a fall staple won't want to take off. 59% organic cotton, 39% recycled polyester, 2% spandex. Machine wash. 6.8oz brushed flannel, Point collar with full front corozo button placket, Long sleeves with adjustable button cuffs, Double chest pockets",
                    1399,
                    "male",
                    new string[] { @"/Images/Male/Shirt_BlueCheck.jpg", @"/Images/Male/TShirt_LightBlue.jpg"},
                    new string[] { "#E40B27", "#C29681" }),

                new Products.DomainEntities.Product(
                    new System.Guid("cb800072-97da-49a8-85db-f830603c69ed"),
                    "Organic Canvas Work Pant",
                    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signature Eco-Fleece, this pant features tailored pockets.",
                    1299,
                    "male",
                    new string[] { @"/Images/Male/Shirt_Grey.jpg", @"/Images/Male/Shirt_OffWhite.jpg", @"/Images/Male/Shirt_Green.jpg" },
                    new string[] { "#D2A8B0", "#55552E", "#6A95C1" }),

                new Products.DomainEntities.Product(
                    new System.Guid("0069bf80-fbf4-4ef7-bf38-814620349f30"),
                    "Organic Cotton Crew Sweater",
                    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signature Eco-Fleece, this pant features tailored pockets and a tapered leg opening.",
                    1799,
                    "male",
                    new string[] { @"/Images/Male/Cardigan_Green.jpg", @"/Images/Male/Shirt_BlueWhite.jpg" },
                    new string[] { "#2D2C33", "#868588" }),



































                new Products.DomainEntities.Product(
                    new System.Guid("3a1794d5-28bb-448a-ab00-53b27f15e3ba"),
                    "Pocket Pouch",
                    "Made from recycled plastic bottles, 100% vegan, water-resistant, and stain resistant.",
                    299,
                    "accessories",
                    new string[] { @"/Images/Accessories/Pouch_Blue.jpg", @"/Images/Accessories/Pouch_BlueOrange.jpg" },
                    new string[] { "#7984a0", "#4C6992" }),

                new Products.DomainEntities.Product(
                    new System.Guid("a76d3fcc-c53d-4d52-9570-7e79d120144c"),
                    "Men's EcoKnit™ Pocket Tee",
                    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signuture Eco-Fleece, this pant features tailored pockets and a tapered leg opening.",
                    399,
                    "accessories",
                    new string[] { @"/Images/Accessories/Cap_Orange.jpg", @"/Images/Accessories/Cap_Black.jpg", @"/Images/Accessories/Cap_Brown.jpg" },
                    new string[] { "#E34226", "#EAB172", "#48454A" }),

                new Products.DomainEntities.Product(
                    new System.Guid("340d57f8-9ed5-433b-b486-6a2441560538"),
                    "Recycled Cotton Cardigan",
                    "A cozy, perfectly-oversized cardigan that's made for lounging around or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    249,
                    "accessories",
                    new string[] { @"/Images/Accessories/Organizer_Brown.jpg", @"/Images/Accessories/Organizer_Yellow.jpg" },
                    new string[] { "black", "#85333A" }),

                new Products.DomainEntities.Product(
                    new System.Guid("05f5c4f2-8636-4573-b03e-0e940e8dfcbc"),
                    "The Men's Bison Ultralight",
                    "A cozy, perfectly-oversized cardigan that's for lounging around or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    399,
                    "accessories",
                    new string[] { @"/Images/Accessories/Organizer_Yellow.jpg", @"/Images/Accessories/Organizer_Brown.jpg"},
                    new string[] { "#073266", "#D99C06" }),

                new Products.DomainEntities.Product(
                    new System.Guid("859a0533-3a2b-4cfd-bac9-c509f88785ba"),
                    "The Slip-On - Honey Rubber Sole",
                    "A cozy, perfectly-oversized cardigan that's made for lounging or dressing up. Made from 100% recycled cotton (meaning it was once fabric on the cutting room floor).",
                    499,
                    "accessories",
                    new string[] { @"/Images/Accessories/Slipper_White.jpg", @"/Images/Accessories/Slipper_Green.jpg" },
                    new string[] { "#2D2C33", "#868588" }),

                new Products.DomainEntities.Product(
                    new System.Guid("e22bf7e3-d559-4166-a933-da9442a9a496"),
                    "Organic Plaid Button Down",
                    "Cloud nine soft. Our signature brushed organic and recycled blend is a fall staple won't want to take off. 59% organic cotton, 39% recycled polyester, 2% spandex. Machine wash. 6.8oz brushed flannel, Point collar with full front corozo button placket, Long sleeves with adjustable button cuffs, Double chest pockets",
                    249,
                    "accessories",
                    new string[] { @"/Images/Accessories/Cap_Grey.jpg", @"/Images/Accessories/Cap_White.jpg" },
                    new string[] { "#E40B27", "#C29681" }),

                new Products.DomainEntities.Product(
                    new System.Guid("3a4d1ac4-7ac3-4dba-8baf-0c21f1226fbe"),
                    "Organic Canvas Work Pant",
                    "The ultimate sweat pant for ultimate comfort (aka your daily work-from-home uniform). Made from signature Eco-Fleece, this pant features tailored pockets.",
                    199,
                    "accessories",
                    new string[] { @"/Images/Accessories/Belt_Yellow.jpg", @"/Images/Accessories/Belt_Blue.jpg" },
                    new string[] { "#CF733A", "blue" }),
            };
        }
    }
}
