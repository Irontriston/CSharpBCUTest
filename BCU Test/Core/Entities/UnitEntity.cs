using Battle_Cats_Ultimate_Test.Blueprints;
using System.Collections.Generic;

namespace BCU_Test.Core.Entities
{
    class UnitEntity : BaseEntity
    {
        public enum EntityState
        {
            Walking = 0,
            Idle = 1,
            Attacking = 2,
            KnockedBack = 3,
            BeginningBurrow = 4,
            MidBurrowing = 5,
            EndingBurrow = 6,
        }
        int Health, MaxHealth;
        bool DeathSurge = false, CounterSurge = false;
        bool IsDead = false, Touchable = true, Targetable = true;
        long DamageDealt = 0L, DamageTaken = 0L, TimeAlive = 0L;
        short TargetWidth, StandingRange, BaseAttackRange; //TargetWidth tells us how far behind itself an entity can target, NOT guaranteed to hit when hurtboxes are manually defined, ex. Zollow.
        byte CannonImmunity; //It was decided in Java BCU to set it up this way, so I'll do something similar here, though likely with a different frontend.
        bool IsActingBase;
        EntityState State;
        FormBlueprint Blueprint;
        List<AttackBlueprint> Attacks;
        List<SurgeEntity> SurgesHitBy;
        List<WaveEntity> WavesHitBy;

        UnitEntity(FormBlueprint blueprint, int position, float magnification, bool isBase = false)
        {
            Blueprint = blueprint;
            Health = MaxHealth = (int)(blueprint.MaxHealth*magnification);
            Position = position;
            IsActingBase = isBase;
            Attacks = blueprint.Attacks;
            SurgesHitBy = [];
            State = EntityState.Walking;
        }
        void PreAtkUpdate()
        {

        }
        new void OnAttack()
        {

        }
        void PostAtkUpdate()
        {

        }
        void OnHitBySurge(SurgeEntity HittingSurge) { }
        void OnHitByWave(WaveEntity HittingWave) { }
        void OnHitByExplosion(ExplosionEntity HittingExplosion) { }
    }
}
