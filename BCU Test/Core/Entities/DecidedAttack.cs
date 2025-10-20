using Microsoft.Xna.Framework;

namespace BCU_Test.Core.Entities
{
    //stores everything when all the procs have been rolled and all the stuff has been taken into account.
    internal class DecidedAttack
    {
        int Damage, FramesPreAttack;
        Vector2 HitBox;//This Hitbox will be writtin with regard to world space, so position won't be needed.
        bool AgainstOpponents;
        int HitTargetTypes;


    }
}
