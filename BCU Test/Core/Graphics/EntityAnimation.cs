using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;

namespace BCU_Test.Core.Graphics
{
    public enum EasingType
    {
        Linear = 0,
        Stall = 1,
        Exponential = 2,
        Polynomic = 3,
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
        public Vector2 Frame;//Both are Vector2s to enable ranges.
        public Vector2 Value;
        public EasingType Ease;
        public byte Parameter;
        public float DecidedFrame;//a float purely to support 60fps and partial anim speed increase.
        public int DecidedValue;
        public int ParentModifier;
        public static KeyFrame Default()
        {
            return new KeyFrame(Vector2.Zero, Vector2.Zero, 0, 0);
        }
        public KeyFrame(Vector2 framespan, Vector2 valuespan, EasingType ease, byte param)
        {
            Frame = framespan;
            Value = valuespan;
            Ease = ease;
            Parameter = param;
        }
        public KeyFrame DeepCopy()
        {
            return new KeyFrame(Vector2.One*Frame, Vector2.One*Value, Ease, Parameter);
        }
        public void Decide()
        {
            DecidedFrame = BattleCatsUltimate.Instance.Running60Fps ? (Frame.GetRandom()*2f).BCRound()*0.5f: Frame.GetRandom().BCRound();
            DecidedValue = Value.GetRandom().BCRound();
        }
    }

    public struct AnimModifier
    {
        public int PartId;
        public ModIdentifier ModId;
        public int LoopNumber;
        public int CurrentLoop;
        public string Name;
        public List<KeyFrame> Frames;
        public float CurrentValue;
        public float LoopRolloverPoint;
        public AnimModifier(int partId, ModIdentifier mod, int loops, string name)
        {
            PartId = partId;
            ModId = mod;
            LoopNumber = loops;
            CurrentLoop = -1;
            Name = name;
            Frames = new List<KeyFrame>();
            CurrentValue = Frames[0].Value.GetRandom();
            LoopRolloverPoint = 0f;
        }
        public void ReadKey(string argument)
        {
            string[] args = argument.Split(',');
            Vector2 frameRange = Vector2.Zero;
            Vector2 valueRange = Vector2.Zero;
            if (args[0].Contains('~'))
            {
                string[] vals = args[0].Split('~');
                frameRange.X = int.Parse(vals[0]);
                frameRange.Y = int.Parse(vals[1]);
            }
            else
                frameRange = new Vector2(int.Parse(args[0]));

            if (args[1].Contains('~'))
            {
                string[] vals = args[1].Split('~');
                valueRange.X = int.Parse(vals[0]);
                valueRange.Y = int.Parse(vals[1]);
            }
            else
                valueRange = new Vector2(int.Parse(args[1]));

            KeyFrame frame = new KeyFrame(frameRange, valueRange, (EasingType)int.Parse(args[2]), byte.Parse(args[3]));
            Frames.Add(frame);
            frame.Decide();
        }
        public AnimModifier DeepCopy()
        {
            AnimModifier newMod = new AnimModifier(PartId, ModId, LoopNumber, (string)Name.Clone());
            foreach (KeyFrame i in Frames)
                newMod.Frames.Add(i.DeepCopy());

            return newMod;
        }
        public void NewKey()
        {
            Frames.Add(new KeyFrame(Vector2.Zero, Vector2.Zero, EasingType.Linear, 0));
        }
        public void DefineValue(float frame)
        {
            //Plan: find two consecutive frames, use a switch statement for easing types and stuff.
            if (frame < Frames[0].DecidedFrame)
            {
                return;
            }
            if (frame > LoopRolloverPoint || frame == 0)
            {
                foreach (KeyFrame key in Frames)
                    key.Decide();

                CurrentLoop++;
                LoopRolloverPoint += Frames[Frames.Count-1].DecidedFrame;
            }
            float inLoopFrame = frame - LoopRolloverPoint;
            List<int> ActedFrames = [];
            for(int i = 0; i < Frames.Count; i++)
            {
                if (inLoopFrame < Frames[i].DecidedFrame)
                    ActedFrames.Add(i);
                else
                {
                    if(i == Frames.Count-1)
                        break;

                    ActedFrames.Add(i);
                    if (Frames[ActedFrames[0]].Ease != EasingType.Polynomic || Frames[i].Ease != EasingType.Polynomic)
                        break;
                }
            }
            float time = (inLoopFrame - Frames[ActedFrames[0]].DecidedFrame)/(Frames[ActedFrames[1]].DecidedFrame - Frames[ActedFrames[0]].DecidedFrame);
            float range = Frames[ActedFrames[1]].DecidedValue - Frames[ActedFrames[0]].DecidedValue;
            switch (Frames[ActedFrames[0]].Ease)
            {
                case EasingType.Linear:
                    break;//Just don't do anything, the work was already done.
                case EasingType.Stall:
                    time = time < 1f ? 0f : 1f;
                    break;
                case EasingType.Exponential:
                    if (Frames[ActedFrames[0]].Parameter == 0)
                        time = time > 0f ? 1f : 0f;
                    else
                    {
                        if (Frames[ActedFrames[0]].Parameter < 0)
                            time = MathF.Sqrt(1-MathF.Pow(1-time, -Frames[ActedFrames[0]].Parameter));
                        else
                            time = 1-MathF.Sqrt(1-MathF.Pow(time, Frames[ActedFrames[0]].Parameter));
                    }
                    break;
                case EasingType.Polynomic:
                    break;//This requires its own special method to set the value, as it's polynomic interpolation and can involve any number of frames.
                case EasingType.Sinusoidal:
                    float valueS = (Frames[ActedFrames[1]].DecidedValue - Frames[ActedFrames[0]].DecidedValue)*time;

                    if (Frames[ActedFrames[0]].Parameter < 0)
                        time = 1-MathF.Sin(MathF.PI*0.5f*time);
                    else if (Frames[ActedFrames[0]].Parameter > 0)
                        time = MathF.Cos(MathF.PI*0.5f*time);
                    else
                        time = 0.5f*(-MathF.Cos(MathF.PI*time)+1);

                    break;
            }

            if (Frames[ActedFrames[0]].Ease == EasingType.Polynomic)
            {
                CurrentValue = 0;
                float tempVal = 0;
                foreach(int f1 in ActedFrames)
                {
                    tempVal = Frames[f1].DecidedValue*4096f;
                    foreach(int f2 in ActedFrames)
                        if(f1 != f2)
                            tempVal *= (time - Frames[f2].DecidedFrame)/(Frames[f1].DecidedFrame-Frames[f2].DecidedFrame);

                    CurrentValue += tempVal;
                }
                CurrentValue = (CurrentValue/4096f).BCRound();
            }
            else
                CurrentValue = Frames[ActedFrames[0]].DecidedValue+(range*time).BCRound();
        }
    }
    public class EntityAnimation
    {
        public string AnimName;
        public List<AnimModifier> AnimModifiers;
        public float CurrentFrame;
        public float AnimLength;//Moreso tells us what the longest modifier in the positive direction is.

