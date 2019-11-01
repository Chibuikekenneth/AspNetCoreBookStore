using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreBookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            //seed categories
            modelbuilder.Entity<Category>().HasData(new Category {
                CategoryId = 1,
                CategoryName = "Technical Books"
            });
            
            modelbuilder.Entity<Category>().HasData(new Category {
                CategoryId = 2,
                CategoryName = "Inspirational Books"
            });
            modelbuilder.Entity<Category>().HasData(new Category {
                CategoryId = 3,
                CategoryName = "Religious Books"
            });
            modelbuilder.Entity<Category>().HasData(new Category {
                CategoryId = 4,
                CategoryName = "Novels"
            });


            //seed Books
            modelbuilder.Entity<Book>().HasData(new Book {
                BookId = 1,
                Name = "Software Engineering 9th Edition By Ian Sommerville",
                Author = "Ian Sommerville",
                ShortDescription = "Intended for introductory and advanced courses in software engineering.",

                LongDescription = 
                        "The ninth edition of Software Engineering presents a broad perspective of software engineering, focusing on the processes and techniques fundamental to the creation of reliable, software systems. Increased coverage of agile methods and software reuse, along with coverage of 'traditional' plan-driven software engineering, gives readers the most up-to-date view of the field currently available. Practical case studies, a full set of easy-to-access supplements, and extensive web resources make teaching the course easier than ever.",
                CategoryId = 1,
                ImageUrl = "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/85/579781/1.jpg?8371",
                Instock = true,
                IsBookOftheWeek = true,
                
            });

            modelbuilder.Entity<Book>().HasData(new Book {
                BookId = 2,
                Name = "Rich Dad Poor Dad",
                Author = "Robert T. Kiyosaki",
                ShortDescription = "Explode the myth that you need to earn a high income.",

                LongDescription = 
                        "Explode the myth that you need to earn a high income to become richChallenge the belief that your house is an assetShow parents why they can't rely on the school system to teach their kids about moneyDefine once and for all an asset and a liabilityTeach you what to teach your kids about money for their future financial success.",
                CategoryId = 2,
                ImageUrl = "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/72/039022/1.jpg?8072",
                Instock = true,
                IsBookOftheWeek = true,   
            });

            modelbuilder.Entity<Book>().HasData(new Book {
                BookId = 3,
                Name = " Understanding The Quiet Time (the secret of spiritual strength)",
                Author = "Dag Heward Mills ",
                ShortDescription = "Bishop Dag Heward-Mills, an exceptional Christian leader, reveals one of his secrets.",

                LongDescription = 
                        "Bishop Dag Heward-Mills, an exceptional Christian leader, reveals one of his secrets: 'If anyone were to ask me what the greatest secret of my relationship with God is, I would say, without hesitation, that it is the power of the quiet times I have with Him everyday.' He has decided to write this book.",
                CategoryId = 2,
                ImageUrl = "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/86/89324/1.jpg?1192",
                Instock = true,
                IsBookOftheWeek = true,   
            });

             modelbuilder.Entity<Book>().HasData(new Book {
                BookId = 4,
                Name = " University Entrance Practice Software (For UTME)",
                Author = "STP Information Services Ltd",
                ShortDescription = "UTME CBT Exam Software",

                LongDescription = 
                        "UTME CBT Exam Software. JPro can set exam, mark it, score you and monitor your progress.It also includes Maths tutor, Grammar tutor and more. You can also use it as a Mock Exam simulator.",
                CategoryId = 2,
                ImageUrl = "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/86/89324/1.jpg?1192",
                Instock = true,
                IsBookOftheWeek = true,   
            });
        }
    }
}
