namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCopies",
                c => new
                    {
                        BookCopyID = c.Int(nullable: false, identity: true),
                        NumberOfCopies = c.Int(nullable: false),
                        FK_Book = c.Int(nullable: false),
                        FK_Library = c.Int(nullable: false),
                        Book_BookID = c.Int(),
                        Library_LibraryID = c.Int(),
                    })
                .PrimaryKey(t => t.BookCopyID)
                .ForeignKey("dbo.Books", t => t.Book_BookID)
                .ForeignKey("dbo.Libraries", t => t.Library_LibraryID)
                .Index(t => t.Book_BookID)
                .Index(t => t.Library_LibraryID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        YearOfIssue = c.Int(nullable: false),
                        NumberOfPages = c.Int(nullable: false),
                        FK_Publisher = c.Int(nullable: false),
                        Publisher_PublisherID = c.Int(),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Publishers", t => t.Publisher_PublisherID)
                .Index(t => t.Publisher_PublisherID);
            
            CreateTable(
                "dbo.Lendings",
                c => new
                    {
                        LendingID = c.Int(nullable: false, identity: true),
                        DateLending = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        FK_Book = c.Int(nullable: false),
                        FK_Client = c.Int(nullable: false),
                        Book_BookID = c.Int(),
                        Client_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.LendingID)
                .ForeignKey("dbo.Books", t => t.Book_BookID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .Index(t => t.Book_BookID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.PublisherID);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        LibraryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.LibraryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookCopies", "Library_LibraryID", "dbo.Libraries");
            DropForeignKey("dbo.Books", "Publisher_PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.Lendings", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.Lendings", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.BookCopies", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Lendings", new[] { "Client_ClientID" });
            DropIndex("dbo.Lendings", new[] { "Book_BookID" });
            DropIndex("dbo.Books", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.BookCopies", new[] { "Library_LibraryID" });
            DropIndex("dbo.BookCopies", new[] { "Book_BookID" });
            DropTable("dbo.Libraries");
            DropTable("dbo.Publishers");
            DropTable("dbo.Clients");
            DropTable("dbo.Lendings");
            DropTable("dbo.Books");
            DropTable("dbo.BookCopies");
        }
    }
}
