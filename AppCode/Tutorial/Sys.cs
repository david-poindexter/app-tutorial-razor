using Custom.Hybrid;
using ToSic.Razor.Blade;
using ToSic.Sxc.Data;
using AppCode.Source;
using AppCode.Output;

namespace AppCode.Tutorial
{

  public class Sys: Custom.Hybrid.CodeTyped
  {
    public Sys Init(RazorTyped page) {
      Path = page.Path;
      return this;
    }

    public string Path {get;set;}

    public SourceCode SourceCode => _sourceCode ??= GetService<SourceCode>().Init(this, Path);
    private SourceCode _sourceCode;

    public ToolbarHelpers ToolbarHelpers => _tlbHelpers ??= GetService<ToolbarHelpers>();
    private ToolbarHelpers _tlbHelpers;

    #region New Links to the new setup

    public IHtmlTag TutPageLink(ITypedItem tutPage) {
      var label = tutPage.String(tutPage.IsNotEmpty("LinkTitle") ? "LinkTitle" : "Title", scrubHtml: "p") + " ";
      var result = Tag.Li()
        .Attr(Kit.Toolbar.Empty().Edit(tutPage))
        .Wrap(
          Tag.Strong(
            Tag.A(label).Href(TutPageUrl(tutPage)),
            Highlighted(tutPage.String("LinkEmphasis"))
          )
        );
      if (tutPage.IsNotEmpty("LinkTeaser")) {
        result = result.Add(Tag.Br(), tutPage.String("LinkTeaser"));
      } else if (tutPage.IsNotEmpty("Intro")) {
        result = result.Add(Tag.Br(), Text.Ellipsis(tutPage.String("Intro", scrubHtml: true), 250));
      }
      return result;
    }

    public string TutPageUrl(ITypedItem tutPage) {
      if (tutPage == null) return null;
      return Link.To(parameters: MyPage.Parameters.Set("tut", tutPage.String("NameId").BeforeLast("-Page")));
    }

    #endregion

    private IHtmlTag Highlighted(string specialText) {
      if (specialText == null) { return null; }
      return Tag.Span(specialText).Class("text-warning");
    }

  }
}