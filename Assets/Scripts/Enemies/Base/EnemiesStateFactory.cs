public class EnemiesStateFactory
{
    //Sử dụng StateFactory để quản lý State của Enemies
    //Thuận tiện hơn cho việc sử dụng và thêm mới state
    //Thay vì khởi tạo ở các class khác nhau dùng state factory giúp dễ dàng quản lý các state hơn
    
    EnemiesStateManager _context;

    public EnemiesStateFactory(EnemiesStateManager currentContext)
    {
        _context = currentContext;
    }

    //Mushroom
    public EnemiesBaseState MushroomWalk()
    {
        return new MushRoomWalkState(_context, this);
    }

    //Plant
    public EnemiesBaseState PlantIdle()
    {
        return new PlantIdleState(_context, this);
    }
    public EnemiesBaseState PlantAttack()
    {
        return new PlantAttackState(_context, this);
    }

    //AngryPig
    public EnemiesBaseState PigWalk()
    {
        return new PigWalkState(_context, this);
    }
    public EnemiesBaseState PigAttack()
    {
        return new PigAttackState(_context, this);
    }

    //Rino
    public EnemiesBaseState RinoIdle()
    {
        return new RinoIdleState(_context, this);
    }
    public EnemiesBaseState RinoAttack()
    {
        return new RinoAttackState(_context, this);
    }

    //Trunk
    public EnemiesBaseState TrunkWalk()
    {
        return new TrunkWalkState(_context, this);
    }
    public EnemiesBaseState TrunkAttack()
    {
        return new TrunkAttackState(_context, this);
    }

    //Radish
    public EnemiesBaseState RadishFly()
    {
        return new RadishFlyingState(_context, this);
    }
    public EnemiesBaseState RadishGotHit()
    {
        return new RadishGotHitState(_context, this);
    }
    public EnemiesBaseState RadishIdle()
    {
        return new RadishIdleState(_context, this);
    }
    public EnemiesBaseState RadishWalk()
    {
        return new RadishWalkState(_context, this);
    }

    //BlueBird
    public EnemiesBaseState BirdIdle()
    {
        return new BirdIdleState(_context, this);
    }
    public EnemiesBaseState BirdAttack()
    {
        return new BirdAttackState(_context, this);
    }
}
