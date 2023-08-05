# dinosaur-genetic-algorithm
This project is a study about Genetic Algorithm using as base the idea of google dinosaurs.
There are the possibility to change some variables with the simulation running to see how the variables affect the simulation.

This is an Unity Project, it was created originally in Unity 2019.2.15f1, but I also tested it in Unity 2022.3.0f and it works, so I guess any version after 2019.2.15f1 will work.

## Demo Gif
![](Dino.gif)

## How it works
This study is about a Genetic Algorithm, that is a kind of Algorithm that "acts like" natural selection,
in this case, we have the Dinos in an ambient when they need to learn how to survive.

Dinos that survive longer than others can give your good genes to next generation of Dinos, that will become more able
to survive than the last generation. _(in theory)_

In the end, we must have good Dino runners that can avoid all obstacles in their way.

## What can be changed
As mentioned before, you can change some variables, and I will explain briefly what you can do.

#### mutationRate
mutationRate sets how frequently do you want mutations _(when the dinosaur's genes are not just a combination of the parents)_.
If you have a low mutation, it will take a lot of time to evolution happens, but if you have a high mutation, the good habits
will not last for generations, so you can loss nice results.

#### minSize
minSize sets how small and light your dinos can be. _(if you don't use this with some caution, your dinos can evolve to birds
before than expected and just 'fly')_

#### maxSize
maxSize sets how big and heavy your dinos can be.

#### spawnRateTree (sec)
spawn Rate (tree) sets in seconds how frequently will appear Trees,
(for best results, I highly recommend to use just primal numbers.).
**If the spawn is at 1 per second, new generations will not appear.**

#### spawnRatePtero(sec)
spawn Rate (Ptero) sets in seconds how frequently will appear our friends Pteros, different from google, here the Pteros
can fly in 3 random heighs.
(for best results, I highly recommend to use just primal numbers.).
**If the spawn is at 1 per second, new generations will not appear.**

#### minVisionRange
minVisionRange sets how short can be the Dinos' vision range, if a Dino has a short vision range, it will react to obstacles
just when they are almost touching them.

#### maxVisionRange
maxVisionRange sets how long can be your Dinos' vision range, if a Dino has a long vision range, it will react to obstacles
with a lot of anticipation, acting when they aren't really next from obstacles.

#### population
population sets how many Dinos you can have in 1 generation.

#### Survivors
Survivor sets if you want Dinos that haven't died to be in the next generation, 
if survivors is true, then survivors will be in next generations, 
else the survivors will die anyway and the next generation will be completely new.

#### GenerationCountdown
Generation Countdown sets how much time a generation will lasts. _(if all dinos die, a new generation will begin, even if
the time is not over.)_

## How to run this Project?
If you want just to "play", change the parameters to see the differences between generations, and to test everything, you can unzip the zip file <a href="https://github.com/MatheusCordeiroP/dinosaur-genetic-algorithm/blob/main/Game.rar">*Game*</a> and run "Dinossauro IA.exe" file. It should works in any windows.

If you want to change the code, change the game, create something based on this, you will need to know that this project was made with a Game Engine, so it will need it to be modified.
You will need to download <a href="https://unity.com/pt/download">Unity Game Engine</a>.

This project was created originally in Unity 2019.2.15f1, but I also tested it in Unity 2022.3.0f and it works, so I guess any version after 2019.2.15f1 will work. So after downloading Unity Hub, you just need to download some of these versions of unity and run the project.

After doing that, you can see some folders, in the project, click in the folder "Scenes" and open the file "Sample Scene.unity", so you will open the main scene of the project.
Feel free to create new scenes or edit this scene for test reasons.

If you have any problem, feel free to contact me at <a  href="mailto:matheuscordeirop@gmail.com" alt="Gmail" target="blank" >matheuscordeirop@gmail.com</a>.
