using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication
{
    class Program
    {
        private const string LibraryPath = "julia_bridge.so";

        [DllImport(LibraryPath)]
        static extern void jl_init();
        
        [DllImport(LibraryPath)]
        static extern void jl_eval_string(string message);

        static void Main(string[] args)
        {
            try
            {
                jl_init();

               // Lire le contenu du fichier .jl dans une chaîne
                string juliaScript = File.ReadAllText("julia.jl");
                
                // Passer cette chaîne à jl_eval_string pour évaluation
                jl_eval_string(juliaScript);    
                //jl_eval_string("x=2");   
                //jl_eval_string("println(\"x = \", x");     
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
