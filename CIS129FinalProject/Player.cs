class Player
{
    public int HP = 100;
    public int MP = 200;
    public bool IsAlive = true;
    public int PositionX;
    public int PositionY;

    public void Fireball(Enemy enemy)
    {
        MP -= 3;
        enemy.TakeDamage(5);
    }

    public void Heal()
    {
        MP -= 5;
        HP += 3;
    }

    public bool Flee()
    {
        Random random = new Random();
        int result = random.Next(0, 100);
        return result <= 50;
    }

    public bool Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                if (PositionY < 4) PositionY++;
                else return false;
                break;
            case Direction.South:
                if (PositionY > 0) PositionY--;
                else return false;
                break;
            case Direction.East:
                if(PositionX > 0) PositionX--;
                else return false;
                break;
            case Direction.West:
                if (PositionX < 4) PositionX++;
                else return false;
                break;
            default:
                throw new NotImplementedException();
        }

        return true;
    }
    public void TakeDamage(int hp)
    {
        HP -= hp;
        if (HP <= 0)
        {
            HP = 0;
            IsAlive = false;
        }
    }

    public Player(int x, int y)
    {
        PositionX = x;
        PositionY = y;
    }
}

enum Direction
{
    North,
    South,
    East,
    West
}


enum PlayerAction
{
    Fireball,
    Heal,
    Flee
}