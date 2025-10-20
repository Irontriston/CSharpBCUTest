using Battle_Cats_Ultimate_Test.Blueprints;
using Microsoft.Xna.Framework;

namespace BCU_Test.Core.Entities
{
    class SurgeEntity : BaseEntity
    {
        static byte StartupTime = 15, MidLoopTime = 20, WindDownTime = 10;
        static byte SoundFxLoopTime = 30;
        int TimeLeft, LifeTime;
        static Vector2 Width = new Vector2(-125f, 250f);
        Vector2 HitWidth;
        AttackBlueprint Attack;
        float DamageMultiplier;

        SurgeEntity(byte level, int position, AttackBlueprint attack, bool facesRight, float damageMult)
        {
            Position = position;
            Attack = attack;
            LifeTime = TimeLeft = StartupTime + MidLoopTime * level + WindDownTime;
            FacingRight = facesRight ;
            HitWidth = Width * (facesRight ? 1 : -1);
            DamageMultiplier = damageMult;
        }
        void Update()
        {
            if(LifeTime-TimeLeft < 15)
            {
                //TODO: Integrate anims
            }
            if(TimeLeft > 10)
            {
                //TODO: Integrate anims
            }
            else
            {

            }
        }
    }
}
