using GroupBox.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GroupBox.Tests
{
  public class HomeUnitTest
  {
    [Fact]
    public void Test_Index()
    {
      var sut = new GroupController();
      var view = sut.Group();

      Assert.NotNull(view);
      Assert.IsType<ViewResult>(view);
    }

    [Fact]
    public void Test_Privacy()
    {
      var sut = new HomeController();
      var view = sut.Privacy();

      Assert.NotNull(view);
    }
  }
}