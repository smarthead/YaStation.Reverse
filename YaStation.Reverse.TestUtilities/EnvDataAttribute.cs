using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace YaStation.Reverse.TestUtilities
{
    public class EnvDataAttribute : DataAttribute
    {
        private readonly string[] _environments;

        public EnvDataAttribute(params string[] environments)
        {
            _environments = environments;
        }
        
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var values = _environments
                .Select(Environment.GetEnvironmentVariable)
                .ToArray();

            return new List<string[]> { values };
        }
    }
}