using Microsoft.Xna.Framework;

namespace BCU_Test.Core.Entities
{
    class ExplosionEntity : BaseEntity
    {
        public DecidedAttack Attack;
        public Vector2[] ExplosionSizes = [new(-75, 75),new(76,175),new(176,275)];
        public static float[] DamageMultipliers = [1, 0.7f, 0.4f];
        byte Timer;
        ExplosionEntity(DecidedAttack attackBP, int position)
        {
            Attack = attackBP;
            Position = position;
            Timer = 0;
        }
        public void Update()
        {
            if(Timer == 10)
            {

            }
            if(Timer == 20)
            {

            }
            if(Timer == 30)
            {

            }
            Timer++;
        }
    }
}
