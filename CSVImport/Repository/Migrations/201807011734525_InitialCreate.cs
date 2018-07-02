namespace Repository.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalId = c.String(nullable: false, maxLength: 50),
                        TradingName = c.String(nullable: false),
                        CompanyType = c.Int(nullable: false),
                        Unused = c.Boolean(nullable: false),
                        IsForwarder = c.Boolean(nullable: false),
                        Phone = c.String(maxLength: 50),
                        Fax = c.String(maxLength: 50),
                        AddressId = c.Int(),
                        MailAddressId = c.Int(),
                        IsCustomClarance = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsCarrier = c.Boolean(nullable: false),
                        IsWarehouse = c.Boolean(nullable: false),
                        ChamberOfCommerce = c.String(),
                        ChamberOfCommerceCi = c.String(),
                        CountryVAT = c.String(),
                        IsExchangeBroker = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Company");
        }
    }
}
