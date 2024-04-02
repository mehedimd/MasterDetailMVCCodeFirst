namespace MvcMasterDetail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculties", "FacultyName", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "CourseName", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "PicPath", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentName", c => c.String());
            AlterColumn("dbo.Faculties", "PicPath", c => c.String());
            AlterColumn("dbo.Faculties", "CourseName", c => c.String());
            AlterColumn("dbo.Faculties", "FacultyName", c => c.String());
        }
    }
}
