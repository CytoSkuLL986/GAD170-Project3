using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingCheckListItem : CheckListItem
{
   public int Score { get; set; }
    public int MaxScore { get; set; }

    public override bool IsComplete { get { return Score == MaxScore; } }

    public override float GetProgress();
    
}
