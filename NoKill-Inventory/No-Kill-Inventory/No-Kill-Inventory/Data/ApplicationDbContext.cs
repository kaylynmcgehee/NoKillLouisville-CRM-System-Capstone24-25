using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace No_Kill_Inventory.Data;

/**
 * This is the DbContext, it is how the program talks to the database, instead of using SQL
 */
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    // When starting, tell the program to use SQLite and where the .db file is located in the project
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=data/app.db");
    }
    // Telling the context what the tables that have been created are
    public DbSet<OtherItem> OtherItems { get; set; }
    public DbSet<CatItem> CatItems { get; set; }
    public DbSet<DogItem> DogItems { get; set; }

    public DbSet<Volunteer> Volunteers { get; set; }
    
    public DbSet<Recipient> Recipients { get; set; }
    
    public DbSet<Pet> Pets { get; set; }
    
    // When the model (schema) is created, do these things
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Creating an object to hash passwords
        var hasher = new PasswordHasher<IdentityUser>();

        // These are unused, but they generated random ID strings
        var adminId = Guid.NewGuid().ToString();
        var adminRoleId = Guid.NewGuid().ToString();
        var userRoleId = Guid.NewGuid().ToString();
        
        /*
         * In the Application user data, create a new user with the below data
         *
         * This creates the admin user
         *
         * Each field (ID, UserName, etc) is a column in the table that the data will go into
         */
        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5", 
                UserName = "adminuser", 
                NormalizedUserName = "ADMINUSER", 
                Email = "adminuser", 
                NormalizedEmail = "ADMINUSER", 
                EmailConfirmed = true, 
                PasswordHash = hasher.HashPassword(null, "noKilladmin2024!"), 
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            }
        );
        
        // In the IdentityRole table, create the Admin role with the below data
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                Name = "Admin",
                NormalizedName = "Admin",
                ConcurrencyStamp = "1"
            }
        );
        
        // In the IdentityROle table, create a User role with the below data
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                Name = "User",
                NormalizedName = "User",
                ConcurrencyStamp = "2"
            }
        );

        // In the IdentityUserRole table, createa a new IdentityUserRole with the below ID's
        // This is so that the Admin role is assigned the correct priveleges
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
               UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
               RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
            }
        );

        modelBuilder.Entity<Recipient>().HasData(
            new Recipient()
            {
                Id = 1,
                FirstName = "Billy",
                LastName = "Madison",
                PhoneNumber = "555-555-5555",
                Email = "billy@gmail.com"
            },
            new Recipient()
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Connor",
                PhoneNumber = "444-123-9876",
                Email = "sarahc@gmail.com"
            },
            new Recipient()
            {
                Id = 3,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "333-456-7890",
                Email = "johndoe@example.com"
            },
            new Recipient()
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "222-654-3210",
                Email = "janesmith@hotmail.com"
            },
            new Recipient()
            {
                Id = 5,
                FirstName = "Michael",
                LastName = "Scott",
                PhoneNumber = "111-777-8888",
                Email = "mscott@dundermifflin.com"
            });
        
        

        modelBuilder.Entity<DogItem>().HasData(
            new DogItem()
            {
                ItemID = 1,
                Type = "Adult",
                Weight = 0
            });
            
        modelBuilder.Entity<DogItem>().HasData(
            new DogItem()
            {
                ItemID = 2,
                Type = "Puppy",
                Weight = 0
            });
        
        modelBuilder.Entity<DogItem>().HasData(
            new DogItem()
            {
                ItemID = 3,
                Type = "Weight Control",
                Weight = 0
            });
        
        modelBuilder.Entity<DogItem>().HasData(
            new DogItem()
            {
                ItemID = 4,
                Type = "Grain Free",
                Weight = 0
            });
        
        modelBuilder.Entity<DogItem>().HasData(
            new DogItem()
            {
                ItemID = 5,
                Type = "Small Bites",
                Weight = 0
            });
        
        modelBuilder.Entity<DogItem>().HasData(
            new DogItem()
            {
                ItemID = 6,
                Type = "Wet",
                Weight = 0
            });
        
        modelBuilder.Entity<DogItem>().HasData(
            new DogItem()
            {
                ItemID = 7,
                Type = "Special",
                Weight = 0
            });
        
        modelBuilder.Entity<CatItem>().HasData(
            new CatItem()
            {
                ItemID = 1,
                Type = "Adult",
                Weight = 0
            });
        
        modelBuilder.Entity<CatItem>().HasData(
            new CatItem()
            {
                ItemID = 2,
                Type = "Kitty",
                Weight = 0
            });
        
        modelBuilder.Entity<CatItem>().HasData(
            new CatItem()
            {
                ItemID = 3,
                Type = "Wet",
                Weight = 0
            });
        
        modelBuilder.Entity<CatItem>().HasData(
            new CatItem()
            {
                ItemID = 4,
                Type = "Special",
                Weight = 0
            });
        
    }
}