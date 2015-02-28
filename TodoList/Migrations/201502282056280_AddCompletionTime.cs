namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompletionTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoTasks", "CompletionTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoTasks", "CompletionTime");
        }
    }
}
