﻿using Egil.RazorComponents.Bootstrap.Options;
using Egil.RazorComponents.Bootstrap.Options.CommonOptions;
using System.Collections.Generic;
using System.Linq;

namespace Egil.RazorComponents.Bootstrap.Parameters
{
    public class SpanParameter : ParameterBase, IParameter
    {
        private const string OptionPrefix = "col";

        protected string ToOptionValue(IOption option)
        {
            if (option is BreakpointWithNumber bwn) bwn.Number.ValidateAsSpanNumber();
            if (option is Number n) n.ValidateAsSpanNumber();

            return option is DefaultBreakpoint
                ? OptionPrefix
                : string.Concat(OptionPrefix, Option.OptionSeparator, option.Value);
        }

        public override int Count => 1;

        public override IEnumerator<string> GetEnumerator()
        {
            yield return OptionPrefix;
        }

        public static implicit operator SpanParameter(int number)
        {
            return new OptionParameter(Number.ToSpanNumber(number));
        }

        public static implicit operator SpanParameter(DefaultBreakpoint _)
        {
            return Default;
        }

        public static implicit operator SpanParameter(Breakpoint option)
        {
            return new OptionParameter(option);
        }

        public static implicit operator SpanParameter(BreakpointWithNumber option)
        {
            option.Number.ValidateAsSpanNumber();
            return new OptionParameter(option);
        }

        public static implicit operator SpanParameter(AutoOption option)
        {
            return new OptionParameter(option);
        }

        public static implicit operator SpanParameter(BreakpointAuto option)
        {
            return new OptionParameter(option);
        }

        public static implicit operator SpanParameter(OptionSet<ISpanOption> set)
        {
            return new OptionSetParameter(set);
        }

        public static implicit operator SpanParameter(OptionSet<IBreakpointWithNumber> set)
        {
            return new OptionSetParameter(set);
        }

        public static readonly SpanParameter Default = new SpanParameter();

        class OptionParameter : SpanParameter
        {
            private readonly string option;

            public OptionParameter(IOption option)
            {
                this.option = ToOptionValue(option);
            }

            public override IEnumerator<string> GetEnumerator()
            {
                yield return option;
            }
        }

        class OptionSetParameter : SpanParameter
        {
            private readonly IReadOnlyCollection<string> set;

            public OptionSetParameter(IOptionSet<IOption> set)
            {
                this.set = ToOptionValueSet(set);
            }

            private List<string> ToOptionValueSet(IOptionSet<IOption> set)
            {
                var res = new List<string>(set.Count);
                var defaultAdded = false;
                var numberAdded = false;

                foreach (var option in set)
                {
                    if (option is DefaultBreakpoint)
                    {
                        if (numberAdded) continue;
                        else defaultAdded = true;
                    }
                    else if (option is Number)
                    {
                        if (defaultAdded) res.Remove(OptionPrefix);
                        numberAdded = true;
                    }

                    res.Add(ToOptionValue(option));
                }

                return res;
            }

            public override int Count => set.Count;

            public override IEnumerator<string> GetEnumerator() => set.GetEnumerator();
        }
    }
}
