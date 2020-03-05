using NUnit.Framework;

namespace tpe_manager
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_passe_2_then_return_OneCoins()
        {
            var manager = new Manager(2);

            var res = manager.GetChange();

            Assert.AreEqual(0, res.Billet10);
            Assert.AreEqual(0, res.Billet5);
            Assert.AreEqual(1, res.Coin2);
        }

        [Test]
        public void When_passe_4_then_return_2_Coins()
        {
            var manager = new Manager(4);

            var res = manager.GetChange();

            Assert.AreEqual(0, res.Billet10);
            Assert.AreEqual(0, res.Billet5);
            Assert.AreEqual(2, res.Coin2);
        }

        [Test]
        public void When_passe_5_then_return_1_Billet5()
        {
            var manager = new Manager(5);

            var res = manager.GetChange();

            Assert.AreEqual(0, res.Billet10);
            Assert.AreEqual(1, res.Billet5);
            Assert.AreEqual(0, res.Coin2);
        }

        [Test]
        public void When_passe_10_then_return_1_Billet10()
        {
            var manager = new Manager(10);

            var res = manager.GetChange();

            Assert.AreEqual(1, res.Billet10);
            Assert.AreEqual(0, res.Billet5);
            Assert.AreEqual(0, res.Coin2);
        }

        [Test]
        public void When_passe_12_then_return_1_Billet10_And_1_Coins2()
        {
            var manager = new Manager(12);

            var res = manager.GetChange();

            Assert.AreEqual(1, res.Billet10);
            Assert.AreEqual(0, res.Billet5);
            Assert.AreEqual(1, res.Coin2);
        }

        [Test]
        public void When_passe_19_then_return_1_Billet10_And_1_Billet5_And_2_Coins2()
        {
            var manager = new Manager(19);

            var res = manager.GetChange();

            Assert.AreEqual(1, res.Billet10);
            Assert.AreEqual(1, res.Billet5);
            Assert.AreEqual(2, res.Coin2);
        }

        [Test]
        public void When_passe_7_then_return_1_Billet5_And_1_Coins2()
        {
            var manager = new Manager(7);

            var res = manager.GetChange();

            Assert.AreEqual(0, res.Billet10);
            Assert.AreEqual(1, res.Billet5);
            Assert.AreEqual(1, res.Coin2);
        }

        [Test]
        public void When_passe_28_then_return_2_Billet10_And_4_Coins2()
        {
            var manager = new Manager(28);

            var res = manager.GetChange();

            Assert.AreEqual(2, res.Billet10);
            Assert.AreEqual(0, res.Billet5);
            Assert.AreEqual(4, res.Coin2);
        }

        [Test]
        public void When_passe_37_then_return_3_Billet10_And_1_Coins2_And_1_Billet5()
        {
            var manager = new Manager(37);

            var res = manager.GetChange();

            Assert.AreEqual(3, res.Billet10);
            Assert.AreEqual(1, res.Billet5);
            Assert.AreEqual(1, res.Coin2);
        }

        [Test]
        public void When_passe_3_then_return_Empty()
        {
            var manager = new Manager(3);

            var res = manager.GetChange();

            Assert.IsNull(res);
        }
    }
}