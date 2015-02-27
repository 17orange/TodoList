namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeadlineFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoTasks", "Name", c => c.String());
            AlterColumn("dbo.TodoTasks", "Description", c => c.String());
            AlterColumn("dbo.TodoTasks", "DeadlineTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoTasks", "DeadlineTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TodoTasks", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.TodoTasks", "Name", c => c.String(nullable: false));
        }
    }
}
