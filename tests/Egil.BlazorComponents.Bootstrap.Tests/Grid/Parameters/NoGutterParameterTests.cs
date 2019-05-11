﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egil.BlazorComponents.Bootstrap.Grid.Parameters;
using Shouldly;
using Xunit;

namespace Egil.BlazorComponents.Bootstrap.Tests.Grid.Parameters
{
    public class NoGutterParameterTests
    {
        [Fact(DisplayName = "Default no-gutter type returns no css class")]
        public void MyTestMethod()
        {
            NoGutterParameter.Default.Count.ShouldBe(0);
        }

        [Fact(DisplayName = "NoGutter type returns correct css class")]
        public void MyTestMethod3()
        {
            NoGutterParameter.NoGutter.Single().ShouldBe("no-gutter");
        }

        [Fact(DisplayName = "NoGutterParameter parameter is convertable from boolean value")]
        public void MyTestMethod4()
        {
            NoGutterParameter hasNoGutter = true;
            hasNoGutter.ShouldBe(NoGutterParameter.NoGutter);

            NoGutterParameter hasGutter = false;
            hasGutter.ShouldBe(NoGutterParameter.Default);
        }
    }
}

