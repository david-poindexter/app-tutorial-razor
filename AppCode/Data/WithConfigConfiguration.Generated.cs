// DO NOT MODIFY THIS FILE - IT IS AUTO-GENERATED
// See also: https://go.2sxc.org/copilot-data
// To extend it, create a "WithConfigConfiguration.cs" with this contents:
/*
namespace AppCode.Data
{
  public partial class WithConfigConfiguration
  {
    // Add your own properties and methods here
  }
}
*/

// Generator:   CSharpDataModelsGenerator v17.05.00
// App/Edition: Tutorial-Razor/
// User:        2sic Web-Developer
// When:        2024-03-22 17:00:25Z
namespace AppCode.Data
{
  // This is a generated class for WithConfigConfiguration 
  // To extend/modify it, see instructions above.

  /// <summary>
  /// WithConfigConfiguration data. <br/>
  /// Generated 2024-03-22 17:00:25Z. Re-generate whenever you change the ContentType. <br/>
  /// <br/>
  /// Default properties such as `.Title` or `.Id` are provided in the base class. <br/>
  /// Most properties have a simple access, such as `.AmountOfItems`. <br/>
  /// For other properties or uses, use methods such as
  /// .IsNotEmpty("FieldName"), .String("FieldName"), .Children(...), .Picture(...), .Html(...).
  /// </summary>
  public partial class WithConfigConfiguration: AutoGenerated.ZagWithConfigConfiguration
  {  }
}

namespace AppCode.Data.AutoGenerated
{
  /// <summary>
  /// Auto-Generated base class for Default.WithConfigConfiguration in separate namespace and special name to avoid accidental use.
  /// </summary>
  public abstract class ZagWithConfigConfiguration: Custom.Data.CustomItem
  {
    /// <summary>
    /// AmountOfItems as int. <br/>
    /// To get other types use methods such as .Decimal("AmountOfItems")
    /// </summary>
    public int AmountOfItems => _item.Int("AmountOfItems");

    /// <summary>
    /// FavoriteColor as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("FavoriteColor", scrubHtml: true) etc.
    /// </summary>
    public string FavoriteColor => _item.String("FavoriteColor", fallback: "");
  }
}