using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step 
{
    public string Number { get; }
    public string Description { get;  }

    public StepType Type { get; }

    public string Hint { get; }

    public int? TimerInS;

    public Step(string num, string desc, StepType type, string hint, int? seconds)
    {
        Number = num;
        Description = desc;
        Type = type;
        Hint = hint;
        TimerInS = seconds;
    }

}
