using ToSic.Razor.Blade;
using ToSic.Sxc.Services;
public class Helpers: Custom.Hybrid.Code12
{

  public dynamic Title(string title) {
    // set browser title for SEO
    var page = GetService<ToSic.Sxc.Web.IPageService>();
    page.SetTitle(title + " DNN / 2sxc Razor Tutorials ");
    return Tag.Custom(
      InitializedPageAssets()
      + TitleLogo("app-icon.png", "https://2sxc.org/dnn-tutorials/en/razor")
      + Tag.H1(title).Attr(Edit.TagToolbar())
    );
  }


  private dynamic Breadcrumb(string name, string topicUrl) {
    var result = Tag.Custom(null).Wrap( 
        Tag.A("Tutorial Home").Href(Link.To())
    );
    if (!string.IsNullOrEmpty(name)) {
      result.Add(" › ", Tag.A(name).Href(Link.To(parameters: topicUrl.Replace("/", "="))));
    }
    return result;
  }

  public dynamic TitleAndBreadcrumb(string title, string name, string topicUrl) {
    return Tag.Custom(
      Title(title).ToString() +
      Breadcrumb(name, topicUrl) +
      Tag.Hr()
    );
  }


  public dynamic TitleLogo(string path, string link, int height = 0) {
    var img = Tag.Img().Src(App.Path + "/" + path + "?w=75&h=75")
      // note: float-right is bs4, float-end BS5
      .Class("float-right ml-3 float-end");
    if (height != 0) img.Style("height: " + height + "px;");
    return Tag.A().Href(link).Target("_blank").Wrap(img);
  }
  
  public dynamic TutLink(string label, string target) {
    target = target.Replace("/", "=");
    target = target + (target.Contains("=") ? "" : "=page");
    return Tag.A(label).Href(Link.To(parameters: target));
  }


  public dynamic TutorialLink(string label, string target, string description = null, string newText = null, string appendix = null) {
    var result = Tag.Li(
      Tag.Strong(
        TutLink(label + " ", target),
        Highlighted(newText),
        appendix
      )
    );
    if(!string.IsNullOrWhiteSpace(description)) {
      result.Add(Tag.Br(), description);
    }
    return result;
  }
  
  public dynamic TutorialLinkHome(string label, string target, string description, string newText = null) {
    return Tag.Li(
      Tag.Strong(
        Tag.A().Href(Link.To(parameters: target + "=home")).Wrap(
          label + " ",
          Highlighted(newText)
        )
      ),
      Tag.Br(),
      description
    );
  }


  public dynamic Highlighted(string specialText) {
    if(specialText == null) { return null; }
    return Tag.Span(specialText).Class("text-warning");
  }


  dynamic InitializedPageAssets() {
    // Tell the page that we need the 2sxc Js APIs
    GetService<IPageService>().Activate("2sxc.JsCore"); 

    var bsCheck = CreateInstance("Bootstrap4.cs");
    bsCheck.EnsureBootstrap4();
    return "<link rel='stylesheet' href='" + @App.Path + "/assets/styles.css' enableoptimizations='true' />";
  }

  public dynamic ExternalLink(string target, string description) {
    return Tag.A(description).Href(target).Target("_blank");
  }

  public dynamic LiExtLink(string target, string description) {
    return Tag.Li(ExternalLink(target, description));
  }  

  public dynamic InfoSection(dynamic content, string title, string icon = "fa-info-circle") {
    return Tag.Div(Tag.H6(Tag.I().Class("fas " + icon), Tag.Span(title).Class("ml-2")).Class("card-header"), Tag.Div(Tag.Ul(content).Class("list-group list-group-flush"))).Class("card");
  }
  public dynamic InfoContent(string title, string link = "", string textColor = "") {
    var content = Tag.Div(title);
    if (Text.Has(link)) {
      return Tag.A(content).Href(link).Target("_blank").Class("list-group-item " + textColor);
    }
    return content.Class("list-group-item " + textColor);
  }
}