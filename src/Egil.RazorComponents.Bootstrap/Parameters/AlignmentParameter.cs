﻿using Egil.RazorComponents.Bootstrap.Options;
using Egil.RazorComponents.Bootstrap.Options.AlignmentOptions;
using System.Collections.Generic;

namespace Egil.RazorComponents.Bootstrap.Parameters
{
    public sealed class VerticalColumnAlignment : IParameterPrefix
    {
        public string Prefix => "align-self";
    }

    public sealed class VerticalRowAlignment : IParameterPrefix
    {
        public string Prefix => "align-items";
    }

    public abstract class AlignmentParameter<TParamPrefix> : ParameterBase, IParameter
        where TParamPrefix : IParameterPrefix, new()
    {
        protected static readonly TParamPrefix SpacingType = new TParamPrefix();

        public static implicit operator AlignmentParameter<TParamPrefix>(AlignmentOption option)
        {
            return new OptionParameter(option);
        }

        public static implicit operator AlignmentParameter<TParamPrefix>(BreakpointAlignmentOption option)
        {
            return new OptionParameter(option);
        }

        public static implicit operator AlignmentParameter<TParamPrefix>(OptionSet<IAlignmentOption> set)
        {
            return new OptionSetParameter(set);
        }

        public static readonly AlignmentParameter<TParamPrefix> None = new NoneParameter();

        class OptionParameter : AlignmentParameter<TParamPrefix>
        {
            private readonly IOption option;

            public OptionParameter(IOption option)
            {
                this.option = option;
            }

            public override int Count => 1;

            public override IEnumerator<string> GetEnumerator()
            {
                yield return string.Concat(SpacingType.Prefix, Option.OptionSeparator, option.Value);
            }
        }

        class OptionSetParameter : AlignmentParameter<TParamPrefix>
        {
            private readonly IOptionSet<IOption> set;

            public OptionSetParameter(IOptionSet<IOption> set)
            {
                this.set = set;
            }

            public override int Count => set.Count;

            public override IEnumerator<string> GetEnumerator()
            {
                foreach (var option in set)
                {
                    yield return string.Concat(SpacingType.Prefix, Option.OptionSeparator, option.Value);
                }
            }
        }

        class NoneParameter : AlignmentParameter<TParamPrefix>
        {
            public override int Count => 0;

            public override IEnumerator<string> GetEnumerator()
            {
                yield break;
            }
        }
    }
}
