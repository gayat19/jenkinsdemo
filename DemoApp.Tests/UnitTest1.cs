using DemoApp;

namespace DemoApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        var calculator = new Calculator();
        Assert.Equal(5, calculator.Add(2, 3));
    }
}
