namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInstructorRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructor", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Instructor", new[] { "Role_Id" });
            DropColumn("dbo.Instructor", "Role_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructor", "Role_Id", c => c.Int());
            CreateIndex("dbo.Instructor", "Role_Id");
            AddForeignKey("dbo.Instructor", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
