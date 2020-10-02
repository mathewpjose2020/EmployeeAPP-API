namespace EmployeeAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeedbV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "name", c => c.String());
            AddColumn("dbo.Employees", "gender", c => c.String());
            AddColumn("dbo.Employees", "email", c => c.String());
            AddColumn("dbo.Employees", "phoneNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Employees", "contactPreference", c => c.String());
            AddColumn("dbo.Employees", "dateOfBirth", c => c.String());
            AddColumn("dbo.Employees", "department", c => c.String());
            AddColumn("dbo.Employees", "isActive", c => c.String());
            AddColumn("dbo.Employees", "photoPath", c => c.String());
            DropColumn("dbo.Employees", "username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "username", c => c.String());
            DropColumn("dbo.Employees", "photoPath");
            DropColumn("dbo.Employees", "isActive");
            DropColumn("dbo.Employees", "department");
            DropColumn("dbo.Employees", "dateOfBirth");
            DropColumn("dbo.Employees", "contactPreference");
            DropColumn("dbo.Employees", "phoneNumber");
            DropColumn("dbo.Employees", "email");
            DropColumn("dbo.Employees", "gender");
            DropColumn("dbo.Employees", "name");
        }
    }
}
