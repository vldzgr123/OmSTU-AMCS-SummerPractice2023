using TechTalk.SpecFlow;

namespace SquareEquation.TestsBDD.Steps
{
    [Binding]
    public sealed class SquareEquationStepDefinitions
    {
       private double[] odds = new double[3];
       private double[] result = new double[2];
       private Exception except = new Exception(); 

       [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
       public void SquareEqGiven(string a, string b, string c)
       {
            this.odds = new double[3];
            string[] odds = {a, b, c};
            
            for(var i = 0; i < 3; i++){
                if (odds[i] == "Double.PositiveInfinity")
                    this.odds[i] = double.PositiveInfinity;
                else if (odds[i] == "Double.NegativeInfinity")
                    this.odds[i] = double.NegativeInfinity;
                else if (odds[i] == "NaN")
                    this.odds[i] = double.NaN;
                else
                    this.odds[i] = double.Parse(odds[i]);
            }
       }
        
       [When("вычисляются корни квадратного уравнения")]
       public void SqEqSolve()
       {
           try{
                this.result = SquareEquationLib.SquareEquation.Solve(odds[0], odds[1], odds[2]);
           }
           catch(ArgumentException e){
                except = e;
           }
       }

       [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
       public void ResultTwoRoots(double expect1, double expect2)
       {
           double[] expected = {expect1, expect2};
           Array.Sort(expected);
           Array.Sort(this.result);

           result.Should().ContainInOrder(expected);
       }

       [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
       public void ResultOneRoot(double expected)
       {
           result[0].Should().Be(expected);
       }

       [Then("множество корней квадратного уравнения пустое")]
       public void ResultEmpty()
       {

            result.Length.Should().Be(0);
       }

       [Then("выбрасывается исключение ArgumentException")]
       public void ResultException()
       {
            except.Should().BeOfType<System.ArgumentException>();
       }
    }
}
