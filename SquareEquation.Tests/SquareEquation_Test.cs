using Xunit;
using SquareEquationLib;

namespace SquareEquation_Test
{
    public class SquareEquation_Test{
     [Fact]
    public void UnitTest_NoRoots()
    {
        double a=2;
        double b=2;
        double c=2;
        var result=SquareEquation.Solve(a,b,c);
        Assert.Equal(new double[0],result);
    }
    [Fact]
    public void UnitTest_OneRoots()
    {
        double a=1;
        double b=2;
        double c=1;
        var result=SquareEquation.Solve(a,b,c);
        Assert.Equal(new double[1]{-1},result);
    }
    [Fact]
    public void UnitTest_TwoRoots()
    {
        double a=1;
        double b=5;
        double c=4;
        var result=SquareEquation.Solve(a,b,c);
        Assert.Equal(new double[2]{-1,-4},result);
    }
    [Fact]
    public void UnitTest_AZero()
    {
        double a=0.1;
        double b=2;
        double c=3;
        var result=SquareEquation.Solve(a,b,c);
        Assert.Throws<System.ArgumentException>(() => result);
    }
    [Fact]
    public void UnitTest_NaNOrInfinity()
    {
        double a=1;
        double b=double.PositiveInfinity;
        double c=3;
        var result=SquareEquation.Solve(a,b,c);
        Assert.Throws<System.ArgumentException>(() => result);
    }
}
}