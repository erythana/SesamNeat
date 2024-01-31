using Microsoft.AspNetCore.Components;

namespace SesamNeat.Blazor.Components.Base;

public abstract class BaseComponent : ComponentBase
{

    protected IReadOnlyDictionary<string, object>? Attributes;
    protected string Classes = "";

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> UnmatchedParameters { get; set; } = new Dictionary<string, object>();

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        Classes = $"{UnmatchedParameters.GetValueOrDefault("class")}";

        // extract non-class attributes
        Attributes = UnmatchedParameters
                .Where(x => x.Key != "class")
                .ToDictionary(k => k.Key, v => v.Value);
    }

}