namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateIndex("dbo.TodoTasks", "StatusID");
            AddForeignKey("dbo.TodoTasks", "StatusID", "dbo.Status", "StatusID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoTasks", "StatusID", "dbo.Status");
            DropIndex("dbo.TodoTasks", new[] { "StatusID" });
            DropTable("dbo.Status");
        }
    }
}
