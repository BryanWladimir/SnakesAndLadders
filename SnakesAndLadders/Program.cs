using Microsoft.Extensions.Configuration;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtener configuraciones iniciales
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var gameSettings = new GameSettings();
            config.GetSection("GameSettings").Bind(gameSettings);

            //Preguntar por los jugadores
            var players = AskForPlayers(gameSettings.MinPlayers, gameSettings.MaxPlayers);

            //Configurar juego
            var game = new Game(players,gameSettings.Squares);

            //Iniciar juego
            game.Init();

            Console.ReadKey();
        }


        private static IList<string> AskForPlayers(int min, int max)
        {
            bool validNumber;
            int value;
            do
            {
                Console.WriteLine("Ingrese el número de jugadores, entre {0} y {1}", min, max);
                validNumber = int.TryParse(Console.ReadLine(), out value);
            }
            while (!validNumber || value < min || value > max);

            var names = new List<string>();

            for (int i = 0; i < value; i++)
            {
                string name;
                bool validName;
                do
                {
                    Console.WriteLine("Ingrese el nombre del jugador {0}", i + 1);
                    name = Console.ReadLine().Trim();
                    validName = !string.IsNullOrEmpty(name) && !names.Any(x => x.ToUpper() == name.ToUpper());
                }
                while (!validName);
                names.Add(name);
            }

            return names;
        }
    }
}
