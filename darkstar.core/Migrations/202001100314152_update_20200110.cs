namespace darkstar.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_20200110 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentIDNo = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Meeting = c.Int(),
                        TeacherIDNo = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
        }
    }
}
