using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    //This will take the role of the foundational blueprint for enemies and units.
    public class FormBlueprint
    {
        int EntityId;
        string Name;
        string Description;
        //int Position;
        int MinimumPosition;
        int Health;
        int MaxHealth;
        int HitBacks;
        Vector2 Layer;
        int CapacityUsage;
        int MovementSpeed;
        int TargetWidth;
        int TimeBetweenAttacks;
        int StandingRange;
        int AttackBaseRange;
        List<AttackBlueprint> Attacks;

        public FormBlueprint()
        {
            Name = "";
            Description = "";
            Health = MaxHealth = 200;
            HitBacks = 4;
            MovementSpeed = 6;
            CapacityUsage = 1;
            Layer = Vector2.Zero;
            MinimumPosition = 200;
            TimeBetweenAttacks = 0;
            StandingRange = AttackBaseRange = 0;
            Attacks = [new AttackBlueprint()];
        }
    }
}
