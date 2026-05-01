namespace Server.data;

public class MainDbContext : DbContext {
    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options) {
    }

    protected MainDbContext(DbContextOptions options)
        : base(options) {
    }
}

public class SubDbContext : MainDbContext {
    public SubDbContext (DbContextOptions<SubDbContext> options)
        : base(options) {
    }
}
