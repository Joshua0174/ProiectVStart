using BusinessLayer.Contracts;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace BusinessLayer.Services
{
    public class TestService : ITestService
    {
        private readonly IRepository<ReviewModel> _reviewRepository;
        private readonly IRepository<StockModel> _stockRepository;
        public TestService(IRepository<StockModel> stockRepository, IRepository<ReviewModel> modelRepository)
        {
            _stockRepository = stockRepository;
            _reviewRepository = modelRepository;
        }

        public int CountRecords()
        {   
            return _stockRepository.GetAll().Count() + _reviewRepository.GetAll().Count() ;
        }
    }
}
