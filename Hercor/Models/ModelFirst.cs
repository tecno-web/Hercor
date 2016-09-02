namespace Hercor.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Reflection;

    public class ModelFirst : DbContext
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        public DbSet<CategoryProductPivot> CategoryProductPivot { get; set; }

        public ModelFirst()
            : base("name=ModelFirst")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    public class ArticlesMap : EntityTypeConfiguration<Article>
    {
       public ArticlesMap()
        {
            HasKey(p=>p.ArticleId);
            Property(p=>p.Name).HasColumnType("varchar").IsRequired();
            Property(p=>p.Content).HasColumnType("varchar").IsRequired().HasMaxLength(500);
            Property(p=>p.Create);
            Property(p=>p.Update);
        }
    }
    public class CategorysMap : EntityTypeConfiguration<Category>
    {
        public CategorysMap()
        {
            HasKey(p=>p.CategoryId);
            Property(p=>p.Name).HasColumnType("varchar").IsRequired();
            Property(p=>p.Description).HasColumnType("varchar").IsOptional().HasMaxLength(500);
        }
    }
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(p=>p.ProductId);
            Property(p=>p.Title).IsRequired();
            Property(p=>p.Description).IsRequired().HasColumnType("varchar").HasMaxLength(500);
            Property(p=>p.Content);
            Property(p=>p.Slug);
            Property(p => p.Image).IsOptional();
            Property(p=>p.Page);
            Property(p => p.Eliminate);
        }
    }
    public class ArticleCategoryMap : EntityTypeConfiguration<ArticleCategory>
    {
        public ArticleCategoryMap()
        {
            HasKey(x=>new { x.ArticleId,x.CategoryId});
        }
    }
    public class CategoryProductMap : EntityTypeConfiguration<CategoryProduct>
    {
        public CategoryProductMap()
        {
            HasKey(p=>p.IdCategoryProduct);
            Property(p=>p.Name).IsRequired();
            Property(p=>p.Description);
            Property(p=>p.slug).IsRequired();
        }
    }
    public class CategoryProductPivotMap : EntityTypeConfiguration<CategoryProductPivot>
    {
        public CategoryProductPivotMap()
        {
            HasKey(p => new { p.ProductId, p.IdCategoryProduct });
        }
    }
    public class BannerMap : EntityTypeConfiguration<Banner>
    {
        public BannerMap()
        {
            HasKey(p=>p.BannerId);
            Property(p=>p.Image);
            Property(p=>p.Eliminate);
        }
    }
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            HasKey(p => p.ImageId);
            Property(p => p.ImageProduct);
            
        }
    }
}