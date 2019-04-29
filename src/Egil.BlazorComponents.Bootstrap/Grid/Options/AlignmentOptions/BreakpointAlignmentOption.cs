﻿using System.Diagnostics;

namespace Egil.BlazorComponents.Bootstrap.Grid.Options.AlignmentOptions
{
    [DebuggerDisplay("AlignmentOption: {Value}")]
    public sealed class BreakpointAlignmentOption : OptionPair<Breakpoint, AlignmentOption>, IAlignmentOption
    {
        public BreakpointAlignmentOption(Breakpoint leftOption, AlignmentOption rightOption) : base(leftOption, rightOption)
        {
        }

        public static IOptionSet<IAlignmentOption> operator |(BreakpointAlignmentOption option1, IAlignmentOption option2)
        {
            return new OptionSet<IAlignmentOption> { option1, option2 };
        }

        public static IOptionSet<IAlignmentOption> operator |(OptionSet<IAlignmentOption> set, BreakpointAlignmentOption option2)
        {
            set.Add(option2);
            return set;
        }
    }
}
