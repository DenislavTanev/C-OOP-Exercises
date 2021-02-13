namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BulletsFired = 10;

        public Rifle(string name, int bulletCount)
            : base(name, bulletCount)
        {

        }
        public override int Fire()
        {
            int bullets = 0;
            if (BulletsCount > BulletsFired)
            {
                this.BulletsCount -= BulletsFired;
                bullets = BulletsFired;
            }
            else if (BulletsCount < BulletsFired && BulletsCount > 0)
            {
                bullets = this.BulletsCount;
                this.BulletsCount = 0;
            }
            return bullets;
        }
    }
}
