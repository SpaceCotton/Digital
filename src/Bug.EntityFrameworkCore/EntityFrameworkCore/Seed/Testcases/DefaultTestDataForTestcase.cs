using Bug.Testcases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bug.EntityFrameworkCore.Seed.Testcases
{
    public class DefaultTestDataForTestcases
    {
        private readonly BugDbContext _context;

        private static readonly List<Testcase> _Testcases;

        public DefaultTestDataForTestcases(BugDbContext context)
        {
            _context = context;
        }

        static DefaultTestDataForTestcases()
        {
            _Testcases = new List<Testcase>()
            {
                new Testcase("Learning ABP deom", "Learning how to use abp framework to build a MPA application."),
                new Testcase("Make Lunch", "Cook 2 dishs")
            };
        }

        public void Create()
        {
            foreach (var testcase in _Testcases)
            {
                if (_context.Testcases.FirstOrDefault(t => t.Title == testcase.Title) == null)
                {
                    _context.Testcases.Add(testcase);
                }
                _context.SaveChanges();
            }
        }

    }

}
