using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sail.Plugin.TypeFinding
{
  public class TypeFinderOptions
  {
    public List<TypeFinderCriteria> TypeFinderCriterias { get; set; } = new List<TypeFinderCriteria>(Defaults.GetDefaultTypeFinderCriterias());

    private static class Defaults
    {
      private static List<TypeFinderCriteria> TypeFinderCriterias { get; set; } = new List<TypeFinderCriteria>();

      public static ReadOnlyCollection<TypeFinderCriteria> GetDefaultTypeFinderCriterias()
      {
        return TypeFinderCriterias.AsReadOnly();
      }
    }
  }
}
