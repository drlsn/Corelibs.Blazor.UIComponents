namespace Corelibs.Blazor.UIComponents.Common;

public record Element(string Id, string Name, string Value, List<Element> Children)
{

}

public record ElementData(string Id, string Name, string Value);

public record Attribute(string Name, string value)
{

}
