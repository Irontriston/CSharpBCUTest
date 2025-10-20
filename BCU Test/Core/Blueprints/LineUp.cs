using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Blueprints
{
    internal class LineUp
    {
        public static Dictionary<string, short> TreasureCap = new Dictionary<string, short>
        {
            {"Attack",300},
            {"Defense", 300},
            {"Cooldown", 300},
            {"Accounting", 300},
            {"WorkerCat", 300},
            {"WalletCap", 300},
            {"CanonRecharge", 600},
            {"CannonAttack", 600},
            {"BaseHealth", 600},
            {"RedFruit", 300},
            {"FloatingFruit", 300},
            {"BlackFruit", 300},
            {"AngleFruit", 300},
            {"MetalFruit", 300},
            {"ZombieFruit", 300},
            {"AlienFruit", 300},
            {"AlienMagReduction", 600},
            {"StarAlienMagReduction", 1500},
            {"GodMask1", 100},
            {"GodMask2", 100},
            {"GodMask3", 100},
        };
        public static Dictionary<string, byte> TechCap = new Dictionary<string, byte>
        {
            {"Cooldown", 30},
            {"Accounting", 30},
            {"BaseHealth", 30},
            {"WorkerCat", 30},
            {"WalletCap", 30},
            {"CannonRecharge", 30},
            {"CannonAttack", 30},
            {"CannonRange", 10}
        };
        public enum CannonType
        {
            NormalCannon = 0,
            SlowBeamCannon = 1,
            IronWallCannon = 2,
            ThunderboltCannon = 3,
            WaterblastCannon = 4,
            HolyblastCannon = 5,
            BreakerblastCannon = 6,
            CurseblastCannon = 7
        }
        public enum BaseType//This will be used for both base types and decor types.
        {
            NormalBase = 0,
            SlowBase = 1,
            IronBase = 2,
            ThunderBase = 3,
            WaterBase = 4,
            HolyBase = 5,
            BreakerBase = 6,
            CurseBase = 7,
        }
        public static byte CannonLevelMax = 30;
        public static byte BaseLevelMax = 30;
        public static byte DecorLevelMax = 20;

        public Unit[] Units = new Unit[10];
        public Dictionary<string, short> Treasures = new Dictionary<string, short>
        {
            {"Attack",300},
            {"Defense", 300},
            {"Cooldown", 300},
            {"Accounting", 300},
            {"WorkerCat", 300},
            {"WalletCap", 300},
            {"CanonRecharge", 600},
            {"CannonAttack", 600},
            {"BaseHealth", 600},
            {"RedFruit", 300},
            {"FloatingFruit", 300},
            {"BlackFruit", 300},
            {"AngleFruit", 300},
            {"MetalFruit", 300},
            {"ZombieFruit", 300},
            {"AlienFruit", 300},
            {"AlienMagReduction", 600},
            {"StarAlienMagReduction", 1500},
            {"GodMask1", 100},
            {"GodMask2", 100},
            {"GodMask3", 100},
        };
        public Dictionary<string, byte> Tech = new Dictionary<string, byte>
        {
            {"Cooldown", 30},
            {"Accounting", 30},
            {"BaseHealth", 30},
            {"WorkerCat", 30},
            {"WalletCap", 30},
            {"CannonRecharge", 30},
            {"CannonAttack", 30},
            {"CannonRange", 10}
        };
        public CannonType Cannon = CannonType.NormalCannon;
        public byte CannonLevel = CannonLevelMax;
        public BaseType BaseDesign = BaseType.NormalBase, DecorDesign = BaseType.NormalBase;
        public byte BaseLevel = BaseLevelMax, BaseDesignLevel = BaseLevelMax, DecorLevel = DecorLevelMax;
    }
}
