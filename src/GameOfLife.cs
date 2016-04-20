using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using GameOfLife;

public class Program
{

    public static void Main(String[] args)
    {
        // given
        var cells = new List<Cell>();
        cells.AddRange(createRow('.', '.', '*', '.', '*', '.', '*', '.'));
        cells.AddRange(createRow('.', '*', '*', '.', '.', '.', '*', '.'));
        cells.AddRange(createRow('.', '*', '*', '.', '.', '.', '*', '.'));
        cells.AddRange(createRow('.', '*', '*', '.', '.', '.', '*', '.'));
        cells.AddRange(createRow('.', '*', '*', '.', '.', '.', '*', '.'));
        cells.AddRange(createRow('.', '*', '*', '.', '.', '.', '*', '.'));
        cells.AddRange(createRow('.', '*', '*', '.', '.', '.', '*', '.'));
        cells.AddRange(createRow('.', '*', '*', '.', '.', '.', '*', '.'));

        var generation = new Generation(8, 8, cells);
        var generationWriter = new StringWriter();
        generationWriter.WriteLine("Generation 1");
        generation.Print(generationWriter);

        for (int generationIndex = 0; generationIndex < 25; generationIndex++)
        {
            generationWriter.WriteLine();
            generationWriter.WriteLine();
            generationWriter.WriteLine("Generation {0}", generationIndex + 2);
            generation = generation.Next();
            generation.Print(generationWriter);
        }

        Console.WriteLine(generationWriter.ToString());
    }

    private static IEnumerable<Cell> createRow(params char[] cells)
    {
        return cells.Select(cell => Cell.CreateFromCharacter(cell));
    }
}