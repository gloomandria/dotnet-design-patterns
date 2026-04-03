# Strategy Pattern

## Description
Le pattern Strategy définit une famille d'algorithmes, encapsule chacun d'eux et les rend interchangeables. Strategy permet à l'algorithme de varier indépendamment des clients qui l'utilisent.

## Utilisation
- Multiples algorithmes pour une même tâche
- Éviter les conditions if/else ou switch complexes
- Validation, tri, compression

## Avantages
- Principe ouvert/fermé
- Composition au lieu d'héritage
- Isole les détails d'implémentation
- Changement d'algorithme à l'exécution

## Inconvénients
- Augmente le nombre de classes
- Les clients doivent connaître les différences entre stratégies
