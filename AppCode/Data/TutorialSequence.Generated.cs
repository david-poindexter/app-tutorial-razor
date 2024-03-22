// DO NOT MODIFY THIS FILE - IT IS AUTO-GENERATED
// See also: https://go.2sxc.org/copilot-data
// To extend it, create a "TutorialSequence.cs" with this contents:
/*
namespace AppCode.Data
{
  public partial class TutorialSequence
  {
    // Add your own properties and methods here
  }
}
*/

// Generator:   CSharpDataModelsGenerator v17.05.00
// App/Edition: Tutorial-Razor/
// User:        2sic Web-Developer
// When:        2024-03-22 17:00:25Z
using System.Collections.Generic;

namespace AppCode.Data
{
  // This is a generated class for TutorialSequence 
  // To extend/modify it, see instructions above.

  /// <summary>
  /// TutorialSequence data. <br/>
  /// Generated 2024-03-22 17:00:25Z. Re-generate whenever you change the ContentType. <br/>
  /// <br/>
  /// Default properties such as `.Title` or `.Id` are provided in the base class. <br/>
  /// Most properties have a simple access, such as `.Sections`. <br/>
  /// For other properties or uses, use methods such as
  /// .IsNotEmpty("FieldName"), .String("FieldName"), .Children(...), .Picture(...), .Html(...).
  /// </summary>
  public partial class TutorialSequence: AutoGenerated.ZagTutorialSequence
  {  }
}

namespace AppCode.Data.AutoGenerated
{
  /// <summary>
  /// Auto-Generated base class for Default.TutorialSequence in separate namespace and special name to avoid accidental use.
  /// </summary>
  public abstract class ZagTutorialSequence: Custom.Data.CustomItem
  {
    /// <summary>
    /// Sections as list of TutorialSection.
    /// </summary>
    /// <remarks>
    /// Generated to return child-list child because field settings had Multi-Value=true. The type TutorialSection was specified in the field settings.
    /// </remarks>
    /// <returns>
    /// An IEnumerable of specified type, but can be empty.
    /// </returns>
    public IEnumerable<TutorialSection> Sections => _sections ??= _item.Children<TutorialSection>("Sections");
    private IEnumerable<TutorialSection> _sections;

    /// <summary>
    /// Teaser as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("Teaser", scrubHtml: true) etc.
    /// </summary>
    public string Teaser => _item.String("Teaser", fallback: "");

    /// <summary>
    /// Title as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("Title", scrubHtml: true) etc.
    /// </summary>
    /// <remarks>
    /// This hides base property Title.
    /// To access original, convert using AsItem(...) or cast to ITypedItem.
    /// Consider renaming this field in the underlying content-type.
    /// </remarks>
    public new string Title => _item.String("Title", fallback: "");
  }
}