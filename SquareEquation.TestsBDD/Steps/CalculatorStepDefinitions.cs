using SquareEquationLib;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;



namespace SquareEquation.TestsBDD.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {

       private const double eps=1e-7;
       private double[] _odds=new double[3];
       private double[] _roots=new double[0];
       private Exception _actualException=new Exception();
       
       [When("вычисляются корни квадратного уравнения")]
       public void GetRoots(){
        try{
            _roots=SquareEquation.Solve(_odds[0],_odds[1],_odds[2]);
        }
        catch(Exception a){
            _actualException=a;
        }
       }

       [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
       public void SquareEquationOdds(string a,string b,string c)
       {
             string[] inputOdds = new string[] {a.Split(".")[^1], b.Split(".")[^1], c.Split(".")[^1]};
        
        for (int i = 0; i < 3; i++)
        {
            if (inputOdds[i] == "NegativeInfinity")
                _odds[i] = double.NegativeInfinity;
            if (inputOdds[i] == "PositiveInfinity")
                _odds[i] = double.PositiveInfinity;
            if (inputOdds[i] == "NaN")
                _odds[i] = double.NaN;
            else
                _odds[i] = Convert.ToDouble(inputOdds[i]);
        }
       }

       [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
       public void GivenTheSecondNumberIs(int number)
       {
           _scenarioContext.Pending();
        }
        
       [When("the two numbers are added")]
       public void WhenTheTwoNumbersAreAdded()
       {
           //TODO: implement act (action) logic

           _scenarioContext.Pending();
       }

       [Then("the result should be (.*)")]
       public void ThenTheResultShouldBe(int result)
       {
           //TODO: implement assert (verification) logic

           _scenarioContext.Pending();
       }
    }
}
