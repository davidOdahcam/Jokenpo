using Jokenpo.Entities;

namespace Jokenpo
{
    internal class Program
    {
        static Dictionary<int, Choice> availableChoices = new Dictionary<int, Choice>();

        static void Main(string[] args)
        {
        }

        static void LoadGameRules()
        {
            var rock     = new Choice { Id = 1, Name = "Pedra" };
            var paper    = new Choice { Id = 2, Name = "Papel" };
            var scissors = new Choice { Id = 3, Name = "Tesoura" };
            var lizard   = new Choice { Id = 4, Name = "Lagarto" };
            var spock    = new Choice { Id = 5, Name = "Spock" };

            availableChoices.Add(rock.Id, rock);
            availableChoices.Add(paper.Id, paper);
            availableChoices.Add(scissors.Id, scissors);
            availableChoices.Add(lizard.Id, lizard);
            availableChoices.Add(spock.Id, spock);

            // Regras do jogo
            rock.AddWeakness(paper);
            rock.AddWeakness(spock);

            paper.AddWeakness(scissors);
            paper.AddWeakness(lizard);

            scissors.AddWeakness(spock);
            scissors.AddWeakness(rock);

            lizard.AddWeakness(rock);
            lizard.AddWeakness(scissors);

            spock.AddWeakness(lizard);
            spock.AddWeakness(paper);
        }

    }
        }
