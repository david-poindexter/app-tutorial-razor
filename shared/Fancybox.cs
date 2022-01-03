using ToSic.Sxc.Services;
using ToSic.Razor.Blade;
public class Fancybox: Custom.Hybrid.Code12
{
  // Create an image which opens a larger version in a lighbox
  public dynamic PreviewWithLightbox(string url, int width = 100, int height = 100, string classes = "", string label = null)
  {
    // Make sure the fancybox is added to the page, but only once
    GetService<IPageService>().Activate("fancybox4"); 

    return Tag.Figure(
      Tag.A().Attr("data-fancybox='gallery'").Href(url).Class(classes).Attr("data-caption", label).Wrap(
        Tag.Img().Src(Link.Image(url, width: width, height: height))
      )
    );
  }
}