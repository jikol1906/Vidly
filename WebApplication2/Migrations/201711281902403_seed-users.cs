namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
          Sql(@"
            
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'324a2e4a-fc81-42fc-91e4-3559444dbe19', N'borisgrunwald@gmail.com', 0, N'AFOnFpXg0XvhnonpCjs7QHYXv2auG6nCVYA8gZOVgjK0kT3OWDKGv43cl7yc99E/og==', N'd5be7e94-82ae-46bd-8806-758668156618', NULL, 0, 0, NULL, 1, 0, N'borisgrunwald@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9bb7c4de-dd3b-4d16-8774-6a200fe4dbb7', N'admin@vidly.com', 0, N'ADKkbZB5tMX7iOvNxCrEJnrDJ3Kz9CJvcl1PgBi8rShHJaGc3SVOMzVUJLU77hBQSg==', N'137ee503-f3f2-4f79-ac09-57c81b6c98b7', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'468e6624-d4dd-4ef4-939d-9de379f014b3', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9bb7c4de-dd3b-4d16-8774-6a200fe4dbb7', N'468e6624-d4dd-4ef4-939d-9de379f014b3')

            ");

            Console.WriteLine("Updated");
        }

        public override void Down()
        {
        }
    }
}
