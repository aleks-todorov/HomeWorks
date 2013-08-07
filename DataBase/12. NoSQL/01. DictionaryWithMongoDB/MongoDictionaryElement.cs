using System;

public struct MongoDictElement
{
    private string key;
    private string value;

    public MongoDictElement(string key, string value)
    {
        this.key = key;
        this.value = value;
    }

    public string Value
    {
        get { return value; }
    }

    public string Key
    {
        get { return key; }
    }

}