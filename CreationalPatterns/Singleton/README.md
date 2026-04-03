# Singleton Pattern

## Description
Le pattern Singleton garantit qu'une classe n'a qu'une seule instance et fournit un point d'accès global à cette instance.

## Utilisation
- Gestion de configuration
- Pool de connexions à la base de données
- Logger
- Cache

## Avantages
- Contrôle strict de l'accès à l'instance unique
- Économie de mémoire
- Point d'accès global

## Inconvénients
- Difficile à tester (couplage fort)
- Peut violer le principe de responsabilité unique
- Problèmes de thread-safety si mal implémenté
