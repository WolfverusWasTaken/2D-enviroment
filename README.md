# 2D Terrain Generation

This is a Unity2D terrain Generation Framework that allows quick 2D game environment generation with little to no hassle.

## About/Preview
This is a functioning 2D Terrain Generation Framework, along with a few other scripts that are added to allow beginner developers to quickly start working on Unity2D projects.

The framework mainly works on Unity2D Tilemaps system. It is made by adding layers of each terrain over the other while a small layer of perlin noise is used to affect how terrain's respective structures will be spawned into the map.

![Slide2](https://user-images.githubusercontent.com/75195899/153038566-e4f08af5-7138-414d-b1bf-9a58c8ad9f52.JPG)

## Generation Overview
### Perlin Noise Generation
Using Perlin Noise and Cellular automata to create the environment such as dirt, grass and water. After which, I added nature related items like plants and leaves.
![Environment Generation Day 1-1](https://user-images.githubusercontent.com/75195899/132948924-5322f749-ff2d-4a7d-90bc-c8aeb3571763.jpeg)

![Environment Generation Day 1-2](https://user-images.githubusercontent.com/75195899/132948932-5cda8e18-55dd-4b0e-8499-0e5d218196ec.jpeg)

![Environment Generation Day 2-1](https://user-images.githubusercontent.com/75195899/132948934-8b8de155-016b-4e5e-b9da-8a3bd806c72c.jpeg)

![Environment Generation Day 2-2](https://user-images.githubusercontent.com/75195899/132948936-c5aa7bf7-c422-4c87-bb8e-cc3d63280c5f.jpeg)

### Day-Night Cycle, Clouds, Rainfall, Humidity and Temperature.
Day-Night cycle affects the temperature. Temperature affects the Humidity in the air and the Humidity affects the how often in rains!

![Environment Generation Day 3-1](https://user-images.githubusercontent.com/75195899/132948939-a5cc451d-0d58-43b9-b434-747ae7c7f30f.jpeg)

![Environment Generation Day 3-2](https://user-images.githubusercontent.com/75195899/132948943-8e2e7224-0905-474e-9afc-97229c3dd496.jpeg)

![Environment Generation Day 4](https://user-images.githubusercontent.com/75195899/132948946-ff21ca2d-464a-4c56-8208-c26fab734eeb.jpeg)

### Creature Spawning Mechanics
Animal Spawning and Despawning. Added a simple animal movement and pathfinding code to tie it all together.
![Environment Generation Day 5](https://user-images.githubusercontent.com/75195899/132948947-811b6eb7-dca5-424e-9f2f-1343b6efe499.jpeg)

![Environment Generation Day 6](https://user-images.githubusercontent.com/75195899/132948950-a26c21bb-e1ca-4d01-b021-fa126fab1ba3.jpeg)

![Environment Generation Day 7](https://user-images.githubusercontent.com/75195899/132948952-e27b11ed-8c53-483a-9f44-e174ea931cfb.jpeg)

## Disclaimer
[Game assets used and taken from RIMWORLD. Used for demonstration purposes only.]

This Repository contains the Terrain Generation Framework, Temperature & Humidity Mechanics and Creature Spawning & De-spawning Feature.

## License
[MIT](https://choosealicense.com/licenses/mit/)

