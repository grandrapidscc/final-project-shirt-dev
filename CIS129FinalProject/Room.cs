class Room
{
    public string Description = "";
    public Enemy? Enemy;
    public Powerup? Powerup;
    public bool IsExit = false;

    public Room(string description, Enemy? enemy, Powerup? powerup)
    {
        Description = description;
        Enemy = enemy;
        Powerup = powerup;
    }
}