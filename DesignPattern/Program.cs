using CreationalPatterns.Singleton;
using CreationalPatterns.Factory;
using CreationalPatterns.Builder;
using CreationalPatterns.Prototype;
using StructuralPatterns.Adapter;
using StructuralPatterns.Decorator;
using StructuralPatterns.Facade;
using StructuralPatterns.Proxy;
using BehavioralPatterns.Strategy;
using BehavioralPatterns.Observer;      
using BehavioralPatterns.Command;
using BehavioralPatterns.State;

Console.WriteLine("╔════════════════════════════════════════════════╗");
Console.WriteLine("║     DESIGN PATTERNS - DÉMONSTRATION .NET       ║");
Console.WriteLine("╚════════════════════════════════════════════════╝");

bool continuer = true;

while (continuer)
{
    Console.WriteLine("\n┌─────────────────────────────────────────┐");
    Console.WriteLine("│ Choisissez une catégorie de patterns:  │");
    Console.WriteLine("├─────────────────────────────────────────┤");
    Console.WriteLine("│ 1. Patterns Créationnels                │");
    Console.WriteLine("│ 2. Patterns Structurels                 │");
    Console.WriteLine("│ 3. Patterns Comportementaux             │");
    Console.WriteLine("│ 0. Quitter                              │");
    Console.WriteLine("└─────────────────────────────────────────┘");
    Console.Write("Votre choix: ");

    var choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            MenuPatternsCreationnels();
            break;
        case "2":
            MenuPatternsStructurels();
            break;
        case "3":
            MenuPatternsComportementaux();
            break;
        case "0":
            continuer = false;
            Console.WriteLine("\nMerci d'avoir exploré les Design Patterns!");
            break;
        default:
            Console.WriteLine("\n❌ Choix invalide!");
            break;
    }
}

static void MenuPatternsCreationnels()
{
    Console.WriteLine("\n╔════════════════════════════════════════════════╗");
    Console.WriteLine("║         PATTERNS CRÉATIONNELS                  ║");
    Console.WriteLine("╚════════════════════════════════════════════════╝");
    Console.WriteLine("1. Singleton");
    Console.WriteLine("2. Factory Method");
    Console.WriteLine("3. Builder");
    Console.WriteLine("4. Prototype");
    Console.WriteLine("0. Retour");
    Console.Write("Votre choix: ");

    var choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            DemoSingleton();
            break;
        case "2":
            DemoFactory();
            break;
        case "3":
            DemoBuilder();
            break;
        case "4":
            DemoPrototype();
            break;
    }
}

static void MenuPatternsStructurels()
{
    Console.WriteLine("\n╔════════════════════════════════════════════════╗");
    Console.WriteLine("║         PATTERNS STRUCTURELS                   ║");
    Console.WriteLine("╚════════════════════════════════════════════════╝");
    Console.WriteLine("1. Adapter");
    Console.WriteLine("2. Decorator");
    Console.WriteLine("3. Facade");
    Console.WriteLine("4. Proxy");
    Console.WriteLine("0. Retour");
    Console.Write("Votre choix: ");

    var choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            DemoAdapter();
            break;
        case "2":
            DemoDecorator();
            break;
        case "3":
            DemoFacade();
            break;
        case "4":
            DemoProxy();
            break;
    }
}

static void MenuPatternsComportementaux()
{
    Console.WriteLine("\n╔════════════════════════════════════════════════╗");
    Console.WriteLine("║       PATTERNS COMPORTEMENTAUX                 ║");
    Console.WriteLine("╚════════════════════════════════════════════════╝");
    Console.WriteLine("1. Strategy");
    Console.WriteLine("2. Observer");
    Console.WriteLine("3. Command");
    Console.WriteLine("4. State");
    Console.WriteLine("0. Retour");
    Console.Write("Votre choix: ");

    var choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            DemoStrategy();
            break;
        case "2":
            DemoObserver();
            break;
        case "3":
            DemoCommand();
            break;
        case "4":
            DemoState();
            break;
    }
}

// ==================== DÉMOS CRÉATIONNELS ====================

