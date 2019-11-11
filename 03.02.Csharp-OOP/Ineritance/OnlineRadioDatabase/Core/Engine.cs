using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }

        public void Run()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            int minutes = 0;
            int seconds = 0;

            for (int i = 0; i < numberOfSongs; i++)
            {
                try
                {
                    string[] splitInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    if (splitInput.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    string artistName = splitInput[0];
                    string songName = splitInput[1];
                    string[] timeSplit = splitInput[2].Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    bool isMinutes = int.TryParse(timeSplit[0], out minutes);
                    bool isSeconds = int.TryParse(timeSplit[1], out seconds);

                    int songLength = minutes.ToString().Length + seconds.ToString().Length + 1;

                    if (isMinutes == false || isSeconds == false || songLength > 5)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Print();
        }

        public void Print()
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            int totalSeconds = songs.Sum(x => (x.Minutes * 60) + x.Seconds);
            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }
    }
}
