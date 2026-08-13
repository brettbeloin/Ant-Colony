using Ant_Colony.Controllers;

namespace AntColonyAutomatedTester
{
    public class ResourceManagerTests 
    {
        [Theory]
        [InlineData(1,1,1)]
        [InlineData(2,2,4)]
        public void GatherLeaves_GainCorrectAmountOfLeaves(int ants, int amountPerAnt, int correctResults)
        {
            //Act and Assert
            ResourceManager.GatherLeaves(ants, amountPerAnt);
            Assert.Equal(ResourceManager.Leaves, correctResults);
        }
    }
}
