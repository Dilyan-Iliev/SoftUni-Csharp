﻿namespace SpaceStation.Models.Planets
{
    using System;
    using SpaceStation.Models.Planets.Contracts;
    using System.Collections.Generic;
    using SpaceStation.Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            this.Items = new List<string>();
        }
        public ICollection<string> Items { get; }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;   
            }
        }
    }
}
