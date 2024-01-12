using System.ComponentModel;

namespace TestDataGeneration;

public interface IHasChangeToken : IChangeTracking
{
    object ChangeToken { get; }
}
