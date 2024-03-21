﻿using DesignPatterns.Repository;
using DesingPatternsAsp.Models.ViewModels;

namespace DesingPatternsAsp.Strategies
{
    public interface IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork);
    }
}
