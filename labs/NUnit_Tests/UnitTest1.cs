using NUnit.Framework;
using lab_12_test_me_out;
using do_it_08_tests_raise_to_power;
using do_it_rabbit_explosion;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMeSomething_RunTestMeNow()
        {
            var expected = 100;
            var actual = TestMeSomething.RunThisTestNow(10);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 100)]
        [TestCase(100, 10000)]
        [TestCase(9, 81)]

        public void TestMeSomething_RunTestMeNow( int input, int expected)
        {
            var actual = TestMeSomething.RunThisTestNow(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MathTools_RaiseToPower()
        {
            var expected = 216;
            var actual = MathTools.RaiseToPower(2, 3, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3, 3, 216)]
        [TestCase(3, 4, 2, 144)]
        [TestCase(1, 9, 3, 729)]
        public void MathTools_RaiseToPower(int input01, int input02, int input03, int expected)
        {
            var actual = MathTools.RaiseToPower(input01, input02, input03);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000, 20)]
        public void TestRabbitExplosion(int populationLimit, int expected)
        {
            var tuple = just_do_it_11_rabbit_exp.ExponentialGrowth(populationLimit);
            int actual = tuple.years;
            int popCount = tuple.population;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(populationLimit, popCount);
        }
    }
}