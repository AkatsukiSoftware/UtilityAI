using System;
using CodeBase.Gameplay.Battle;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Skills;
using CodeBase.StaticData.Skills;

namespace CodeBase.Gameplay.AI.Utility
{
    public class UtilityFunction : IUtilityFunction
    {
        private readonly Func<BattleSkill, IHero, bool> _appliesTo;
        private readonly Func<BattleSkill, IHero, ISkillSolver, float> _getInput;
        private readonly Func<float, IHero, float> _score;
        public SkillType SkillType { get; }

        public UtilityFunction(
          Func<BattleSkill, IHero, bool> appliesTo,
          Func<BattleSkill, IHero, ISkillSolver, float> getInput,
          Func<float, IHero, float> score,
          SkillType type)
        {
            SkillType = type;
            _appliesTo = appliesTo;
            _getInput = getInput;
            _score = score;
        }

        public bool AppliesTo(BattleSkill skill, IHero hero) =>
          _appliesTo(skill, hero);

        public float GetInput(BattleSkill skill, IHero hero, ISkillSolver skillSolver) =>
          _getInput(skill, hero, skillSolver);

        public float Score(float input, IHero hero) => _score(input, hero);
    }
}