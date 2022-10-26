using Xunit;
using MortalKombat;
using Moq;
using MortalKombat.Fighters;
using System.Collections.Generic;

namespace UnitTesting
{
    public class FighterTests
    {
        [Fact]
        public void Hit_ShouldDecreaseLife()
        {
            // arrange
            var sut = new Bruiser();
            sut.BasicDamage = 10;
            sut.CritChance = 0;
            sut.SpecialAvailable = 0;

            var target = new Bruiser();
            target.HP = 100;

            var expected = 90;
            // act
            sut.Hit(target);
            // assert
            Assert.Equal(expected, target.HP);
        }

        [Fact]
        public void CriticalHit_ShouldDecreaseMoreLife()
        {
            // arrange
            var sut = new Bruiser(100, 10, 35, 0, "You Weak, Pathetic Fool!", 100);

            var target = new Bruiser(100, 10, 35, 1, "You Weak, Pathetic Fool!", 50);

            var expected = 80;
            // act
            sut.CalculateCritical();
            target.HP -= sut.BasicDamage;
            // assert
            Assert.Equal(expected, target.HP);
        }

        [Fact]
        public void CriticalHit_ShouldResetDamageAfter()
        {
            // arrange
            var sut = new Bruiser(100, 10, 35, 0, "You Weak, Pathetic Fool!", 100);

            var target = new Bruiser(100, 10, 35, 1, "You Weak, Pathetic Fool!", 50);

            var expected = 70;
            // act
            sut.CalculateCritical();
            target.HP -= sut.BasicDamage;
            sut.CritChance = 1;
            sut.CalculateCritical();
            target.HP -= sut.BasicDamage;
            // assert
            Assert.Equal(expected, target.HP);
        }

        [Fact]
        public void DodgeHit_ShouldTakeNoDamage()
        {
            // arrange
            var sut = new Assassin(100, 10, 35, 0, "You Weak, Pathetic Fool!", 100);
            sut.DodgeSucces = 1;

            var target = new Bruiser(100, 10, 35, 1, "You Weak, Pathetic Fool!", 50);

            var expected = 100;
            // act
            target.Hit(sut);
            // assert
            Assert.Equal(expected, target.HP);
        }

        [Fact]
        public void LastHit_HealthShouldNotBeNegative()
        {
            // arrange
            var sut = new Bruiser(100, 10, 35, 1, "You Weak, Pathetic Fool!", 0);
            sut.DodgeSucces = 1;

            var target = new Bruiser(5, 10, 35, 1, "You Weak, Pathetic Fool!", 50);
            var arena = new Arena();

            var expected = 0;
            // act
            sut.Hit(target);
            arena.PrintFormat(sut, target);

            // assert
            Assert.Equal(expected, target.HP);
        }

        [Fact]
        public void BruiserVersusMage_ShouldBeBalaned()
        {
            // arrange
            var player1 = new Bruiser(100, 10, 35, 1, "You Weak, Pathetic Fool!", 50);
            var player2 = new Mage(100, 15, 30, 1, "Flawless Victory!", 0);
            var arena = new Arena();
            int countWinner1 = 0;
            int countWinner2 = 0;
            Fighter winner = null;
            // act
            for (int i = 0; i < 10; i++)
            {
                while (player1.HP > 0 && player2.HP > 0)
                {
                    player1.Hit(player2);
                    if (player2.HP <= 0)
                    {
                        winner = arena.EndGame(player1, player2);
                        break;
                    }

                    player2.Hit(player1);
                    if (player1.HP <= 0)
                    {
                        winner = arena.EndGame(player1, player2);
                        break;
                    }
                }

                if (String.Equals(winner.GetType().Name, "Bruiser"))
                {
                    countWinner1++;
                } else
                {
                    countWinner2++;
                }
            }
            // assert
            Assert.True(Math.Abs(countWinner2 - countWinner1) <= 3);

        }
    }
}