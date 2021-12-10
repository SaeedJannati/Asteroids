using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public partial class SROptions
{
    private int _itemValue = 1;
    [NumberRange(0, 20000)]
    [Category("General")]
    public int ItemValue
    {
        get => _itemValue;
        set => _itemValue = value;
    }
    [Category("General")]
    public void SetHighScore()
    {
        ScorePrefs.HighScore = _itemValue;
    }
    [Category("General")]
    public void ClearHighScore()
    {
        ScorePrefs.ClearHighScore();
    }
    
}
