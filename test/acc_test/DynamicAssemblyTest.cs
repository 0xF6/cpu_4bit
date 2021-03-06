﻿namespace ancient.runtime.compiler.test
{
    using System;
    using emit;
    using System.Linq;
    using Xunit;

    public class DynamicAssemblyTest
    {
        [Fact]
        public void Create()
        {
            var d = new DynamicAssembly("test", ("foo", "bar"));
            Assert.Equal("test", d.Name);
            Assert.Equal(("foo", "bar"), d.Metadata.First());
            Assert.Throws<InvalidOperationException>(() => { d.GetBytes(); });
            Assert.NotNull(d.GetGenerator());
            Assert.IsType<ILGen>(d.GetGenerator());
            d.GetGenerator().Emit(new ldi(0xF, 0xC));
            Assert.Equal(sizeof(ulong), d.GetILCode().Length);
            Assert.Equal($"{0x1F00C00000000:X}", $"{BitConverter.ToUInt64(d.GetILCode().Reverse().ToArray()):X}");
        }
    }
}