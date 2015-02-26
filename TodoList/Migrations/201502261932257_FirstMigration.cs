namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoTasks",
                c => new
                    {
                        TodoTaskID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable:false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        DeadlineTime = c.DateTime(nullable: true),
                        StatusID = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TodoTaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoTasks");
        }
    }
}
