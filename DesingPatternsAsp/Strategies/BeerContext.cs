using DesignPatterns.Repository;
using DesingPatternsAsp.Models.ViewModels;

namespace DesingPatternsAsp.Strategies
{
    public class BeerContext
    {
        private IBeerStrategy _beerStrategy;

        public IBeerStrategy BeerStrategy
        {
            set { _beerStrategy = value; }
        }

        public BeerContext(IBeerStrategy strategy) { _beerStrategy = strategy; }

        public void Add(FormBeerViewModel beerVM,IUnitOfWork unitOfWork)
        {
            _beerStrategy.Add(beerVM,unitOfWork);
        }
    }
}
