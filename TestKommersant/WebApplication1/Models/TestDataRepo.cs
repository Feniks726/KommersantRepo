using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TestDataRepo
    {
        private static List<TestData> list = new List<TestData>();

        public List<TestData> Get() { return list; }

        public void Set(List<TestData> lst) { list.AddRange(lst); }

        public void SetAt(List<TestData> lst) { list = lst; }

        internal void Update(TestData itm)
        {
            var item = list.Find(t => t.Id == itm.Id);
            item.Selected=itm.Selected;
        }
    }
}