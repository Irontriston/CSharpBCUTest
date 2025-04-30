using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    //This will take the role of the foundational blueprint for enemies and units.
    public class FormBlueprint : OtherBlueprints
    {
        int EntityId;
        string Name;
        string Description;
        int MinimumPosition;
        int MaxHealth;
        int HitBacks;
        int Price;
        int RespawnTime;
        int SpawnLimit;
        Vector2 Layer;
        int SpawnCapWeight;
        int MovementSpeed;
        int TargetWidth; //Bc the actual hitbox is more of a hit'point', this only affects targeting.
        int TimeBetweenAttacks;
        int StandingRange;
        int AttackBaseRange;
        List<AttackBlueprint> Attacks;
        bool BlocksWaves, CommonProc;
        Dictionary<string, int> AffectModifiers;
        List<Traits> SelfTraits;
        List<Traits> TargetTraits;
        List<SubTraits> SelfSubTraits;
        
        public FormBlueprint()
        {
            Name = "";
            Description = "";
            MaxHealth = 200;
            HitBacks = 4;
            RespawnTime = 120;
            SpawnLimit = -1;
            MovementSpeed = 6;
            SpawnCapWeight = 1;
            Layer = new Vector2(0, 9);
            MinimumPosition = 200;
            TimeBetweenAttacks = 0;
            StandingRange = AttackBaseRange = 0;
            Attacks = [new AttackBlueprint()];
            BlocksWaves = false;
            CommonProc = false;
            SelfTraits = new List<Traits>();
            SelfSubTraits = new List<SubTraits>();
        }
    }
}
