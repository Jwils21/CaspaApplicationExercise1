namespace CaspaApplicationExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprerequisites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prerequisites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Schools", "PrerequisiteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schools", "PrerequisiteId");
            AddForeignKey("dbo.Schools", "PrerequisiteId", "dbo.Prerequisites", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "PrerequisiteId", "dbo.Prerequisites");
            DropIndex("dbo.Schools", new[] { "PrerequisiteId" });
            DropColumn("dbo.Schools", "PrerequisiteId");
            DropTable("dbo.Prerequisites");
        }
    }
}
