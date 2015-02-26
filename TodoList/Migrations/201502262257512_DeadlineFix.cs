namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeadlineFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoTasks", "HasDeadline", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoTasks", "HasDeadline");
        }
    }
}
