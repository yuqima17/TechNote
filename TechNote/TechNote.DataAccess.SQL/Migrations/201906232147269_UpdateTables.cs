namespace TechNote.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "NoteUsers");
            AddColumn("dbo.Notes", "UserEmail", c => c.String());
            AddColumn("dbo.NoteUsers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NoteUsers", "Email");
            DropColumn("dbo.Notes", "UserEmail");
            RenameTable(name: "dbo.NoteUsers", newName: "Users");
        }
    }
}
