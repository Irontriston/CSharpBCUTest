using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test.Graphics
{
    public enum EasingType
    {
        Linear = 0,
        Stall = 1,
        Exponential = 2,
        PolynomicInterp = 3,
        Sinusoidal = 4
    }
    public enum ModIdentifier
    {
        SetParent = 0,
        SetPartId = 1,
        SetSpriteId = 2,
        ZOrder = 3,
        PositionX = 4,
        PositionY = 5,
        PivotX = 6,
        PivotY = 7,
        ScaleStatic = 8,
        ScaleX = 9,
        ScaleY = 10,
        Angle = 11,
        Opacity = 12,
        FlipHorizontal = 13,
        FlipVertical = 14,
        ExtendX = 50,
        ExtendY = 51,
        ScaleMultiplier = 52
    }
    public struct KeyFrame
    {
        public int Id;
        public Vector2 Frame;
        public Vector2 Value;
        public EasingType Ease;
        public byte Parameter;
        public static KeyFrame Default(int id)
        {
            return new KeyFrame(id, Vector2.Zero, Vector2.Zero, 0, 0);
        }
        public KeyFrame(int id, Vector2 framespan, Vector2 valuespan, EasingType ease, byte param)
        {
            Id = id;
            Frame = framespan;
            Value = valuespan;
            Ease = ease;
            Parameter = param;
        }
    }
    public struct AnimModifier
    {
        public int SelfId;
        public int PartId;
        public ModIdentifier ModId;
        public int LoopNumber;
        public string Name;
        public List<KeyFrame> Frames;
        public AnimModifier(int id, int partId, ModIdentifier mod, int loops, string name)
        {
            SelfId = id;
            PartId = partId;
            ModId = mod;
            LoopNumber = loops;
            Name = name;
            Frames = new List<KeyFrame>();
        }
        public void NewKey()
        {
            Frames.Add(new KeyFrame(Frames.Count, Vector2.Zero, Vector2.Zero, EasingType.Linear, 0));
        }
        public void ReadKey(string argument)
        {
            string[] args = argument.Split(',');
            Vector2 frameRange = Vector2.Zero;
            Vector2 valueRange = Vector2.Zero;
            if (args[0][2] == '~')
            {
                string[] vals = args[0].Split('~');
                frameRange.X = int.Parse(vals[0]);
                frameRange.Y = int.Parse(vals[1]);
            }
            else { frameRange = new Vector2(int.Parse(args[0])); }
            if (args[1][2] == '~')
            {
                string[] vals = args[1].Split('~');
                valueRange.X = int.Parse(vals[0]);
                valueRange.Y = int.Parse(vals[1]);
            }
            else { valueRange = new Vector2(int.Parse(args[1])); }
            Frames.Add(new KeyFrame(Frames.Count, frameRange, valueRange, (EasingType)int.Parse(args[2]), byte.Parse(args[3])));
        }
    }
    public class EntityAnimation
    {
        public string AnimName;
        public EntityModel Model;
        public List<AnimModifier> AnimModifiers;
        public float CurrentFrame;

        private EntityAnimation()
        {
            AnimName = "";
            Model = EntityModel.NewModel();
            AnimModifiers = new List<AnimModifier>();
            CurrentFrame = 0;
        }
        public static EntityAnimation NewAnimation()
        {
            return new EntityAnimation();
        }
        public void NewModifier()
        {
            AnimModifiers.Add(new AnimModifier(AnimModifiers.Count, 0, ModIdentifier.PositionY, -1, ""));
        }
        public static EntityAnimation FromFile(string path)
        {
            EntityAnimation EntityAnim = new EntityAnimation();
            using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
            {
                int lastSlashSpot = 0;
                int extensionStart = 0;
                for(int c = 0; c < fs.Name.Length; c++)
                {
                    if (fs.Name[c] == '/') { lastSlashSpot = c; }
                    if (fs.Name[c] == '.')
                    {
                        extensionStart = c;
                        break;
                    }
                }
                EntityAnim.AnimName = fs.Name.Substring(lastSlashSpot+1, extensionStart-lastSlashSpot-1);
                using (StreamReader sr = new(fs))
                {
                    for (int silly = 0; silly < 2; silly++) { sr.ReadLine(); }
                    int ModNumber = int.Parse(sr.ReadLine().Trim());
                    for (int i = 0; i < ModNumber; i++)
                    {
                        string[] argsS = sr.ReadLine().Trim().Split(',');
                        int[] argsI = new int[4];
                        for (int j = 0; j < 4; j++)
                        {
                            argsI[j] = int.Parse(argsS[j]);
                        }
                        AnimModifier animMod = new AnimModifier(EntityAnim.AnimModifiers.Count, argsI[0], (ModIdentifier)argsI[1], argsI[2], argsS[5]);
                        EntityAnim.AnimModifiers.Add(animMod);
                        int Keys = int.Parse(sr.ReadLine().Trim());
                        for (int k = 0; k < Keys; k++)
                        {
                            animMod.ReadKey(sr.ReadLine().Trim());
                        }
                    }
                }
            }
            return EntityAnim;
        }
    }
}
