using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            var songs = new List<Song>(); //правя нов обект списък от тип Song 

            for (int i = 1; i <= numberOfSongs; i++)
            {
                string[] songData = Console.ReadLine().Split("_").ToArray(); //прочитам отделните песни
                string type = songData[0];
                string name = songData[1];
                string time = songData[2];

                Song currentSong = new Song(); //създавам обект от тип Song
                currentSong.TypeList = type; //задавам стойности благодарение на член данните от class Song и get; set;
                currentSong.Name = name;
                currentSong.Time = time;

                songs.Add(currentSong); //добавям обект currentSong към главния обект списък songs;
            }

            string typeList = Console.ReadLine(); //прочитам последния ред от задачата и правя съответната проверка
            if (typeList == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

    }
}