static void DemoSingleton()
{
    Console.WriteLine("\n>>> SINGLETON PATTERN <<<");
    Console.WriteLine("Garantit une seule instance de la classe ConfigurationManager\n");

    var config1 = ConfigurationManager.Instance;
    var config2 = ConfigurationManager.Instance;

    Console.WriteLine($"config1 == config2: {ReferenceEquals(config1, config2)}");

    config1.DisplayAllSettings();

    config1.SetSetting("NewSetting", "NewValue");
    Console.WriteLine("\nAprès modification via config1:");
    config2.DisplayAllSettings();
}

static void DemoFactory()
{
    Console.WriteLine("\n>>> FACTORY METHOD PATTERN <<<");
    Console.WriteLine("Crée différents types de notifications\n");

    NotificationFactory emailFactory = new EmailNotificationFactory();
    NotificationFactory smsFactory = new SmsNotificationFactory();
    NotificationFactory pushFactory = new PushNotificationFactory();

    emailFactory.NotifyUser("Your order has been shipped!");
    smsFactory.NotifyUser("Your package will arrive today");
    pushFactory.NotifyUser("New message received");
}

static void DemoBuilder()
{
    Console.WriteLine("\n>>> BUILDER PATTERN <<<");
    Console.WriteLine("Construction d'ordinateurs personnalisés\n");

    var gamingPC = new GamingComputerBuilder()
        .SetStorage("2TB NVMe SSD")
        .Build();

    Console.WriteLine("Gaming PC:");
    gamingPC.DisplaySpecs();

    Console.WriteLine("\nCustom Office PC:");
    var officePC = new ComputerBuilder()
        .SetCPU("Intel i5-12400")
        .SetRAM("16GB DDR4")
        .SetStorage("512GB SSD")
        .SetGPU("Integrated")
        .AddWiFi()
        .Build();

    officePC.DisplaySpecs();
}

static void DemoPrototype()
{
    Console.WriteLine("\n>>> PROTOTYPE PATTERN <<<");
    Console.WriteLine("Clonage d'employés à partir de prototypes\n");

    var registry = new EmployeePrototypeRegistry();

    var devPrototype = new Employee
    {
        Department = "Development",
        Salary = 75000,
        Address = new Address { City = "Paris", ZipCode = "75001" }
    };

    var hrPrototype = new Employee
    {
        Department = "Human Resources",
        Salary = 60000,
        Address = new Address { City = "Lyon", ZipCode = "69001" }
    };

    registry.RegisterPrototype("Developer", devPrototype);
    registry.RegisterPrototype("HR", hrPrototype);

    var john = registry.CreateEmployee("Developer");
    if (john != null)
    {
        john.Name = "John Doe";
        john.Address.Street = "123 Rue de la Paix";
        Console.WriteLine("\nJohn (Developer):");
        john.DisplayInfo();
    }

    var jane = registry.CreateEmployee("HR");
    if (jane != null)
    {
        jane.Name = "Jane Smith";
        jane.Address.Street = "456 Avenue de la République";
        Console.WriteLine("\nJane (HR):");
        jane.DisplayInfo();
    }
}

// ==================== DÉMOS STRUCTURELS ====================

static void DemoAdapter()
{
    Console.WriteLine("\n>>> ADAPTER PATTERN <<<");
    Console.WriteLine("Adaptation de services de paiement tiers\n");

    IPaymentProcessor stripeProcessor = new StripeAdapter(new StripePaymentService());
    IPaymentProcessor paypalProcessor = new PayPalAdapter(new PayPalPaymentService());

    stripeProcessor.ProcessPayment(99.99m, "EUR");
    paypalProcessor.ProcessPayment(149.50m, "USD");
}

static void DemoDecorator()
{
    Console.WriteLine("\n>>> DECORATOR PATTERN <<<");
    Console.WriteLine("Ajout dynamique d'ingrédients au café\n");

    ICoffee coffee = new SimpleCoffee();
    Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");

    coffee = new MilkDecorator(coffee);
    Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");

    coffee = new SugarDecorator(coffee);
    Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");

    coffee = new WhippedCreamDecorator(coffee);
    Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");

    coffee = new CaramelDecorator(coffee);
    Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost():C}");
}

static void DemoFacade()
{
    Console.WriteLine("\n>>> FACADE PATTERN <<<");
    Console.WriteLine("Conversion vidéo simplifiée\n");

    var facade = new VideoConversionFacade();
    facade.ConvertVideo("funny-cats.ogg", "mp4");
}

