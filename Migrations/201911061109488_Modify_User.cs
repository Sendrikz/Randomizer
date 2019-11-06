namespace RandomizerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_User : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "ReqUser_Id", "dbo.Users");
            DropPrimaryKey("dbo.Requests");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Requests", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Requests", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.Requests", "ReqUser_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "ReqUser_Id", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Requests");
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Login", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Requests", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Requests", "Id");
            AddForeignKey("dbo.Requests", "ReqUser_Id", "dbo.Users", "Id");
        }
    }
}
