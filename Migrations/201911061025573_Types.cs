namespace RandomizerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Types : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        From = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        ReqUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReqUser_Id)
                .Index(t => t.ReqUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        LastAccess = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "ReqUser_Id", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "ReqUser_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
        }
    }
}
