# MVC5
Hi , this program is a simple clean MVC structure, which give you a good advice for building up your MVC applications. There are no copyright issue and anyone welcome to copy or modify it. I hope you can get some inspiration from my code. Thanks.

This is the code first program and to initalize it you need to do execute bellow code.

enable-migrations -ContextTypeName DataLay.DbContexts.DemoDbContext -MigrationsDirectory DbContexts\DemoMigrations add-migration -ConfigurationTypeName DataLay.DbContexts.DemoMigrations.Configuration "IntialCreate" update-database -ConfigurationTypeName DataLay.DbContexts.DemoMigrations.Configuration
