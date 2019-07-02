namespace TechNote.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noteType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoteTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        createdAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notes", "NoteType", c => c.String());
            DropColumn("dbo.Notes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Type", c => c.String());
            DropColumn("dbo.Notes", "NoteType");
            DropTable("dbo.NoteTypes");
        }
    }
}
