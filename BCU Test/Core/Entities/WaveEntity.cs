using Battle_Cats_Ultimate_Test.Blueprints;

namespace BCU_Test.Core.Entities
{
    internal class WaveletEntity : BaseEntity
    {
        public WaveletEntity(float position)
        {
            Position = position;
        }
        void Update()
        {
            //Only going to be for the anim, really.
        }
    }
    internal class WaveEntity : BaseEntity
    {
        static byte AttackTime = 6;
        short Level;
        short CurrentPeak;
        short TimeBetweenPeaks, Timer; //Arguably a dumb idea to try to do anything above 10, but whatever floats ya boat.
        float DamageMultiplier;
        AttackBlueprint Attack;
        //I could see about making the Size a unique parameter too.
        static short EnemySize = 500, AllySize = 400;
        public WaveEntity(AttackBlueprint blueprint, int position, bool facesRight, float damageMultiplier)
        {
            Attack = blueprint;
            Position = position;
            FacingRight = facesRight;
            CurrentPeak = 0;
            Timer = 0;
            DamageMultiplier = damageMultiplier;
        }
        public void Update()
        {
            if(Timer >= TimeBetweenPeaks && CurrentPeak < Level)
            {
                Timer = 0;
                CurrentPeak++;
            }
            Timer++;
        }
    }
}
