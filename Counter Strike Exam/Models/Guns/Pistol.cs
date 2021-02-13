namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsFired = 1;

        public Pistol(string name, int bulletCount)
            :base(name, bulletCount)
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
            return bullets;
        }
    }
}
