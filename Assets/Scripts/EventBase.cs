using System;

public class EventBase
{
    public string eventname;

    public dynamic[] parameters;

    public Action<dynamic[]> callback;
}
