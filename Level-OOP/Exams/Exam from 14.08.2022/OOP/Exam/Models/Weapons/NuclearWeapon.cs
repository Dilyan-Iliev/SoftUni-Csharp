namespace PlanetWars.Models.Weapons
{
    using System;

    public class NuclearWeapon : Weapon
    {
        private const double NuclearWeaponPrice = 15;

        public NuclearWeapon(int destructionLevel) 
            : base(destructionLevel, NuclearWeaponPrice)
        {
        }
    }
}
