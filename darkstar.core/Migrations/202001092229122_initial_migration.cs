namespace darkstar.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeCode = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        DepartmentCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeCode)
                .ForeignKey("dbo.Department", t => t.DepartmentCode)
                .Index(t => t.DepartmentCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentCode", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentCode" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
