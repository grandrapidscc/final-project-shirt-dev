var rooms = SetupRooms();
var player = new Player(1, 3); // start at room (1, 3)

static Room[,] SetupRooms()
{
    Room[,] rooms = new Room[5, 5];

    rooms[0, 0] = new Room("bruh", null, null);
    rooms[0, 1] = new Room("bruh", new GoblinEnemy(), null);
    rooms[0, 2] = new Room("bruh", null, new HealthPotionPowerup());
    rooms[0, 3] = new Room("bruh", new OrcEnemy(), null);
    rooms[0, 4] = new Room("bruh", null, null);

    rooms[1, 0] = new Room("bruh", new BansheeEnemy(), null);
    rooms[1, 1] = new Room("bruh", null, new MagickaPotionPowerup());
    rooms[1, 2] = new Room("bruh", new GoblinEnemy(), new HealthPotionPowerup());
    rooms[1, 3] = new Room("bruh", null, null);
    rooms[1, 4] = new Room("bruh", new OrcEnemy(), new MagickaPotionPowerup());

    rooms[2, 0] = new Room("bruh", new GoblinEnemy(), null);
    rooms[2, 1] = new Room("bruh", new GoblinEnemy(), new MagickaPotionPowerup());
    rooms[2, 2] = new Room("bruh", null, new HealthPotionPowerup());
    rooms[2, 3] = new Room("bruh", null, new MagickaPotionPowerup());
    rooms[2, 4] = new Room("bruh", null, null);

    rooms[3, 0] = new Room("bruh", new BansheeEnemy(), new HealthPotionPowerup());
    rooms[3, 1] = new Room("bruh", null, new MagickaPotionPowerup());
    rooms[3, 2] = new Room("bruh", new GoblinEnemy(), null);
    rooms[3, 3] = new Room("bruh", null, new HealthPotionPowerup());
    rooms[3, 4] = new Room("bruh", new OrcEnemy(), null);

    rooms[4, 0] = new Room("bruh", new OrcEnemy(), null);
    rooms[4, 1] = new Room("bruh", null, new HealthPotionPowerup());
    rooms[4, 2] = new Room("bruh", null, null);
    rooms[4, 3] = new Room("bruh", new BansheeEnemy(), null);
    rooms[4, 4] = new Room("bruh", null, null);

    return rooms;
}
