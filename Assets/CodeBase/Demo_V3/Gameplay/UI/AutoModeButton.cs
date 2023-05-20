﻿using CodeBase.Gameplay.Battle;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Gameplay.UI
{
  public class AutoModeButton : MonoBehaviour
  {
    public Button Button;
    private IBattleConductor _battleConductor;

    [Inject]
    private void Construct(IBattleConductor battleConductor)
    {
      _battleConductor = battleConductor;
    }

    private void Awake()
    {
      Button.onClick.AddListener(SetMode);
    }
    
    private void Update()
    {
      Button.interactable = _battleConductor.Mode == BattleMode.Manual;
    }

    private void SetMode()
    {
      _battleConductor.SetMode(BattleMode.Auto);
      _battleConductor.ResumeTurnTimer();
    }

    private void OnDestroy()
    {
      Button.onClick.RemoveListener(SetMode);
    }
  }
}