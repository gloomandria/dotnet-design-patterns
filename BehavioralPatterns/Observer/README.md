# Observer Pattern

## Description
Le pattern Observer définit une dépendance un-à-plusieurs entre objets de sorte que lorsqu'un objet change d'état, tous ses dépendants en sont notifiés et mis à jour automatiquement.

## Utilisation
- Event handling systems
- Model-View-Controller (MVC)
- Pub/Sub messaging
- Reactive programming

## Avantages
- Principe ouvert/fermé
- Couplage faible entre sujet et observateurs
- Relations dynamiques à l'exécution

## Inconvénients
- Les observateurs sont notifiés dans un ordre aléatoire
- Peut causer des fuites mémoire si mal géré
- Difficulté à déboguer
