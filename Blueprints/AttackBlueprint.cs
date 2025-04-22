using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    public class AttackBlueprint
    {
        int Damage;
        int FramesPreAttack;
        Vector2 HitRange;
        int HitTargetTypes;
        bool AgainstOpponents;
        int MaxUses;//Anything below zero will be seen as infinite.
        int UserMoveDistance;//Funnily enough this makes the attack forcibly move its owner forwards by this amount. Totally doesn't screw things up.


        public AttackBlueprint()
        {
            Damage = 0;
            FramesPreAttack = 1;
            HitRange = Vector2.Zero;
            HitTargetTypes = 1;
            AgainstOpponents = true;
            MaxUses = -1;
        }
    }
}
