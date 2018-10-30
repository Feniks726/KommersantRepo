using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITestDataService
    {
        List<TestData> GetRepo();

        void FillRepo();

        void ClearRepo(List<TestData> list);
    }
}
