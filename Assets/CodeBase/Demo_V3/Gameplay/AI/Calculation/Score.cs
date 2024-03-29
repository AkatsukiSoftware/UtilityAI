using System;
using CodeBase.Gameplay.Battle;
using CodeBase.Gameplay.Heroes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Gameplay.AI.Calculation
{
    //Score result value for action
    public static class Score
    {
        public static float AsIs(float input, IHero target) => input;

        public static Func<float, IHero, float> ScaleBy(float scale)
        {
            return (input, _) => input * scale;
        }

        public static Func<float, IHero, float> IfTrueThen(float value)
        {
            return (input, _) => input * value;
        }

        public static float CullByTargetHp(float healPercentage, IHero target)
        {
            if (target.State.HpPercentage >= 0.7f)
                return -30;

            return 100 * (healPercentage + 3 * (0.7f - target.State.HpPercentage));
        }

        public static Func<float, IHero, float> CullByTargetInitiative(float scaleBy, float cullThreshold)
        {
            return (input, target) => target.State.InitiativePercentage > cullThreshold
              ? input * scaleBy
              : 0;
        }
    }
}