using SquareEquationLib;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;
using Xunit;



namespace SquareEquationLib.TestsBDD.Steps
{

    [Binding]
    public sealed class StepDefinitions
    {

        private const double eps = 1e-7;
        private double[] _odds = new double[3];
        private double[] _roots = new double[0];
        private Exception _actualException = new Exception();

        [When("вычисляются корни квадратного уравнения")]
        public void GetRoots()
        {
            try
            {
                _roots = SquareEquation.Solve(_odds[0], _odds[1], _odds[2]);
            }
            catch (Exception a)
            {
                _actualException = a;
            }
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void SquareEquationOdds(string a, string b, string c)
        {
            string[] inputOdds = new string[] { a.Split(".")[^1], b.Split(".")[^1], c.Split(".")[^1] };

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
        public void ExistsTwoRootsOne(double a, double b)
        {
            double[] expectedRoots = new double[] { a, b };

            Array.Sort(expectedRoots);
            Array.Sort(_roots);

            if (_roots.Length != 2)
            {
                Assert.True(false, "Message");
            }

            for (int i = 0; i < expectedRoots.Length; i++)
            {
                Assert.Equal(_roots[i], expectedRoots[i]);
            }
        }
        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void SquareEquationHasOneRoot(double x)
        {
            double[] expectedRoots = new double[] { x };

            if (_roots.Length != 1)
            {
                Assert.True(false, "Message");
            }

            for (int i = 0; i < expectedRoots.Length; i++)
            {
                Assert.Equal(_roots[i], expectedRoots[i]);
            }
        }
        [Then("выбрасывается исключение ArgumentException")]
        public void ThrowingArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => throw _actualException);
        }
    }

}
