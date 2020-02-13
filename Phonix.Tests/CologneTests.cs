using Xunit;

namespace Phonix.Tests
{
    public class CologneTests
    {
        private static readonly string[] Names1 = new[] { "Müller", "Müler" };
        private static readonly string[] Names2 = new[] { "Schäfer", "Shepher" };
        readonly ColognePhonetic _generator = new ColognePhonetic();

        [Fact]
        public void Should_Be_Similar()
        {
            Assert.True(_generator.IsSimilar(Names1));
            Assert.True(_generator.IsSimilar(Names2));
        }
    }
}
