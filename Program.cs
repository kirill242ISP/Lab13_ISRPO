// Probe.Run();

Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);
Hero alexander = new Hero("   Александр   ", 150);
Hero sergey = new Hero("Сергей", 110);

alexander.TakeDamage(10);
alexander.Heal(10);

Guild guild = new Guild("Гильдия героев");
guild.AddHero(yaroslav);
guild.AddHero(anastasia);
guild.AddHero(artem);
guild.AddHero(alexander);
guild.AddHero(sergey);

List<Hero> members = guild.GetMembers();

Console.WriteLine($">>> {guild.Name}: перекличка <<<");
Console.WriteLine($"Участников: {guild.MemberCount}");

if (members.Count > 0)
{
    Console.WriteLine($"Первый: {members[0].Name}");
    Console.WriteLine($"Последний: {members[members.Count - 1].Name}");
}

Console.WriteLine();
foreach (Hero hero in members)
{
    Console.WriteLine(hero.GetInfo());
    Console.WriteLine();
}

Hero? found = guild.FindHeroByName(" аРтЁм ");
if (found != null)
{
    Console.WriteLine($"Найден по запросу « аРтЁм »: {found.Name}");
}
else
{
    Console.WriteLine("По запросу « аРтЁм » никого нет.");
}

Console.WriteLine($"Повтор Александра принят: {guild.AddHero(alexander)}");
Console.WriteLine($"Удалён отсутствующий: {guild.RemoveHero("Борис")}");
Console.WriteLine($"Участников после проверок: {guild.MemberCount}");

Console.WriteLine($"Могут нести тяжёлые ящики (здоровье от 120): {guild.CountHealthy(120)}");

Hero? strongest = guild.FindStrongest();
if (strongest != null)
{
    Console.WriteLine($"Самый здоровый: {strongest.Name} ({strongest.Health})");
}

Console.WriteLine();
Warehouse warehouse = new Warehouse("Оружейный склад гильдии");

Product shield = new Product("Железный щит", 800, 10);
Product sword = new Product("Стальной меч", 1200, 2);
Product potion = new Product("Зелье лечения", 150, 15);
Product bow = new Product("Охотничий лук", 950, 1);

Console.WriteLine($">>> {warehouse.Name} <<<");
Console.WriteLine($"Приём «Железный щит»: {warehouse.AddProduct(shield)}");
Console.WriteLine($"Приём «Стальной меч»: {warehouse.AddProduct(sword)}");
Console.WriteLine($"Приём «Зелье лечения»: {warehouse.AddProduct(potion)}");
Console.WriteLine($"Приём «Охотничий лук»: {warehouse.AddProduct(bow)}");
Console.WriteLine($"Повтор «СТАЛЬНОЙ МЕЧ» принят: {warehouse.AddProduct(new Product("  СТАЛЬНОЙ МЕЧ ", 1200, 5))}");
Console.WriteLine($"Позиций на складе: {warehouse.ProductCount}");

Product? foundProduct = warehouse.FindProductByName("  зелье лечения ");
if (foundProduct != null)
{
    Console.WriteLine($"Найден товар: {foundProduct.Name} | Цена: {foundProduct.Price} | Остаток: {foundProduct.StockQuantity} шт.");
}
else
{
    Console.WriteLine("Товар не найден.");
}

Product? missingProduct = warehouse.FindProductByName("Волшебный посох");
if (missingProduct != null)
{
    Console.WriteLine($"Найден товар: {missingProduct.Name}");
}
else
{
    Console.WriteLine("Запрос «Волшебный посох»: товар на складе отсутствует.");
}

Console.WriteLine($"Товаров с критическим остатком (< 3 шт.): {warehouse.CountLowStock(3)}");
Console.WriteLine($"Удалён «охотничий лук»: {warehouse.RemoveProduct("охотничий лук")}");
Console.WriteLine($"Позиций на складе после удаления: {warehouse.ProductCount}");