static void DemoProxy()
{
    Console.WriteLine("\n>>> PROXY PATTERN <<<");
    Console.WriteLine("Chargement lazy et mise en cache d'images\n");

    Console.WriteLine("=== Lazy Loading Proxy ===");
    IDocument doc = new DocumentProxy("LargeDocument.pdf");
    Console.WriteLine("Proxy créé mais document non chargé");
    doc.Display();
    Console.WriteLine("\nDeuxième affichage (déjà chargé):");
    doc.Display();

    Console.WriteLine("\n=== Caching Proxy ===");
    IImageService imageService = new CachedImageProxy();
    imageService.DisplayImage("image1.jpg");
    imageService.DisplayImage("image2.jpg");
    imageService.DisplayImage("image1.jpg");

    Console.WriteLine("\n=== Protection Proxy ===");
    IImageService adminService = new ProtectedImageProxy("admin");
    IImageService userService = new ProtectedImageProxy("guest");

    adminService.DisplayImage("secure-image.jpg");
    userService.DisplayImage("secure-image.jpg");
}

// ==================== DÉMOS COMPORTEMENTAUX ====================

static void DemoStrategy()
{
    Console.WriteLine("\n>>> STRATEGY PATTERN <<<");
    Console.WriteLine("Différentes méthodes de paiement\n");

    var cart = new ShoppingCart();
    cart.AddItem("Laptop");
    cart.AddItem("Mouse");
    cart.AddItem("Keyboard");

    cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456", "123"));
    cart.Checkout(1299.99m);

    cart.SetPaymentStrategy(new PayPalPayment("user@example.com"));
    cart.Checkout(1299.99m);

    cart.SetPaymentStrategy(new CryptocurrencyPayment("0x1234567890abcdef", "Bitcoin"));
    cart.Checkout(1299.99m);
}

static void DemoObserver()
{
    Console.WriteLine("\n>>> OBSERVER PATTERN <<<");
    Console.WriteLine("Station météo notifiant plusieurs affichages\n");

    var weatherStation = new WeatherStation();

    var phoneDisplay1 = new PhoneDisplay("Alice's iPhone");
    var phoneDisplay2 = new PhoneDisplay("Bob's Android");
    var desktopDisplay = new DesktopDisplay("Office");
    var logger = new WeatherLogger();

    weatherStation.Attach(phoneDisplay1);
    weatherStation.Attach(phoneDisplay2);
    weatherStation.Attach(desktopDisplay);
    weatherStation.Attach(logger);

    weatherStation.SetMeasurements(25.5f, 65f, 1013f);

    weatherStation.Detach(phoneDisplay2);

    weatherStation.SetMeasurements(23.2f, 70f, 1010f);
}

static void DemoCommand()
{
    Console.WriteLine("\n>>> COMMAND PATTERN <<<");
    Console.WriteLine("Contrôle de lumière avec Undo/Redo\n");

    var light = new Light();
    var remote = new RemoteControl();

    var lightOn = new LightOnCommand(light);
    var lightOff = new LightOffCommand(light);

    remote.ExecuteCommand(lightOn);
    remote.ExecuteCommand(lightOff);
    remote.Undo();
    remote.Undo();

    Console.WriteLine("\n=== Éditeur de texte avec Undo ===");
    var editor = new TextEditor();
    var textRemote = new RemoteControl();

    textRemote.ExecuteCommand(new WriteCommand(editor, "Hello "));
    textRemote.ExecuteCommand(new WriteCommand(editor, "World!"));
    textRemote.Undo();
    textRemote.ExecuteCommand(new WriteCommand(editor, "Design Patterns!"));
}

static void DemoState()
{
    Console.WriteLine("\n>>> STATE PATTERN <<<");
    Console.WriteLine("Gestion des états d'une commande\n");

    var order = new Order("ORD-12345");

    Console.WriteLine("\nTentative d'expédition avant paiement:");
    order.Ship();

    Console.WriteLine("\nPaiement de la commande:");
    order.Pay();

    Console.WriteLine("\nExpédition de la commande:");
    order.Ship();

    Console.WriteLine("\nTentative d'annulation après expédition:");
    order.Cancel();

    Console.WriteLine("\nLivraison de la commande:");
    order.Deliver();

    Console.WriteLine("\n--- Nouvelle commande ---");
    var order2 = new Order("ORD-67890");
    order2.Pay();
    Console.WriteLine("\nAnnulation d'une commande payée:");
    order2.Cancel();
}
