using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Partosazancnc.Models
{
    public class MyContext:DbContext
    {
        public DbSet<LinkManager> LinkManagers { get; set; }
        public DbSet<VisitorLogs> VisitorLogses { get; set; }
        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }
        public DbSet<Brands> Brandses { get; set; }
        public DbSet<Users> Userses { get; set; }
        public DbSet<Roles> Roleses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Pages> Pageses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttachFile> ProductAttachFiles { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Faqs> Faqses { get; set; }
        public DbSet<UserFaqs> UserFaqses { get; set; }
        public DbSet<PostComments> PostCommentses { get; set; }
        public DbSet<Sliders> Sliderses { get; set; }
        public DbSet<LayerSliders> LayerSliderses { get; set; }
        public DbSet<ProductComments> ProductCommentses { get; set; }
        public DbSet<NewsLetterList> NewsLetterLists { get; set; }
        public DbSet<NewsLetters> NewsLetterses { get; set; }
        public DbSet<NewsLetterMember> NewsLetterMembers { get; set; }
        public DbSet<NewsLettersMail> NewsLettersMails { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}