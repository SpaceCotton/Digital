using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bug.Testcases
{
    public class TestcaseEventData : EventData
    {
        public Testcase Testcase { get; set; }
    }
}
