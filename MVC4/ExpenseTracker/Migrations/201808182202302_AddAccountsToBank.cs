namespace ExpenseTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountsToBank : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "BankStatus", c => c.String());
            AlterColumn("dbo.Banks", "Name", c => c.String(nullable: false, maxLength: 1024));
            AlterColumn("dbo.Banks", "FriendlyName", c => c.String(maxLength: 1024));
            CreateIndex("dbo.BankAccounts", "BankId");
            AddForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks", "BankId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks");
            DropIndex("dbo.BankAccounts", new[] { "BankId" });
            AlterColumn("dbo.Banks", "FriendlyName", c => c.String());
            AlterColumn("dbo.Banks", "Name", c => c.String());
            DropColumn("dbo.Banks", "BankStatus");
        }
    }
}
