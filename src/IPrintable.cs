using System.IO;

namespace GameOfLife
{
    public interface IPrintable
    {
        void Print(TextWriter writer);
    }
}