using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletCount;

        public Gun(string name, int bulletCount)
        {
            this.Name = name;
            this.BulletsCount = bulletCount;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get
            {
                return this.bulletCount;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                this.bulletCount = value;
            }
        }

        public abstract int Fire();

    }
}
