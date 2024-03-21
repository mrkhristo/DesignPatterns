﻿using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesingPatternsAsp.Models.ViewModels;

namespace DesingPatternsAsp.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;
            beer.BrandId = beerVM.BrandId;
            
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
