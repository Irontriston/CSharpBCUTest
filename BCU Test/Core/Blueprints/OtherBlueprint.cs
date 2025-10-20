using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    internal class OtherBlueprint
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
            Aku = 9,
        }
        public enum SubTraits
        {
            Witch = 0,
            EvaAngel = 1,
            Colossus = 2,
            Behemoth = 3,
            Sage = 4
        }
        public enum TalentOrbType
        {
            Attack = 0,
            Defense = 1,
            Strong = 2,
            Resist = 3,
            Massive = 4,
            DeathMiniSurge = 5,
            WaveResist = 6,
            CostReturn = 7,
            KnockbackResist = 8,
            ColossusSlayer = 9,
            SoLBuff = 10
        }
        public struct TalentOrb
        {
            TalentOrbType Type;
            Traits TargetTrait;
            byte Grade;
            public TalentOrb(TalentOrbType type, Traits trait, byte grade)
            {
                Type = type;
                TargetTrait = trait;
                Grade = grade;
            }
        }
        //From left to right: Atk add, Defense mult, Strong mult, Massive mult, Resist mult
        public static float[] EffectOrbInc = [1, 0.04f, 0.06f, 0.1f, 0.05f];
        public static float[] DeathMiniSurgeChance = [0.03f, 0.06f, 0.1f, 0.14f, 0.2f];
        public static float[] NotColSlayerOrbInc = [0.05f, 0.1f, 0.2f, 0.3f, 0.5f];
        public static float[] ColSlayerResistMult = [0.05f, 0.1f, 0.15f, 0.2f, 0.3f];
        public static float[] ColSlayerDamageMult = [0.05f, 0.1f, 0.25f, 0.4f, 0.6f];
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
            Counter = 32,
            SuperArmor = 33,
            MysticShield = 34,
            Adrenaline = 35
        }
        public enum ChanceEffects
        {
            KnockBack = 0,
            Freeze = 1,
            Slow = 2,
            Crit = 3,
            Wave = 4,
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
            MoveAttack = 32,
            Seal = 33,
            Summon = 34,
            TimeFreeze = 35,
            SniperKB = 36,
            ThemeChange = 37,
            BossShockwave = 38,
            Poison = 39,
            ArmorBreak = 40,
            Haste = 41
        }
        public static List<ChanceEffects> BarrierBlocked = [
            ChanceEffects.Freeze,
            ChanceEffects.Slow,
            ChanceEffects.Weaken,
            ChanceEffects.Curse,
            ChanceEffects.Seal,
            ChanceEffects.Poison,
            ChanceEffects.ArmorBreak,
            ChanceEffects.Haste
            ];
        public class ChanceEffect
        {
            public ChanceEffects Id;
            public float Chance;
            public Vector2 Value1, Value2;
            public bool CurseAffected;

            public DecidedChanceEffect? Decide()
            {
                if(BCUltimate.Rand.NextSingle()<Chance)
                {
                    return new DecidedChanceEffect(Id, Value1.GetRandom().StupidRound(), Value2.GetRandom().StupidRound());
                }
                return null;
            }
        }
        public class WaveSpawnEffect : ChanceEffect
        {
            Vector2 SpawnPosition;
            bool FollowSpawnerDirection;
            public WaveSpawnEffect(float chance)
            {
                Id = ChanceEffects.Wave;
                SpawnPosition = new(215);
                CurseAffected = false;
            }
            public WaveSpawnEffect NormalWave(float chance, int lv)//Creates a traditional BC wave Effect
            {
                WaveSpawnEffect normalWaveEffect = new WaveSpawnEffect(chance);
                normalWaveEffect.Value1 = new(lv);
                normalWaveEffect.Value2 = new(1);
                FollowSpawnerDirection = true;
                return normalWaveEffect;
            }
            public WaveSpawnEffect NormalMiniwave(float chance, int lv)//Creates a traditional BC miniwave Effect
            {
                WaveSpawnEffect normalMiniwaveEffect = new WaveSpawnEffect(chance);
                normalMiniwaveEffect.Value1 = new(lv);
                normalMiniwaveEffect.Value2 = new(0.2f);
                FollowSpawnerDirection = true;
                return normalMiniwaveEffect;
            }
        }
        public class DecidedChanceEffect //The same as ChanceEffect, but with Chance and CurseAffected stripped.
        {
            public ChanceEffects Id;
            public int Value1, Value2;
            public DecidedChanceEffect(ChanceEffects id, int param1, int param2)
            {
                Id = id;
                Value1 = param1;
                Value2 = param2;
            }
        }
        public struct Ability
        {
            public Abilities Id;
            public int Value1;//For stuff like Behemoth Slayer and Strengthen where other values are needed.
            public int Value2;
        }
    }
}
