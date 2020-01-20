﻿namespace ancient.runtime
{
    public class pull : Instruction
    {
        internal readonly byte _index;

        public pull(byte index) : base(IID.pull) => _index = index;

        protected override void OnCompile() => Construct(_index);
    }
}