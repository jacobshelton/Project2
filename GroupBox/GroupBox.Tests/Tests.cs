using GroupBox.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GroupBox.Tests
{
  public class HomeUnitTest
  {
    [Fact]
    public void Test_Group()
    {
      var sut = new GroupController();
      var view = sut.Group();

      Assert.NotNull(view);
    }

    [Fact]
    public void Test_AllGroups()
    {
      var sut = new GroupController();
      var view = sut.AllGroups();

      Assert.NotNull(view);
    }
  }
}