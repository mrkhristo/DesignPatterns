// See https://aka.ms/new-console-template for more information
//using DesignPatterns.AbstractFactory;
//using DesignPatterns.DependencyInjection;
using DesignPatterns.Builder;
using DesignPatterns.Models;
using DesignPatterns.Repository;
using DesignPatterns.Strategy;
using DesignPatterns.UnitOfWork;
//using DesignPatterns.Singleton;

//Singleton
//var log = Log.Instance;
//log.Save("a");
//log.Save("b");
//var a = Log.Instance;
//var b = Log.Instance;
//Console.WriteLine(a == b);

//Factory
//SaleFactory storeSaleFactory = new StoreSaleFactory(10);
//SaleFactory internetSaleFactory = new InternetSaleFactory(5);
//
//ISale sale1 = storeSaleFactory.GetSale();
//sale1.Sell(15);
//ISale sale2 = internetSaleFactory.GetSale();
//sale2.Sell(15);

//DependencyInjection
//var beer = new Beer("Pikantus", "Erdinger");
//var drinkWithBeer = new DrinkWithBeer(10,1,beer);
//drinkWithBeer.Build();


//Repository
//using (var context  = new DesignPatternsContext())
//{
//    var beerRepository = new BeerRespository(context);
//
//    var beer = new Beer();
//    beer.Name = "Corona";
//    beer.Style = "Blond Ale";
//
//    beerRepository.Add(beer);
//    beerRepository.Save();
//    foreach (var b in beerRepository.Get())
//    {
//        Console.WriteLine(b.Name);
//    }
//}
//RepositoryGenerics
//using(var context = new DesignPatternsContext())
//{
//    var repository = new Repository<Beer>(context);
//    var beer = new Beer() { Name="Fuller",Style="Strong Ale"};
//    repository.Add(beer);
//    //repository.Delete(5);
//    repository.Save();
//
//    foreach (var b in repository.Get())
//    {
//        Console.WriteLine($"{b.BeerId}-{b.Name}");
//    }
//
//    var repository2 = new Repository<Brand>(context);
//    var brand = new Brand() { Name = "TEsta" };
//    repository2.Add(brand);
//    //repository2.Delete(5);
//    repository2.Save();
//
//    foreach (var b in repository2.Get())
//    {
//        Console.WriteLine($"{b.BrandId}-{b.Name}");
//    }
//
//}

//UnitOfWork
//using(var context = new DesignPatternsContext())
//{
//    var unitOfWork = new UnitOfWork(context);
//
//    var beers = unitOfWork.Beers;
//
//    var beer = new Beer() 
//    { 
//        Name = "Fuller",
//        Style = "Blond Ale"
//    };
//    
//    beers.Add(beer);
//
//    var brands = unitOfWork.Brands;
//
//    var brand = new Brand()
//    {
//        Name = "Penka"
//    };
//
//    brands.Add(brand);
//
//    unitOfWork.Save();
//    
//}

//Strategy
//var context = new Context(new CarStrategy());
//context.Run();
//
//context.Strategy = new BikeStrategy();
//context.Run();
//
//context.Strategy = new BicicleStrategy();
//context.Run();

//Builder
var builder = new PreparedAlcoholicDrinkConcreteBuilder();
builder.AddIngredients("Tequila");
builder.SetAlcohol(0.4m);

var preparedDrink = builder.Get();

Console.WriteLine(preparedDrink.Result);
//With director
var director = new BarManDirector(builder);
director.PrepareMargarita();
var margarita = builder.Get();
Console.WriteLine(margarita.Result);

director.PreparePiñaColada();
var piñaColada = builder.Get();
Console.WriteLine(piñaColada.Result);