using ToSic.Razor.Blade;

public class Bootstrap4 : Custom.Hybrid.Code12
{
  // if the theme framework is not BS4, just activate/load it from the WebResources
  // this solves both the cases where its unknown, or another framework
  public void EnsureBootstrap4()
  {
    var pageCss = GetService<Connect.Koi.ICss>();
    if(pageCss.IsUnknown) {
      GetService<ToSic.Sxc.Services.IPageService>().Activate("Bootstrap4");
    }
  }

  // show warning for admin if koi.json is missing
  public dynamic WarnAboutMissingOrUnknownBootstrap() {
    var pageCss = GetService<Connect.Koi.ICss>();
    if (pageCss.IsUnknown && CmsContext.User.IsSiteAdmin) {
      return Tag.Div().Class("dnnFormMessage dnnFormWarning").Wrap(
        Connect.Koi.Messages.CssInformationMissing,
        Tag.Br(),
        Connect.Koi.Messages.OnlyAdminsSeeThis
      );
    }
    return null;
  }
}
