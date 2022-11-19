class Player
{
    public int HP = 100;
    public int MP = 200;
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

    public void Flee()
    {
        throw new NotImplementedException();
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                if(PositionY < 4) PositionY++;
                break;
            case Direction.South:
                if (PositionY > 0) PositionY--;
                break;
            case Direction.East:
                if(PositionX > 0) PositionX--;
                break;
            case Direction.West:
                if (PositionY < 4) PositionX++;
                break;
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