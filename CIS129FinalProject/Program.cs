var rooms = SetupRooms();
var player = new Player(1, 3); // start at room (1, 3)

do
{
    var currentRoom = rooms[player.PositionX, player.PositionY];

    if(currentRoom.Enemy != null && currentRoom.Enemy.IsAlive)
    {
        Console.WriteLine(currentRoom.Enemy.Name);
    }

    if (currentRoom.Powerup != null && !currentRoom.Powerup.IsUsed)
    {
        Console.WriteLine(currentRoom.Powerup.Name);
    }

    bool moved = false;
    string message = @"You are in a room illuminated by torches.  It reeks of orc, though you do not see any nearby.  Press...
1.	To go north
2.	To go south
3.	To go east
4.	To go west
";

    Console.WriteLine(message);

    do
    {
        var response = Console.ReadKey(true);

        switch (response.Key)
        {
            case ConsoleKey.D1:
                moved = player.Move(Direction.North);
                break;
            case ConsoleKey.D2:
                moved = player.Move(Direction.South);
                break;
            case ConsoleKey.D3:
                moved = player.Move(Direction.East);
                break;
            case ConsoleKey.D4:
                moved = player.Move(Direction.West);
                break;
            default:
                break;
        }

        if (!moved)
        {
            Console.WriteLine("You have hit a wall. Try going a different direction.");
            continue;
        }

    } while (!moved);
    

} while (player.HP > 0);


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
