namespace ExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Guid(nullable: false),
                        BankId = c.Guid(nullable: false),
                        AccountNumber = c.String(),
                        AccountType = c.String(),
                        RoutingNumber = c.String(),
                        FriendlyName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.BankAccountId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.Guid(nullable: false),
                        Name = c.String(),
                        FriendlyName = c.String(),
                        BankUserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BankId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Banks");
            DropTable("dbo.BankAccounts");
        }
    }
}
