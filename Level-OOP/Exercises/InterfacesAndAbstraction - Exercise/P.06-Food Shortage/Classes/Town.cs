using System;
using System.Collections.Generic;
using System.Text;

namespace P._06_Food_Shortage.Classes
{
    public class Town
    {
        private readonly List<Citizen> citizens;
        private readonly List<Rebel> rebels;

        public Town()
        {
            this.citizens = new List<Citizen>();
            this.rebels = new List<Rebel>();
        }

        public IReadOnlyCollection<Citizen> Citizens => this.citizens;
        public IReadOnlyCollection<Rebel> Rebels => this.rebels;

        public void AddCitizen(Citizen citizen)
        {
            if (!this.citizens.Contains(citizen))
            {
                this.citizens.Add(citizen);
            }
        }

        public void AddRebel(Rebel rebel)
        {
            if (!this.rebels.Contains(rebel))
            {
                this.rebels.Add(rebel);
            }
        }
    }
}
