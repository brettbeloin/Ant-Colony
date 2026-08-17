using Ant_Colony.Controllers;

namespace AntColonyAutomatedTester
{
    public class ResourceManagerTests 
    {
        [Theory]
        [InlineData(1,1,1)]
        [InlineData(2,2,4)]
        [InlineData(3,0,0)]
        public void GatherLeaves_GainCorrectAmountOfLeaves(int ants, int amountPerAnt, int correctResults)
        {
            // Arrange
            ResourceManager.ResetResources();

            //Act and Assert
            ResourceManager.GatherLeaves(ants, amountPerAnt);
            Assert.Equal(correctResults, ResourceManager.Leaves );
        }

        
        [Theory]
        [InlineData(1,1,1)]
        [InlineData(2,2,4)]
        [InlineData(3,0,0)]
        public void GatherFood_GainCorrectAmountOfFood(int ants, int amountPerAnt,int correctResults)
        { 
            // Arrange
            ResourceManager.ResetResources();

            //Act and Assert
            ResourceManager.GatherLeaves(ants, amountPerAnt);
            ResourceManager.GatherFood(ants, amountPerAnt);
            Assert.Equal(correctResults, ResourceManager.Food );
        }
 
        [Theory]
        [InlineData(1,1,10,1)]
        [InlineData(2,2,10,4)]
        [InlineData(6,2,10,10)]
        public void GatherFood_LooseCorrectAmountOfLeaves(int ants, int amountPerAnt, int amountOfLeaves,int correctResults)
        { 
            // Arrange
            ResourceManager.ResetResources();
            ResourceManager.GatherLeaves(amountOfLeaves);

            //Act and Assert
            ResourceManager.GatherFood(ants, amountPerAnt);
            Assert.Equal(correctResults, ResourceManager.Leaves );
        }
    }
}
