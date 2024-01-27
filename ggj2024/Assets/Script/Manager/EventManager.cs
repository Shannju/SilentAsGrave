using System;
using System.Collections.Generic;
using Script.Mapping;

public interface IEventInfo
{
}

public class EventInfo : IEventInfo
{
    public Action action;
}

public class EventInfo<T> : IEventInfo
{
    public Action<T> action;
}

public class EventInfo<T, U> : IEventInfo
{
    public Action<T, U> action;
}

public static class EventManager
{
    // # region ====Singleton====
    //
    // private static EventManager instance;
    // public static EventManager Instance => Nested.Instance;
    //
    // private class Nested
    // {
    //     private Nested()
    //     {
    //     }
    //
    //     internal static readonly EventManager Instance = new();
    // }

    // # endregion

    private static readonly Dictionary<GameEventType, IEventInfo> actionDict = new();

    public static void AddListener(GameEventType name, Action method)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo)actionDict[name]).action += method;
        }
        else
        {
            var eventInfo = new EventInfo
            {
                action = method
            };
            actionDict.Add(name, eventInfo);
        }
    }

    public static void AddListener<T>(GameEventType name, Action<T> method)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo<T>)actionDict[name]).action += method;
        }
        else
        {
            var eventInfo = new EventInfo<T>
            {
                action = method
            };
            actionDict.Add(name, eventInfo);
        }
    }

    public static void AddListener<T, U>(GameEventType name, Action<T, U> method)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo<T, U>)actionDict[name]).action += method;
        }
        else
        {
            var eventInfo = new EventInfo<T, U>
            {
                action = method
            };
            actionDict.Add(name, eventInfo);
        }
    }

    public static void RemoveListener(GameEventType name, Action method)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo)actionDict[name]).action -= method;
        }
    }

    public static void RemoveListener<T>(GameEventType name, Action<T> method)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo<T>)actionDict[name]).action -= method;
        }
    }

    public static void RemoveListener<T, U>(GameEventType name, Action<T, U> method)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo<T, U>)actionDict[name]).action -= method;
        }
    }

    public static void SendMessage(GameEventType name)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo)actionDict[name]).action?.Invoke();
        }
    }

    public static void SendMessage<T>(GameEventType name, T paramT)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo<T>)actionDict[name]).action?.Invoke(paramT);
        }
    }

    public static void SendMessage<T, U>(GameEventType name, T paramT, U paramU)
    {
        if (actionDict.ContainsKey(name))
        {
            ((EventInfo<T, U>)actionDict[name]).action?.Invoke(paramT, paramU);
        }
    }


    public static void ClearEvent()
    {
        actionDict.Clear();
    }
}