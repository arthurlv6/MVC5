# MVC5
Hi , this program is a simple clean MVC structure, which give you a good advice for building up your MVC applications. There are no copyright issue and anyone welcome to copy or modify it. I hope you can get some inspiration from my code. Thanks.

Function List<br>
1,Global Server Exception control in Global.asax.cs<br>
2,Exception control for controllers<br>
3,To get specific file by overriding ActionResult, take getting excel file for example.<br>
4,Global action filter for IP restriction<br>
5,Data cache usage in management controller<br>
6,Implement Dependence injection by using structureMap<br>
7,Universal Search and List template<br>
8,Image show<br>
9,async feature in the controller and the respository<br>
10,fully testing the product edit function.<br>
11,WebApi2+AngularJS.<br>
This is the code first program and to initalize it you need to do execute bellow code.

enable-migrations -ContextTypeName DataModel.DbContexts.DemoDbContext -MigrationsDirectory DbContexts\DemoMigrations<br>
add-migration -ConfigurationTypeName DataModel.DbContexts.DemoMigrations.Configuration "IntialCreate"<br>
update-database -ConfigurationTypeName DataModel.DbContexts.DemoMigrations.Configuration<br>
