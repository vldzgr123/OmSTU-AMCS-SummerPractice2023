namespace SquareEqution.Tests;

public class UnitTest1
{
    [Fact]
    public void TestSolve_WhenAZero()
    {
        var a=0.0;
        var b=1.0;
        var c=1.0;
        var result=SquareEqution.Solve(a,b,c);
        bool flag=false;
        if (result=System.ArgumentException()) flag=true;
        Assert.IsTrue(result);
    }
    [Fact]
    public void  TestSolve_WhenAorBorCInfonityOrNaN(){
        var a=1.0;
        var b=double.PositiveInfinity;
        var c=1.0;
        var result=SquareEqution.Solve(a,b,c);
        Assert.Null(result);
    }
    [Fact]
    public void  TestSolve_WhenNoRoots(){
        var a=1.0;
        var b=double.PositiveInfinity;
        var c=1.0;
        var result=SquareEqution.Solve(a,b,c);
        Assert.Null(result);
    }
    [Fact]
    public void  TestSolve_WhenOneRoots(){
        var a=2.0;
        var b=2.0;
        var c=1.0;
        var result=SquareEqution.Solve(a,b,c);
        Assert.Null(result);
    }
    [Fact]
    public void  TestSolve_WhenTwoRoots(){
        var a=2.0;
        var b=2.0;
        var c=1.0;
        var result=SquareEqution.Solve(a,b,c);
        Assert.Null(result);
    }

}