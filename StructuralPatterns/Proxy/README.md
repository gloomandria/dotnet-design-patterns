# Proxy Pattern

## Description
Le pattern Proxy fournit un substitut ou placeholder pour un autre objet afin de contrôler l'accès à celui-ci.

## Utilisation
- Lazy initialization (virtual proxy)
- Contrôle d'accès (protection proxy)
- Logging et caching (smart proxy)
- Communication réseau (remote proxy)

## Avantages
- Principe ouvert/fermé
- Contrôle sur le cycle de vie de l'objet
- Fonctionne même si l'objet n'est pas prêt
- Sécurité et optimisation

## Inconvénients
- Complexité accrue
- Latence possible
- Code dupliqué si mal implémenté
