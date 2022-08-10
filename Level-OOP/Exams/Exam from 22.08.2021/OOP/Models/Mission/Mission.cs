namespace SpaceStation.Models.Mission
{
    using System.Linq;
    using System.Collections.Generic;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaout in astronauts
                .Where(x => x.Oxygen > 0))
            {
                foreach (var item in planet.Items.ToList())
                {
                    astronaout.Bag.Items.Add(item);
                    astronaout.Breath();
                    planet.Items.Remove(item);

                    if (astronaout.Oxygen <= 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
