namespace ExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultValues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks");
            DropPrimaryKey("dbo.Banks");
            AlterColumn("dbo.Banks", "BankId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Banks", "BankId");
            AddForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks", "BankId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks");
            DropPrimaryKey("dbo.Banks");
            AlterColumn("dbo.Banks", "BankId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Banks", "BankId");
            AddForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks", "BankId", cascadeDelete: true);
        }
    }
}
