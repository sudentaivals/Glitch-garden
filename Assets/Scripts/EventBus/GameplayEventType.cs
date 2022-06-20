using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameplayEventType
{
    UIObjectActivated,
    UIObjectDeactivated,
    StartWave,
    StartMidWave,
    DestroyAllProjectiles,
    ActivateActionsCanvas,
    ChangeStarsOnDisplay,
    ChangeLivesOnDisplay,
    ChangeLives,
    ChangeWavesOnDisplay,
    GameOver,
    LevelComplete,
    OpenPauseMenu,
    ClosePauseMenu,
    PauseGame,
    UnpauseGame
}
