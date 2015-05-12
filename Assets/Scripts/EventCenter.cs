using System;
using UnityEngine;
public class EventCenter : MonoBehaviour
{
    public delegate void EventHandler(object arg);

    //
    // Static Fields
    //
    public static EventCenter Instance;

    //
    // Fields
    //
    private EventCenter.EventHandler[] allEventHandler = new EventCenter.EventHandler[7];

    //
    // Indexer
    //
    public EventCenter.EventHandler this[EventCenter.EventType type]
    {
        get
        {
            return this.allEventHandler[(int)type];
        }
        set
        {
            this.allEventHandler[(int)type] = value;
        }
    }

    //
    // Methods
    //
    public void DoEvent(EventCenter.EventType type, object arg)
    {
        try
        {
            if (this.allEventHandler[(int)type] != null)
            {
                this.allEventHandler[(int)type](arg);
            }
        }
        catch (Exception var_0_20)
        {
        }
    }

    private void Start()
    {
        EventCenter.Instance = this;
    }

    //
    // Nested Types
    //
    public enum EventType
    {
        None,
        UIShow_Recruit,
        UIShow_Recruit_Result,
        UIShow_Dupmap,
        UIShow_Trench,
        UIShow_DupLevelInfo,
        BackTo_MainUI,
        Count
    }
}
