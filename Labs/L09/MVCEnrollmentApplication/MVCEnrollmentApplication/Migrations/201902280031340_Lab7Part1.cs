namespace MVCEnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lab7Part1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollments", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollments", "Notes");
        }
    }
}
