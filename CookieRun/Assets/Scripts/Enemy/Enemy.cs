using CsvHelper.Configuration.Attributes;

public class Enemy
{
    [Index(0)]
    public int Id { get; set; }
    [Index(1)]
    public string Name { get; set; }
    [Index(2)]
    public string SpriteName { get; set; }
    [Index(3)]
    public string AnimatorName { get; set; }
}

public enum EnemyKind
{
    LarvaSmall,
    LarvaBig,
    LarvaHanging
}
