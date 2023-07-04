using TechTalk.SpecFlow;
using SpaceBattle;

namespace SpacebBattle.TestsBDD.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
       
       private SpaceBattle _spaceShip = new SpaceBattle();
        private Exception _actualException = new Exception();


       [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
       public void GivenTheFirstNumberIs(double x, double y)
       {
            double[] coordinates=new double[2]{x,y};
            try {
                _spaceShip.SetCoordinates(coordinates);
            }
            catch

       }

       [Given("the second number is (.*)")]
       public void GivenTheSecondNumberIs(int number)
       {
           //TODO: implement arrange (precondition) logic
           // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
           // To use the multiline text or the table argument of the scenario,
           // additional string/Table parameters can be defined on the step definition
           // method. 

           _scenarioContext.Pending();
        
        }
        
        
       [When("происходит прямолинейное равномерное движение без деформации")]
       public void MovementSpaceShip(double[] coordinates,double[] speed)
       {
           
       }

       [Then("the result should be (.*)")]
       public void ThenTheResultShouldBe(int result)
       {
           //TODO: implement assert (verification) logic

           _scenarioContext.Pending();
       }
    }
}
