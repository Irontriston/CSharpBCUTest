using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    internal class AttackBlueprint : OtherBlueprint
    {
        int Damage;
        int FramesPreAttack;
        Vector2 HitRange;
        int HitTargetTypes;
        bool AgainstOpponents;
        int MaxUses;//Anything below zero will be seen as infinite.
        int UserMoveDistance;//Funnily enough this makes the attack forcibly move its owner forwards by this amount. Totally doesn't screw things up.
        List<DecidedChanceEffect> EffectSet;
        List<Traits> TargetTraits;
        List<Traits> OwnerTraits;
        List<SubTraits> OwnerSubTraits;
        List<Ability> AttackSpecificAbilities;

        public AttackBlueprint()
        {
            Damage = 0;
            FramesPreAttack = 1;
            HitRange = Vector2.Zero;
            HitTargetTypes = 1;
            AgainstOpponents = true;
            MaxUses = -1;
            UserMoveDistance = 0;
            EffectSet = [];
            TargetTraits = [];
            OwnerTraits = [];
            OwnerSubTraits = [];
            AttackSpecificAbilities = [];
        }
        public AttackBlueprint DeepCopy()
        {
            AttackBlueprint result = new AttackBlueprint();
            result.Damage = Damage;
            result.FramesPreAttack = FramesPreAttack;
            result.HitRange = HitRange;
            result.HitTargetTypes = HitTargetTypes;
            result.AgainstOpponents = AgainstOpponents;
            result.MaxUses = MaxUses;
            result.UserMoveDistance = UserMoveDistance;
            result.EffectSet = [..EffectSet];
            result.TargetTraits = [..TargetTraits];
            result.OwnerTraits = [..OwnerTraits];
            result.OwnerSubTraits = [..OwnerSubTraits];
            result.AttackSpecificAbilities = [..AttackSpecificAbilities];
            return result;
        }
        public void CommitToAttack(int spawnPosition, bool ownerCursed, bool ownerSealed)
        {

        }
    }
}
