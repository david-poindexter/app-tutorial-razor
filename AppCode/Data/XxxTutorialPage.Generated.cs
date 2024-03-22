// DO NOT MODIFY THIS FILE - IT IS AUTO-GENERATED
// See also: https://go.2sxc.org/copilot-data
// To extend it, create a "XxxTutorialPage.cs" with this contents:
/*
namespace AppCode.Data
{
  public partial class XxxTutorialPage
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
using ToSic.Sxc.Data;

namespace AppCode.Data
{
  // This is a generated class for XxxTutorialPage 
  // To extend/modify it, see instructions above.

  /// <summary>
  /// XxxTutorialPage data. <br/>
  /// Generated 2024-03-22 17:00:25Z. Re-generate whenever you change the ContentType. <br/>
  /// <br/>
  /// Default properties such as `.Title` or `.Id` are provided in the base class. <br/>
  /// Most properties have a simple access, such as `.Accordions`. <br/>
  /// For other properties or uses, use methods such as
  /// .IsNotEmpty("FieldName"), .String("FieldName"), .Children(...), .Picture(...), .Html(...).
  /// </summary>
  public partial class XxxTutorialPage: AutoGenerated.ZagXxxTutorialPage
  {  }
}

namespace AppCode.Data.AutoGenerated
{
  /// <summary>
  /// Auto-Generated base class for Default.XxxTutorialPage in separate namespace and special name to avoid accidental use.
  /// </summary>
  public abstract class ZagXxxTutorialPage: Custom.Data.CustomItem
  {
    /// <summary>
    /// Accordions as list of ITypedItem.
    /// </summary>
    /// <remarks>
    /// Generated to return child-list child because field settings had Multi-Value=true. 
    /// </remarks>
    /// <returns>
    /// An IEnumerable of specified type, but can be empty.
    /// </returns>
    public IEnumerable<ITypedItem> Accordions => _accordions ??= _item.Children("Accordions");
    private IEnumerable<ITypedItem> _accordions;

    /// <summary>
    /// Intro as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("Intro", scrubHtml: true) etc.
    /// </summary>
    public string Intro => _item.String("Intro", fallback: "");

    /// <summary>
    /// IntroMoreDyn as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("IntroMoreDyn", scrubHtml: true) etc.
    /// </summary>
    public string IntroMoreDyn => _item.String("IntroMoreDyn", fallback: "");

    /// <summary>
    /// IntroMoreTyped as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("IntroMoreTyped", scrubHtml: true) etc.
    /// </summary>
    public string IntroMoreTyped => _item.String("IntroMoreTyped", fallback: "");

    /// <summary>
    /// NameId as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("NameId", scrubHtml: true) etc.
    /// </summary>
    public string NameId => _item.String("NameId", fallback: "");

    /// <summary>
    /// Note as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("Note", scrubHtml: true) etc.
    /// </summary>
    public string Note => _item.String("Note", fallback: "");

    /// <summary>
    /// Notes as list of TutorialNote.
    /// </summary>
    /// <remarks>
    /// Generated to return child-list child because field settings had Multi-Value=true. The type TutorialNote was specified in the field settings.
    /// </remarks>
    /// <returns>
    /// An IEnumerable of specified type, but can be empty.
    /// </returns>
    public IEnumerable<TutorialNote> Notes => _notes ??= _item.Children<TutorialNote>("Notes");
    private IEnumerable<TutorialNote> _notes;

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

    /// <summary>
    /// TitleForPicker as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("TitleForPicker", scrubHtml: true) etc.
    /// </summary>
    public string TitleForPicker => _item.String("TitleForPicker", fallback: "");
  }
}