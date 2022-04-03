using System;

namespace P._01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task - Hogwarts

            string spell = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Abracadabra")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = cmdArgs[0];

                if (currentCmd == "Abjuration")
                {
                    spell = AbjurationCmd(spell);
                }
                else if (currentCmd == "Necromancy")
                {
                    spell = NecromancyCmd(spell);
                }
                else if (currentCmd == "Illusion")
                {
                    spell = IllusionCmd(spell, cmdArgs);
                }
                else if (currentCmd == "Divination")
                {
                    spell = DivinationCmd(spell, cmdArgs);
                }
                else if (currentCmd == "Alteration")
                {
                    spell = AlterationCmd(spell, cmdArgs);
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
            }
            //Console.WriteLine(spell);
        }

        static string AbjurationCmd(string spell)
        {
            spell = string.Join("", spell.ToUpper());

            Console.WriteLine(spell);

            return spell;
        }

        static string NecromancyCmd(string spell)
        {
            spell = string.Join("", spell.ToLower());

            Console.WriteLine(spell);

            return spell;
        }

        static string IllusionCmd(string spell, string[] arr)
        {
            int index = int.Parse(arr[1]);
            string letter = arr[2];

            if (index >=0 && index < spell.Length)
            {
                spell = spell.Remove(index, letter.Length);
                spell = spell.Insert(index, letter);

                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("The spell was too weak.");
            }
            return spell;
        }

        static string DivinationCmd(string spell, string[] arr)
        {
            string oldPart = arr[1];
            string newPart = arr[2];

            spell = spell.Replace(oldPart, newPart);

            Console.WriteLine(spell);

            return spell;
        }

        static string AlterationCmd(string spell, string[] arr)
        {
            string substringToCut = arr[1];

            if (spell.Contains(substringToCut))
            {
                int indexToStartRemoving = spell.IndexOf(substringToCut);
                spell = spell.Remove(indexToStartRemoving, substringToCut.Length);

                Console.WriteLine(spell);
            }

            return spell;
        }
    }
}
