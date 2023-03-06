
using System;

public class AppCheckerResult
{
    //public string schema { get; set; }
    //public string version { get; set; }
    public Run[] runs { get; set; }
}

public class Run
{
    public Result[] results { get; set; }
    public Tool tool { get; set; }
    public Invocation[] invocations { get; set; }
    public string columnKind { get; set; }
}

public class Tool
{
    public Driver driver { get; set; }
}

public class Driver
{
    public string name { get; set; }
    public string fullName { get; set; }
    public string version { get; set; }
    public Rule[] rules { get; set; }
}

public class Rule
{
    public string id { get; set; }
    public Messagestrings messageStrings { get; set; }
    public Properties properties { get; set; }
}

public class Messagestrings
{
    public Issue issue { get; set; }
}

public class Issue
{
    public string text { get; set; }
}

public class Properties
{
    public string[] howToFix { get; set; }
    public string whyFix { get; set; }
    public string level { get; set; }
    public string componentType { get; set; }
    public string primaryCategory { get; set; }
}

public class Result
{
    public string ruleId { get; set; }
    public int ruleIndex { get; set; }
    public Message message { get; set; }
    public Location[] locations { get; set; }
    public Properties1 properties { get; set; }
}

public class Message
{
    public string id { get; set; }

    public string[] arguments;
}

public class Properties1
{
    public string level { get; set; }
}

public class Location
{
    public Physicallocation physicalLocation { get; set; }
    public Logicallocation[] logicalLocations { get; set; }
    public Properties2 properties { get; set; }
}

public class Physicallocation
{
    public Address address { get; set; }
}

public class Address
{
    public int relativeAddress { get; set; }
    public string fullyQualifiedName { get; set; }
}

public class Properties2
{
    public string module { get; set; }
    public string type { get; set; }
    public string member { get; set; }
}

public class Logicallocation
{
    public string fullyQualifiedName { get; set; }
}

public class Invocation
{
    public DateTime startTimeUtc { get; set; }
    public DateTime endTimeUtc { get; set; }
    public bool executionSuccessful { get; set; }
}
