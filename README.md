# Design Patterns .NET

Une collection complète des design patterns les plus utilisés, organisés par catégorie, avec des implémentations en C# (.NET 8).

## Structure du Projet

```
├── CreationalPatterns/     # Patterns de création
│   ├── Singleton/         # Instance unique globale
│   ├── Factory/           # Création d'objets via factories
│   ├── Builder/           # Construction d'objets complexes
│   └── Prototype/         # Clonage d'objets
│
├── StructuralPatterns/    # Patterns de structure
│   ├── Adapter/           # Adaptation d'interfaces
│   ├── Decorator/         # Ajout dynamique de fonctionnalités
│   ├── Facade/            # Interface simplifiée
│   └── Proxy/             # Contrôle d'accès et lazy loading
│
├── BehavioralPatterns/    # Patterns de comportement
│   ├── Strategy/          # Algorithmes interchangeables
│   ├── Observer/          # Notification d'événements
│   ├── Command/           # Encapsulation de requêtes
│   └── State/             # Comportement basé sur l'état
│
└── DesignPattern/         # Application de démonstration

```

## Patterns Créationnels

### 1. Singleton
**Objectif**: Garantir qu'une classe n'a qu'une seule instance  
**Utilisation**: Configuration, Logger, Cache, Pool de connexions  
**Exemple**: `ConfigurationManager` - Gestion centralisée de la configuration

### 2. Factory Method
**Objectif**: Déléguer la création d'objets à des sous-classes  
**Utilisation**: Création d'objets dont le type varie, Plugins  
**Exemple**: `NotificationFactory` - Création de différents types de notifications (Email, SMS, Push)

### 3. Builder
**Objectif**: Construction d'objets complexes étape par étape  
**Utilisation**: Objets avec beaucoup de paramètres, Fluent API  
**Exemple**: `ComputerBuilder` - Construction personnalisée d'ordinateurs

### 4. Prototype
**Objectif**: Créer de nouveaux objets par clonage  
**Utilisation**: Objets coûteux à créer, Templates  
**Exemple**: `EmployeePrototype` - Clonage d'employés à partir de prototypes

## Patterns Structurels

### 1. Adapter
**Objectif**: Convertir une interface en une autre  
**Utilisation**: Intégration de code legacy, APIs tierces  
**Exemple**: `PaymentAdapter` - Adaptation de Stripe et PayPal vers une interface commune

### 2. Decorator
**Objectif**: Ajouter dynamiquement des responsabilités  
**Utilisation**: Extension de fonctionnalités, Streams .NET  
**Exemple**: `CoffeeDecorator` - Ajout d'ingrédients au café

### 3. Facade
**Objectif**: Interface simplifiée pour un sous-système complexe  
**Utilisation**: Simplification d'APIs, Bibliothèques  
**Exemple**: `VideoConversionFacade` - Conversion vidéo simplifiée

### 4. Proxy
**Objectif**: Contrôler l'accès à un objet  
**Utilisation**: Lazy loading, Caching, Sécurité  
**Exemple**: `DocumentProxy` - Chargement lazy et mise en cache

## Patterns Comportementaux

### 1. Strategy
**Objectif**: Algorithmes interchangeables  
**Utilisation**: Éviter les if/else complexes, Validation, Tri  
**Exemple**: `PaymentStrategy` - Différentes méthodes de paiement

### 2. Observer
**Objectif**: Notification automatique des dépendants  
**Utilisation**: Event handling, MVC, Pub/Sub  
**Exemple**: `WeatherStation` - Notification des changements météo

### 3. Command
**Objectif**: Encapsuler une requête comme un objet  
**Utilisation**: Undo/Redo, File d'attente, Macro-commandes  
**Exemple**: `RemoteControl` - Contrôle de lumière avec historique

### 4. State
**Objectif**: Modifier le comportement selon l'état  
**Utilisation**: Machines à états, Workflows  
**Exemple**: `OrderState` - Gestion du cycle de vie d'une commande

## Démarrage

```bash
# Cloner le repository
git clone https://github.com/gloomandria/dotnet-design-patterns

# Naviguer vers le projet
cd dotnet-design-patterns/DesignPattern

# Compiler la solution
dotnet build

# Exécuter l'application de démonstration
dotnet run
```

## Utilisation

L'application de démonstration propose un menu interactif pour explorer chaque pattern:

1. **Patterns Créationnels** - Singleton, Factory, Builder, Prototype
2. **Patterns Structurels** - Adapter, Decorator, Facade, Proxy
3. **Patterns Comportementaux** - Strategy, Observer, Command, State

Chaque démonstration inclut:
- Une explication du pattern
- Un exemple d'implémentation
- Un cas d'usage concret

## Technologies

- **.NET 8.0**
- **C# 12.0**
- **Design Patterns Gang of Four (GoF)**

## Ressources

- [Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns) - Gang of Four
- [Refactoring Guru - Design Patterns](https://refactoring.guru/design-patterns)
- [Microsoft Docs - Design Patterns](https://docs.microsoft.com/en-us/azure/architecture/patterns/)

## Contribution

Les contributions sont les bienvenues! N'hésitez pas à:
- Ajouter de nouveaux patterns
- Améliorer les exemples existants
- Corriger les bugs
- Améliorer la documentation

## Licence

Ce projet est sous licence MIT.
