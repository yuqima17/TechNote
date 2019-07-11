namespace TechNote.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCreateDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CodingLanguages", "createdAt", c => c.String());
            AlterColumn("dbo.Notes", "createdAt", c => c.String());
            AlterColumn("dbo.NoteTypes", "createdAt", c => c.String());
            AlterColumn("dbo.NoteUsers", "createdAt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NoteUsers", "createdAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.NoteTypes", "createdAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Notes", "createdAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.CodingLanguages", "createdAt", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
