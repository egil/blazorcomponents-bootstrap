﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Egil.RazorComponents.Bootstrap.Tests.TestUtilities
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class NumberRangeData : DataAttribute
    {
        private readonly int start;
        private readonly int count;

        public NumberRangeData(int start, int end)
        {
            this.start = start;
            count = end - start + 1;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return Enumerable.Range(start, count).Select(x => new object[] { x });
        }
    }
}
