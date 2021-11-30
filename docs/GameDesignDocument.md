# Kanvas - Game Design Document<br/>

## :pushpin: Table of Contents
<details>
<summary> Click to expand! </summary>

- [1- Design History - Changelog](#history)
- [2- Goals and Vision](#goals-vision)
  - [2.1 Gameplay synopsis](#gameplay-synopsis)
- [3- Audience, Platform, and Marketing](#audience-platform-market)
  - [3.1 Target audience](#target-audience)
  - [3.2 Platform](#platform)
  - [3.3 System requirements](#system-requirements)
  - [3.4 Top performers](#top-performers)
  - [3.5 Feature comparison](#feature-comparison)
  - [3.6 Sales expectations](#sales-expectations)
- [4- Legal Analysis](#legal-analysis)
- [5- Gameplay](#gameplay)
  - [5.1 Overview](#overview)
  - [5.2 Gameplay description](#gameplay-description)
  - [5.3 Controls](#controls)
    - [5.3.1 Interfaces](#interfaces)
  - [5.4 Rules](#rules)
  - [5.5 Game Procedures](#game-procedures)
  - [5.6 Scoring/winning conditions](#score-win-conditions)
  - [5.7 Modes and other features](#modes)
  - [5.8 Levels](#levels)
    - [5.8.1 Level 0 - The dead tree](#level-0)
    - [5.8.2 Level L - The lighthouse](#level-l)
    - [5.8.3 Level P - The power plant](#level-p)
    - [5.8.1 Level B - The buried city](#level-b)
    - [5.8.1 Level *[letter]* - The *[name]*](#level-letter)
    - [5.8.1 Level 5 - The new tree](#level-5)
  - [5.9 Flowchart](#flowchart)
  - [5.10 Editor](#editor)
- [6- Game Characters](#game-characters)
  - [6.1 Character design](#character-design)
  - [6.2 Types](#types)
    - [6.2.1 PCs (player characters)](#player-characters)
    - [6.2.2 NPCs (nonplayer characters)](non-player-characters)
- [7- Story](#story)
  - [7.1 Synopsis](#synopsis)
  - [7.2 Complete story](#complete-story)
  - [7.3 Backstory](#backstory)
  - [7.4 Narrative devices](#narrative-devices)
  - [7.5 Subplots](#subplots)
    - [7.5.1 Subplot #1](#subplot1)
    - [7.5.2 Subplot #2](#subplot2)
- [8- The Game World](#game-world)
  - [8.1 Overview](#overview)
  - [8.2 Key locations](#key-locations)
  - [8.3 Travel](#travel)
  - [8.4 Mapping](#mapping)
  - [8.5 Scale](#scale)
  - [8.6 Physical objects](#physical-objects)
  - [8.7 Weather conditions](#weather-conditions)
  - [8.8 Day and night](#day-and-night)
  - [8.9 Time](#time)
  - [8.10 Physics](#physics)
  - [8.11 Society/ culture](#society-culture)
- [9- Media List](#media-list)
  - [9.1 Interface assets](#interface-assets)
  - [9.2 Environments](#environments)
  - [9.3 Characters](#characters)
  - [9.4 Animation](#animation)
  - [9.5 Music and sound effects](#music-and-sound-effects)
- [10- Technical Specifications](#technical-specifications)
  - [10.1 Technical analysis](#technical-analysis)
    - [10.1.1 New technology](#new-technology)
    - [10.1.2 Major software development tasks](#major-software-development-tasks)
    - [10.1.3 Risks](#risks)
    - [10.1.4 Alternatives](#alternatives)
    - [10.1.5 Estimated resources required](#estimated-resources-required)
  - [10.2 Development platform and tools](#development-platform-and-tools)
    - [10.2.1 Software](#software)
    - [10.2.2 Hardware](#hardware)
  - [10.3 Delivery](#delivery)
    - [10.3.1 Required hardware and software](#required-hardware-and-software)
    - [10.3.2 Required materials](#required-materials)
  - [10.4 Game engine](#game-engine)
    - [10.4.1 Technical specs](#technical-specs)
    - [10.4.2 Design](#design)
    - [10.4.3 Collision detection](#collision-detection)
  - [10.5 Interface technical specs](#interface-technical-specs)
  - [10.6 Controls' technical specs](#controls-technical-specs)
  - [10.7 Lighting models](#lighting-models)
    - [10.7.1 Modes](#modes)
    - [10.7.2 Models](#models)
    - [10.7.3 Light-sources](#light-sources)
  - [10.8 Rendering system](#rendering-system)
    - [10.8.1 Camera](#camera)
  - [10.9 Internet/network spec](#internet-network-spec)
  - [10.10 System parameters](#system-parameters)
    - [10.10.1 Max players](#max-players)
    - [10.10.2 Servers](#servers)
    - [10.10.3 Customization](#customization)
    - [10.10.4 Connectivity](#connectivity)
    - [10.10.5 Websites](#websites)
    - [10.10.6 Persistence](#persistence)
    - [10.10.7 Saving games](#saving-games)
    - [10.10.8 Loading games](#loading-games)
  - [10.11 Other](#other)
    - [10.11.1 Help](#help)
    - [10.11.2 Manual](#manual)
    - [10.11.3 Setup](#setup)

</details>

## :date: 1- Design History - Changelog <a name="history"></a>
<details>
<summary> Click to expand! </summary>

Include what, when and who changed the GDD for future reference and knowing exactly where to focus when someone else check the document (Use a table). This makes it simple and effortless to track changes to the document.

| V.  | Date       | Description | Author |
|-----|------------|-------------|--------|
| 1.0 | 13/09/2021 | Created the document | Viktor Rydsund |
| 1.1 | 13/09/2021 | Wrote a first draft of 2, 3, 4, 5, 6 and 10 | Mattias Smedman |
| 1.2 | 13/09/2021 | Wrote a first draft of 7 and 8 | Viktor Rydsund |
| 1.3 | 13/09/2021 | Wrote a first draft of 9 | Jonathan Ryytty |
| 1.4 | 26/09/2021 | Reformatted document to markdown | Danny Darwiche |
| 1.5 | 10/10/2021 | Added collapsible chapters, emojis. Updated 4, 5.8, 8.1, 8.2, 8.7, 8.11, 9.5, 10.1.2, 10.10.7, 10.10.8 | Danny Darwiche
| 1.6 | 29/11/2021 | Updated Legal Analysis, Controls, removed irrelevant paragraphs. Added elaboration on the spline tool. Added Greek Pillar descriptions | Mattias Smedman

</details>

## :mag_right: 2- Goals and Vision <a name="goals-vision"></a>
<details>
<summary> Click to expand! </summary>

Our goal is to create a short and sweet game that takes the player through a journey of discovery through the use of music and colours. We want to create an experience where the player travels through the emotions of sadness, loneliness, friendship and ultimately happiness. We hope to do this through a story without words, told simply through the use of the music, colours, and the world under the ice.

We wanted to create a game that women could resonate with, to go along the theme of the event "I am no man!". However as the time constraints came in, this unfortunately got pushed aside. 

### 2.1 Gameplay synopsis <a name="gameplay-synopsis"></a>
We want to create a very relaxing gameplay loop. The main gameplay loop is simply ice skating without any overwhelmingly complex controls. As the player skates, music will be created through their movement, and the world will react to them based on their input. Through this we hope to create a unique experience.

The game starts off black and white, in the middle of a frozen body of water. The music will be quiet and feel sad, but as the player explores, the world starts to be filled in with colour and the music starts changing. We’re going to aim for a look that reminds people of Ink and Watercolours, we don’t want it to be realistic but we want it to be something that the players can relate to, and that they feel relaxed by.

</details>

## :chart_with_upwards_trend: 3- Audience, Platform, and Marketing <a name="audience-platform-market"></a>
<details>
<summary> Click to expand! </summary>

### 3.1 Target audience <a name="target-audience"></a>
Our target audience is the people who play games a lot more casually. We aren’t aiming at any specific age group, as casual games are becoming increasingly popular even within the age groups that typically play more active games.

### 3.2 Platform <a name="platform"></a>
We will be developing the game for Windows, Mac and Linux. The reason for this is that Unity natively can build to these platforms without any additional development effort from us.

### 3.3 System requirements <a name="system-requirements"></a>
We’re aiming to have low system requirements as we are not going for very realistic or intensive graphics, though there might be some aspects that require a bit more power from the PC. We have plans to address these performance issues if they come up.

### 3.4 Top performers <a name="top-performers"></a>
ABZU (2016) is one of the best selling games of this type of casual gameplay. In ABZU, you play as a diver swimming alongside aquatic life, and you explore the world that’s under the water directly. While we could not find direct sales figures, it was near the top of the week and month of it’s release on every platform it was released on.

A short hike (2019) is another game that sold very well in a similar genre. In a short hike, the player is tasked with climbing a mountain, and to do so they must interact with the world to unlock new abilities. A short hike also sold very well, doing incredibly well on the Switch compared to how they did on Steam, even though they also did well on Steam.

Journey (2012) is a game that’s known worldwide for its amazing success. In Journey, the player is a robed figure that travels across a vast desert. In Journey there are no words spoken, even though the player can even interact with other players at times. While the exact figures are hard to find, it’s very easy to find that Journey was a very popular game that sold incredibly well on every platform it was released on.

We also took inspiration from The Ramp (2021). The ramp is a simple game where the player plays as a skateboarder on a ramp. While it differs a bit from the previous games, we were inspired by the very simple but catching mechanics of the game. The ramp isn’t nearly as well known as the games mentioned previously, but it is still a game that was well received by those that have played it.

### 3.5 Feature comparison <a name="feature-comparison"></a>
In the first three games mentioned, the player is still actively involved in making events transpire. We aim to create a game where even though the play interacts with the world, it should not feel like the player is in control of the world. Through the use of ice, we have a constant layer between the world that the player is interacting with and the player themself. The colour mechanic is also something that these games do not have. Seeing the world gain colour we hope evokes a feeling of exploration, without the world actually having been changed itself, compared to these games where the world changes because the player is in new areas.

### 3.6 Sales expectations <a name="sales-expectations"></a>
Our plan was to release the game on Itch or Steam, however due to time constraints we've decided not to do so. 

</details>

## :books: 4- Legal Analysis <a name="legal-analysis"></a>
<details>
<summary> Click to expand! </summary>

Unity allows for games to be released commercially for free as long as the game is developed by a company that makes less than $100k.

We'll be using FMod to combine Unity and Sound easily. The license for FMod is free as long as we've made less than $200k in revenue this year, which we're not expecting in the slightest.

We will use Blender because they allow us to commercially license our models

We will keep the commercial aspect in mind for every asset we might buy.

We will need to check if the name “Kanvas” is a name that we are free to use, however the name is easily changed so this is not a big concern at this moment.

While we kept all of these things in mind as we worked on the project, as we decided not to release the game it does not have any impact on us.

</details>

## :video_game: 5- Gameplay <a name="gameplay"></a>
<details>
<summary> Click to expand! </summary>

### 5.1 Overview <a name="overview"></a>
The core gameplay loop is incredibly simple. The game starts off black and white, and the player moves on the ice thro3ugh skating, and as they explore the world they will encounter wild life, typically that lives under the ice, that they can sync up with to create unique events. After triggering a big event, the player will unlock the ability to see a new colour.

![Gameplay](https://drive.google.com/uc?export=view&id=1BFIyZmLKUMcRTxv-Z7jZ3JtbRwBXypP6)

### 5.2 Gameplay description <a name="gameplay-description"></a>
As the player moves through the world, they will encounter different events. The player will need to interact with these events through various means. The ways to interact with the events is the following ways:

Leading a fish from one point to another. The player has to lead different fishes to an end destiniation, and doing so completes a puzzle. 

The player has to move over certain fishes to play sounds to match to the background music. 

### 5.3 Controls <a name="controls"></a>
The controls right now are fairly lackluster at the moment. The character moves towards where they're pointing their mouse by alternating between A and D. There's very little engagment in the controls as they have no reason to match it to anything. The controller would need to be updated to follow a rhythm as they're alternating to get engagment.  

We ran tests where we compared different types of controllers to try to get a good controller going. We tests a total of 7 different controllers, two of them standing out as the best ones. From the test results, we made the decision to focus on a controller that's based on Rhythm. The controller still needs a lot of work to become engaging, however considering the minimal amount of active controls the game has we found that it's best to have a character controller that does require some level of engagement. 
Test results can be found here: https://docs.google.com/forms/d/1Cpn-qBux9VwBPjD6pvHw3jEIJgguhTKkajAR1MG92Us/edit?usp=sharing

#### 5.3.1 Interfaces <a name="interfaces"></a>
Main Menu Example:

![MainMenu](https://drive.google.com/uc?export=view&id=1PG7Oyxe07W6tfUmoL7jBdFJYS293GUHi)

In the main menu, the player only has three different choices. They can either start the game, change the settings, or quit.

While the game is running, there isn’t actually any interface or UI. The player has no resource or information that they need to track, so we’re leaving the in-game screen as clean as possible, so that there’s more space for the player to look at the world.

### 5.4 Rules <a name="rules"></a>
The player only has black and white colours at the start of the game.

The player unlocks more colours as they complete various events. These events will be filled in here as the game is developed:
- The player can swim over specific parts of the ice to play sounds. These sounds will trigger events when played in the right order.
- Certain fish will follow the player to a location. If the player strays too far from the goal while guiding the fish will swim back to its original location.
- The player has to swim in specific patterns to match with the fish. For example, if there are fishes swimming in a figure 8 under the ice, the player needs to start skating in a figure 8 as well. They'll need to do so in the same area that the fish is swimming in, but they don't need to match up exactly with the fish. So if the fish is at the bottom of the 8, the player can start at the top of the 8 and then make an 8 from there. 

The player has no way of directly interacting with the wild life, as in they can not touch it. Any interaction they have will be distant.

Wildlife fish will be swimming around under the ice for the player to look at. Most of these will be swimming aimlessly.

If the player gets lost or does not make progress for a certain amount of time, a noticeable fish will help guide the player towards their goal.

### 5.5 Game Procedures <a name="game-procedures"></a>
The player wakes up, with no colours unlocked. They explore the ice and find one of a few events, finishing it will unlock a new colour. Once they’ve done this for all the events, the game is finished.

### 5.6 Scoring/winning conditions <a name="score-win-conditions"></a>
The win condition of the game happens when the player has finished all the major events and they have unlocked all the colours. When they’ve done this, the game will trigger an ‘end scene’ event that will be a drastic encounter that makes the player lose all their colours again for a short while. Once they get them all back to a short impactful moment, the game will end.

### 5.7 Modes and other features <a name="modes"></a>
After the game has ended the player is free to skate around on the ice.

### 5.8 Levels <a name="levels"></a>
The game does not feature levels in the traditional sense since the game has a non-linear open world progression. Instead there are a set amount of locations in the world the player needs to find where they can interact with their surroundings. We consider these locations and interactions Kanvas' levels.

#### 5.8.1 Level 0 - The dead tree <a name="level-0"></a>
This is the area the player starts the game from and is placed at the center of the map. At the start of the game, when the player has no colors unlocked, this area is barren and the only thing the player can outline is the stem and branches of a tree. This tree and area is a central location to the game as it will change throughout the playthrough and be the final location the player needs to return to once all colors have been unlocked. This serves as a tutorial, introducing the companion fish and teaching the player how to skate and sync to the music.

*[Images/sketches of the location to be added.]*

#### 5.8.2 Level L - The lighthouse <a name="level-l"></a>
The lighthouse is located at the eye of a storm. The player has to navigate through the storm to reach this place. The storm is hard to navigate through and constantly pushes the player away from the center disorienting them. The lighthouse is filled with water, inhabited by countless of eels. Every now and then they send out shocks of electricity, temporarily lighting the lighthouse. The player can use this beam of light whenever it appears to realign themselves and push through towards the center. At the center it is calm and quiet. Some interaction is to be performed here.

*[Images/sketches of the location to be added.]*

#### 5.8.3 Level P - The power plant <a name="level-p"></a>
The plant is a submerged frozen power plant with large silos and chimneys extruding the ice. Different types of animals use this place as their playground creating music with the different parts of the plant. For instance frogs croaking into the large silos to create reverbs and echoes. The play is expected to accompany their music with their own to complete some interaction.

*[Images/sketches of the location to be added.]*

#### 5.8.4 Level B - The buried city <a name="level-b"></a>
The buried city is an area of the game where a large city is buried under ice. The player can skate freely around above it and see aquatic life that has inhabited the buildings and streets. In this city different types of fish are lost and the player needs to lead them back to their shoal. The player thus explores the city and helps the animals they find.

*[Images/sketches of the location to be added.]*

#### 5.8.5 Level 5 - The new tree <a name="level-5"></a>
The new tree is the same location as the dead tree (level 0). The difference is that the player, at this stage, has unlocked all the colors and the scene has thus changed. The area is now sprawling with life and color. This is the place where the finale of the game will take place. Whilst the ending isn't finished one thought is a confrontation with the orca.

*[Images/sketches of the location to be added.]*

#### 5.8.6 Level P - The Greek Pillar <a name="level-P"></a>
The greek pillar is an area filled with colourful groups of fishes. The player can skate around the pillar, which has some colorful flowers on top. As the player approaches the pillar, music becomes more prominent, and the player can hear notes being played in a specific order. When they swim over the groups of fishes, they play different notes. If they play the notes in the same order as the music in the background, they complete a puzzle. 

[Location still to be determined]


#### 5.8.7 Level *[Letter]* - The *[name]* <a name="level-letter"></a>
[Location still to be determined]

### 5.9 Flowchart <a name="flowchart"></a>
Create a flowchart showing all the areas and screens that will need to be created.

Below is the basic outline of how we imagine the game world. The world is open, meaning that each section of the map is accessible from the get-go. Each area has a subset of meaningful interactions.

The following is an example of how such an event might be structured:

EX) **Section A**: Has the interaction of guiding a single lost red fish back to the school of fish with the corresponding color. Doing this will unlock the color “Red” and the accompanying music.

**Section E**: This is the final area of the game. When all other areas have been completed the end event happens here

![WorldLayout](https://drive.google.com/uc?export=view&id=1LcCZqW5GkJ2moDL5mDXKRCWWynhtrk5-)

### 5.10 Editor <a name="editor"></a>

</details>

## :family: 6- Game Characters <a name="game-characters"></a>
<details>
<summary> Click to expand! </summary>

This is where you describe any game characters and their attributes.

### 6.1 Character design <a name="character-design"></a>
The character is a woman who wakes up alone on the ice. We’re going for a watercolour and ink feel on everything, so they will have clear defined lines, and when colours are all in the world again they  will be colourful.

### 6.2 Types <a name="types"></a>

#### 6.2.1 PCs (player characters) <a name="player-characters"></a>
Our player character has no attributes that they need to keep track of. It’ll simply be just a character that you can move around freely.

#### 6.2.2 NPCs (non-player characters) <a name="non-player-characters"></a>
If your game involves character types, you will need to treat each one as an object, defining its properties and functionality.

Our game has no NPCs that the player talks to interacts with, but there will be a large amount of NPC animals. Each unique animal will get a subsection here that explains their purpose:

##### 6.2.2.1 Behavior
If the artificial intelligence is an important component of your project since the NPCs have a set of complex intertwined systems, you should open a subsection or whole section only for it.
We will be utilizing a few versions of AI to create a natural feeling wildlife. Most of the fish will be controlled through Boids, so that they appear to be moving around naturally. Some of the other fishes will use pathfinding and behaviour trees to make sure that they’re more noticeable, but still feel natural.

</details>

## :speech_balloon: 7- Story <a name="story"></a>
<details>
<summary> Click to expand! </summary>

### 7.1 Synopsis <a name="synopsis"></a>
A lost ice-skater befriends a fish and restores colour and music to the world. The fish dies and the protagonist becomes sad. Later the fish is revealed to be alive and the world becomes vibrant again.

### 7.2 Complete story <a name="complete-story"></a>
This is your chance to outline the entire story. Do not just tell the story, structure it as it will unfold in the gameplay and try to follow the dramatic arcs presented in class.

**Chapter 1**:

The basic premise of the story is as follows: The polar ice caps have melted and the world has been flooded. A new ice age begins and the ocean is frozen yet again. Leaving only the tip of once recognizable landmarks above the heavy curtain of ice.

Lost and frozen our protagonist wakes up with no memories of events prior. As the protagonist fully wakes up it dawns that something is amiss. The “colours of music” are long gone leaving only a black and white silhouette.

Wandering the desolated planes of ice our protagonist crosses paths with seemingly the only other life around. A little red fish. This strange meeting does not go as planned as the red fish initially is avoidant of any interaction.

. . .

Note: - Below are writing prompts used to plot out key happenings in the story.

**Chapter 2**:

As our protagonist learns more of the world she understands that through ice-skating the world can be altered.

**Chapter ?**:

The little red fish who now has become a friend in need dies. The death of the fish launches our protagonist back into a cycle of hopelessness as the “colours of music” fade once more.

**Ending**:

Suddenly powerful rhythmic thuds can be felt as the ice shakes. The thuds seem to hint at our protagonist, urging her to follow and investigate. Following the thuds to its source it becomes clear that our friend the red fish survived. This reveal makes our protagonist so happy the “colors of music” return.

### 7.3 Backstory <a name="backstory"></a>
Describe any important elements of your story that do not tie directly into the gameplay. For instance, the backstory of how the dwarfs found ancient weapons and as such they dominate the region. It does not need to make it to the actual game but it is good as reference.

As mentioned, the story takes place on a large frozen over sea. In this story the presence of music and colours are tied together. Meaning music has a dimension of form and colour.

### 7.4 Narrative devices <a name="narrative-devices"></a>
Describe the various ways in which you plan to reveal the story. What are the devices you plan to use to tell the story?

The story is never told explicitly but instead via exploration and interaction with the environment. Ice being see-through lends itself to telling stories under the ice.

### 7.5 Subplots <a name="subplots"></a>
Since games do not need to be linear, there might be numerous smaller stories interwoven into the main story. Describe each of these subplots and explain how they tie into the gameplay and the master plot.

#### 7.5.1 Subplot #1 <a name="subplot1"></a>
Our protagonist encounters a ginormous eye frozen solid near the surface of the ice. Later as colour is restored the eye opens and the iris starts looking around. This orca is later responsible for the loud thuds guiding our player back to the red fish.

#### 7.5.2 Subplot #2 <a name="subplot2"></a>
tbd

</details>

## :earth_africa: 8- The Game World <a name="game-world"></a>
<details>
<summary> Click to expand! </summary>

### 8.1 Overview <a name="overview"></a>
In a lot of ways the world is reminiscent to ours taking place in a not so distant future. The exception however is that the world is flooded by the oceans with a thick layer of ice encapsulating it. The players world exists only on the ice. The aquatic life however live freely within the ruins of the past civilization.

It is a cold and desolate world for anything above the surface, with the only colors left being black and white. With time, warmth is restored to the world through music, colors and friendship as the player interacts with the world around them. Whilst the environmental setting is explicit, the majority of elements in the world are left implicit. An empty canvas onto which the player can project their own interpretation and meaning hence the games title and the game starting of as black and white but allowing the player to create music and even draw on the ice with their trails.

### 8.2 Key locations <a name="key-locations"></a>
The game will feature a lot of locations, some more important than others. They can be categorized as 2 types, Essential and Atmospheric. The essential locations are the ones outlined in section 5.8 Levels. The player is required to find them in order to complete the game. The atmospheric locations can be thought of as decorations. They fill the world with variation, breaking up the monotony of the otherwise flat and boring world the player would be presented when skating from one essential location to the next. The atmospheric don't serve an interactive purpose. They are mostly a visual component which also helps the player orient themselves in the world and get a sense of direction.

List of implemented locations:

<details>
<summary> The lighthouse </summary>

- **Type**: Essential
- **Number of colors**: 0-3
- **Breadcrumb**: Snow storm, light beam
- **Description**: The lighthouse is covered in a heavy snow storm. Only at the eye of the storm can tranquility be found. The player must endure the storm and push their way through despite its attempts to force the player out. Inside the storm the player has little chance of navigating through since they will be moved and rotated by the storm all the while the view is very limited. They are however not alone. The lighthouse is full with water with eels living inside. Whenever they release a pulse of electricity the lighthouse lights up for a couple of seconds. This will give the player the direction they need to navigate the storm. Thus, even after civilizations fall the trusty lighthouse still fulfills its purpose (with a little help from its new residents). Thematically the storm and lighthouse represent the feeling of being lost and overwhelmed yet overcoming adversity and finding a state of peace thanks to a little help. Once at the center, the player can perform some interaction to unlock a color.

</details>

<details>
<summary> Greek Pillar </summary>

- **Type**: Essential
- **Number of colors**: 0-3
- **Breadcrumb**: Music in the distance that plays notes in a specific order
- **Description**: Fishes are swimming around an old pillar with flowers on top. As the player approaches the pillar they start hearing notes being played inside of the music. As the player skates over the fishes, different notes get played based on the colour of the fish. 

</details>

<details>
<summary> The buried city </summary>

- **Type**: Essential
- **Number of colors**: 0-3
- **Breadcrumb**: Large city under ice, companion fish
- **Description**: The buried city is an artifact of the past civilization now inhabited by aquatic life. Since the player is above the city they can freely skate above it and explore it from any angle. Here some lost fish can be found and the player can guide them through the streets and buildings of the city to return the to their shoal. This is the interaction that takes place at this location.

</details>

List of planned locations:

<details>
<summary> The dead tree </summary>

- **Type**: Essential
- **Number of colors**: None
- **Breadcrumb**: The only tree, companion fish
- **Description**: This is the starting area of the game which is at the center of the world. It features a lone tree breaking through the ice at the bottom of the stem. Initially it looks dead, a bare tree with no leaves, no color, the ice surrounding it being completely white. This is because the player has yet to explore the world and unlock any new colors. As the player progresses and unlocks new colors in the world, color and life is brought back to this tree and it's surroundings. The tree revitalizes and leaves reappear, under the ice all sorts of fish can be seen swimming around. Whether the tree was actually ever dead and regrown or if the character simple changes their point of view of the world as the game progresses will never be explicitly stated. This is part of the subtle environmental storytelling where as few things are defined allowing the player to project their own interpretation and meaning to the different interactions and developments of the world.

</details>

<details>
<summary> The power plant </summary>

- **Type**: Essential
- **Number of colors**: 0-3
- **Breadcrumb**: Faint music in the distance
- **Description**: The power plant is a visual representation of the cause of the state of the world. Disregard of the environment causes the civilization to fall. Once a hostile place it now serves as a playground for animals where they create their own music using the husk of the very thing that once threatened their eco system. The player can hear the sound of frogs croaking into silos or seals barking into pipes long before they reach the location. At this place the player needs to harmonize with the animals to create some musical piece thus unlocking a new color.

</details>


<details>
<summary> The new tree </summary>

- **Type**: Essential
- **Number of colors**: 4
- **Breadcrumb**: Trail of leaves, companion fish
- **Description**: The new tree is actually the same tree from the starting location. At this point of the game a lot has changed and the scenery with the original tree looks very different to the point where one could assume it is a different one. "The new tree" alludes to "the new me" referencing that the character and player have changed since the start of their journey and are not the same as they were. Whether a physical change (the tree revitalized) or a emotional change (perspective of the world) the scene is set for the player to determine this themselves. This is the finale location of the game. Once here the player will need to complete one final interaction before the climax of the game. What the finale will be is still undetermined.

</details>

<details>
<summary> The ice canyon </summary>

- **Type**: Atmospheric
- **Number of colors**: None
- **Breadcrumb**: None
- **Description**: A large canyon of separated ice frozen deep into the ocean. Serves as some world border or cutoff point limiting access to some areas from certain directions.

</details>

<details>
<summary> The frozen waterfalls </summary>

- **Type**: Atmospheric
- **Number of colors**: None
- **Breadcrumb**: None
- **Description**: A small area featuring rivers and waterfalls frozen solid. A peaceful and quiet stop on the road. The player can skate of course skate behind the waterfall to find some hidden thing.

</details>

<details>
<summary> The flower field </summary>

- **Type**: Atmospheric
- **Number of colors**: None
- **Breadcrumb**: None
- **Description**: A field of flowers on the ice. Near some shore or hill a field of flora are stuck in the ice creating a field of flowers on top of the ice. No necessary interaction just a colorful field of flowers to skate amongst with the music.

</details>

<details>
<summary> The orca </summary>

- **Type**: Atmospheric
- **Number of colors**: None
- **Breadcrumb**: None
- **Description**: An orca frozen solid along the surface of the ice. At first it is not visible because the required colors are missing. As more colors are unlocked new elements to the orca become visible. For instance if we unlock blue, we can spot a large blue eye looking back at us from the ice. As more colors are unlocked more warmth is brought into the world through color, music and friendship. This warmth causes the orca to thaw eventually breaking out of the ice and returning into the waters. Visiting this place after it has escaped will leave trails of its path and shattered ice.

</details>

<br/>

![WorldLayout](https://drive.google.com/uc?export=view&id=1LcCZqW5GkJ2moDL5mDXKRCWWynhtrk5-)

### 8.3 Travel <a name="travel"></a>
Travel will be done through skating. No fast travel.

### 8.4 Mapping <a name="mapping"></a>
Open world, divided into five zones each containing a key location.

### 8.5 Scale <a name="scale"></a>
It will take the player a few minutes to skate the map border to border.

![Scale](https://drive.google.com/uc?export=view&id=19QiKrK1m9Q1xP4fSWk1TFuvbHgDKJ4x5)

### 8.6 Physical objects <a name="physical-objects"></a>
None.

### 8.7 Weather conditions <a name="weather-conditions"></a>
The game will feature different weather conditions. These range from rain and snow to wind and heavy storms. They will all have different effects on their surroundings and the player.

**Snow** will increase the friction of the ice making the player slower.

**Rain** will lower the friction of the ice making the player slide more.

**Wind** will push the player in a certain direction increasing their movement speed along that direction but lowering their speed in any other direction.

**Storm** will have similar functionality to wind however it limits the players visibility and attempts to push them out and rotate them making the storms very hard to navigate.

### 8.8 Day and night <a name="day-and-night"></a>
TBD

### 8.9 Time <a name="time"></a>
Real time.

### 8.10 Physics <a name="physics"></a>
Real life physics (more or less).

### 8.11 Society/culture <a name="society-culture"></a>
Because the game takes place in a near future setting to our own a lot of the societal and cultural setting is similar to our own. However, because the world is flooded this civilization has disappeared and the only remnant of humanity could be the main character. Whether or not the player is the last human alive is outside the scope of the story, which focuses on more personal issues like depression or loss. The frozen world is a catalyst to visualize these issues.

</details>

## :art: 9- Media List <a name="media-list"></a>
<details>
<summary> Click to expand! </summary>

Any type of digital asset that you will be using should be placed here.

### 9.1 Interface assets <a name="interface-assets"></a>

### 9.2 Environments <a name="environments"></a>
These are references for assets that will be produced/ purchased:

https://assetstore.unity.com/packages/3d/environments/landscapes/stylized-ice-formations-163302

https://assetstore.unity.com/packages/3d/environments/stylized-nature-pack-37457

https://assetstore.unity.com/packages/3d/vegetation/story-northern-nature-164556

https://blenderartists.org/t/black-and-white-comic-book-materials-cycles/645066

### 9.3 Characters <a name="characters"></a>

### 9.4 Animation <a name="animation"></a>
Purchased:
https://assetstore.unity.com/packages/3d/animations/female-speed-skater-134446

### 9.5 Music and sound effects <a name="music-and-sound-effects"></a>
List all of the media that will need to be produced. The specifics of your game will dictate what categories you need to include. Be detailed with this list, and create a file naming convention up front. This can avoid a lot of confusion later on.

**Elvins Theme**: <br/>
https://drive.google.com/file/d/1WGvEP0Pn1RtlSUsIFNBEHG80pqUs2S6H/view?usp=sharing

**Aramis Theme**: <br/>
https://drive.google.com/file/d/1M8eDLzNd0i3LuxDolsAWynsjCHU_N7ec/view?usp=sharing

**Alexanders Theme**: <br/>
https://drive.google.com/file/d/1NkHCHW2pyYD7N00V79hH-gSXizjV4pCS/view?usp=sharing
<br/>
https://drive.google.com/file/d/1Y84VaUGPoFpLW8fQPkE5IOqFUwH0_8uB/view?usp=sharing

</details>

## :computer: 10- Technical Specifications <a name="technical-specifications"></a>
<details>
<summary> Click to expand! </summary>

#### 10.1.1 New technology <a name="new-technology"></a>
Is there any new technology that you plan on developing for this game? If so, describe it in detail.

#### 10.1.2 Major software development tasks <a name="major-software-development-tasks"></a>
We are using a preexisting game engine to make the development process easier. We will be developing through Unity.

We will also be developing our own spline tool to make it easier for us to draw patterns for our pattern recognition, trails, camera path and fish behavior.

The spline tool lets us create an easy to adjust curve within unity that we can use for aspects such as Pattern Recognition and making fishes swim in a specific pattern. We can also use it to easy populate the curve with objects. An example where we use both the populating function and the pattern following one is in the Lighthouse, where we have two circles that we populate with wind walls using the spline tool. The wind walls then follow the spline, always pointing forward. Doing this manually would have been much more work. 

Spline tool used to create a circle: 
https://drive.google.com/file/d/1--34tAOb52R86YAVO3imOQH-jvQTdMNP/view?usp=sharing

Fishes follow the spline tool and automatically look forward: 
https://drive.google.com/file/d/1EBqZvrrZmNvq1w2DfZlldIxgNW6d8Nct/view?usp=sharing

### 10.2 Development platform and tools <a name="development-platform-and-tools"></a>
Describe the development platform, as well as any software tools and hardware that are required to produce the game.

#### 10.2.1 Software <a name="software"></a>
- Github - Used as version control and as a way for us to organize all our work.
- Blender - Used to create 3D Models.
- Unity - Used as a game engine for the entire process.

#### 10.3.2 Required materials <a name="required-materials"></a>

### 10.4 Game engine <a name="game-engine"></a>

#### 10.4.3 Collision detection <a name="collision-detection"></a>
If your game involves collision detection, how does it work?

### 10.5 Interface technical specs <a name="interface-technical-specs"></a>
This is where you describe how your interface is designed from a technical perspective. What tools do you plan to use, and how will it function?

### 10.6 Controls' technical specs <a name="controls-technical-specs"></a>
This is where you describe how your controls work from a technical perspective. Are you planning on supporting any unusual input devices that would require specialized programming?

### 10.7 Lighting models <a name="lighting-models"></a>
Lighting can be a substantial part of a game. Describe how it works and the features that you require.

#### 10.7.1 Modes <a name="modes"></a>

#### 10.7.2 Models <a name="models"></a>

#### 10.7.3 Light sources <a name="light-sources"></a>

### 10.8 Rendering system <a name="rendering-system"></a>

#### 10.8.1 Camera <a name="camera"></a>

### 10.10 System parameters <a name="system-parameters"></a>

#### 10.10.1 Max players <a name="max-players"></a>
1

#### 10.10.7 Saving games <a name="saving-games"></a>
The save system will save the player transform, fish transforms, colors unlocked and interactions completed.

Two save systems are currently used. Unity's PlayerPrefs and a custom script converting data to a binary file.

#### 10.10.8 Loading games <a name="loading-games"></a>
Loading is done through Unity's PlayerPrefs and the binary file.
</details>