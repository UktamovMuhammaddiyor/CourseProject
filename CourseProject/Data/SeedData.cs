using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Data
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (context.Reviews.Count() == 0)
            {
                Review review1 = new Review
                {
                    RiviewName = "Avatar 2: Suv yo‘li",
                    Description = " \"Avatar 2: Suv yo'li\" filmi yilning eng kassabop filmiga aylandi!\r\n\r\n“Avatar 2: Suv yo‘li” “Top Gan: Maverik” filmini yangi yilning birinchi haftasi oxiriga kelib ortda qoldirib, 2022-yilning eng yuqori daromad keltiruvchi kinoloyihasiga aylanadi. \r\n\r\nShunday qilib “Avatar-2” 1,5 milliard dollarlik natijani qayd etdi va bu 1.49 milliard dollar olib kelgan harbiy trillerni ortda qoldirish uchun yetarli bo‘ldi.\nBir nechta blokbasterlar mavjudligiga qaramay, ushbu yil Amerika kinoteatrlari pandemiyadan oldingi davrlarga nisbatan juda yomon yil bo‘ldi. Shunday qilib, Shimoliy Amerikadagi jamlangan kassa 2022-yil oxiriga kelib 7,46 milliard dollarga yetdi, bu Marvel komikslari asosidagi filmlar kassada ustunlik qilgan 2019 yildagi 11,4 milliard dollar ko‘rsatkichidan ancha kam.",
                    Group = "Movie",
                    Grade = 7,
                    Tags = "#movie",
                    createdTime = DateTime.Now,
                    ImageUrl = "http://kinochi.net/uploads/posts/2023-01/film-avatar-2-merilis-cuplikan-resmi_220510082209-275.jpg",
                };

                context.Reviews.Add(review1);
                context.SaveChanges();
            }
        }
    }
}
