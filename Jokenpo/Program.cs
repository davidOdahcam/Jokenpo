using Jokenpo.Entities;

namespace Jokenpo
{
    internal class Program
    {
        static Dictionary<int, Choice> availableChoices = new Dictionary<int, Choice>();

        static void Main(string[] args)
        {
            LoadGameRules();

            // Jogadores
            Player p1 = new Player { Name = "Jogador 1" };
            Player p2 = new Player { Name = "Jogador 2" };

            PlayMovement(p1);
            PlayMovement(p2);

            if (p1.Choice.Weakness.ContainsKey(p2.Choice.Id))
            {
                Console.WriteLine($"O vencedor do duelo foi {p2.Name}, pois {p2.Choice.Name} vence {p1.Choice.Name}");
            }
            else if (p2.Choice.Weakness.ContainsKey(p1.Choice.Id))
            {
                Console.WriteLine($"O vencedor do duelo foi {p1.Name}, pois {p1.Choice.Name} vence {p2.Choice.Name}");
            }
            else
            {
                Console.WriteLine("Empate");
            }
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

        static void PlayMovement(Player player)
        {
            Console.WriteLine($"Vez de {player.Name}");
            Console.WriteLine("Escolha uma opção válida:");

            availableChoices.ToList().ForEach(c => Console.WriteLine($"{c.Value.Id}: {c.Value.Name}"));

            while (true)
            {
                Console.Write("\nDigite uma opção: ");
                int nChoice = int.Parse(Console.ReadLine());

                if (availableChoices.ContainsKey(nChoice))
                {
                    player.Choice = availableChoices[nChoice];
                    break;
                }

                Console.WriteLine("Escolha uma opção válida!");
            }
        }
    }
}