        private EntityAnimation()
        {
            AnimName = "";
            AnimModifiers = new List<AnimModifier>();
            CurrentFrame = 0;
        }
        public static EntityAnimation NewAnimation()
        {
            return new EntityAnimation();
        }
        public static EntityAnimation FromFile(string path)
        {
            EntityAnimation EntityAnim = new EntityAnimation();
            using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
            {
                int lastSlashSpot = 0;
                int extensionStart = 0;
                for(int charSlot = 0; charSlot < fs.Name.Length; charSlot++)
                {
                    if (fs.Name[charSlot] == '/')
                        lastSlashSpot = charSlot;
                    if (fs.Name[charSlot] == '.')
                    {
                        extensionStart = charSlot;
                        break;
                    }
                }
                EntityAnim.AnimName = fs.Name.Substring(lastSlashSpot+1, extensionStart-lastSlashSpot-1);
                using (StreamReader sr = new(fs))
                {
                    for (int silly = 0; silly < 2; silly++)
                        sr.ReadLine();

                    int ModNumber = int.Parse(sr.ReadLine().Trim());
                    for (int i = 0; i < ModNumber; i++)
                    {
                        string[] argsS = sr.ReadLine().Trim().Split(',');
                        int[] argsI = new int[4];
                        for (int j = 0; j < 4; j++)
                            argsI[j] = int.Parse(argsS[j]);

                        AnimModifier animMod = new AnimModifier(argsI[0], (ModIdentifier)argsI[1], argsI[2], argsS[5]);
                        EntityAnim.AnimModifiers.Add(animMod);
                        int Keys = int.Parse(sr.ReadLine().Trim());
                        for (int k = 0; k < Keys; k++)
                            animMod.ReadKey(sr.ReadLine().Trim());
                    }
                }
            }
            return EntityAnim;
        }
        public void SetFrame()
        {
            foreach (AnimModifier animMod in AnimModifiers)
                animMod.DefineValue(CurrentFrame);
        }
        public EntityAnimation DeepCopy()
        {
            EntityAnimation newEntityAnim = new EntityAnimation();
            newEntityAnim.AnimName = (string)AnimName.Clone();
            newEntityAnim.AnimModifiers = [];
            foreach(AnimModifier i in AnimModifiers)
                newEntityAnim.AnimModifiers.Add(i.DeepCopy());

            return newEntityAnim;
        }
        public void NewModifier()
        {
            AnimModifiers.Add(new AnimModifier(0, ModIdentifier.PositionY, 0, ""));
        }
    }
}
