using Ant_Colony.Controllers;
using Ant_Colony.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntColonyAutomatedTester
{
    public class TestAntClasses
    {
        [Theory]
        [InlineData(1,2)]
        [InlineData(0,1)]
        [InlineData(3,4)]
        public void GetAttackDamage_ScalesProperlyWithLevel(int levelUpTimes, int correctValue)
        {
            // Arrange
            BaseAnt ant = new BaseAnt();

            // Act
            ant.LevelUp(levelUpTimes);

            // Assert

            Assert.Equal(correctValue, ant.GetAttackDamage());

        }

        [Theory]
        [InlineData(-1,1)]
        [InlineData(0,1)] 
        [InlineData(1,3)] 
        [InlineData(2,2)]
        public void AntDamageConstant_PolymorhpismWorks(int antType, int correctValue)
        {
            // arrange
            BaseAnt ant = AntManager.InstantiateAnt(antType);

            // Assert
            Assert.Equal(correctValue, ant.BASE_DAMAGE); 
        }

        [Theory]
        [InlineData(-1, 0, 1)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0, 3)]
        [InlineData(1, 2, 9)]
        [InlineData(2, 1, 4)]
        public void GetAttackDamage_ScalesWithPolymorphicStats(int antType, int levelUpTimes, int correctValue)
        {
            // Arrange
            BaseAnt ant = AntManager.InstantiateAnt(antType);

            // Act
            ant.LevelUp(levelUpTimes);

            // Assert
            Assert.Equal(correctValue, ant.GetAttackDamage());

        }

        [Theory]
        [InlineData(1,2)]
        [InlineData(0,1)]
        [InlineData(3,4)]
        public void GetDefenceAmount_ScalesProperlyWithLevel(int levelUpTimes, int correctValue)
        { 
            // Arrange
            BaseAnt ant = new BaseAnt();

            // Act
            ant.LevelUp(levelUpTimes);

            // Assert

            Assert.Equal(correctValue, ant.GetDefenceAmount());
        }

        [Theory]
        [InlineData(-1, 0, 1)]
        [InlineData(0, 0, 3)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 2, 3)]
        [InlineData(2, 1, 4)]
        public void GetDefenceAmount_ScalesWithPolymorphicStats(int antType, int levelUpTimes, int correctValue)
        { 
            // Arrange
            BaseAnt ant = AntManager.InstantiateAnt(antType);

            // Act
            ant.LevelUp(levelUpTimes);

            // Assert
            Assert.Equal(correctValue, ant.GetDefenceAmount());
        }

    }
}
