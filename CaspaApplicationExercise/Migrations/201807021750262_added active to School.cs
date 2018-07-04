namespace CaspaApplicationExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedactivetoSchool : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schools", "PrerequisiteId", "dbo.Prerequisites");
            DropIndex("dbo.Schools", new[] { "PrerequisiteId" });
            AddColumn("dbo.Prerequisites", "SchoolId", c => c.Int(nullable: false));
            CreateIndex("dbo.Prerequisites", "SchoolId");
            AddForeignKey("dbo.Prerequisites", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
            DropColumn("dbo.Schools", "PrerequisiteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schools", "PrerequisiteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Prerequisites", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Prerequisites", new[] { "SchoolId" });
            DropColumn("dbo.Prerequisites", "SchoolId");
            CreateIndex("dbo.Schools", "PrerequisiteId");
            AddForeignKey("dbo.Schools", "PrerequisiteId", "dbo.Prerequisites", "Id", cascadeDelete: true);
        }
    }
}
