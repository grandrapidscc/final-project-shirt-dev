using Spectre.Console;

do
{
    var rooms = SetupRooms();

    var random = new Random();
    var player = new Player(random.Next(0, 5), random.Next(0, 5));

    rooms[random.Next(0, 5), random.Next(0, 5)].IsExit = true;

    do
    {
        var currentRoom = rooms[player.PositionX, player.PositionY];
        bool fled = false;

        if (currentRoom.IsExit)
        {
            bool continueGame = AnsiConsole.Confirm("Congratulations! You have won the game!\nWould you like to play again?");
            if (!continueGame)
            {
                AnsiConsole.WriteLine("Thank you for playing!");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            break;
        }

        if (currentRoom.Enemy != null && currentRoom.Enemy.IsAlive)
        {
            do
            {
                AnsiConsole.Clear();
                AnsiConsole.WriteLine(string.Format("You have encountered a {0}!", currentRoom.Enemy.Name));
                AnsiConsole.WriteLine(string.Format("{0} used {1}!", currentRoom.Enemy.Name, currentRoom.Enemy.AttackName));
                currentRoom.Enemy.Attack(player);
                AnsiConsole.WriteLine(string.Format("\nYour HP: {0}\nYour MP: {1}\nEnemy HP: {2}\n", player.HP, player.MP, currentRoom.Enemy.HP));


                var choice = AnsiConsole.Prompt(new SelectionPrompt<PlayerAction>()
                    .Title("What do you want to do?")
                    .AddChoices(new[] { PlayerAction.Fireball, PlayerAction.Heal, PlayerAction.Flee })
                );

                switch (choice)
                {
                    case PlayerAction.Fireball:
                        AnsiConsole.Clear();
                        player.Fireball(currentRoom.Enemy);
                        AnsiConsole.WriteLine("You cast a fireball!");
                        if (!currentRoom.Enemy.IsAlive)
                        {
                            AnsiConsole.WriteLine(string.Format("{0} fainted.", currentRoom.Enemy.Name));
                        }
                        break;
                    case PlayerAction.Heal:
                        AnsiConsole.Clear();
                        player.Heal();
                        AnsiConsole.WriteLine("You cast a spell to heal your wounds!\nYou regained 3 HP.");
                        break;
                    case PlayerAction.Flee:
                        AnsiConsole.Clear();
                        fled = player.Flee();
                        if (fled) AnsiConsole.WriteLine("You got away safely!");
                        else AnsiConsole.WriteLine("You couldn't get away!");
                        break;
                }

                Thread.Sleep(3000);
                AnsiConsole.Clear();

            } while (currentRoom.Enemy.IsAlive && player.IsAlive && !fled);

        }

        if (currentRoom.Powerup != null && !currentRoom.Powerup.IsUsed && !fled)
        {
            AnsiConsole.Clear();
            AnsiConsole.WriteLine(string.Format("You found a {0}!", currentRoom.Powerup.Name));
            currentRoom.Powerup.Use(player);
            switch (currentRoom.Powerup.Type)
            {
                case PowerupType.HealthPotion:
                    AnsiConsole.WriteLine(string.Format("The potion restores {0} HP!", currentRoom.Powerup.HP));
                    break;
                case PowerupType.MagickaPotion:
                    AnsiConsole.WriteLine(string.Format("The potion restores {0} MP!", currentRoom.Powerup.MP));
                    break;
            }
            currentRoom.Powerup.Use(player);
            AnsiConsole.WriteLine(string.Format("\nYour HP: {0}\nYour MP: {1}", player.HP, player.MP));

            Thread.Sleep(3000);
            AnsiConsole.Clear();

        }

        bool moved;
        do
        {
            AnsiConsole.Clear();
            AnsiConsole.WriteLine(string.Format("Your HP: {0}\nYour MP: {1}\n", player.HP, player.MP));

            var direction = AnsiConsole.Prompt(new SelectionPrompt<Direction>()
            .Title("You are in a room illuminated by torches. Which direction would you like to go?")
            .AddChoices(new[] { Direction.North, Direction.South, Direction.East, Direction.West })
            );

            moved = player.Move(direction);

            if (!moved)
            {
                AnsiConsole.WriteLine("You have hit a wall. Try going a different direction.\n");
                Thread.Sleep(3000);
                AnsiConsole.Clear();
                continue;
            }

        } while (!moved);


    } while (player.IsAlive);

} while (true);


static Room[,] SetupRooms()
{
    Room[,] rooms = new Room[5, 5];

    rooms[0, 0] = new Room("bruh", null, null);
    rooms[0, 1] = new Room("bruh", new Enemy(EnemyType.Goblin), null);
    rooms[0, 2] = new Room("bruh", null, new Powerup(PowerupType.HealthPotion));
    rooms[0, 3] = new Room("bruh", new Enemy(EnemyType.Orc), null);
    rooms[0, 4] = new Room("bruh", null, null);

    rooms[1, 0] = new Room("bruh", new Enemy(EnemyType.Banshee), null);
    rooms[1, 1] = new Room("bruh", null, new Powerup(PowerupType.MagickaPotion));
    rooms[1, 2] = new Room("bruh", new Enemy(EnemyType.Goblin), new Powerup(PowerupType.HealthPotion));
    rooms[1, 3] = new Room("bruh", null, null);
    rooms[1, 4] = new Room("bruh", new Enemy(EnemyType.Orc), new Powerup(PowerupType.MagickaPotion));

    rooms[2, 0] = new Room("bruh", new Enemy(EnemyType.Goblin), null);
    rooms[2, 1] = new Room("bruh", new Enemy(EnemyType.Goblin), new Powerup(PowerupType.MagickaPotion));
    rooms[2, 2] = new Room("bruh", null, new Powerup(PowerupType.HealthPotion));
    rooms[2, 3] = new Room("bruh", null, new Powerup(PowerupType.MagickaPotion));
    rooms[2, 4] = new Room("bruh", null, null);

    rooms[3, 0] = new Room("bruh", new Enemy(EnemyType.Banshee), new Powerup(PowerupType.HealthPotion));
    rooms[3, 1] = new Room("bruh", null, new Powerup(PowerupType.MagickaPotion));
    rooms[3, 2] = new Room("bruh", new Enemy(EnemyType.Goblin), null);
    rooms[3, 3] = new Room("bruh", null, new Powerup(PowerupType.HealthPotion));
    rooms[3, 4] = new Room("bruh", new Enemy(EnemyType.Orc), null);

    rooms[4, 0] = new Room("bruh", new Enemy(EnemyType.Orc), null);
    rooms[4, 1] = new Room("bruh", null, new Powerup(PowerupType.HealthPotion));
    rooms[4, 2] = new Room("bruh", null, null);
    rooms[4, 3] = new Room("bruh", new Enemy(EnemyType.Banshee), null);
    rooms[4, 4] = new Room("bruh", null, null);

    return rooms;
}
