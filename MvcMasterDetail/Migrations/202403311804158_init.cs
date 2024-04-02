namespace MvcMasterDetail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(),
                        CourseName = c.String(),
                        CourseStartDate = c.DateTime(nullable: false),
                        PicPath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Address = c.String(),
                        FacultyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: true)
                .Index(t => t.FacultyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "FacultyID", "dbo.Faculties");
            DropIndex("dbo.Students", new[] { "FacultyID" });
            DropTable("dbo.Students");
            DropTable("dbo.Faculties");
        }
    }
}
