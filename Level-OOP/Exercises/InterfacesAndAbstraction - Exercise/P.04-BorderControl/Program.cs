using _7.Core;
using _7.Core.Interfaces;
using System;
//вход за shoppint spree:
//=3;
//Chushki = 1;Domati = 2;Sirene = 3;
//Jeko Chushki;
//Jeko Domati;
//Jeko Sirene;
//END

namespace _7
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
