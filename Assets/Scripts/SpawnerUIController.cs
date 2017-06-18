using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerUIController : Selector{

    [Space]
    public Text soundNameText;
    public TempoController tempoController;
    public SoundSelector soundSelector;
    public BeadSpawner beadSpawner;
    public float tempoDelta = 10f;

    public void CycleSounds(bool direction)
    {
        soundSelector.Cycle(direction);
    }

    public void ModifyBPM(bool direction)
    {
        tempoController.ModifyTempo(direction ? -tempoDelta : tempoDelta);
    }

}
