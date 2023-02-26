using NUnit.Framework;


namespace Blocks
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test_is_valid()
        {
            var config = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 2, 3, 4, 1 },
                { 3, 4, 1, 2 },
                { 4, 1, 2, 3 }
            };
            Assert.That(Helpers.IsValidConfiguration(config), Is.True);
        }

        [Test]
        public void Test_is_not_valid()
        {
            var config = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 2, 3, 4, 1 },
                { 3, 4, 1, 2 },
                { 1, 3, 2, 4 }
            };
            Assert.That(Helpers.IsValidConfiguration(config), Is.False);
        }

        [Test]
        public void Test_all_view()
        {
            var config = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 2, 3, 4, 1 },
                { 3, 4, 1, 2 },
                { 4, 1, 2, 3 }
            };
            Assert.That(Program.GetView(config), Is.EquivalentTo(new[] { 4, 3, 2, 1, 1, 2, 2, 2, 4, 3, 2, 1, 1, 2, 2, 2 }));
        }
    }
}
