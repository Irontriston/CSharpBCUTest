using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    public class OtherBlueprints
    {
        //Both enums are structured according to first chronological appearance.
        public enum Traits
        {
            Traitless = 0,
            Red = 1,
            Floating = 2,
            Black = 3,
            Metal = 4,
            Angel = 5,
            Alien = 6,
            Zombie = 7,
            Relic = 8,
            Aku = 9
        }
        public enum SubTraits
        {
            Witch = 0,
            EvaAngel = 1,
            Colossus = 2,
            Behemoth = 3,
            Sage = 4
        }
        public struct ChanceEffect
        {
            public byte Id;
            public byte Chance;
            public int Value1;
            public int Value2;
            public bool CurseAffected;
        }
        public struct Ability
        {
            public byte Id;
            public int Value1;//For stuff like Behemoth Slayer and Strengthen where other values are needed.
            public int Value2;
        }
        //Unsure of how to implement abilities and CC.
        public enum Abilities
        {
            Strong = 0,
            MassiveDamage = 1,
            Resistant = 2,
            Bounty = 3,
            TargetOnly = 4,
            InsaneDamage = 5,
            InsaneResistant = 6,
            Strengthen = 7,
            WitchKill = 8,
            Burrow = 9,
            Revive = 10,
            ZombieKill = 11,
            Barrier = 12,
            EvaAngelKill = 13,
            AkuShield = 14,
            ColossusSlayer = 15,
            BehemothSlayer = 16,
            SoulStrike = 17,
            Conjure = 18,
            SageSlayer = 19,
            MetalKill = 20,
            Counter = 35,
            SuperArmor = 36,
            MysticShield = 37,
            Adrenaline = 38
        }
        public enum ChanceEffects
        {
            KnockBack = 0,
            Freeze = 1,
            Slow = 2,
            Crit = 3,
            Waves = 4,
            Weaken = 5,
            Survive = 6,
            SavageBlow = 7,
            Dodge = 8,
            Toxic = 9,
            BarrierBreak = 10,
            Warp = 11,
            Curse = 12,
            Surge = 13,
            Miniwave = 14,
            DeathSurge = 15,
            Minisurge = 16,
            CounterSurge = 17,
            Explosion = 18,
            DeathMinisurge = 19,
            MoveAttack = 30,
            Seal = 31,
            Summon = 32,
            TimeFreeze = 33,
            SniperKB = 34,
            ThemeChange = 35,
            BossShockwave = 36,
            Poison = 37,
            ArmorBreak = 38,
            Haste = 39
        }
        public static List<ChanceEffects> BarrierBlocked = [
            ChanceEffects.Freeze,
            ChanceEffects.Slow,
            ChanceEffects.Weaken,
            ChanceEffects.Curse,
            ChanceEffects.Seal,
            ChanceEffects.Poison,
            ChanceEffects.ArmorBreak,
            ChanceEffects.Haste ];
    }
}
