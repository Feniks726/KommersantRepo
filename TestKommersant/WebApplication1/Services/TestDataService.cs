using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TestDataService: ITestDataService
    {
        private readonly TestDataRepo _repo;

        public TestDataService(TestDataRepo repo)
        {
            _repo = repo;
        }

        public List<TestData> GetRepo()
        {
            return _repo.Get();
        }

        public void FillRepo()
        {
            var maxId = 0;

            if (_repo.Get().Any()) maxId= _repo.Get().Max(t => t.Id);

            var list = new List<TestData>();

            var maxIteration = 100;
            for (var i = 0; i < maxIteration; i++)
            {
                list.Add(new TestData { Id = maxId + i, Title=$"Title{i}", TextData=$"Text data {i}", Selected=false });
            }

            _repo.Set(list);
        }

        public void ClearRepo(List<TestData> lst)
        {
            var list = _repo.Get();

            list.RemoveAll(t => lst.Where(x => x.Selected).Select(x => x.Id).Contains(t.Id));

            _repo.SetAt(list);
        }
    }
}