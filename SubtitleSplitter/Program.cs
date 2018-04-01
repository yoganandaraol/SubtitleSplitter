using System;
namespace SubtitleSplitter
{
    class Program
    {
        static void Main()
        {
            string SAMPLE_TEXT =
                "Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 " +
                "characters. The program should try to break on complete sentences or punctuation marks if possible.  " +
                "If a comma or sentence break occurs within 5 characters of the max line length, the line should be broken early.  " +
                "The exception to this rule is when the next line will only contain 5 characters.  Redundant whitespace should " +
                "not be counted between lines, and any duplicate   spaces should be removed.  " +
                "Does this make sense? If not please ask for further clarification, an array containing " +
                "the desired outcome has been provided below. Any text beyond this point is not part of the instructions, " +
                "it's only here to ensure test converge. Finish line. Aaa asdf asdfjk las, asa.";

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(SAMPLE_TEXT);
            Console.WriteLine("\n###############################");
            Console.WriteLine("##        Parsed Text        ##");
            Console.WriteLine("###############################\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            SubtitleParser objSubtitleParser = new SubtitleParser();
            Console.WriteLine(objSubtitleParser.Parse(SAMPLE_TEXT));
            Console.Read();

        }
    }
}
