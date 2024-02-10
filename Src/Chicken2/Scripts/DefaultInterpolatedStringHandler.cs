// JuicyChicken.DefaultInterpolatedStringHandler

using System;

namespace JuicyChicken
{
    internal class DefaultInterpolatedStringHandler
    {
        private int v1;
        private int v2;

        public DefaultInterpolatedStringHandler(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        // TODO
        internal void AppendFormatted(string table)
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine("AppendFormatted : NotImplementedException");
        }

        internal void AppendFormatted<T>(T elapsedMilliseconds)
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine("AppendFormatted T : NotImplementedException");
        }

        internal void AppendLiteral(string v)
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine("AppendLiteral : NotImplementedException");
        }

        //RnD
        internal string ToStringAndClear()
        {
            //throw new NotImplementedException();
            return "test";
        }
    }
}