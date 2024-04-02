namespace MvcMasterDetail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculties", "PicPath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faculties", "PicPath", c => c.String(nullable: false));
        }
    }
}
