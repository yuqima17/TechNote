namespace TechNote.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodingLanguages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        createdAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        dateModified = c.String(),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        NoteContent = c.String(maxLength: 2000),
                        CodingLanguage = c.String(),
                        Type = c.String(),
                        createdAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
            DropTable("dbo.CodingLanguages");
        }
    }
}
